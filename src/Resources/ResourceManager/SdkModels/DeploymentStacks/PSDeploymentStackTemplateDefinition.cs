using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStackTemplateDefinition
    {
        public string Template { get; set; }

        //public PSDeploymentStackTemplateLink TemplateLink { get; set; }
        public DeploymentStacksTemplateLink TemplateLink { get; set; }

        internal PSDeploymentStackTemplateDefinition(object template, DeploymentStacksTemplateLink link)
        {
            if (template != null)
            {
                Template = template.ToString();
            }
            //TemplateLink = new PSDeploymentStackTemplateLink(link);
            TemplateLink = link;
        }
    }
}
