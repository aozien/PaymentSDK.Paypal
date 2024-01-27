using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class Frequency
    {
        public Frequency() { }

        [JsonProperty("interval_unit")]
        public string IntervalUnit { get; set; }
        [JsonProperty("interval_count")]
        public int IntervalCount { get; set; }
    }
}
