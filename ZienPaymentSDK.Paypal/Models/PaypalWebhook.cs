using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class PaypalWebhook
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("event_types")]
        public EventTypes[] EventTypes { get; set; }
        [JsonProperty("links")]
        public LinkDescriptionObject[] links { get; set; }
    }
    public class EventTypes
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class PaypalWebhookPage : PaypalPageBase
    {
        [JsonProperty("webhooks")]
        public PaypalWebhook[] Webhooks { get; set; }
    }
}
