using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class PaymentMethod
    {
        public PaymentMethod() { }

        [JsonProperty("payer_selected")]
        public string PayerSelected { get; set; }
        [JsonProperty("payee_preferred")]
        public string PayeePreferred { get; set; }
    }
}
