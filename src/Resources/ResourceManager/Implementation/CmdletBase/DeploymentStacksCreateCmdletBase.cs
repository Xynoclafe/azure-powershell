using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase
{
    public abstract class DeploymentStacksCreateCmdletBase : ResourceWithParameterCmdletBase, IDynamicParameters 
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

                this.deploymentStacksSdkClient.VerboseLogger = WriteVerboseWithTimestamp;
                this.deploymentStacksSdkClient.ErrorLogger = WriteErrorWithTimestamp;
                this.deploymentStacksSdkClient.WarningLogger = WriteWarningWithTimestamp;

                return this.deploymentStacksSdkClient;
            }

            set
            {
                this.deploymentStacksSdkClient = value;
            }
        }
    }
}
