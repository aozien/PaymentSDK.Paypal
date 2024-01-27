using Microsoft.Extensions.Options;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.DefaultImplementations
{
    public class DefaultBasicAuthenticator : HttpBasicAuthenticator
    {
        public DefaultBasicAuthenticator(IOptionsSnapshot<PaypalProviderOptions> options):
            base(options.Value.ClientId, options.Value.ClientSecret)
        {
        }
    }
}
