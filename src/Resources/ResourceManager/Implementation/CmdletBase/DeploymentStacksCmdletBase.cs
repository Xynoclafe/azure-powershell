using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        /// Deployment stacks client instance field
        /// </summary>
        private DeploymentStacksSdkClient deploymentStacksSdkClientForDelete;

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

        /// <summary>
        /// Gets or sets the deployment stacks sdk client with delete handler
        /// </summary>
        public DeploymentStacksSdkClient DeploymentStacksSdkClientForDelete
        {
            get
            {
                if (this.deploymentStacksSdkClientForDelete == null)
                {
                    this.deploymentStacksSdkClientForDelete = new DeploymentStacksSdkClient(DefaultContext, new StacksDeletePollingHandler());
                }
                return this.deploymentStacksSdkClientForDelete;
            }

            set
            {
                this.deploymentStacksSdkClientForDelete = value;
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

        protected Hashtable GetTemplateParameterObject(Hashtable templateParameterObject)
        {
            //create a new Hashtable so that user can re-use the templateParameterObject.
            var parameterObject = new Hashtable();
            foreach (var parameterKey in templateParameterObject.Keys)
            {
                // Let default behavior of a value parameter if not a KeyVault reference Hashtable
                var hashtableParameter = templateParameterObject[parameterKey] as Hashtable;
                if (hashtableParameter != null && hashtableParameter.ContainsKey("reference"))
                {
                    parameterObject[parameterKey] = templateParameterObject[parameterKey];
                }
                else
                {
                    parameterObject[parameterKey] = new Hashtable { { "value", templateParameterObject[parameterKey] } };
                }
            }
            return parameterObject;
        }

            /// <summary>
            /// Unregisters delegating handler if registered.
            /// </summary>
            protected void UnregisterDelegatingHandlerIfRegistered()
        {
            var apiExpandHandler = GetStacksHandler();

            if (apiExpandHandler != null)
            {
                AzureSession.Instance.ClientFactory.RemoveHandler(apiExpandHandler.GetType());
            }
        }

        /// <summary>
        /// Returns expand handler, if exists.
        /// </summary>
        private DelegatingHandler GetStacksHandler()
        {
            return AzureSession.Instance.ClientFactory.GetCustomHandlers()?
                .Where(handler => handler.GetType().Equals(typeof(StacksDeletePollingHandler))).FirstOrDefault();
        }
    }
}
