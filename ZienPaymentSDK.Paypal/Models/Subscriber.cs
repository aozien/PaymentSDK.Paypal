using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class Subscriber
    {
        public Subscriber() { }

        [JsonProperty("name")]
        public Name Name { get; set; }
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }
    }
}
