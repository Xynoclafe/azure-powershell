using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public class DeploymentStacksCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Deployment stacks client instance field
        /// </summary>
        private DeploymentStacksSdkClient deploymentStacksSdkClient;

        /// <summary>
        /// Gets or sets the deployment stacks sdk client
        /// </summary>
        public DeploymentStacksSdkClient DeploymentStacksSdkClient
        {
            get
            {
                if (this.deploymentStacksSdkClient == null)
                {
                    this.deploymentStacksSdkClient = new DeploymentStacksSdkClient(DefaultContext);
                }
                return this.deploymentStacksSdkClient;
            }

            set
            {
                this.deploymentStacksSdkClient = value;
            }
        }

        protected Hashtable GetParameterObject(string parameterFile)
        {
            var parameters = new Hashtable();
            string templateParameterFilePath = this.ResolvePath(parameterFile);
            if (parameterFile != null && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                var parametersFromFile = TemplateUtility.ParseTemplateParameterFileContents(templateParameterFilePath);
                parametersFromFile.ForEach(dp =>
                {
                    var parameter = new Hashtable();
                    if (dp.Value.Value != null)
                    {
                        parameter.Add("value", dp.Value.Value);
                    }
                    if (dp.Value.Reference != null)
                    {
                        parameter.Add("reference", dp.Value.Reference);
                    }

                    parameters[dp.Key] = parameter;
                });
            }
            return parameters;
        }
    }
}
