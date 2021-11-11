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

    [Cmdlet("Remove", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStackSnapshot",
        SupportsShouldProcess = true, DefaultParameterSetName = RemoveAzSubscriptionDeploymentStackSnapshot.RemoveByResourceIdParameterSetName), OutputType(typeof(bool))]
    public class RemoveAzSubscriptionDeploymentStackSnapshot : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveByResourceIdParameterSetName = "RemoveByResourceId";
        internal const string RemoveByResourceNameParameterSetname = "RemoveByResourceName";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceNameParameterSetname,
            HelpMessage = "The name of the deploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string StackName { get; set; }

        [Alias("SnapshotName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceNameParameterSetname,
            HelpMessage = "The name of the deploymentStack snapshot to delete")]
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

        protected override void OnProcessRecord()
        {
            try
            {
                ResourceIdentifier resourceIdentifier = (ResourceId != null)
                    ? new ResourceIdentifier(ResourceId)
                    : null;

                StackName = StackName ?? ResourceIdUtility.GetResourceName(ResourceId);

                if (ResourceId != null && Name == null)
                {
                    StackName = StackName.Split('/')[0];
                    Name = resourceIdentifier.ResourceName;
                }

                string confirmationMessage = $"Are you sure you want to remove snapshot '{Name}' of DeploymentStack '{StackName}'";

                ConfirmAction(
                    Force.IsPresent,
                    confirmationMessage,
                    "Deleting Deployment Stack Snapshot...",
                    Name,
                    () => DeploymentStacksSdkClient.DeleteSubscriptionDeploymentStackSnapshot(StackName, Name)
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
