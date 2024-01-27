using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZienPaymentSDK.Paypal.Constants;
using ZienPaymentSDK.Paypal.Models;
using ZienPaymentSDK.Paypal.Services;

namespace PaymentSDK.Paypal.Runner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaypalServiceController : ControllerBase
    {
        private readonly ILogger<PaypalServiceController> _logger;
        private readonly IPaypalAPIService _paypalAPIService;

        public PaypalServiceController(ILogger<PaypalServiceController> logger,
            IPaypalAPIService paypalAPIService
            )
        {
            _logger = logger;
            _paypalAPIService = paypalAPIService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder()
        {
            var orderManager = _paypalAPIService.OrdersManager;
            var baseUrl = $"https://{this.Request.Host}";

            var paypalOrderRequest = await _paypalAPIService.OrdersManager
            .CreateAsync(new PaypalOrder
            {
                PurchaseUnits = new List<PurchaseUnit>
                {
                    new PurchaseUnit() {
                        ReferenceId = Guid.NewGuid().ToString(), // You can provide any id you like
                        Description = $"Test Creating order on paypal",
                        Amount = new Amount()
                        {
                            CurrencyCode = "USD",
                            Value = "9.99"
                        }
                    }
                },

                Intent = "CAPTURE",

                PaymentSource = new PaymentSource()
                {
                    Paypal = new ZienPaymentSDK.Paypal.Models.Paypal
                    {
                        ExperienceContext = new ExperienceContext
                        {
                            UserAction = "PAY_NOW",
                            BrandName = "Zien Payment SDKs",
                            ReturnUrl = $"{baseUrl}/paypalservice/confirm",
                            CancelUrl = $"{baseUrl}/paypalservice/cancel"
                        }
                    }
                }
            });


            var approvalLink = paypalOrderRequest.Data?.Links.FirstOrDefault(x => x.Rel == "payer-action")?.Href;
            if (!paypalOrderRequest.IsSuccessful || String.IsNullOrWhiteSpace(approvalLink))
            {
                return BadRequest(paypalOrderRequest.ErrorMessage);
            }

            return Redirect(approvalLink);
        }


        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmOrder(string token, string payerId)
        {
            // IMPORTANT: calling this action on it's own doesn't necessarily mean the order was confirmed,
            // Use this action to retrieve the Order status from PAYPAL, alternatively you can add a value token in the return url
            // per each order to confirm the request is from paypal,
            // however it's more reliable to use the webhooks

            var getOrderRequest = await _paypalAPIService.OrdersManager.GetAsync(token);
            //-- check on order state
            if (getOrderRequest.Data.Status != "APPROVED")
            {
                return BadRequest();
            }

            var captureOrderRequest = await _paypalAPIService.OrdersManager.CaptureAsync(token);

            if (!captureOrderRequest.IsSuccessful
                || captureOrderRequest.Data.Status != "COMPLETED")
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("cancel")]
        public async Task<IActionResult> CancelOrder(string token)
        {
            return Ok();
        }

        [HttpPost("webhook")] //Webhook events use POST method
        public async Task<IActionResult> ProcessWebhookEvent()
        {
            using var reader = new StreamReader(HttpContext.Request.Body);
            var body = await reader.ReadToEndAsync();
            var headers = HttpContext.Request.Headers.ToDictionary(x => x.Key.ToUpper(), x => x.Value.FirstOrDefault());

            //Verify webhook
            var isValidEvent = await _paypalAPIService.WebhooksManager.VerifyEvent(body, headers);

            if (!isValidEvent)
            {
                _logger.LogInformation($"Validating Webhook Failed");
                return BadRequest();
            }

            // Process Webhook
            //
            var webhookObj = JsonConvert.DeserializeObject<PaypalBaseWebhookEventObject<dynamic>>(body);

            switch (webhookObj.EventType)
            {
                case PaypalWebHookConstants.CHECKOUT_ORDER_APPROVED:
                    // Capture the order
                    break;
                case PaypalWebHookConstants.CHECKOUT_ORDER_COMPLETED:
                    // Maybe update your system records
                    break;
                default:

                    break;
            }

            return Ok();
        }
    }
}
