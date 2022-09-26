// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.PowerShell;

    /// <summary>Properties of the private endpoint.</summary>
    [System.ComponentModel.TypeConverter(typeof(PrivateEndpointPropertiesTypeConverter))]
    public partial class PrivateEndpointProperties
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PrivateEndpointProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PrivateEndpointProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PrivateEndpointProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PrivateEndpointProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("NetworkInterface"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).NetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface[]) content.GetValueForProperty("NetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).NetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.NetworkInterfaceTypeConverter.ConvertFrom));
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.ProvisioningState.CreateFrom);
            }
            if (content.Contains("PrivateLinkServiceConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).PrivateLinkServiceConnection = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceConnection[]) content.GetValueForProperty("PrivateLinkServiceConnection",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).PrivateLinkServiceConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("ManualPrivateLinkServiceConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ManualPrivateLinkServiceConnection = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceConnection[]) content.GetValueForProperty("ManualPrivateLinkServiceConnection",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ManualPrivateLinkServiceConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("CustomDnsConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).CustomDnsConfig = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICustomDnsConfigPropertiesFormat[]) content.GetValueForProperty("CustomDnsConfig",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).CustomDnsConfig, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICustomDnsConfigPropertiesFormat>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CustomDnsConfigPropertiesFormatTypeConverter.ConvertFrom));
            }
            if (content.Contains("ApplicationSecurityGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ApplicationSecurityGroup = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApplicationSecurityGroup[]) content.GetValueForProperty("ApplicationSecurityGroup",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ApplicationSecurityGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApplicationSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ApplicationSecurityGroupTypeConverter.ConvertFrom));
            }
            if (content.Contains("IPConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateEndpointIPConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("CustomNetworkInterfaceName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).CustomNetworkInterfaceName = (string) content.GetValueForProperty("CustomNetworkInterfaceName",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).CustomNetworkInterfaceName, global::System.Convert.ToString);
            }
            if (content.Contains("Subnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubnet) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).Subnet, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubnetTypeConverter.ConvertFrom);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PrivateEndpointProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("NetworkInterface"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).NetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface[]) content.GetValueForProperty("NetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).NetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.NetworkInterfaceTypeConverter.ConvertFrom));
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.ProvisioningState.CreateFrom);
            }
            if (content.Contains("PrivateLinkServiceConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).PrivateLinkServiceConnection = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceConnection[]) content.GetValueForProperty("PrivateLinkServiceConnection",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).PrivateLinkServiceConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("ManualPrivateLinkServiceConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ManualPrivateLinkServiceConnection = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceConnection[]) content.GetValueForProperty("ManualPrivateLinkServiceConnection",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ManualPrivateLinkServiceConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("CustomDnsConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).CustomDnsConfig = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICustomDnsConfigPropertiesFormat[]) content.GetValueForProperty("CustomDnsConfig",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).CustomDnsConfig, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICustomDnsConfigPropertiesFormat>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CustomDnsConfigPropertiesFormatTypeConverter.ConvertFrom));
            }
            if (content.Contains("ApplicationSecurityGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ApplicationSecurityGroup = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApplicationSecurityGroup[]) content.GetValueForProperty("ApplicationSecurityGroup",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).ApplicationSecurityGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApplicationSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ApplicationSecurityGroupTypeConverter.ConvertFrom));
            }
            if (content.Contains("IPConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateEndpointIPConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("CustomNetworkInterfaceName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).CustomNetworkInterfaceName = (string) content.GetValueForProperty("CustomNetworkInterfaceName",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).CustomNetworkInterfaceName, global::System.Convert.ToString);
            }
            if (content.Contains("Subnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubnet) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointPropertiesInternal)this).Subnet, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubnetTypeConverter.ConvertFrom);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the private endpoint.
    [System.ComponentModel.TypeConverter(typeof(PrivateEndpointPropertiesTypeConverter))]
    public partial interface IPrivateEndpointProperties

    {

    }
}