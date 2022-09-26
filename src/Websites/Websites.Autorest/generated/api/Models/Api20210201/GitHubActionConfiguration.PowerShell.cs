// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.PowerShell;

    /// <summary>The GitHub action configuration.</summary>
    [System.ComponentModel.TypeConverter(typeof(GitHubActionConfigurationTypeConverter))]
    public partial class GitHubActionConfiguration
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.GitHubActionConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new GitHubActionConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.GitHubActionConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new GitHubActionConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="GitHubActionConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.GitHubActionConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal GitHubActionConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("CodeConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionCodeConfiguration) content.GetValueForProperty("CodeConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.GitHubActionCodeConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("ContainerConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionContainerConfiguration) content.GetValueForProperty("ContainerConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.GitHubActionContainerConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("IsLinux"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).IsLinux = (bool?) content.GetValueForProperty("IsLinux",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).IsLinux, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("GenerateWorkflowFile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).GenerateWorkflowFile = (bool?) content.GetValueForProperty("GenerateWorkflowFile",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).GenerateWorkflowFile, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("CodeConfigurationRuntimeStack"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfigurationRuntimeStack = (string) content.GetValueForProperty("CodeConfigurationRuntimeStack",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfigurationRuntimeStack, global::System.Convert.ToString);
            }
            if (content.Contains("CodeConfigurationRuntimeVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfigurationRuntimeVersion = (string) content.GetValueForProperty("CodeConfigurationRuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfigurationRuntimeVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ContainerConfigurationServerUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationServerUrl = (string) content.GetValueForProperty("ContainerConfigurationServerUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationServerUrl, global::System.Convert.ToString);
            }
            if (content.Contains("ContainerConfigurationImageName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationImageName = (string) content.GetValueForProperty("ContainerConfigurationImageName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationImageName, global::System.Convert.ToString);
            }
            if (content.Contains("ContainerConfigurationUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationUsername = (string) content.GetValueForProperty("ContainerConfigurationUsername",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationUsername, global::System.Convert.ToString);
            }
            if (content.Contains("ContainerConfigurationPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationPassword = (string) content.GetValueForProperty("ContainerConfigurationPassword",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationPassword, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.GitHubActionConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal GitHubActionConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("CodeConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionCodeConfiguration) content.GetValueForProperty("CodeConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.GitHubActionCodeConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("ContainerConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionContainerConfiguration) content.GetValueForProperty("ContainerConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.GitHubActionContainerConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("IsLinux"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).IsLinux = (bool?) content.GetValueForProperty("IsLinux",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).IsLinux, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("GenerateWorkflowFile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).GenerateWorkflowFile = (bool?) content.GetValueForProperty("GenerateWorkflowFile",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).GenerateWorkflowFile, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("CodeConfigurationRuntimeStack"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfigurationRuntimeStack = (string) content.GetValueForProperty("CodeConfigurationRuntimeStack",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfigurationRuntimeStack, global::System.Convert.ToString);
            }
            if (content.Contains("CodeConfigurationRuntimeVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfigurationRuntimeVersion = (string) content.GetValueForProperty("CodeConfigurationRuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).CodeConfigurationRuntimeVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ContainerConfigurationServerUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationServerUrl = (string) content.GetValueForProperty("ContainerConfigurationServerUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationServerUrl, global::System.Convert.ToString);
            }
            if (content.Contains("ContainerConfigurationImageName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationImageName = (string) content.GetValueForProperty("ContainerConfigurationImageName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationImageName, global::System.Convert.ToString);
            }
            if (content.Contains("ContainerConfigurationUsername"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationUsername = (string) content.GetValueForProperty("ContainerConfigurationUsername",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationUsername, global::System.Convert.ToString);
            }
            if (content.Contains("ContainerConfigurationPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationPassword = (string) content.GetValueForProperty("ContainerConfigurationPassword",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.IGitHubActionConfigurationInternal)this).ContainerConfigurationPassword, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The GitHub action configuration.
    [System.ComponentModel.TypeConverter(typeof(GitHubActionConfigurationTypeConverter))]
    public partial interface IGitHubActionConfiguration

    {

    }
}