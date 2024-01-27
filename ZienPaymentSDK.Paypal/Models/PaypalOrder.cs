using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ZienPaymentSDK.Paypal.Models
{



    [DataContract]
    public class Paypal
    {

        [DataMember(Name = "name")]
        public Name Name { get; set; }

        [DataMember(Name = "email_address")]
        public string EmailAddress { get; set; }

        [DataMember(Name = "account_id")]
        public string AccountId { get; set; }

        [DataMember(Name = "experience_context")]
        public ExperienceContext ExperienceContext { get; set; }
    }

    [DataContract]
    public class ExperienceContext
    {
        [DataMember(Name = "brand_name")]
        public string BrandName { get; set; }

        [DataMember(Name = "user_action")]
        public string UserAction { get; set; } //Configures a Continue or Pay Now checkout flow.


        [DataMember(Name = "return_url")]
        public string ReturnUrl { get; set; }

        [DataMember(Name = "cancel_url")]
        public string CancelUrl { get; set; }
    }
    [DataContract]
    public class PaymentSource
    {

        [DataMember(Name = "paypal")]
        public Paypal Paypal { get; set; }
    }

    [DataContract]
    public class Amount
    {

        [DataMember(Name = "currency_code")]
        public string CurrencyCode { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }

    [DataContract]
    public class PurchaseUnit
    {
        /// <summary>
        /// The API caller-provided external ID for the purchase unit.Required for multiple purchase units when you must update the order through PATCH.If you omit this value and the order contains only one purchase unit, PayPal sets this value to default
        /// </summary>
        [DataMember(Name = "reference_id")]
        public string ReferenceId { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "amount")]
        public Amount Amount { get; set; }
    }
    [DataContract]
    public class PayerInfo
    {
        [DataMember(Name = "name")]
        public Name Name { get; set; }
        [DataMember(Name = "email_address")]
        public string EmailAddress { get; set; }
        [DataMember(Name = "payer_id")]
        public string PayerId { get; set; }
    }

    [DataContract]
    public class PaypalOrder
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }


        /// <summary>
        /// The order status.
        /// - CREATED : The order was created with the specified context.
        /// - SAVED : The order was saved and persisted. The order status continues to be in progress until a capture is made with final_capture = true for all purchase units within the order.
        /// - APPROVED : The customer approved the payment through the PayPal wallet or another form of guest or unbranded payment. For example, a card, bank account, or so on.
        /// - VOIDED : All purchase units in the order are voided.
        /// - COMPLETED : The payment was authorized or the authorized payment was captured for the order.
        /// - PAYER_ACTION_REQUIRED : The order requires an action from the payer (e.g. 3DS authentication). Redirect the payer to the "rel":"payer-action" HATEOAS link returned as part of the response prior to authorizing or capturing the order.
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "application_context", EmitDefaultValue = false)]
        public ApplicationContext ApplicationContext;

        /// <summary>
        /// The intent to either capture payment immediately or authorize a payment for an order after order creation.
        ///  - CAPTURE: The merchant intends to capture payment immediately after the customer makes a payment
        ///  - AUTHORIZE: The merchant intends to authorize a payment and place funds on hold after the customer makes a payment. Authorized payments are best captured within three days of authorization but are available to capture for up to 29 days. After the three-day honor period, the original authorized payment expires and you must re-authorize the payment. You must make a separate request to capture payments on demand. 
        /// This intent is not supported when you have more than one purchase_unit within your order.
        /// </summary>
        [DataMember(Name = "intent")]
        public string Intent { get; set; }

        [DataMember(Name = "payment_source")]
        public PaymentSource PaymentSource { get; set; }

        [DataMember(Name = "purchase_units")]
        public IList<PurchaseUnit> PurchaseUnits { get; set; }

        [Obsolete]
        [DataMember(Name = "payer")]
        public PayerInfo Payer { get; set; }

        [DataMember(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        [DataMember(Name = "update_time")]
        public DateTime? UpdateTime { get; set; }

        [DataMember(Name = "links")]
        public IList<LinkDescriptionObject> Links { get; set; }
    }
}
