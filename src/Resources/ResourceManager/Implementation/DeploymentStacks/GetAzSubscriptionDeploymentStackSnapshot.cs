﻿using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet("Get", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStackSnapshot",
        DefaultParameterSetName = GetAzSubscriptionDeploymentStackSnapshot.ListParameterSetname), OutputType(typeof(PSDeploymentStackSnapshot))]
    class GetAzSubscriptionDeploymentStackSnapshot : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string GetByStackNameParameterSetname = "GetIndividualDeploymentStack";
        internal const string GetByResourceIdParameterSetName = "GetDeploymentStackByResourceId";
        internal const string ListParameterSetname = "ListDeploymentStacks";

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByStackNameParameterSetname,
            HelpMessage = "The name of the deploymentStack to get")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ListParameterSetname,
            HelpMessage = "The name of the deploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByStackNameParameterSetname,
            HelpMessage = "The name of the deploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string SnapshotName { get; set; }

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
                        WriteObject(DeploymentStacksSdkClient.GetSubscriptionDeploymentStackSnapshot(Name, SnapshotName));
                        break;
                    case GetByResourceIdParameterSetName:
                        ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ResourceId);
                        Name = ResourceIdUtility.GetResourceName(ResourceId).Split('/')[0];
                        SnapshotName = resourceIdentifier.ResourceName;
                        WriteObject(DeploymentStacksSdkClient.GetSubscriptionDeploymentStackSnapshot(Name, SnapshotName));
                        break;
                    case ListParameterSetname:
                        WriteObject(DeploymentStacksSdkClient.ListSubscriptionDeploymentStackSnapshot(Name));
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
