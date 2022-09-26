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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Management.Automation;

    [Cmdlet("Export", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStackTemplate",
        DefaultParameterSetName = ExportAzResourceGroupDeploymentStackTemplate.ExportByDeploymentStackName)]
    public class ExportAzResourceGroupDeploymentStackTemplate : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ExportByResourceIdParameterSetName = "ExportDeploymentStackTemplateByResourceId";
        internal const string ExportByDeploymentStackName = "ExportDeploymentStackTemplateByStackName";

        [Alias("Id")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByResourceIdParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByDeploymentStackName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("StackName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByDeploymentStackName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The path to the file where the deployment stack template will be output to.")]
        [ValidateNotNullOrEmpty]
        public string OutputFile { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try
            {
                JObject template;
                switch (ParameterSetName)
                {
                    case ExportByResourceIdParameterSetName:
                        template = DeploymentStacksSdkClient.ExportResourceGroupDeploymentStack(ResourceIdUtility.GetResourceGroupName(ResourceId), ResourceIdUtility.GetDeploymentName(ResourceId));
                        break;
                    case ExportByDeploymentStackName:
                        template = DeploymentStacksSdkClient.ExportResourceGroupDeploymentStack(ResourceGroupName, Name);
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }


                // Ensure our output path is resolved based on the current powershell working
                // directory instead of the current process directory:
                OutputFile = ResolveUserPath(OutputFile);

                string path = FileUtility.SaveTemplateFile(
                    templateName: this.Name,
                    contents: template.ToString(),
                    outputPath: OutputFile,
                    overwrite: true,
                    shouldContinue: ShouldContinue);

                WriteObject(PowerShellUtilities.ConstructPSObject(null, "Path", OutputFile));
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion
    }
}
