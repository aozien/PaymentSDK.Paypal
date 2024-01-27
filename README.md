## About Project
Modern paypal .Net SDK, Acts as a wrapper for paypal REST API, for creating resources such as orders products, and subscriptions, 
it also can be used for processing paypal webhook events


## Getting Started

1- Install the project's nuget package ZienPaymentSDK.Paypal
```
dotnet add package ZienPaymentSDK.Paypal
```
2- In your startup file, or program.cs add Paypal Service to Dependency Injections 
```
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//-- Adds Paypal Service to Dependency Injections 
builder.Services.AddPaypalAPIService(); 
//---
```

3- Setup your paypal credentials in `.AddPaypalAPIService(options=> {})`
or in AppSettings file 
```
{
  ...

  "PaymentSDK": {
    "Paypal": {
      "ClientId": "{{YOUR-CLIENT-ID}}",
      "ClientSecret": "{{YOUR-CLIENT-SECRET}}",
      "BaseUrl": "https://api-m.sandbox.paypal.com" <-- Change this based on paypal environment
      "WebhookId": <-- required for verifying webhook events
    }
  }
}
```

## Request Authorizations
by default the library uses BasicAuth, but you can change this behavior by overriding the 
`IAuthenticator` service in the dependency Injection