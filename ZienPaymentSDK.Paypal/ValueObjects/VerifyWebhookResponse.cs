using Newtonsoft.Json;

namespace ZienPaymentSDK.Paypal.ValueObjects
{
    public class VerifyWebhookResponse
    {
        [JsonProperty("verification_status")]
        public string VerificationStatus { get; set; }
    }
}
