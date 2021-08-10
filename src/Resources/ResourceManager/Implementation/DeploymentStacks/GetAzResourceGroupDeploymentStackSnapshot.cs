// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Text;

    [Cmdlet("Get", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStackSnapshot",
        DefaultParameterSetName = GetAzResourceGroupDeploymentStackSnapshot.ListByResourceGroupNameParameterSetName), OutputType(typeof(PSDeploymentStackSnapshot))]
    public class GetAzResourceGroupDeploymentStackSnapshot : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string GetByResourceIdParameterSetName = "GetDeploymentStackByResourceId";
        internal const string ListByResourceGroupNameParameterSetName = "ListDeploymentStacksByResourceGroupName";
        internal const string GetByDeploymentStackName = "GetDeploymentStackByStackName";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ListByResourceGroupNameParameterSetName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByDeploymentStackName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByDeploymentStackName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ListByResourceGroupNameParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByDeploymentStackName)]
        [ValidateNotNullOrEmpty]
        public string SnapshotName { get; set; }

        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetByResourceIdParameterSetName:
                        ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ResourceId);
                        Name = ResourceIdUtility.GetResourceName(ResourceId).Split('/')[0];
                        WriteObject(ResourceIdUtility.GetResourceName(ResourceId));
                        WriteObject(Name);
                        SnapshotName = resourceIdentifier.ResourceName;
                        WriteObject(DeploymentStacksSdkClient.GetResourceGroupDeploymentStackSnapshot(ResourceIdUtility.GetResourceGroupName(ResourceId), Name, SnapshotName));
                        break;
                    case ListByResourceGroupNameParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.ListResourceGroupDeploymentStackSnapshot(ResourceGroupName, Name));
                        break;
                    case GetByDeploymentStackName:
                        WriteObject(DeploymentStacksSdkClient.GetResourceGroupDeploymentStackSnapshot(ResourceGroupName, Name, SnapshotName));
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
