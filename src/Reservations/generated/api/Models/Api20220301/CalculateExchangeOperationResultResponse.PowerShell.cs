// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.PowerShell;

    /// <summary>CalculateExchange operation result</summary>
    [System.ComponentModel.TypeConverter(typeof(CalculateExchangeOperationResultResponseTypeConverter))]
    public partial class CalculateExchangeOperationResultResponse
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.CalculateExchangeOperationResultResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CalculateExchangeOperationResultResponse(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Properties"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Properties = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponseProperties) content.GetValueForProperty("Properties",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Properties, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.CalculateExchangeResponsePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Error"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultError) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.OperationResultErrorTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus.CreateFrom);
            }
            if (content.Contains("PolicyResult"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PolicyResult = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyErrors) content.GetValueForProperty("PolicyResult",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PolicyResult, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ExchangePolicyErrorsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SessionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).SessionId = (string) content.GetValueForProperty("SessionId",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).SessionId, global::System.Convert.ToString);
            }
            if (content.Contains("NetPayable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).NetPayable = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("NetPayable",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).NetPayable, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("RefundsTotal"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).RefundsTotal = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("RefundsTotal",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).RefundsTotal, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("PurchasesTotal"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PurchasesTotal = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("PurchasesTotal",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PurchasesTotal, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("ReservationsToPurchase"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).ReservationsToPurchase = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToPurchaseCalculateExchange[]) content.GetValueForProperty("ReservationsToPurchase",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).ReservationsToPurchase, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToPurchaseCalculateExchange>(__y, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ReservationToPurchaseCalculateExchangeTypeConverter.ConvertFrom));
            }
            if (content.Contains("ReservationsToExchange"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).ReservationsToExchange = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToExchange[]) content.GetValueForProperty("ReservationsToExchange",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).ReservationsToExchange, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToExchange>(__y, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ReservationToExchangeTypeConverter.ConvertFrom));
            }
            if (content.Contains("Code"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Code, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyResultPolicyError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PolicyResultPolicyError = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyError[]) content.GetValueForProperty("PolicyResultPolicyError",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PolicyResultPolicyError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ExchangePolicyErrorTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.CalculateExchangeOperationResultResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CalculateExchangeOperationResultResponse(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Properties"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Properties = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponseProperties) content.GetValueForProperty("Properties",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Properties, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.CalculateExchangeResponsePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Error"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultError) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.OperationResultErrorTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus.CreateFrom);
            }
            if (content.Contains("PolicyResult"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PolicyResult = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyErrors) content.GetValueForProperty("PolicyResult",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PolicyResult, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ExchangePolicyErrorsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SessionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).SessionId = (string) content.GetValueForProperty("SessionId",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).SessionId, global::System.Convert.ToString);
            }
            if (content.Contains("NetPayable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).NetPayable = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("NetPayable",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).NetPayable, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("RefundsTotal"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).RefundsTotal = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("RefundsTotal",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).RefundsTotal, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("PurchasesTotal"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PurchasesTotal = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("PurchasesTotal",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PurchasesTotal, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("ReservationsToPurchase"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).ReservationsToPurchase = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToPurchaseCalculateExchange[]) content.GetValueForProperty("ReservationsToPurchase",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).ReservationsToPurchase, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToPurchaseCalculateExchange>(__y, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ReservationToPurchaseCalculateExchangeTypeConverter.ConvertFrom));
            }
            if (content.Contains("ReservationsToExchange"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).ReservationsToExchange = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToExchange[]) content.GetValueForProperty("ReservationsToExchange",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).ReservationsToExchange, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToExchange>(__y, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ReservationToExchangeTypeConverter.ConvertFrom));
            }
            if (content.Contains("Code"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Code, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyResultPolicyError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PolicyResultPolicyError = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyError[]) content.GetValueForProperty("PolicyResultPolicyError",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal)this).PolicyResultPolicyError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ExchangePolicyErrorTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.CalculateExchangeOperationResultResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponse"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponse DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CalculateExchangeOperationResultResponse(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.CalculateExchangeOperationResultResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponse"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponse DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CalculateExchangeOperationResultResponse(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CalculateExchangeOperationResultResponse" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="CalculateExchangeOperationResultResponse" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponse FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// CalculateExchange operation result
    [System.ComponentModel.TypeConverter(typeof(CalculateExchangeOperationResultResponseTypeConverter))]
    public partial interface ICalculateExchangeOperationResultResponse

    {

    }
}