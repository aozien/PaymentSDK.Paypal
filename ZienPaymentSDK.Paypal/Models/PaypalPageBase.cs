using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class PaypalPageBase {
        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("links")]
        public List<LinkDescriptionObject> Links { get; set; }
    }

}
