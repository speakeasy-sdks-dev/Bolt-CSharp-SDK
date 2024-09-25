//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK
{
    using Boltpay.SDK.Hooks;
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Models.Errors;
    using Boltpay.SDK.Models.Requests;
    using Boltpay.SDK.Utils.Retries;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System;

    /// <summary>
    /// Use the Orders API to create and manage orders, including orders that have been placed outside the Bolt ecosystem.
    /// </summary>
    public interface IOrders
    {

        /// <summary>
        /// Create an order that was prepared outside the Bolt ecosystem.
        /// 
        /// <remarks>
        /// Create an order that was prepared outside the Bolt ecosystem. Some Bolt-powered flows automatically manage order creation - in those flows the order ID will be provided separately and not through this API.
        /// </remarks>
        /// </summary>
        Task<OrdersCreateResponse> OrdersCreateAsync(OrdersCreateSecurity security, string xPublishableKey, string xMerchantClientId, Order order);
    }

    /// <summary>
    /// Use the Orders API to create and manage orders, including orders that have been placed outside the Bolt ecosystem.
    /// </summary>
    public class Orders: IOrders
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.2.1";
        private const string _sdkGenVersion = "2.422.22";
        private const string _openapiDocVersion = "3.2.1";
        private const string _userAgent = "speakeasy-sdk/csharp 0.2.1 2.422.22 3.2.1 Boltpay.SDK";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Boltpay.SDK.Models.Components.Security>? _securitySource;

        public Orders(ISpeakeasyHttpClient client, Func<Boltpay.SDK.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<OrdersCreateResponse> OrdersCreateAsync(OrdersCreateSecurity security, string xPublishableKey, string xMerchantClientId, Order order)
        {
            var request = new OrdersCreateRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
                Order = order
            };

            async Task<OrdersCreateResponse> ordersCreateAsync(OrdersCreateSecurity security, OrdersCreateRequest request)
            {
                string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

                var urlString = baseUrl + "/orders";

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
                httpRequest.Headers.Add("user-agent", _userAgent);
                HeaderSerializer.PopulateHeaders(ref httpRequest, request);

                var serializedBody = RequestBodySerializer.Serialize(request, "Order", "json", false, false);
                if (serializedBody != null)
                {
                    httpRequest.Content = serializedBody;
                }

                Func<OrdersCreateSecurity>? securitySource = null;
                if (security != null)
                {
                    httpRequest = new SecurityMetadata(() => security).Apply(httpRequest);
                    securitySource = () => security;
                }

                var hookCtx = new HookContext("ordersCreate", null, securitySource);

                httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

                HttpResponseMessage httpResponse;
                try
                {
                    httpResponse = await _client.SendAsync(httpRequest);
                    int _statusCode = (int)httpResponse.StatusCode;

                    if (_statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                    {
                        var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                        if (_httpResponse != null)
                        {
                            httpResponse = _httpResponse;
                        }
                    }
                }
                catch (Exception error)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                    else
                    {
                        throw;
                    }
                }

                httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

                var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
                int responseStatusCode = (int)httpResponse.StatusCode;
                if(responseStatusCode == 200)
                {
                    if(Utilities.IsContentTypeMatch("application/json", contentType))
                    {
                        var obj = ResponseBodyDeserializer.Deserialize<OrderResponse>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                        var response = new OrdersCreateResponse()
                        {
                            HttpMeta = new Models.Components.HTTPMetadata()
                            {
                                Response = httpResponse,
                                Request = httpRequest
                            }
                        };
                        response.OrderResponse = obj;
                        return response;
                    }

                    throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
                }
                else if(responseStatusCode >= 400 && responseStatusCode < 500)
                {
                    if(Utilities.IsContentTypeMatch("application/json", contentType))
                    {
                        var obj = ResponseBodyDeserializer.Deserialize<Response4xx>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                        switch (obj!.Type.ToString()) {
                            case "error":
                                  throw obj!.Error!;
                            case "field-error":
                                  throw obj!.FieldError!;
                            default:
                                throw new InvalidOperationException("Unknown error type.");
                        };
                    }

                    throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
                }
                else if(responseStatusCode >= 500 && responseStatusCode < 600)
                {
                    throw new Models.Errors.SDKException("API error occurred", httpRequest, httpResponse);
                }
                else
                {    
                    return new OrdersCreateResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                }
            }

            return await ordersCreateAsync(security, request);
        }
    }
}