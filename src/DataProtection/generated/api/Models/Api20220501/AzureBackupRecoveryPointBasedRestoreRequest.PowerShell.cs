// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Azure backup recoveryPoint based restore request</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureBackupRecoveryPointBasedRestoreRequestTypeConverter))]
    public partial class AzureBackupRecoveryPointBasedRestoreRequest
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.AzureBackupRecoveryPointBasedRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureBackupRecoveryPointBasedRestoreRequest(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("RecoveryPointId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequestInternal)this).RecoveryPointId = (string) content.GetValueForProperty("RecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequestInternal)this).RecoveryPointId, global::System.Convert.ToString);
            }
            if (content.Contains("ObjectType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).ObjectType, global::System.Convert.ToString);
            }
            if (content.Contains("RestoreTargetInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IRestoreTargetInfoBase) content.GetValueForProperty("RestoreTargetInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.RestoreTargetInfoBaseTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDataStoreType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).SourceDataStoreType = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType) content.GetValueForProperty("SourceDataStoreType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).SourceDataStoreType, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType.CreateFrom);
            }
            if (content.Contains("SourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).SourceResourceId = (string) content.GetValueForProperty("SourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).SourceResourceId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.AzureBackupRecoveryPointBasedRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureBackupRecoveryPointBasedRestoreRequest(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("RecoveryPointId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequestInternal)this).RecoveryPointId = (string) content.GetValueForProperty("RecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequestInternal)this).RecoveryPointId, global::System.Convert.ToString);
            }
            if (content.Contains("ObjectType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).ObjectType, global::System.Convert.ToString);
            }
            if (content.Contains("RestoreTargetInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IRestoreTargetInfoBase) content.GetValueForProperty("RestoreTargetInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.RestoreTargetInfoBaseTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceDataStoreType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).SourceDataStoreType = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType) content.GetValueForProperty("SourceDataStoreType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).SourceDataStoreType, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType.CreateFrom);
            }
            if (content.Contains("SourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).SourceResourceId = (string) content.GetValueForProperty("SourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRestoreRequestInternal)this).SourceResourceId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.AzureBackupRecoveryPointBasedRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequest DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureBackupRecoveryPointBasedRestoreRequest(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.AzureBackupRecoveryPointBasedRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequest DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureBackupRecoveryPointBasedRestoreRequest(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureBackupRecoveryPointBasedRestoreRequest" />, deserializing the content from a
        /// json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="AzureBackupRecoveryPointBasedRestoreRequest" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IAzureBackupRecoveryPointBasedRestoreRequest FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Azure backup recoveryPoint based restore request
    [System.ComponentModel.TypeConverter(typeof(AzureBackupRecoveryPointBasedRestoreRequestTypeConverter))]
    public partial interface IAzureBackupRecoveryPointBasedRestoreRequest

    {

    }
}