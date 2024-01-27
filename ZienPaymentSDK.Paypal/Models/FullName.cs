using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.Models
{
    public class FullName
    {
        public FullName() { }

        [JsonProperty("full_name")]
        public string Fullname { get; set; }
    }
}
