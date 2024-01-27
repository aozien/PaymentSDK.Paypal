using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class Taxes
    {
        [JsonProperty("percentage")]
        public string Percentage { get; set; }
        [JsonProperty("inclusive")]
        public bool Inclusive { get; set; }
    }
}
