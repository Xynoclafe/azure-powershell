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

    [Cmdlet("Get", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStack",
        DefaultParameterSetName = GetAzSubscriptionDeploymentStack.ListParameterSetname), OutputType(typeof(PSDeploymentStack))]
    public class GetAzSubscriptionDeploymentStack : DeploymentStacksCmdletBase
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
