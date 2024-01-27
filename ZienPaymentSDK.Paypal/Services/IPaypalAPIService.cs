using PaymentProvider.Paypal.Services.PaypalSDK;
using ZienPaymentSDK.Paypal.Services.PaypalManagers;

namespace ZienPaymentSDK.Paypal.Services
{
    public interface IPaypalAPIService
    {
        PaypalOrdersManager OrdersManager { get; set; }
        PaypalPlanManager PlansManager { get; set; }
        PaypalProductManager ProductsManager { get; set; }
        PaypalSubscriptionManager SubscriptionsManager { get; set; }
        PaypalWebhookManager WebhooksManager { get; set; }
    }
}