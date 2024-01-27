using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ZienPaymentSDK.Paypal.Enums;

namespace ZienPaymentSDK.Paypal.Models
{
    /// <summary>
    /// Customize the payer experience during the approval process for the payment with PayPal
    /// </summary>
    public class ApplicationContext
    {
        public ApplicationContext() { }
        [Obsolete("The fields in application_context are now available in the experience_context object under the payment_source which supports them (eg. payment_source.paypal.experience_context.brand_name). Please specify this field in the experience_context object instead of the application_context")]
        [JsonProperty("brand_name")]
        public string BrandName { get; set; }
        [Obsolete("The fields in application_context are now available in the experience_context object under the payment_source which supports them (eg. payment_source.paypal.experience_context.locale). Please specify this field in the experience_context object instead of the application_context")]
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [Obsolete("The fields in application_context are now available in the experience_context object under the payment_source which supports them (eg. payment_source.paypal.experience_context.shipping_preference). Please specify this field in the experience_context object instead of the application_context")]
        [JsonProperty("shipping_preference")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ApplicationContextShippingPreference? ShippingPreference { get; set; }

        [Obsolete("The fields in application_context are now available in the experience_context object under the payment_source which supports them. Please specify this field in the experience_context object instead of the application_context")]
        [JsonProperty("user_action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ApplicationContextUserAction? UserAction { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Obsolete("The fields in application_context are now available in the experience_context object under the payment_source which supports them (eg. payment_source.paypal.experience_context.return_url). Please specify this field in the experience_context object instead of the application_context")]
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        [Obsolete("The fields in application_context are now available in the experience_context object under the payment_source which supports them (eg. payment_source.paypal.experience_context.cancel_url). Please specify this field in the experience_context object instead of the application_context")]
        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }
    }
}
