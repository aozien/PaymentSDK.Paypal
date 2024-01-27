using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProvider.Paypal.ValueObjects
{
    public class PaypalProviderOptions
    {
        public const string ConfigurationSectionName = "PaymentProviders:Paypal";

        public string BaseUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string WebhookId { get; set; }

        public string ReturnUrl { get; set; }
        public string CancelUrl { get; set; }
        public string BrandName { get; set; }
        public string Locale { get; set; }
    }
}
