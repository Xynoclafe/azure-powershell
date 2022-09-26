// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>ResourceMoveDetails will be returned in response to GetResource call from ARM</summary>
    [System.ComponentModel.TypeConverter(typeof(ResourceMoveDetailsTypeConverter))]
    public partial class ResourceMoveDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.ResourceMoveDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ResourceMoveDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.ResourceMoveDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ResourceMoveDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ResourceMoveDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ResourceMoveDetails" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.ResourceMoveDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ResourceMoveDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("OperationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).OperationId = (string) content.GetValueForProperty("OperationId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).OperationId, global::System.Convert.ToString);
            }
            if (content.Contains("StartTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).StartTimeUtc = (string) content.GetValueForProperty("StartTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).StartTimeUtc, global::System.Convert.ToString);
            }
            if (content.Contains("CompletionTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).CompletionTimeUtc = (string) content.GetValueForProperty("CompletionTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).CompletionTimeUtc, global::System.Convert.ToString);
            }
            if (content.Contains("SourceResourcePath"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).SourceResourcePath = (string) content.GetValueForProperty("SourceResourcePath",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).SourceResourcePath, global::System.Convert.ToString);
            }
            if (content.Contains("TargetResourcePath"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).TargetResourcePath = (string) content.GetValueForProperty("TargetResourcePath",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).TargetResourcePath, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.ResourceMoveDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ResourceMoveDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("OperationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).OperationId = (string) content.GetValueForProperty("OperationId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).OperationId, global::System.Convert.ToString);
            }
            if (content.Contains("StartTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).StartTimeUtc = (string) content.GetValueForProperty("StartTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).StartTimeUtc, global::System.Convert.ToString);
            }
            if (content.Contains("CompletionTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).CompletionTimeUtc = (string) content.GetValueForProperty("CompletionTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).CompletionTimeUtc, global::System.Convert.ToString);
            }
            if (content.Contains("SourceResourcePath"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).SourceResourcePath = (string) content.GetValueForProperty("SourceResourcePath",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).SourceResourcePath, global::System.Convert.ToString);
            }
            if (content.Contains("TargetResourcePath"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).TargetResourcePath = (string) content.GetValueForProperty("TargetResourcePath",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IResourceMoveDetailsInternal)this).TargetResourcePath, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// ResourceMoveDetails will be returned in response to GetResource call from ARM
    [System.ComponentModel.TypeConverter(typeof(ResourceMoveDetailsTypeConverter))]
    public partial interface IResourceMoveDetails

    {

    }
}