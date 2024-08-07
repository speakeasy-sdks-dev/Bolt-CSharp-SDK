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
    using Newtonsoft.Json;
    
    public class CartShipment
    {

        [JsonProperty("address")]
        public AddressReferenceInput? Address { get; set; }

        public AddressReferenceId? GetAddressId()
        {
            return Address != null ? Address.AddressReferenceId : null;
        }

        public AddressReferenceExplicitInput? GetAddressExplicit()
        {
            return Address != null ? Address.AddressReferenceExplicitInput : null;
        }

        /// <summary>
        /// A monetary amount, i.e. a base unit amount and a supported currency.
        /// </summary>
        [JsonProperty("cost")]
        public Amount? Cost { get; set; }

        /// <summary>
        /// The name of the carrier selected.
        /// </summary>
        [JsonProperty("carrier")]
        public string? Carrier { get; set; }
    }
}