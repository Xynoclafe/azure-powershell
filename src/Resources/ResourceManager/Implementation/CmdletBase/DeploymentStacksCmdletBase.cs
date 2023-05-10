using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public abstract class DeploymentStacksCmdletBase : ResourceManagerCmdletBase
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
