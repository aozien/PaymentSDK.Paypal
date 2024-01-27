using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class LinkDescriptionObject
    {
        public LinkDescriptionObject() { }

        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("rel")]
        public string Rel { get; set; }
    }
}
