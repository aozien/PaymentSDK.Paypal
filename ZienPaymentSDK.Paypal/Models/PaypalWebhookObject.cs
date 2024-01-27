using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ZienPaymentSDK.Paypal.Enums;

namespace ZienPaymentSDK.Paypal.Models
{
    public class PaypalBaseWebhookEventObject<T>
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("create_time")]
        public DateTime? CreateTime { get; set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("transmissions")]
        public Transmission[] Transmissions { get; set; }
        [JsonProperty("links")]
        public LinkDescriptionObject[] Links { get; set; }
        [JsonProperty("event_version")]
        public string EventVersion { get; set; }
        [JsonProperty("resource_version")]
        public string ResourceVersion { get; set; }

        [JsonProperty("resource")]
        public T Resource { get; set; }
    }
    public class PaypalDefaultWebhookEventObject : PaypalBaseWebhookEventObject<dynamic>
    { }
    public class PaypalBillingSubscriptionWebhookEvent
        : PaypalBaseWebhookEventObject<ResourceBillingSubscription>
    { }
    public class PaypalWebhookPaymentSaleObject
        : PaypalBaseWebhookEventObject<PaymentSaleResource>
    { }


    public abstract class PaypalResourceBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }
        [JsonProperty("create_time")]
        public DateTime? CreateTime { get; set; }
        [JsonProperty("links")]
        public LinkDescriptionObject[] Links { get; set; }
    }

    public class PaymentSaleResource : PaypalResourceBase
    {
        [JsonProperty("billing_agreement_id")]
        public string BillingAgreementId { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("payment_mode")]
        public string PaymentMode { get; set; }

        [JsonProperty("protection_eligibility_type")]
        public string ProtectionEligibilityType { get; set; }

        [JsonProperty("transaction_fee")]
        public Currency TransactionFee { get; set; }

        [JsonProperty("protection_eligibility")]
        public string ProtectionEligibility { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentSaleStatus State { get; set; }
        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }
    }

    public class ResourceBillingSubscription : PaypalResourceBase
    {
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("subscriber")]
        public PayerInfo Subscriber { get; set; }

        [JsonProperty("plan_overridden")]
        public bool? PlanOverridden { get; set; }

        [JsonProperty("shipping_amount")]
        public Currency ShippingAmount { get; set; }

        [JsonProperty("billing_info")]
        public BillingInfo BillingInfo { get; set; }

        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionStatus Status { get; set; }

        [JsonProperty("status_update_time")]
        public DateTime StatusUpdateTime { get; set; }
    }

    public class Transmission
    {
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        [JsonProperty("http_status")]
        public int HttpStatus { get; set; }

        [JsonProperty("reason_phrase")]
        public string ReasonPhrase { get; set; }

        [JsonProperty("response_headers")]
        public object ResponseHeaders { get; set; }

        [JsonProperty("transmission_id")]
        public string TransmissionId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }
    }
}