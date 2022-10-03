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
    using Microsoft.Azure.Management.ResourceManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Text;

    [Cmdlet("Remove", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = RemoveAzResourceGroupDeploymentStack.RemoveByNameAndResourceGroupNameParameterSetName), OutputType(typeof(bool))]
    public class RemoveAzResourceGroupDeploymentStack : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveByResourceIdParameterSetName = "RemoveByResourceId";
        internal const string RemoveByNameAndResourceGroupNameParameterSetName = "RemoveByNameAndResourceGroupName";

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByNameAndResourceGroupNameParameterSetName,
            HelpMessage = "The name of the deploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByNameAndResourceGroupNameParameterSetName,
        HelpMessage = "The name of the Resource Group with the stack to delete")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceIdParameterSetName,
            HelpMessage = "ResourceId of the stack to delete")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete both unmanaged Resources and ResourceGroups after updating stack.")]
        public SwitchParameter DeleteAll { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack Resources after updating stack.")]
        public SwitchParameter DeleteResources { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack ResourceGroups after updating stack.")]
        public SwitchParameter DeleteResourceGroups { get; set; }

        // Not Yet Supported.
        /*[Parameter(Mandatory = false, HelpMessage = "Singal to delete unmanaged stack management groups after updating stack.")]
        public SwitchParameter DeleteManagementGroups { get; set; }*/

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try
            {
                var shouldDeleteResources = (DeleteAll.ToBool() || DeleteResources.ToBool()) ? true : false;
                var shouldDeleteResourceGroups = (DeleteAll.ToBool() || DeleteResourceGroups.ToBool()) ? true : false;

                ResourceIdentifier resourceIdentifier = (ResourceId != null)
                    ? new ResourceIdentifier(ResourceId)
                    : null;

                ResourceGroupName = ResourceGroupName ?? resourceIdentifier.ResourceGroupName;
                Name = Name ?? ResourceIdUtility.GetResourceName(ResourceId);

                string confirmationMessage = $"Are you sure you want to remove DeploymentStack '{Name}'";

                ConfirmAction(
                    Force.IsPresent,
                    confirmationMessage,
                    "Deleting Deployment Stack ...",
                    Name,
                    () => DeploymentStacksSdkClient.DeleteResourceGroupDeploymentStack(
                        ResourceGroupName, 
                        Name, 
                        resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach", 
                        resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach"
                    )
                );

                WriteObject(true);
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Message + " : " + dex.Body.Error.Code + " : " + dex.Body.Error.Message);
                else
                    WriteExceptionError(ex);
            }
        }

        #endregion
    }
}
