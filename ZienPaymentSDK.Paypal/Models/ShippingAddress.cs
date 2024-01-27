using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class ShippingAddress
    {
        public ShippingAddress() { }

        [JsonProperty("name")]
        public FullName Name { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
