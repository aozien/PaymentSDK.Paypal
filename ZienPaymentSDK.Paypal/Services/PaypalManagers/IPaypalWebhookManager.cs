namespace ZienPaymentSDK.Paypal.Services.PaypalManagers
{
    public interface IPaypalWebhookManager
    {
        Task<bool> VerifyEvent(string webhookId, string json, Dictionary<string, string> headerDictionary);
    }
}