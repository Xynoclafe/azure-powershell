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

    [Cmdlet("Set", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = SetAzResourceGroupDeploymentStack.ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeploymentStack))]
    public class SetAzResourceGroupDeploymentStack : DeploymentStacksCmdletBase
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

        [Flags]
        public enum updateBehvaiorEnum {detachResources,purgeResources}

        [Alias("StackName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deploymentStack to create")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the ResourceGroup to be used")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ParameterFileTemplateFileParameterSetName, 
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterObjectTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterlessTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        public string TemplateFile { get; set; }

        [Parameter(Position = 2, ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterObjectTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterlessTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        public string TemplateUri { get; set; }

        [Parameter(Position = 2, ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterObjectTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterlessTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        public string TemplateSpecId { get; set; }

        [Parameter(Position = 3, ParameterSetName = ParameterFileTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        [Parameter(Position = 3, ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        [Parameter(Position = 3, ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        public string TemplateParameterFile { get; set; }

        [Parameter(Position = 3, ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        [Parameter(Position = 3, ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        [Parameter(Position = 3, ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        public string TemplateParameterUri { get; set; }

        [Parameter(ParameterSetName = ParameterObjectTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public Hashtable TemplateParameterObject { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description for the stack")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "Update behavior for the stack. Value can be detachResources or failedResources.")]
        public updateBehvaiorEnum UpdateBehavior { get; set; }

        [Parameter(Mandatory = false,
        HelpMessage = "Do not ask for confirmation when overwriting an existing stack.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                Hashtable parameters = new Hashtable();
                switch (ParameterSetName)
                {
                    case ParameterlessTemplateFileParameterSetName:
                    case ParameterUriTemplateFileParameterSetName:
                        string filePath = this.TryResolvePath(TemplateFile);
                        if(!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        TemplateUri = filePath;
                        break;
                    case ParameterFileTemplateSpecParameterSetName:
                    case ParameterFileTemplateUriParameterSetName:
                        parameters = this.GetParameterObject(TemplateParameterFile);
                        break;
                    case ParameterFileTemplateFileParameterSetName:
                        string templatePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(templatePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        parameters = this.GetParameterObject(TemplateParameterFile);
                        TemplateUri = templatePath;
                        break;
                    case ParameterObjectTemplateFileParameterSetName:
                        filePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        TemplateUri = filePath;
                        parameters = GetTemplateParameterObject(TemplateParameterObject);
                        break;
                    case ParameterObjectTemplateSpecParameterSetName:
                    case ParameterObjectTemplateUriParameterSetName:
                        parameters = GetTemplateParameterObject(TemplateParameterObject);
                        break;
                }

                Action createOrUpdateAction = () =>
                    {
                    var deploymentStack = DeploymentStacksSdkClient.ResourceGroupCreateOrUpdateDeploymentStack(
                    Name,
                    ResourceGroupName,
                    TemplateUri,
                    TemplateSpecId,
                    TemplateParameterUri,
                    parameters,
                    Description,
                    (UpdateBehavior.ToString() == "detachResources") ? "detachResources" : "purgeResources"
                    );
                    WriteObject(deploymentStack);
                };

                if (!Force.IsPresent && DeploymentStacksSdkClient.GetResourceGroupDeploymentStack(
                        ResourceGroupName,
                        Name,
                        throwIfNotExists: false) == null)
                {
                    string confirmationMessage =
                        $"The DeploymentStack '{Name}' you're trying to modify does not exist in '{ResourceGroupName}'. Do you want to create a new stack?";

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
