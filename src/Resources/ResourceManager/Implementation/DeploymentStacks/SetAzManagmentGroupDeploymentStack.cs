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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using System.Text;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    [Cmdlet("Set", Common.AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeploymentStack))]
    public class SetAzManagementGroupDeploymentStack : DeploymentStacksCmdletBase
    {

        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ParameterlessTemplateFileParameterSetName = "ByTemplateFileWithNoParameters";
        internal const string ParameterlessTemplateUriParameterSetName = "ByTemplateUriWithNoParameters";
        internal const string ParameterlessTemplateSpecParameterSetName = "ByTemplateSpecWithNoParameters";

        internal const string ParameterFileTemplateFileParameterSetName = "ByTemplateFileWithParameterFile";
        internal const string ParameterFileTemplateUriParameterSetName = "ByTemplateUriWithParameterFile";
        internal const string ParameterFileTemplateSpecParameterSetName = "ByTemplateSpecWithParameterFile";

        internal const string ParameterUriTemplateFileParameterSetName = "ByTemplateFileWithParameterUri";
        internal const string ParameterUriTemplateUriParameterSetName = "ByTemplateUriWithParameterUri";
        internal const string ParameterUriTemplateSpecParameterSetName = "ByTemplateSpecWithParameterUri";

        internal const string ParameterObjectTemplateFileParameterSetName = "ByTemplateFileWithParameterObject";
        internal const string ParameterObjectTemplateUriParameterSetName = "ByTemplateUriWithParameterObject";
        internal const string ParameterObjectTemplateSpecParameterSetName = "ByTemplateSpecWithParameterObject";

        [Alias("StackName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deploymentStack to create")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ManagementGroupId")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of the management group that the deploymentStack will be deployed into")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The subscription Id at which the deployment should be created.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentSubscriptionId { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the stack")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 4, ParameterSetName = ParameterFileTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterObjectTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterlessTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        public string TemplateFile { get; set; }

        [Parameter(Position = 4, ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterObjectTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterlessTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        public string TemplateUri { get; set; }

        [Parameter(Position = 4, ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterObjectTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        [Parameter(Position = 4, ParameterSetName = ParameterlessTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        public string TemplateSpecId { get; set; }

        [Parameter(Position = 5, ParameterSetName = ParameterFileTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        [Parameter(Position = 5, ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        [Parameter(Position = 5, ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        public string TemplateParameterFile { get; set; }

        [Parameter(Position = 5, ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        [Parameter(Position = 5, ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        [Parameter(Position = 5, ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        public string TemplateParameterUri { get; set; }

        [Parameter(Position = 5, ParameterSetName = ParameterObjectTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(Position = 5, ParameterSetName = ParameterObjectTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(Position = 5, ParameterSetName = ParameterObjectTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public Hashtable TemplateParameterObject { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description for the stack")]
        public string Description { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "List of role-based management operations that are excluded from " +
            "the denySettings. Up to 200 actions are permitted.")]
        public string[] DenySettingsExcludedDataActions { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Apply to child scopes.")]
        public SwitchParameter DenySettingsApplyToChildScopes { get; set; }

        [Parameter(Mandatory = false,
        HelpMessage = "Do not ask for confirmation when overwriting an existing stack.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try
            {
                Hashtable parameters = new Hashtable();
                string filePath = "";
                switch (ParameterSetName)
                {
                    case ParameterlessTemplateFileParameterSetName:
                    case ParameterUriTemplateFileParameterSetName:
                        filePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        filePath = ResolveBicepFile(filePath);
                        TemplateUri = filePath;
                        break;
                    case ParameterFileTemplateSpecParameterSetName:
                    case ParameterFileTemplateUriParameterSetName:
                        parameters = this.GetParameterObject(TemplateParameterFile);
                        break;
                    case ParameterFileTemplateFileParameterSetName:
                        filePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        filePath = ResolveBicepFile(filePath);
                        parameters = this.GetParameterObject(TemplateParameterFile);
                        TemplateUri = filePath;
                        break;
                    case ParameterObjectTemplateFileParameterSetName:
                        filePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        filePath = ResolveBicepFile(filePath);
                        TemplateUri = filePath;
                        parameters = GetTemplateParameterObject(TemplateParameterObject);
                        break;
                    case ParameterObjectTemplateSpecParameterSetName:
                    case ParameterObjectTemplateUriParameterSetName:
                        parameters = GetTemplateParameterObject(TemplateParameterObject);
                        break;
                }

                var shouldDeleteResources = (DeleteAll.ToBool() || DeleteResources.ToBool()) ? true : false;
                var shouldDeleteResourceGroups = (DeleteAll.ToBool() || DeleteResourceGroups.ToBool()) ? true : false;

                Action createOrUpdateAction = () =>
                {
                    var deploymentStack = DeploymentStacksSdkClient.ManagementGroupCreateOrUpdateDeploymentStack(
                            Name,
                            ManagementGroupId,
                            Location,
                            TemplateUri,
                            TemplateSpecId,
                            TemplateParameterUri,
                            parameters,
                            Description,
                            resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach",
                            resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach",
                            managementGroupsCleanupAction: "detach",
                            DeploymentSubscriptionId,
                            DenySettingsMode.ToString(),
                            DenySettingsExcludedPrincipals,
                            DenySettingsExcludedActions,
                            DenySettingsApplyToChildScopes.IsPresent
                        );

                    WriteObject(deploymentStack);
                };

                if (!Force.IsPresent && DeploymentStacksSdkClient.GetManagementGroupDeploymentStack(
                        Name,
                        ManagementGroupId,
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
