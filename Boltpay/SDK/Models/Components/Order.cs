//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
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
    using Newtonsoft.Json;
    
    public class Order
    {

        /// <summary>
        /// An account&apos;s identifying information.
        /// </summary>
        [JsonProperty("profile")]
        public Profile Profile { get; set; } = default!;

        [JsonProperty("cart")]
        public Cart Cart { get; set; } = default!;
    }
}