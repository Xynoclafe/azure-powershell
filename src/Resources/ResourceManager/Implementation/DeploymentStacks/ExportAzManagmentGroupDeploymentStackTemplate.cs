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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Management.Automation;

    [Cmdlet("Export", Common.AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentStackTemplate",
        DefaultParameterSetName = ExportAzManagementGroupDeploymentStackTemplate.ExportByName)]
    public class ExportAzManagementGroupDeploymentStackTemplate : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ExportByResourceId = "ExportByResourceId";
        internal const string ExportByName = "ExportByName";

        [Alias("Id")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("StackName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ManagementGroupId")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByName)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

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
                    case ExportByResourceId:
                        template = DeploymentStacksSdkClient.ExportManagementGroupDeploymentStack(ResourceIdUtility.GetManagementGroupId(ResourceId), ResourceIdUtility.GetDeploymentName(ResourceId));
                        break;
                    case ExportByName:
                        template = DeploymentStacksSdkClient.ExportManagementGroupDeploymentStack(ManagementGroupId, Name);
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
                    outputPath: this.OutputFile,
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
