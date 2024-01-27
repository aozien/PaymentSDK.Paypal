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

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "application_context", EmitDefaultValue = false)]
        public ApplicationContext ApplicationContext;

        [DataMember(Name = "intent")]
        public string Intent { get; set; }

        [DataMember(Name = "payment_source")]
        public PaymentSource PaymentSource { get; set; }

        [DataMember(Name = "purchase_units")]
        public IList<PurchaseUnit> PurchaseUnits { get; set; }

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
