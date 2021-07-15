using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet("Remove", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = RemoveAzSubscriptionDeploymentStack.RemoveByResourceIdParameterSetName), OutputType(typeof(bool))]
    public class RemoveAzSubscriptionDeploymentStack : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveByResourceIdParameterSetName = "RemoveByResourceId";
        internal const string RemoveByResourceNameParameterSetname = "RemoveByResourceName";

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceNameParameterSetname,
            HelpMessage = "The name of the deploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceIdParameterSetName,
            HelpMessage = "ResourceId of the stack to delete")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                Name = Name ?? ResourceIdUtility.GetResourceName(ResourceId);

                string confirmationMessage = $"Are you sure you want to remove DeploymentStack '{Name}'";

                ConfirmAction(
                    Force.IsPresent,
                    confirmationMessage,
                    "Deleting Deployment Stack ...",
                    Name,
                    () => DeploymentStacksSdkClient.DeleteSubscriptionDeploymentStack(Name)
                );

                WriteObject(true);
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion
    }
}
