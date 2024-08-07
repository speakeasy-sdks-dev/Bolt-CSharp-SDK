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
    
    public class AccountTestCreationData
    {

        [JsonProperty("email_state")]
        public EmailState EmailState { get; set; } = default!;

        [JsonProperty("phone_state")]
        public PhoneState PhoneState { get; set; } = default!;

        [JsonProperty("is_migrated")]
        public bool? IsMigrated { get; set; }

        [JsonProperty("has_address")]
        public bool? HasAddress { get; set; }

        [JsonProperty("has_credit_card")]
        public bool? HasCreditCard { get; set; }
    }
}