# Orders
(*Orders*)

## Overview

Use the Orders API to create and manage orders, including orders that have been placed outside the Bolt ecosystem.

### Available Operations

* [OrdersCreate](#orderscreate) - Create an order that was prepared outside the Bolt ecosystem.

## OrdersCreate

Create an order that was prepared outside the Bolt ecosystem. Some Bolt-powered flows automatically manage order creation - in those flows the order ID will be provided separately and not through this API.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;
using System.Collections.Generic;

var sdk = new BoltSDK();

var res = await sdk.Orders.OrdersCreateAsync(
    security: new OrdersCreateSecurity() {
        ApiKey = "<YOUR_API_KEY_HERE>",
    },
    xPublishableKey: "<value>",
    xMerchantClientId: "<id>",
    order: new Order() {
        Profile = new Profile() {
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
                    Address = AddressReferenceInput.CreateAddressReferenceExplicitInput(
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
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                           | Type                                                                                                                                                                                                                | Required                                                                                                                                                                                                            | Description                                                                                                                                                                                                         |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `security`                                                                                                                                                                                                          | [Boltpay.SDK.Models.Requests.OrdersCreateSecurity](../../Models/Requests/OrdersCreateSecurity.md)                                                                                                                   | :heavy_check_mark:                                                                                                                                                                                                  | The security requirements to use for the request.                                                                                                                                                                   |
| `XPublishableKey`                                                                                                                                                                                                   | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | The publicly shareable identifier used to identify your Bolt merchant division.                                                                                                                                     |
| `XMerchantClientId`                                                                                                                                                                                                 | *string*                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                  | A unique identifier for a shopper's device, generated by Bolt. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |
| `Order`                                                                                                                                                                                                             | [Order](../../Models/Components/Order.md)                                                                                                                                                                           | :heavy_check_mark:                                                                                                                                                                                                  | N/A                                                                                                                                                                                                                 |

### Response

**[OrdersCreateResponse](../../Models/Requests/OrdersCreateResponse.md)**

### Errors

| Error Object                           | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 4xx-5xx                                | */*                                    |
