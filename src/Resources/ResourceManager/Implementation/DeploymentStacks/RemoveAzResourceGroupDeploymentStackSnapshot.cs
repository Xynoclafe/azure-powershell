using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet("Remove", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStackSnapshot",
        SupportsShouldProcess = true, DefaultParameterSetName = RemoveAzResourceGroupDeploymentStackSnapshot.RemoveByResourceIdParameterSetName), OutputType(typeof(bool))]
    public class RemoveAzResourceGroupDeploymentStackSnapshot : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveByResourceIdParameterSetName = "RemoveByResourceId";
        internal const string RemoveByResourceNameParameterSetname = "RemoveByResourceName";

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceNameParameterSetname,
            HelpMessage = "The name of the deploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceNameParameterSetname,
            HelpMessage = "The name of the deploymentStack snapshot to delete")]
        [ValidateNotNullOrEmpty]
        public string SnapshotName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceNameParameterSetname,
        HelpMessage = "The name of the Resource Group with the stack to delete")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

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
                ResourceIdentifier resourceIdentifier = (ResourceId != null)
                    ? new ResourceIdentifier(ResourceId)
                    : null;

                ResourceGroupName = ResourceGroupName ?? resourceIdentifier.ResourceGroupName;
                Name = Name ?? ResourceIdUtility.GetResourceName(ResourceId);

                if(ResourceId != null && SnapshotName == null)
                {
                    Name = Name.Split('/')[0];
                    SnapshotName = resourceIdentifier.ResourceName;
                }

                string confirmationMessage = $"Are you sure you want to remove snapshot '{SnapshotName}' of DeploymentStack '{Name}'";

                ConfirmAction(
                    Force.IsPresent,
                    confirmationMessage,
                    "Deleting Deployment Stack Snapshot...",
                    Name,
                    () => DeploymentStacksSdkClient.DeleteResourceGroupDeploymentStackSnapshot(ResourceGroupName, Name, SnapshotName)
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
