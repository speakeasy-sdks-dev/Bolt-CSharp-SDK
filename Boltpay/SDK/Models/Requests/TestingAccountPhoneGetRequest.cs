//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Requests
{
    using Boltpay.SDK.Utils;
    
    public class TestingAccountPhoneGetRequest
    {

        /// <summary>
        /// The publicly shareable identifier used to identify your Bolt merchant division.
        /// </summary>
        [SpeakeasyMetadata("header:style=simple,explode=false,name=X-Publishable-Key")]
        public string XPublishableKey { get; set; } = default!;
    }
}