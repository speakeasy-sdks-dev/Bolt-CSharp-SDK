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

    public interface ILoggedIn
    {

        /// <summary>
        /// Initialize a Bolt payment for logged in shoppers
        /// 
        /// <remarks>
        /// Initialize a Bolt logged-in shopper&apos;s intent to pay for a cart, using the specified payment method. Payments must be finalized before indicating the payment result to the shopper. Some payment methods will finalize automatically after initialization. For these payments, they will transition directly to &quot;finalized&quot; and the response from Initialize Payment will contain a finalized payment.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<PaymentsInitializeResponse> InitializeAsync(string xPublishableKey, string xMerchantClientId, PaymentInitializeRequest paymentInitializeRequest);

        /// <summary>
        /// Finalize a pending payment
        /// 
        /// <remarks>
        /// Finalize a pending payment being made by a Bolt logged-in shopper. Upon receipt of a finalized payment result, payment success should be communicated to the shopper.
        /// </remarks>
        /// </summary>
        Task<PaymentsActionResponse> PerformActionAsync(string xPublishableKey, string xMerchantClientId, string id, PaymentActionRequest paymentActionRequest);
    }

    public class LoggedIn: ILoggedIn
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.2.1";
        private const string _sdkGenVersion = "2.432.0";
        private const string _openapiDocVersion = "3.2.1";
        private const string _userAgent = "speakeasy-sdk/csharp 0.2.1 2.432.0 3.2.1 Boltpay.SDK";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Boltpay.SDK.Models.Components.Security>? _securitySource;

        public LoggedIn(ISpeakeasyHttpClient client, Func<Boltpay.SDK.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<PaymentsInitializeResponse> InitializeAsync(string xPublishableKey, string xMerchantClientId, PaymentInitializeRequest paymentInitializeRequest)
        {
            var request = new PaymentsInitializeRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
                PaymentInitializeRequest = paymentInitializeRequest,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/payments";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            var serializedBody = RequestBodySerializer.Serialize(request, "PaymentInitializeRequest", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("paymentsInitialize", null, _securitySource);

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
                    var obj = ResponseBodyDeserializer.Deserialize<PaymentResponse>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new PaymentsInitializeResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.PaymentResponse = obj;
                    return response;
                }

                throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<ResponsePaymentError>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    switch (obj!.Type.ToString()) {
                        case "error":
                              throw obj!.Error!;
                        case "field-error":
                              throw obj!.FieldError!;
                        case "cart-error":
                              throw obj!.CartError!;
                        case "credit-card-error":
                              throw obj!.CreditCardError!;
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
                return new PaymentsInitializeResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
        }

        public async Task<PaymentsActionResponse> PerformActionAsync(string xPublishableKey, string xMerchantClientId, string id, PaymentActionRequest paymentActionRequest)
        {
            var request = new PaymentsActionRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
                Id = id,
                PaymentActionRequest = paymentActionRequest,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/payments/{id}", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            var serializedBody = RequestBodySerializer.Serialize(request, "PaymentActionRequest", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("paymentsAction", null, _securitySource);

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
                    var obj = ResponseBodyDeserializer.Deserialize<PaymentResponse>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new PaymentsActionResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.PaymentResponse = obj;
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
                return new PaymentsActionResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
        }
    }
}