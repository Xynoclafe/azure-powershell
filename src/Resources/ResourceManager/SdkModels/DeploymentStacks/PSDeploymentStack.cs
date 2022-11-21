﻿using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStack
    {

        public string id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string resourcesCleanupAction { get; set; }

        public string resourceGroupsCleanupAction { get; set; }

        public SystemData systemData { get; set; }

        public string location { get; set; }

        public DenySettings denySettings { get; set; }

        public Dictionary<string, DeploymentVariable> outputs { get; set; }

        public Dictionary<string, DeploymentVariable> parameters { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public DeploymentStacksParametersLink parametersLink { get; set; }

        public DeploymentStacksDebugSetting debugSetting { get; set; }

        public string provisioningState { get; set; }

        public string deploymentScope { get; set; }

        public string description { get; set; }

        public string duration { get; set; }

        public IList<ManagedResourceReference> resources { get; set; }

        public IList<ResourceReference> detachedResources { get; set; }

        public IList<ResourceReferenceExtended> failedResources { get; set; }

        public IList<ResourceReference> deletedResources { get; set; }

        public string deploymentId { get; set; }

        public ErrorResponse error { get; set; }

        // Deprecated.
        // public LockSettings locks { get; set; }
        // public string snapshotId { get; set; }
        // public object template { get; set; }
        // public DeploymentStacksTemplateLink templateLink { get; set; }

        public PSDeploymentStack() { }

        internal PSDeploymentStack(DeploymentStack deploymentStack)
        {
            this.id = deploymentStack.Id;
            this.name = deploymentStack.Name;
            this.type = deploymentStack.Type;
            this.systemData = deploymentStack.SystemData;
            this.resourcesCleanupAction = (deploymentStack.ActionOnUnmanage != null) ? deploymentStack.ActionOnUnmanage.Resources : null;
            this.resourceGroupsCleanupAction = (deploymentStack.ActionOnUnmanage != null) ? deploymentStack.ActionOnUnmanage.ResourceGroups : null;
            this.location = deploymentStack.Location;
            this.parametersLink = deploymentStack.ParametersLink;
            this.debugSetting = deploymentStack.DebugSetting;
            this.provisioningState = deploymentStack.ProvisioningState;
            this.deploymentScope = deploymentStack.DeploymentScope;
            this.description = deploymentStack.Description;
            this.resources = deploymentStack.Resources;
            this.denySettings = deploymentStack.DenySettings;
            this.detachedResources = deploymentStack.DetachedResources;
            this.deletedResources = deploymentStack.DeletedResources;
            this.failedResources = deploymentStack.FailedResources;
            this.deploymentId = deploymentStack.DeploymentId;
            this.duration = deploymentStack.Duration;
            this.error = deploymentStack.Error;
            this.parametersLink = deploymentStack.ParametersLink;
            this.Tags = deploymentStack.Tags;

            // Convert the raw outputs and parameters objects to dictionaries.
            this.parameters = deploymentStack.Parameters != null ? FormatMappedObject(deploymentStack.Parameters) : null;
            this.outputs = deploymentStack.Outputs != null ? FormatMappedObject(deploymentStack.Outputs) : null;

            // Deprecated.
            // this.snapshotId = deploymentStack.SnapshotId
            // this.locks = deploymentStack.Locks

        }

        internal static PSDeploymentStack FromAzureSDKDeploymentStack(DeploymentStack stack)
        {
            return stack != null
                ? new PSDeploymentStack(stack)
                : null;
        }

        internal static Dictionary<string, DeploymentVariable> FormatMappedObject(object rawObject)
        {
            Dictionary<string, DeploymentVariable> mappedDeploymentVariables = new Dictionary<string, DeploymentVariable>();

            // Extract DeploymentVariables from the passed in json object.
            var jObject = JObject.Parse(rawObject.ToString());
            foreach (var props in jObject.Properties())
            {
                mappedDeploymentVariables[props.Name] = ExtractDeploymentVariable(props.Value as JObject);
            }

            // Continue deserialize if the type of Value in DeploymentVariable is array.
            mappedDeploymentVariables?.Values.ForEach(dv =>
            { 
                if ("Array".Equals(dv?.Type))
                {
                    dv.Value = JsonConvert.DeserializeObject<object[]>(dv.Value.ToString());
                }
            });

            return mappedDeploymentVariables;
        }

        internal static DeploymentVariable ExtractDeploymentVariable(JObject jObject)
        {
            // Attempt to desialize the DeploymentVariable.
            DeploymentVariable dVar = JsonConvert.DeserializeObject<DeploymentVariable>(jObject.ToString());

            // If the type is null, attempt to infer the type.
            if (dVar.Type is null)
            {
                JToken value; 
                var hasValue = jObject.TryGetValue("value", out value);
                
                // Value was there, we can infer the type.
                if (hasValue)
                {
                    // interpret type and find matching ARM type
                    switch (value.Type)
                    {
                        case JTokenType.String:
                            dVar.Type = "string";
                            break;
                        case JTokenType.Array:
                            dVar.Type = "array";
                            break;
                        case JTokenType.Integer:
                            dVar.Type = "integer";
                            break;
                        case JTokenType.Boolean:
                            dVar.Type = "boolean";
                            break;
                        default:
                            dVar.Type = "object";
                            break;
                    }
                }
            }
            
            return dVar;
        }
    }
}