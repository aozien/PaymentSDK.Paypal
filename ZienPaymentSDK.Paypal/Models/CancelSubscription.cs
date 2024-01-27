using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class CancelSubscription
    {
        public CancelSubscription() { }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
