// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>The list of versions for supported orchestrators.</summary>
    [System.ComponentModel.TypeConverter(typeof(OrchestratorVersionProfileListResultTypeConverter))]
    public partial class OrchestratorVersionProfileListResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.OrchestratorVersionProfileListResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OrchestratorVersionProfileListResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.OrchestratorVersionProfileListResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OrchestratorVersionProfileListResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OrchestratorVersionProfileListResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="OrchestratorVersionProfileListResult" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.OrchestratorVersionProfileListResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OrchestratorVersionProfileListResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.OrchestratorVersionProfilePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Orchestrator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Orchestrator = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfile[]) content.GetValueForProperty("Orchestrator",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Orchestrator, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.OrchestratorVersionProfileTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.OrchestratorVersionProfileListResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OrchestratorVersionProfileListResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.OrchestratorVersionProfilePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Orchestrator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Orchestrator = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfile[]) content.GetValueForProperty("Orchestrator",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResultInternal)this).Orchestrator, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.OrchestratorVersionProfileTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The list of versions for supported orchestrators.
    [System.ComponentModel.TypeConverter(typeof(OrchestratorVersionProfileListResultTypeConverter))]
    public partial interface IOrchestratorVersionProfileListResult

    {

    }
}