using Microsoft.Extensions.Options;
using PaymentProvider.Paypal.Services.PaypalSDK;
using RestSharp.Serialization;
using ZienPaymentSDK.Paypal.Services.PaypalManagers;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Services
{

    public class PaypalAPIService : IPaypalAPIService
    {
        protected readonly IRestSerializer _restSerializer;
        protected readonly PaypalProviderOptions _paypalOptions;

        public PaypalAPIService(IRestSerializer restSerializer,
            IOptionsSnapshot<PaypalProviderOptions> options)
        {
            _restSerializer = restSerializer;
            _paypalOptions = options.Value;
        }

        internal PaypalAPIService(IRestSerializer restSerializer, PaypalProviderOptions options)
        {
            _restSerializer = restSerializer;
            _paypalOptions = options;
        }

        private PaypalProductManager _paypalProductManager;
        public PaypalProductManager ProductsManager
        {
            get
            {
                if (_paypalProductManager == null)
                {
                    _paypalProductManager = new PaypalProductManager(_paypalOptions, _restSerializer);
                }
                return _paypalProductManager;

            }
            set { _paypalProductManager = value; }
        }

        private PaypalPlanManager _paypalPlansManager;
        public PaypalPlanManager PlansManager
        {
            get
            {
                if (_paypalPlansManager == null)
                {
                    _paypalPlansManager = new PaypalPlanManager(_paypalOptions, _restSerializer);
                }
                return _paypalPlansManager;

            }
            set { _paypalPlansManager = value; }
        }

        private PaypalWebhookManager _paypalWebhooksManager;
        public PaypalWebhookManager WebhooksManager
        {
            get
            {
                if (_paypalWebhooksManager == null)
                {
                    _paypalWebhooksManager = new PaypalWebhookManager(_paypalOptions, _restSerializer);
                }
                return _paypalWebhooksManager;

            }
            set { _paypalWebhooksManager = value; }
        }

        private PaypalSubscriptionManager _paypalSubscriptionsManager;
        public PaypalSubscriptionManager SubscriptionsManager
        {
            get
            {
                if (_paypalSubscriptionsManager == null)
                {
                    _paypalSubscriptionsManager = new PaypalSubscriptionManager(_paypalOptions, _restSerializer);
                }
                return _paypalSubscriptionsManager;

            }
            set { _paypalSubscriptionsManager = value; }
        }

        private PaypalOrdersManager _paypalOrdersManager;
        public PaypalOrdersManager OrdersManager
        {
            get
            {
                if (_paypalOrdersManager == null)
                {
                    _paypalOrdersManager = new PaypalOrdersManager(_paypalOptions, _restSerializer);
                }
                return _paypalOrdersManager;

            }
            set { _paypalOrdersManager = value; }
        }


    }
}
