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
    /// Use the OAuth API to enable your ecommerce server to make API calls on behalf of a Bolt logged-in shopper.
    /// 
    /// <see>https://help.bolt.com/products/accounts/direct-api/oauth-guide/}</see>
    /// </summary>
    public interface IOAuth
    {

        /// <summary>
        /// Get OAuth token
        /// 
        /// <remarks>
        /// Retrieve a new or refresh an existing OAuth token.
        /// </remarks>
        /// </summary>
        Task<OauthGetTokenResponse> GetTokenAsync(string xMerchantClientId, TokenRequest tokenRequest);
    }

    /// <summary>
    /// Use the OAuth API to enable your ecommerce server to make API calls on behalf of a Bolt logged-in shopper.
    /// 
    /// <see>https://help.bolt.com/products/accounts/direct-api/oauth-guide/}</see>
    /// </summary>
    public class OAuth: IOAuth
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.2.1";
        private const string _sdkGenVersion = "2.437.1";
        private const string _openapiDocVersion = "3.2.1";
        private const string _userAgent = "speakeasy-sdk/csharp 0.2.1 2.437.1 3.2.1 Boltpay.SDK";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Boltpay.SDK.Models.Components.Security>? _securitySource;

        public OAuth(ISpeakeasyHttpClient client, Func<Boltpay.SDK.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<OauthGetTokenResponse> GetTokenAsync(string xMerchantClientId, TokenRequest tokenRequest)
        {
            var request = new OauthGetTokenRequest()
            {
                XMerchantClientId = xMerchantClientId,
                TokenRequest = tokenRequest,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/oauth/token";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            var serializedBody = RequestBodySerializer.Serialize(request, "TokenRequest", "form", false, false);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            var hookCtx = new HookContext("oauthGetToken", null, null);

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
                    var obj = ResponseBodyDeserializer.Deserialize<GetAccessTokenResponse>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new OauthGetTokenResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.GetAccessTokenResponse = obj;
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
                return new OauthGetTokenResponse()
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