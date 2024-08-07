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
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    using System;
    
    /// <summary>
    /// The type of address reference
    /// </summary>
    public enum AddressReferenceIdTag
    {
        [JsonProperty("id")]
        Id,
    }

    public static class AddressReferenceIdTagExtension
    {
        public static string Value(this AddressReferenceIdTag value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static AddressReferenceIdTag ToEnum(this string value)
        {
            foreach(var field in typeof(AddressReferenceIdTag).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    var enumVal = field.GetValue(null);

                    if (enumVal is AddressReferenceIdTag)
                    {
                        return (AddressReferenceIdTag)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum AddressReferenceIdTag");
        }
    }

}