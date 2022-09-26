// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.PowerShell;

    /// <summary>Properties of the virtual network peering.</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkPeeringPropertiesFormatTypeConverter))]
    public partial class VirtualNetworkPeeringPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualNetworkPeeringPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualNetworkPeeringPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualNetworkPeeringPropertiesFormat" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="VirtualNetworkPeeringPropertiesFormat" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeAll)?.ToString();

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

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualNetworkPeeringPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("DatabricksVirtualNetwork"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork) content.GetValueForProperty("DatabricksVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("DatabricksAddressSpace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IAddressSpace) content.GetValueForProperty("DatabricksAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.AddressSpaceTypeConverter.ConvertFrom);
            }
            if (content.Contains("RemoteVirtualNetwork"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork) content.GetValueForProperty("RemoteVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("RemoteAddressSpace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IAddressSpace) content.GetValueForProperty("RemoteAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.AddressSpaceTypeConverter.ConvertFrom);
            }
            if (content.Contains("AllowVirtualNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVirtualNetworkAccess = (bool?) content.GetValueForProperty("AllowVirtualNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVirtualNetworkAccess, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("AllowForwardedTraffic"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic = (bool?) content.GetValueForProperty("AllowForwardedTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("AllowGatewayTransit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit = (bool?) content.GetValueForProperty("AllowGatewayTransit",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("UseRemoteGateway"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway = (bool?) content.GetValueForProperty("UseRemoteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("PeeringState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState?) content.GetValueForProperty("PeeringState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState.CreateFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState.CreateFrom);
            }
            if (content.Contains("DatabrickVirtualNetworkId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickVirtualNetworkId = (string) content.GetValueForProperty("DatabrickVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickVirtualNetworkId, global::System.Convert.ToString);
            }
            if (content.Contains("DatabrickAddressSpaceAddressPrefix"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("DatabrickAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("RemoteVirtualNetworkId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetworkId = (string) content.GetValueForProperty("RemoteVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetworkId, global::System.Convert.ToString);
            }
            if (content.Contains("RemoteAddressSpaceAddressPrefix"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("RemoteAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualNetworkPeeringPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("DatabricksVirtualNetwork"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork) content.GetValueForProperty("DatabricksVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("DatabricksAddressSpace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IAddressSpace) content.GetValueForProperty("DatabricksAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.AddressSpaceTypeConverter.ConvertFrom);
            }
            if (content.Contains("RemoteVirtualNetwork"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork) content.GetValueForProperty("RemoteVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("RemoteAddressSpace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IAddressSpace) content.GetValueForProperty("RemoteAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.AddressSpaceTypeConverter.ConvertFrom);
            }
            if (content.Contains("AllowVirtualNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVirtualNetworkAccess = (bool?) content.GetValueForProperty("AllowVirtualNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVirtualNetworkAccess, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("AllowForwardedTraffic"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic = (bool?) content.GetValueForProperty("AllowForwardedTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("AllowGatewayTransit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit = (bool?) content.GetValueForProperty("AllowGatewayTransit",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("UseRemoteGateway"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway = (bool?) content.GetValueForProperty("UseRemoteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("PeeringState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState?) content.GetValueForProperty("PeeringState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState.CreateFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState.CreateFrom);
            }
            if (content.Contains("DatabrickVirtualNetworkId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickVirtualNetworkId = (string) content.GetValueForProperty("DatabrickVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickVirtualNetworkId, global::System.Convert.ToString);
            }
            if (content.Contains("DatabrickAddressSpaceAddressPrefix"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("DatabrickAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("RemoteVirtualNetworkId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetworkId = (string) content.GetValueForProperty("RemoteVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetworkId, global::System.Convert.ToString);
            }
            if (content.Contains("RemoteAddressSpaceAddressPrefix"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("RemoteAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20220401Preview.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializePSObject(content);
        }
    }
    /// Properties of the virtual network peering.
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkPeeringPropertiesFormatTypeConverter))]
    public partial interface IVirtualNetworkPeeringPropertiesFormat

    {

    }
}