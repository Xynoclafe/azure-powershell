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

    [Cmdlet("Remove", Common.AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = RemoveAzManagementGroupDeploymentStack.RemoveByResourceIdParameterSetName), OutputType(typeof(bool))]
    public class RemoveAzManagementGroupDeploymentStack : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveByResourceIdParameterSetName = "RemoveByResourceId";
        internal const string RemoveByResourceNameParameterSetname = "RemoveByResourceName";

        [Alias("StackName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceNameParameterSetname,
            HelpMessage = "The name of the DeploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("Id")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceIdParameterSetName,
            HelpMessage = "ResourceId of the DeploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The id of the ManagementGroup where the DeploymentStack is being deleted")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

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

                // resolve Name and ManagementGroupId if ResourceId was provided
                ManagementGroupId = ManagementGroupId ?? ResourceIdUtility.GetManagementGroupId(ResourceId);
                Name = Name ?? ResourceIdUtility.GetDeploymentName(ResourceId);

                // failed resolving the resource id
                if (Name == null || ManagementGroupId == null)
                {
                    throw new PSArgumentException($"Provided Id '{ResourceId}' is not in correct form.");
                }

                string confirmationMessage = $"Are you sure you want to remove DeploymentStack '{Name}'";

                ConfirmAction(
                    Force.IsPresent,
                    confirmationMessage,
                    "Deleting Deployment Stack ...",
                    Name,
                    () =>
                    {
                        DeploymentStacksSdkClient.DeleteManagementGroupDeploymentStack(
                            Name,
                            ManagementGroupId,
                            resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach",
                            resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach"
                        );
                        WriteObject(true);
                    }
                );
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Message + " : " + dex.Body.Error.Code + " : " + dex.Body.Error.Message);
                else
                    WriteObject(false);
                    WriteExceptionError(ex);
            }
        }

        #endregion
    }
}
