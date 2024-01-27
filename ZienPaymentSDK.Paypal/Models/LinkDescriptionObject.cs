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
        /// <summary>
        /// The link relation type, which serves as an ID for a link that unambiguously describes the semantics of the link
        /// </summary>
        [JsonProperty("rel")]
        public string Rel { get; set; }
    }
}
