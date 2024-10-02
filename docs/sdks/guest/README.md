# Guest
(*Payments.Guest*)

## Overview

### Available Operations

* [Initialize](#initialize) - Initialize a Bolt payment for guest shoppers
* [PerformAction](#performaction) - Finalize a pending guest payment

## Initialize

Initialize a Bolt guest shopper's intent to pay for a cart, using the specified payment method. Payments must be finalized before indicating the payment result to the shopper. Some payment methods will finalize automatically after initialization. For these payments, they will transition directly to "finalized" and the response from Initialize Payment will contain a finalized payment.

### Example Usage

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

### Parameters

| Parameter                                                                                                                                                                                                           | Type                                                                                                                                                                                                                | Required                                                                                                                                                                                                            | Description                                                                                                                                                                                                         |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `security`                                                                                                                                                                                                          | [Boltpay.SDK.Models.Requests.GuestPaymentsInitializeSecurity](../../Models/Requests/GuestPaymentsInitializeSecurity.md)                                                                                             | :heavy_check_mark:                                                                                                                                                                                                  | The security requirements to use for the request.                                                                                                                                                                   |
| `XPublishableKey`                                                                                                                                                                                                   | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                     |
| `XMerchantClientId`                                                                                                                                                                                                 | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | A unique identifier for a shopper's device, generated by Bolt. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |
| `GuestPaymentInitializeRequest`                                                                                                                                                                                     | [GuestPaymentInitializeRequest](../../Models/Components/GuestPaymentInitializeRequest.md)                                                                                                                           | :heavy_check_mark:                                                                                                                                                                                                  | N/A                                                                                                                                                                                                                 |

### Response

**[GuestPaymentsInitializeResponse](../../Models/Requests/GuestPaymentsInitializeResponse.md)**

### Errors

| Error Type                                | Status Code                               | Content Type                              |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| Boltpay.SDK.Models.Errors.Error           | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.FieldError      | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.CartError       | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.CreditCardError | 4XX                                       | application/json                          |
| Boltpay.SDK.Models.Errors.SDKException    | 5XX                                       | \*/\*                                     |

## PerformAction

Finalize a pending payment being made by a Bolt guest shopper. Upon receipt of a finalized payment result, payment success should be communicated to the shopper.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;

var sdk = new BoltSDK();

var res = await sdk.Payments.Guest.PerformActionAsync(
    security: new GuestPaymentsActionSecurity() {
        ApiKey = "<YOUR_API_KEY_HERE>",
    },
    xPublishableKey: "<value>",
    xMerchantClientId: "<id>",
    id: "iKv7t5bgt1gg",
    paymentActionRequest: new PaymentActionRequest() {
        DotTag = Boltpay.SDK.Models.Components.PaymentActionRequestTag.Finalize,
        RedirectResult = "eyJ0cmFuc",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                           | Type                                                                                                                                                                                                                | Required                                                                                                                                                                                                            | Description                                                                                                                                                                                                         | Example                                                                                                                                                                                                             |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `security`                                                                                                                                                                                                          | [Boltpay.SDK.Models.Requests.GuestPaymentsActionSecurity](../../Models/Requests/GuestPaymentsActionSecurity.md)                                                                                                     | :heavy_check_mark:                                                                                                                                                                                                  | The security requirements to use for the request.                                                                                                                                                                   |                                                                                                                                                                                                                     |
| `XPublishableKey`                                                                                                                                                                                                   | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                     |                                                                                                                                                                                                                     |
| `XMerchantClientId`                                                                                                                                                                                                 | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | A unique identifier for a shopper's device, generated by Bolt. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |                                                                                                                                                                                                                     |
| `Id`                                                                                                                                                                                                                | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The ID of the guest payment to operate on                                                                                                                                                                           | iKv7t5bgt1gg                                                                                                                                                                                                        |
| `PaymentActionRequest`                                                                                                                                                                                              | [PaymentActionRequest](../../Models/Components/PaymentActionRequest.md)                                                                                                                                             | :heavy_check_mark:                                                                                                                                                                                                  | N/A                                                                                                                                                                                                                 |                                                                                                                                                                                                                     |

### Response

**[GuestPaymentsActionResponse](../../Models/Requests/GuestPaymentsActionResponse.md)**

### Errors

| Error Type                             | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 5XX                                    | \*/\*                                  |