using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.ValueObjects
{
    public class PatchObject
    {
        [JsonProperty("op")]
        public string Op { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
