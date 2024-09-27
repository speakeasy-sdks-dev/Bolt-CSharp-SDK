# Boltpay.SDK

<div align="left">
    <a href="https://speakeasyapi.dev/"><img src="https://custom-icon-badges.demolab.com/badge/-Built%20By%20Speakeasy-212015?style=for-the-badge&logoColor=FBE331&logo=speakeasy&labelColor=545454" /></a>
    <a href="https://opensource.org/licenses/MIT">
        <img src="https://img.shields.io/badge/License-MIT-blue.svg" style="width: 100px; height: 28px;" />
    </a>
</div>

<!-- Start Summary [summary] -->
## Summary

Bolt API Reference: A comprehensive Bolt API reference for interacting with Accounts, Payments, Orders and more.
<!-- End Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents

* [SDK Installation](#sdk-installation)
* [SDK Example Usage](#sdk-example-usage)
* [Available Resources and Operations](#available-resources-and-operations)
* [Error Handling](#error-handling)
* [Server Selection](#server-selection)
* [Authentication](#authentication)
<!-- End Table of Contents [toc] -->

<!-- Start SDK Installation [installation] -->
## SDK Installation

To add a reference to a local instance of the SDK in a .NET project:
```bash
dotnet add reference Boltpay/SDK/Boltpay.SDK.csproj
```
<!-- End SDK Installation [installation] -->

<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Account.GetDetailsAsync(
    xPublishableKey: "<value>",
    xMerchantClientId: "<id>"
);

// handle response
```
<!-- End SDK Example Usage [usage] -->

<!-- Start Available Resources and Operations [operations] -->
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

### [Account](docs/sdks/account/README.md)

* [GetDetails](docs/sdks/account/README.md#getdetails) - Retrieve account details
* [AddAddress](docs/sdks/account/README.md#addaddress) - Add an address
* [UpdateAddress](docs/sdks/account/README.md#updateaddress) - Edit an existing address
* [DeleteAddress](docs/sdks/account/README.md#deleteaddress) - Delete an existing address
* [AddPaymentMethod](docs/sdks/account/README.md#addpaymentmethod) - Add a payment method
* [DeletePaymentMethod](docs/sdks/account/README.md#deletepaymentmethod) - Delete an existing payment method


### [OAuth](docs/sdks/oauth/README.md)

* [GetToken](docs/sdks/oauth/README.md#gettoken) - Get OAuth token

### [Orders](docs/sdks/orders/README.md)

* [OrdersCreate](docs/sdks/orders/README.md#orderscreate) - Create an order that was prepared outside the Bolt ecosystem.

### [Payments](docs/sdks/payments/README.md)


#### [Payments.Guest](docs/sdks/guest/README.md)

* [Initialize](docs/sdks/guest/README.md#initialize) - Initialize a Bolt payment for guest shoppers
* [PerformAction](docs/sdks/guest/README.md#performaction) - Finalize a pending guest payment

#### [Payments.LoggedIn](docs/sdks/loggedin/README.md)

* [Initialize](docs/sdks/loggedin/README.md#initialize) - Initialize a Bolt payment for logged in shoppers
* [PerformAction](docs/sdks/loggedin/README.md#performaction) - Finalize a pending payment

### [Testing](docs/sdks/testing/README.md)

* [CreateAccount](docs/sdks/testing/README.md#createaccount) - Create a test account
* [TestingAccountPhoneGet](docs/sdks/testing/README.md#testingaccountphoneget) - Get a random phone number
* [GetCreditCard](docs/sdks/testing/README.md#getcreditcard) - Retrieve a tokenized test credit card

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Error Handling [errors] -->
## Error Handling

Handling errors in this SDK should largely match your expectations.  All operations return a response object or thow an exception.  If Error objects are specified in your OpenAPI Spec, the SDK will raise the appropriate type.

| Error Object                           | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 4xx-5xx                                | */*                                    |

### Example

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;
using System;
using Boltpay.SDK.Models.Errors;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

try
{
    var res = await sdk.Account.GetDetailsAsync(
        xPublishableKey: "<value>",
        xMerchantClientId: "<id>"
    );

    // handle response
}
catch (Exception ex)
{
    if (ex is Error)
    {
        // Handle exception data
        throw;
    }
    if (ex is FieldError)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Models.Errors.SDKException)
    {
        // Handle default exception
        throw;
    }
}
```
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Select Server by Index

You can override the default server globally by passing a server index to the `serverIndex: number` optional parameter when initializing the SDK client instance. The selected server will then be used as the default on the operations that use it. This table lists the indexes associated with the available servers:

| # | Server | Variables |
| - | ------ | --------- |
| 0 | `https://{environment}.bolt.com/v3` | `environment` (default is `api-sandbox`) |



#### Variables

Some of the server options above contain variables. If you want to set the values of those variables, the following options are provided for doing so:
 * `environment: ServerEnvironment`

### Override Server URL Per-Client

The default server can also be overridden globally by passing a URL to the `serverUrl: str` optional parameter when initializing the SDK client instance. For example:
<!-- End Server Selection [server] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security schemes globally:

| Name         | Type         | Scheme       |
| ------------ | ------------ | ------------ |
| `Oauth`      | oauth2       | OAuth2 token |
| `ApiKey`     | apiKey       | API key      |

You can set the security parameters through the `security` optional parameter when initializing the SDK client instance. The selected scheme will be used by default to authenticate with the API for all operations that support it. For example:
```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
    Oauth = "<YOUR_OAUTH_HERE>",
    ApiKey = "<YOUR_API_KEY_HERE>",
});

var res = await sdk.Account.GetDetailsAsync(
    xPublishableKey: "<value>",
    xMerchantClientId: "<id>"
);

// handle response
```

### Per-Operation Security Schemes

Some operations in this SDK require the security scheme to be specified at the request level. For example:
```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;
using System.Collections.Generic;

var sdk = new BoltSDK();

var res = await sdk.Payments.Guest.InitializeAsync(
    security: new GuestPaymentsInitializeSecurity() {
        ApiKey = "<YOUR_API_KEY_HERE>",
    },
    xPublishableKey: "<value>",
    xMerchantClientId: "<id>",
    guestPaymentInitializeRequest: new GuestPaymentInitializeRequest() {
        Profile = new ProfileCreationData() {
            CreateAccount = true,
            FirstName = "Alice",
            LastName = "Baker",
            Email = "alice@example.com",
            Phone = "+14155550199",
        },
        Cart = new Cart() {
            OrderReference = "order_100",
            OrderDescription = "Order #1234567890",
            DisplayId = "215614191",
            Shipments = new List<CartShipment>() {
                new CartShipment() {
                    Address = AddressReferenceInput.CreateAddressReferenceId(
                        new AddressReferenceId() {
                            DotTag = Boltpay.SDK.Models.Components.AddressReferenceIdTag.Id,
                            Id = "D4g3h5tBuVYK9",
                        }
                    ),
                    Cost = new Amount() {
                        Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                        Units = 900,
                    },
                    Carrier = "FedEx",
                },
            },
            Discounts = new List<CartDiscount>() {
                new CartDiscount() {
                    Amount = new Amount() {
                        Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                        Units = 900,
                    },
                    Code = "SUMMER10DISCOUNT",
                    DetailsUrl = "https://www.example.com/SUMMER-SALE",
                },
            },
            Items = new List<CartItem>() {
                new CartItem() {
                    Name = "Bolt Swag Bag",
                    Reference = "item_100",
                    Description = "Large tote with Bolt logo.",
                    TotalAmount = new Amount() {
                        Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                        Units = 900,
                    },
                    UnitPrice = 1000,
                    Quantity = 1,
                    ImageUrl = "https://www.example.com/products/123456/images/1.png",
                },
            },
            Total = new Amount() {
                Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                Units = 900,
            },
            Tax = new Amount() {
                Currency = Boltpay.SDK.Models.Components.Currency.Usd,
                Units = 900,
            },
        },
        PaymentMethod = PaymentMethodInput.CreatePaymentMethodCreditCardInput(
            new PaymentMethodCreditCardInput() {
                DotTag = Boltpay.SDK.Models.Components.DotTag.CreditCard,
                BillingAddress = AddressReferenceInput.CreateAddressReferenceId(
                    new AddressReferenceId() {
                        DotTag = Boltpay.SDK.Models.Components.AddressReferenceIdTag.Id,
                        Id = "D4g3h5tBuVYK9",
                    }
                ),
                Network = Boltpay.SDK.Models.Components.CreditCardNetwork.Visa,
                Bin = "411111",
                Last4 = "1004",
                Expiration = "2029-03",
                Token = "a1B2c3D4e5F6G7H8i9J0k1L2m3N4o5P6Q7r8S9t0",
            }
        ),
    }
);

// handle response
```
<!-- End Authentication [security] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->

# Development

## Maturity

This SDK is in beta, and there may be breaking changes between versions without a major version update. Therefore, we recommend pinning usage
to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally
looking for the latest version.

## Contributions

While we value open-source contributions to this SDK, this library is generated programmatically. Any manual changes added to internal files will be overwritten on the next generation. 

### SDK Created by [Speakeasy](https://docs.speakeasyapi.dev/docs/using-speakeasy/client-sdks)
