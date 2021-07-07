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
        DefaultParameterSetName = GetAzResourceGroupDeploymentStackSnapshot.ListDeploymentStack), OutputType(typeof(PSDeploymentStackSnapshot))]
    public class GetAzResourceGroupDeploymentStackSnapshot : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ListDeploymentStack = "ListDeploymentStack";

        internal const string GetByResourceIdParameterSetName = "GetDeploymentStackByResourceId";
        internal const string GetByResourceGroupNameParameterSetName = "GetDeploymentStacksByResourceGroupName";
        internal const string GetByDeploymentStackName = "GetDeploymentStackByStackName";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceGroupNameParameterSetName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByDeploymentStackName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }


        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByDeploymentStackName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceGroupNameParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string StackName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSetName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByDeploymentStackName)]
        [ValidateNotNullOrEmpty]
        public string SnapshotName { get; set; }


        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetByResourceIdParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.GetResourceGroupDeploymentStackSnapshot(ResourceIdUtility.GetResourceGroupName(ResourceId), ResourceIdUtility.GetDeploymentName(ResourceId), SnapshotName));
                        break;
                    case GetByResourceGroupNameParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.ListResourceGroupDeploymentStackSnapshot(ResourceGroupName, StackName));
                        break;
                    case GetByDeploymentStackName:
                        WriteObject(DeploymentStacksSdkClient.GetResourceGroupDeploymentStackSnapshot(ResourceGroupName, StackName, SnapshotName));
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
