﻿// ----------------------------------------------------------------------------------
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

    [Cmdlet("Get", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStack",
        DefaultParameterSetName = GetAzResourceGroupDeploymentStack.ListParameterSetName), OutputType(typeof(PSDeploymentStack))]
    public class GetAzResourceGroupDeploymentStack : DeploymentStacksCmdletBase
    {
        internal const string ListParameterSetName = "ListDeploymentStacks";

        internal const string GetByResourceIdParameterSetName = "GetDeploymentStackByResourceId";
        internal const string GetByResourceGroupNameParameterSetName = "GetDeploymentStacksByResourceGroupName";
        internal const string GetByDeploymentStackName = "GetDeploymentStackByStackName";

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceGroupNameParameterSetName)]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByDeploymentStackName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByDeploymentStackName)]
        [ValidateNotNullOrEmpty]
        public string StackName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetByResourceIdParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.GetResourceGroupDeploymentStack(ResourceIdUtility.GetResourceGroupName(ResourceId), ResourceIdUtility.GetDeploymentName(ResourceId)));
                        break;
                    case GetByResourceGroupNameParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.ListResourceGroupDeploymentStack(ResourceGroupName));
                        break;
                    case GetByDeploymentStackName:
                        WriteObject(DeploymentStacksSdkClient.GetResourceGroupDeploymentStack(ResourceGroupName, StackName));
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




    }
}
