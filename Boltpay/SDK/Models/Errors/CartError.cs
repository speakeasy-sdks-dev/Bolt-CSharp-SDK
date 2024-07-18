//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Errors
{
    using Boltpay.SDK.Models.Errors;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    using System;
    
    public class CartError : Exception
    {

        /// <summary>
        /// The type of error returned
        /// </summary>
        [JsonProperty(".tag")]
        public CartErrorTag DotTag { get; set; } = default!;

        /// <summary>
        /// A human-readable error message, which might include information specific to the request that was made.
        /// </summary>
        [JsonProperty("message")]
        private string? _message { get; set; }
        public override string Message { get {return _message ?? "";} }
    }
}