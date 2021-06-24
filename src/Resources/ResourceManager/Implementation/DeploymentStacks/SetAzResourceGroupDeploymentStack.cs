﻿namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
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
        [Parameter(Position = 2, ParameterSetName = ParameterlessTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack")]
        public string TemplateFile { get; set; }

        [Parameter(Position = 2, ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterlessTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack")]
        public string TemplateUri { get; set; }

        [Parameter(Position = 2, ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        [Parameter(Position = 2, ParameterSetName = ParameterlessTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack")]
        public string TemplateSpec { get; set; }

        [Parameter(Position = 3, ParameterSetName = ParameterFileTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        [Parameter(Position = 3, ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        [Parameter(Position = 3, ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template")]
        public string ParameterFile { get; set; }

        [Parameter(Position = 3, ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        [Parameter(Position = 3, ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        [Parameter(Position = 3, ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template")]
        public string ParameterUri { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description for the stack")]
        public string Description { get; set; }

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
                        break;
                    case ParameterFileTemplateSpecParameterSetName:
                    case ParameterFileTemplateUriParameterSetName:
                        parameters = this.GetParameterObject(ParameterFile);
                        break;
                    case ParameterFileTemplateFileParameterSetName:
                        string templatePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(templatePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        parameters = this.GetParameterObject(ParameterFile);
                        break;
                }

                var deploymentStack = DeploymentStacksSdkClient.ResourceGroupCreateOrUpdateDeploymentStack(
                    Name,
                    ResourceGroupName,
                    TemplateUri,
                    TemplateSpec,
                    ParameterUri,
                    parameters,
                    Description
                    );
                WriteObject(deploymentStack);

            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion

    }
}
