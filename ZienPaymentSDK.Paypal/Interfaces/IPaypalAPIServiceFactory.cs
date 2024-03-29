﻿using ZienPaymentSDK.Paypal.Services;
using ZienPaymentSDK.Paypal.ValueObjects;

namespace ZienPaymentSDK.Paypal.Interfaces
{
    public interface IPaypalAPIServiceFactory
    {
        PaypalAPIService CreateUnitOfWork(PaypalProviderOptions options);
    }
}