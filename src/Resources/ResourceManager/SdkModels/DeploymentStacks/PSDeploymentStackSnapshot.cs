using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStackSnapshot
    {
        public string updateBehavior { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public SystemData systemData { get; set; }

        public object template { get; set; }

        public DeploymentStacksTemplateLink templateLink { get; set; }

        public object parameters { get; set; }

        public DeploymentStacksParametersLink parametersLink { get; set; }

        public DeploymentStacksDebugSetting debugSetting { get; set; }

        public string provisioningState { get; set; }

        public string deploymentScope { get; set; }

        public string description { get; set; }

        public string deploymentId { get; set; }

        public LockSettings locks { get; set; }

        public ErrorResponse error { get; set; }

        public IList<ManagedResourceReference> managedResources { get; set; }

        public IList<ResourceReference> detatchedResources { get; set; }

        public IList<ResourceReference> deletedResources { get; set; }

        public object failedResources { get; set; }

        public PSDeploymentStackSnapshot() { }

        internal PSDeploymentStackSnapshot(DeploymentStackSnapshot deploymentStackSnapshot)
        {
            this.id = deploymentStackSnapshot.Id;
            this.name = deploymentStackSnapshot.Name;
            this.type = deploymentStackSnapshot.Type;
            this.systemData = deploymentStackSnapshot.SystemData;
            this.updateBehavior = deploymentStackSnapshot.UpdateBehavior;
            this.template = deploymentStackSnapshot.Template;
            this.templateLink = deploymentStackSnapshot.TemplateLink;
            this.parameters = deploymentStackSnapshot.Parameters;
            this.parametersLink = deploymentStackSnapshot.ParametersLink;
            this.debugSetting = deploymentStackSnapshot.DebugSetting;
            this.provisioningState = deploymentStackSnapshot.ProvisioningState;
            this.deploymentScope = deploymentStackSnapshot.DeploymentScope;
            this.description = deploymentStackSnapshot.DeploymentScope;
            this.deploymentId = deploymentStackSnapshot.DeploymentId;
            this.locks = deploymentStackSnapshot.Locks;
            this.error = deploymentStackSnapshot.Error;
            this.managedResources = deploymentStackSnapshot.ManagedResources;
            this.detatchedResources = deploymentStackSnapshot.DetachedResources;
            this.deletedResources = deploymentStackSnapshot.DeletedResources;
            this.failedResources = deploymentStackSnapshot.FailedResources;
        }

        internal static PSDeploymentStackSnapshot FromAzureSDKDeploymentStack(DeploymentStackSnapshot stackSnapshot)
        {
            return stackSnapshot != null
                ? new PSDeploymentStackSnapshot(stackSnapshot)
                : null;
        }
    }
}
