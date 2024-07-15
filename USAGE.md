<!-- Start SDK Example Usage [usage] -->
```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
        Oauth = "<YOUR_OAUTH_HERE>",
    });

var res = await sdk.Account.GetDetailsAsync(
    xPublishableKey: "<value>",
    xMerchantClientId: "<value>");

// handle response
```
<!-- End SDK Example Usage [usage] -->