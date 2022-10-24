using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStackTemplateDefinition
    {
        public string Template { get; set; }

        public DeploymentStacksTemplateLink TemplateLink { get; set; }

        internal PSDeploymentStackTemplateDefinition(string template, DeploymentStacksTemplateLink link)
        {
            Template = template;
            TemplateLink = link; 
        }

    }
}
