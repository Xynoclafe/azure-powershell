using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
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
    }
}
