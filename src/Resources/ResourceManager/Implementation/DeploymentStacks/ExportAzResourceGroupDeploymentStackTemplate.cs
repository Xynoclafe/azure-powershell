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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Management.Automation;

    [Cmdlet("Export", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStackTemplate",
        DefaultParameterSetName = ExportByNameAndResourceGroupNameParameterSetName), OutputType(typeof(PSDeploymentStackTemplateDefinition))]
    public class ExportAzResourceGroupDeploymentStackTemplate : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ExportByResourceIdParameterSetName = "ExportByResourceId";
        internal const string ExportByNameAndResourceGroupNameParameterSetName = "ExportByNameAndResourceGroupName";

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByResourceIdParameterSetName,
             HelpMessage = "ResourceId of the DeploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByNameAndResourceGroupNameParameterSetName,
             HelpMessage = "The name of the ResourceGroup where the DeploymentStack is deployed")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("StackName")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByNameAndResourceGroupNameParameterSetName,
             HelpMessage = "The name of the DeploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case ExportByResourceIdParameterSetName:
                        ResourceGroupName = ResourceIdUtility.GetResourceGroupName(ResourceId);
                        Name = ResourceIdUtility.GetDeploymentName(ResourceId);
                        if (ResourceGroupName == null || Name == null)
                        {
                            throw new PSArgumentException($"Provided Id '{ResourceId}' is not in correct form. Should be in form " + 
                                "/subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>");
                        }
                        WriteObject(DeploymentStacksSdkClient.ExportResourceGroupDeploymentStack(ResourceGroupName, Name), true);
                        break;
                    case ExportByNameAndResourceGroupNameParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.ExportResourceGroupDeploymentStack(ResourceGroupName, Name), true);
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
