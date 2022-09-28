using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks
{
    public class PSDeploymentStackTemplateDefinition
    {
        public object Template { get; set; }

        public DeploymentStacksTemplateLink TemplateLink { get; set; }

        internal PSDeploymentStackTemplateDefinition(DeploymentStackTemplateDefinition deploymentStackTemplateDefinition)
        {
            Template = deploymentStackTemplateDefinition.Template;
            TemplateLink = deploymentStackTemplateDefinition.TemplateLink; 
        }

    }
}
