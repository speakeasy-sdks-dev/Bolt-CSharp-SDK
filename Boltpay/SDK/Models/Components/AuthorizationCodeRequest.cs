//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Components
{
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Utils;
    using System.Collections.Generic;
    
    public class AuthorizationCodeRequest
    {

        /// <summary>
        /// The type of OAuth 2.0 grant being utilized.
        /// </summary>
        [SpeakeasyMetadata("form:name=grant_type")]
        public GrantType GrantType { get; set; } = default!;

        /// <summary>
        /// Fetched value using OTP value from the Authorization Modal.
        /// </summary>
        [SpeakeasyMetadata("form:name=code")]
        public string Code { get; set; } = default!;

        /// <summary>
        /// The OAuth client ID, which corresponds to the merchant publishable key, which can be retrieved in your Merchant Dashboard.
        /// </summary>
        [SpeakeasyMetadata("form:name=client_id")]
        public string ClientId { get; set; } = default!;

        /// <summary>
        /// The OAuth client secret, which corresponds the merchant API key, which can be retrieved in your Merchant Dashboard.
        /// </summary>
        [SpeakeasyMetadata("form:name=client_secret")]
        public string ClientSecret { get; set; } = default!;

        /// <summary>
        /// The requested scopes. If the request is successful, the OAuth client will be able to perform operations requiring these scopes.
        /// 
        /// <see>https://help.bolt.com/developers/references/bolt-oauth/#scopes} - OAuth Developer Reference</see>
        /// </summary>
        [SpeakeasyMetadata("form:name=scope")]
        public List<Scope> Scope { get; set; } = default!;

        /// <summary>
        /// A randomly generated string sent along with an authorization code. This must be included if provided. It is used to prevent cross-site request forgery (CSRF) attacks.
        /// </summary>
        [SpeakeasyMetadata("form:name=state")]
        public string? State { get; set; }
    }
}