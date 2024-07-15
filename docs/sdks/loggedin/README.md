# LoggedIn
(*Payments.LoggedIn*)

### Available Operations

* [Initialize](#initialize) - Initialize a Bolt payment for logged in shoppers
* [Update](#update) - Update an existing payment
* [PerformAction](#performaction) - Perform an irreversible action (e.g. finalize) on a pending payment

## Initialize

Initialize a Bolt payment token that will be used to reference this payment to
Bolt when it is updated or finalized for logged in shoppers.


### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;
using System.Collections.Generic;

var sdk = new BoltSDK(security: new Security() {
        Oauth = "<YOUR_OAUTH_HERE>",
    });

var res = await sdk.Payments.LoggedIn.InitializeAsync(
    xPublishableKey: "<value>",
    xMerchantClientId: "<value>",
    paymentInitializeRequest: new PaymentInitializeRequest() {
    Cart = new Cart() {
        OrderReference = "order_100",
        OrderDescription = "Order #1234567890",
        DisplayId = "215614191",
        Shipments = new List<CartShipment>() {
            new CartShipment() {
                Address = AddressReferenceInput.CreateId(
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
    PaymentMethod = PaymentMethodExtended.CreateAffirm(
            new PaymentMethodAffirm() {
                DotTag = Boltpay.SDK.Models.Components.PaymentMethodAffirmTag.Affirm,
                ReturnUrl = "www.example.com/handle_affirm_success",
            }
    ),
});

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                           | Type                                                                                                                                                                                                                | Required                                                                                                                                                                                                            | Description                                                                                                                                                                                                         |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                   | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The publicly viewable identifier used to identify a merchant division.                                                                                                                                              |
| `XMerchantClientId`                                                                                                                                                                                                 | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | A unique identifier for a shopper's device, generated by Bolt. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |
| `PaymentInitializeRequest`                                                                                                                                                                                          | [PaymentInitializeRequest](../../Models/Components/PaymentInitializeRequest.md)                                                                                                                                     | :heavy_check_mark:                                                                                                                                                                                                  | N/A                                                                                                                                                                                                                 |


### Response

**[PaymentsInitializeResponse](../../Models/Requests/PaymentsInitializeResponse.md)**
### Errors

| Error Object                                   | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Boltpay.SDK.Models.Errors.ResponsePaymentError | 4XX                                            | application/json                               |
| Boltpay.SDK.Models.Errors.SDKException         | 4xx-5xx                                        | */*                                            |

## Update

Update a pending payment


### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;
using System.Collections.Generic;

var sdk = new BoltSDK(security: new Security() {
        Oauth = "<YOUR_OAUTH_HERE>",
    });

var res = await sdk.Payments.LoggedIn.UpdateAsync(
    xPublishableKey: "<value>",
    xMerchantClientId: "<value>",
    id: "iKv7t5bgt1gg",
    paymentUpdateRequest: new PaymentUpdateRequest() {
    Cart = new Cart() {
        OrderReference = "order_100",
        OrderDescription = "Order #1234567890",
        DisplayId = "215614191",
        Shipments = new List<CartShipment>() {
            new CartShipment() {
                Address = AddressReferenceInput.CreateExplicit(
                        new AddressReferenceExplicitInput() {
                            DotTag = Boltpay.SDK.Models.Components.AddressReferenceExplicitTag.Explicit,
                            FirstName = "Alice",
                            LastName = "Baker",
                            Company = "ACME Corporation",
                            StreetAddress1 = "535 Mission St, Ste 1401",
                            StreetAddress2 = "c/o Shipping Department",
                            Locality = "San Francisco",
                            PostalCode = "94105",
                            Region = "CA",
                            CountryCode = Boltpay.SDK.Models.Components.CountryCode.Us,
                            Email = "alice@example.com",
                            Phone = "+14155550199",
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
});

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                           | Type                                                                                                                                                                                                                | Required                                                                                                                                                                                                            | Description                                                                                                                                                                                                         | Example                                                                                                                                                                                                             |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                   | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The publicly viewable identifier used to identify a merchant division.                                                                                                                                              |                                                                                                                                                                                                                     |
| `XMerchantClientId`                                                                                                                                                                                                 | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | A unique identifier for a shopper's device, generated by Bolt. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |                                                                                                                                                                                                                     |
| `Id`                                                                                                                                                                                                                | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The ID of the payment to update                                                                                                                                                                                     | iKv7t5bgt1gg                                                                                                                                                                                                        |
| `PaymentUpdateRequest`                                                                                                                                                                                              | [PaymentUpdateRequest](../../Models/Components/PaymentUpdateRequest.md)                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                  | N/A                                                                                                                                                                                                                 |                                                                                                                                                                                                                     |


### Response

**[PaymentsUpdateResponse](../../Models/Requests/PaymentsUpdateResponse.md)**
### Errors

| Error Object                           | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Response4xx  | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 4xx-5xx                                | */*                                    |

## PerformAction

Perform an irreversible action on a pending payment, such as finalizing it.


### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK(security: new Security() {
        Oauth = "<YOUR_OAUTH_HERE>",
    });

var res = await sdk.Payments.LoggedIn.PerformActionAsync(
    xPublishableKey: "<value>",
    xMerchantClientId: "<value>",
    id: "iKv7t5bgt1gg",
    paymentActionRequest: new PaymentActionRequest() {
    DotTag = Boltpay.SDK.Models.Components.PaymentActionRequestTag.Finalize,
    RedirectResult = "eyJ0cmFuc",
});

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                           | Type                                                                                                                                                                                                                | Required                                                                                                                                                                                                            | Description                                                                                                                                                                                                         | Example                                                                                                                                                                                                             |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `XPublishableKey`                                                                                                                                                                                                   | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The publicly viewable identifier used to identify a merchant division.                                                                                                                                              |                                                                                                                                                                                                                     |
| `XMerchantClientId`                                                                                                                                                                                                 | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | A unique identifier for a shopper's device, generated by Bolt. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |                                                                                                                                                                                                                     |
| `Id`                                                                                                                                                                                                                | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The ID of the payment to operate on                                                                                                                                                                                 | iKv7t5bgt1gg                                                                                                                                                                                                        |
| `PaymentActionRequest`                                                                                                                                                                                              | [PaymentActionRequest](../../Models/Components/PaymentActionRequest.md)                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                  | N/A                                                                                                                                                                                                                 |                                                                                                                                                                                                                     |


### Response

**[PaymentsActionResponse](../../Models/Requests/PaymentsActionResponse.md)**
### Errors

| Error Object                           | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Response4xx  | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 4xx-5xx                                | */*                                    |
