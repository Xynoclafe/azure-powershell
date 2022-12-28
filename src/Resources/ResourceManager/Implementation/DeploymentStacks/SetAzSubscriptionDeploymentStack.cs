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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections;
    using System.IO;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;

    [Cmdlet("Set", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeploymentStack))]
    public class SetAzSubscriptionDeploymentStack : DeploymentStacksCreateCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deploymentStack to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description for the stack.")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the stack.")]
        public string Location { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The ResourceGroup at which the deployment will be created. If none is specified, it will default to the " +
            "subscription level scope of the deployment stack.")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete both unmanaged Resources and ResourceGroups after deleting stack.")]
        public SwitchParameter DeleteAll { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack Resources after deleting stack.")]
        public SwitchParameter DeleteResources { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack ResourceGroups after deleting stack.")]
        public SwitchParameter DeleteResourceGroups { get; set; }

        // Not Yet Supported.
        /*[Parameter(Mandatory = false, HelpMessage = "Singal to delete unmanaged stack management groups after updating stack.")]
        public SwitchParameter DeleteManagementGroups { get; set; }*/

        [Parameter(Mandatory = false, HelpMessage = "Mode for DenySettings. Possible values include: 'denyDelete', 'denyWriteAndDelete', and 'none'.")]
        public PSDenySettingsMode DenySettingsMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of AAD principal IDs excluded from the lock. Up to 5 principals are permitted.")]
        public string[] DenySettingsExcludedPrincipals { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of role-based management operations that are excluded from " +
            "the denySettings. Up to 200 actions are permitted.")]
        public string[] DenySettingsExcludedActions { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Apply to child scopes.")]
        public SwitchParameter DenySettingsApplyToChildScopes { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation when overwriting an existing stack.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try 
            { 
                var shouldDeleteResources = (DeleteAll.ToBool() || DeleteResources.ToBool()) ? true : false;
                var shouldDeleteResourceGroups = (DeleteAll.ToBool() || DeleteResourceGroups.ToBool()) ? true : false;

                // construct deploymentScope if ResourceGroup was provided
                var deploymentScope = ResourceGroupName != null ? "/subscriptions/" + DeploymentStacksSdkClient.DeploymentStacksClient.SubscriptionId
                        + "/resourceGroups/" + ResourceGroupName : null;

                Action createOrUpdateAction = () =>
                {
                    var deploymentStack = DeploymentStacksSdkClient.SubscriptionCreateOrUpdateDeploymentStack(
                        deploymentStackName: Name,
                        location: Location,
                        templateUri: TemplateUri ?? TemplateFile,
                        templateSpec: TemplateSpecId,
                        templateObject: TemplateObject,
                        parameterUri: TemplateParameterUri,
                        parameterObject: this.GetTemplateParameterObject(this.TemplateParameterObject),
                        description: Description,
                        resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach",
                        resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach",
                        managementGroupsCleanupAction: "detach",
                        deploymentScope: deploymentScope,
                        denySettingsMode: DenySettingsMode.ToString(),
                        denySettingsExcludedPrincipals: DenySettingsExcludedPrincipals,
                        denySettingsExcludedActions: DenySettingsExcludedActions,
                        denySettingsApplyToChildScopes: DenySettingsApplyToChildScopes.IsPresent
                    );

                    WriteObject(deploymentStack);
                };

                if (!Force.IsPresent && DeploymentStacksSdkClient.GetSubscriptionDeploymentStack(
                        Name,
                        throwIfNotExists: false) == null)
                {
                    string confirmationMessage =
                        $"The DeploymentStack '{Name}' you're trying to modify does not exist in the current subscription scope. Do you want to create a new stack?";

                    ConfirmAction(
                        Force.IsPresent,
                        confirmationMessage,
                        "Update",
                        $"{Name}",
                        createOrUpdateAction
                    );
                }
                else
                {
                    if (!ShouldProcess($"{Name}", "Create"))
                    {
                        return; // Don't perform the actual creation/update action
                    }

                    createOrUpdateAction();
                }

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
