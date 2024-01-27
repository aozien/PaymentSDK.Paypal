using System.ComponentModel.DataAnnotations;

namespace ZienPaymentSDK.Paypal.ValueObjects
{
    public class PaypalProviderOptions
    {
        /// <summary>
        /// API BaseURL to use, this changes based on paypal environment, 
        /// test environment (sandbox) has a different base url than the live one
        /// </summary>
        [Required]
        public string BaseUrl { get; set; }
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ClientSecret { get; set; }
        public string WebhookId { get; set; }
        public string ReturnUrl { get; set; }
        public string CancelUrl { get; set; }
        public string BrandName { get; set; }
        public string Locale { get; set; }
    }
}
