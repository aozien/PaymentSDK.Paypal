using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class LastPaymentDetails
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("amount")]
        public Currency Amount { get; set; }
    }
}
