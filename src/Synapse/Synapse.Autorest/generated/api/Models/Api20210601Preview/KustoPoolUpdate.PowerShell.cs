// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Synapse.Runtime.PowerShell;

    /// <summary>Class representing an update to a Kusto kusto pool.</summary>
    [System.ComponentModel.TypeConverter(typeof(KustoPoolUpdateTypeConverter))]
    public partial class KustoPoolUpdate
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.KustoPoolUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdate DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new KustoPoolUpdate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.KustoPoolUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdate DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new KustoPoolUpdate(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="KustoPoolUpdate" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdate FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Synapse.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.KustoPoolUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal KustoPoolUpdate(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IAzureSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.AzureSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.KustoPoolPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.KustoPoolUpdateTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuSize = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.SkuSize) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuSize, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.SkuSize.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscale = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IOptimizedAutoscale) content.GetValueForProperty("OptimizedAutoscale",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscale, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.OptimizedAutoscaleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.State.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).LanguageExtension = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.ILanguageExtensionsList) content.GetValueForProperty("LanguageExtension",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).LanguageExtension, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.LanguageExtensionsListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.ResourceProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.ResourceProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).DataIngestionUri = (string) content.GetValueForProperty("DataIngestionUri",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).DataIngestionUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).StateReason = (string) content.GetValueForProperty("StateReason",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).StateReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).EnableStreamingIngest = (bool?) content.GetValueForProperty("EnableStreamingIngest",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).EnableStreamingIngest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).EnablePurge = (bool?) content.GetValueForProperty("EnablePurge",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).EnablePurge, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).WorkspaceUid = (string) content.GetValueForProperty("WorkspaceUid",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).WorkspaceUid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleVersion = (int) content.GetValueForProperty("OptimizedAutoscaleVersion",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleMinimum = (int) content.GetValueForProperty("OptimizedAutoscaleMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleMaximum = (int) content.GetValueForProperty("OptimizedAutoscaleMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleIsEnabled = (bool) content.GetValueForProperty("OptimizedAutoscaleIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).LanguageExtensionValue = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.ILanguageExtension[]) content.GetValueForProperty("LanguageExtensionValue",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).LanguageExtensionValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.ILanguageExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.LanguageExtensionTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.KustoPoolUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal KustoPoolUpdate(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IAzureSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.AzureSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.KustoPoolPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.KustoPoolUpdateTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuSize = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.SkuSize) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuSize, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.SkuSize.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscale = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IOptimizedAutoscale) content.GetValueForProperty("OptimizedAutoscale",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscale, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.OptimizedAutoscaleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.State.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).LanguageExtension = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.ILanguageExtensionsList) content.GetValueForProperty("LanguageExtension",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).LanguageExtension, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.LanguageExtensionsListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.ResourceProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Support.ResourceProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).DataIngestionUri = (string) content.GetValueForProperty("DataIngestionUri",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).DataIngestionUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).StateReason = (string) content.GetValueForProperty("StateReason",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).StateReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).EnableStreamingIngest = (bool?) content.GetValueForProperty("EnableStreamingIngest",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).EnableStreamingIngest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).EnablePurge = (bool?) content.GetValueForProperty("EnablePurge",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).EnablePurge, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).WorkspaceUid = (string) content.GetValueForProperty("WorkspaceUid",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).WorkspaceUid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleVersion = (int) content.GetValueForProperty("OptimizedAutoscaleVersion",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleMinimum = (int) content.GetValueForProperty("OptimizedAutoscaleMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleMaximum = (int) content.GetValueForProperty("OptimizedAutoscaleMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleIsEnabled = (bool) content.GetValueForProperty("OptimizedAutoscaleIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).OptimizedAutoscaleIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).LanguageExtensionValue = (Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.ILanguageExtension[]) content.GetValueForProperty("LanguageExtensionValue",((Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IKustoPoolUpdateInternal)this).LanguageExtensionValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.ILanguageExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.LanguageExtensionTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Synapse.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing an update to a Kusto kusto pool.
    [System.ComponentModel.TypeConverter(typeof(KustoPoolUpdateTypeConverter))]
    public partial interface IKustoPoolUpdate

    {

    }
}