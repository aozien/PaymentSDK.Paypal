using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class Name
    {
        public Name() { }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
    }
}
