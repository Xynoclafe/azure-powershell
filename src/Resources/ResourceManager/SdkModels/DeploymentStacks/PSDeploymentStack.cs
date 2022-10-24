using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStack
    {

        public string id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public DeploymentStackPropertiesSharedActionOnUnmanage actionOnUnmanage { get; set; }

        public SystemData systemData { get; set; }

        public string location { get; set; }

        public object template { get; set; }
        
        public DeploymentStacksTemplateLink templateLink { get; set; }

        public DenySettings denySettings { get; set; }

        public object parameters { get; set; }

        public DeploymentStacksParametersLink parametersLink { get; set; }

        public DeploymentStacksDebugSetting debugSetting { get; set; }

        public string provisioningState { get; set; }

        public string deploymentScope { get; set; }

        public string description { get; set; }

        public IList<ManagedResourceReference> resources { get; set; }

        public IList<ResourceReference> detachedResources { get; set; }

        public IList<ResourceReferenceExtended> failedResources { get; set; }

        public IList<ResourceReference> deletedResources { get; set; }

        public string deploymentId { get; set; }

        // public LockSettings locks { get; set; }

        public ErrorResponse error { get; set; }

        // public string snapshotId { get; set; }

        public PSDeploymentStack() { }

        internal PSDeploymentStack(DeploymentStack deploymentStack)
        {
            this.id = deploymentStack.Id;
            this.name = deploymentStack.Name;
            this.type = deploymentStack.Type;
            this.systemData = deploymentStack.SystemData;
            this.actionOnUnmanage = deploymentStack.ActionOnUnmanage;
            this.location = deploymentStack.Location;
            this.template = deploymentStack.Template;
            this.templateLink = deploymentStack.TemplateLink;
            this.parameters = deploymentStack.Parameters;
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
            // this.locks = deploymentStack.Locks;
            this.error = deploymentStack.Error;
        }

        internal static PSDeploymentStack FromAzureSDKDeploymentStack(DeploymentStack stack)
        {
            return stack != null
                ? new PSDeploymentStack(stack)
                : null;
        }
    }
}