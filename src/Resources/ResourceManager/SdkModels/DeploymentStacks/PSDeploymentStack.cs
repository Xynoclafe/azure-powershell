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
        public string updateBehavior { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public SystemData systemData { get; set; }

        public string location { get; set; }

        public object template { get; set; }
        
        public DeploymentStacksTemplateLink templateLink { get; set; }

        public object parameters { get; set; }

        public DeploymentStacksParametersLink parametersLink { get; set; }

        public DeploymentStacksDebugSetting debugSetting { get; set; }

        public string provisioningState { get; set; }

        public string deploymentScope { get; set; }

        public string description { get; set; }

        public IList<ManagedResourceReference> managedResources { get; set; }

        public string deploymentId { get; set; }

        public LockSettings locks { get; set; }

        public ErrorResponse error { get; set; }

        public string snapshotId { get; set; }

        public PSDeploymentStack() { }

        internal PSDeploymentStack(DeploymentStack deploymentStack)
        {
            this.id = deploymentStack.Id;
            this.name = deploymentStack.Name;
            this.type = deploymentStack.Type;
            this.systemData = deploymentStack.SystemData;
            this.updateBehavior = deploymentStack.UpdateBehavior;
            this.location = deploymentStack.Location;
            this.template = deploymentStack.Template;
            this.templateLink = deploymentStack.TemplateLink;
            this.parameters = deploymentStack.Parameters;
            this.parametersLink = deploymentStack.ParametersLink;
            this.debugSetting = deploymentStack.DebugSetting;
            this.provisioningState = deploymentStack.ProvisioningState;
            this.deploymentScope = deploymentStack.DeploymentScope;
            this.description = deploymentStack.Description;
            this.managedResources = deploymentStack.ManagedResources;
            this.deploymentId = deploymentStack.DeploymentId;
            this.locks = deploymentStack.Locks;
            this.error = deploymentStack.Error;
            this.snapshotId = deploymentStack.SnapshotId;
        }

        internal static PSDeploymentStack FromAzureSDKDeploymentStack(DeploymentStack stack)
        {
            return stack != null
                ? new PSDeploymentStack(stack)
                : null;
        }
    }
}