using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet("Get", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStack",
        DefaultParameterSetName = GetAzSubscriptionDeploymentStack.ListParameterSetname), OutputType(typeof(PSDeploymentStack))]
    [Alias("Get-AzDeploymentStack")]
    class GetAzSubscriptionDeploymentStack : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string GetByStackNameParameterSetname = "GetIndividualDeploymentStack";
        internal const string GetByResourceIdParameterSetName = "GetDeploymentStackByResourceId";
        internal const string ListParameterSetname = "ListDeploymentStacks";

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByStackNameParameterSetname,
            HelpMessage = "The name of the deploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSetName,
            HelpMessage = "ResourceId of the stack to get")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetByStackNameParameterSetname:
                        WriteObject(DeploymentStacksSdkClient.GetSubscriptionDeploymentStack(Name));
                        break;
                    case GetByResourceIdParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.GetSubscriptionDeploymentStack(ResourceIdUtility.GetResourceName(ResourceId)));
                        break;
                    case ListParameterSetname:
                        WriteObject(DeploymentStacksSdkClient.ListSubscriptionDeploymentStack());
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion
    }
}
