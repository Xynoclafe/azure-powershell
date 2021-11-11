using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Linq;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    public class DeploymentStacksSdkClient
    {
        public IDeploymentStacksClient DeploymentStacksClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        private IAzureContext azureContext;

        public DeploymentStacksSdkClient(IDeploymentStacksClient deploymentStacksClient)
        {
            this.DeploymentStacksClient = deploymentStacksClient;
        }

        // <summary>
        /// Parameter-less constructor for mocking
        /// </summary>
        public DeploymentStacksSdkClient()
        {
        }

        public DeploymentStacksSdkClient(IAzureContext context)
            : this(
                AzureSession.Instance.ClientFactory.CreateArmClient<DeploymentStacksClient>(context,
                    AzureEnvironment.Endpoint.ResourceManager))
        {
            this.azureContext = context;
        }

        public PSDeploymentStack GetResourceGroupDeploymentStack(
            string resourceGroupName,
            string deploymentStackName,
            bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStack = DeploymentStacksClient.DeploymentStacks.GetAtResourceGroup(resourceGroupName, deploymentStackName);
                return new PSDeploymentStack(deploymentStack);
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStack '{deploymentStackName}' in Resource Group '{resourceGroupName}' not found."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public IList<PSDeploymentStack> ListResourceGroupDeploymentStack(string resourceGroupName, bool throwIfNotExists = true)
        {
            try
            {
                var list = new List<PSDeploymentStack>();

                var deploymentStacks = DeploymentStacksClient.DeploymentStacks.ListAtResourceGroup(resourceGroupName);

                list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));

                while (deploymentStacks.NextPageLink != null)
                {
                    deploymentStacks =
                        DeploymentStacksClient.DeploymentStacks.ListAtResourceGroupNext(deploymentStacks.NextPageLink);
                    list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (!throwIfNotExists)
                    return null;

                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Body.Error.Message);
                
                throw ex;
            }
        }

        public IEnumerable<PSDeploymentStackSnapshot> ListResourceGroupDeploymentStackSnapshot(string resourceGroupName, string stackName, bool throwIfNotExists = true)
        {
            try
            {
                var list = new List<PSDeploymentStackSnapshot>();

                var deploymentStackSnapshots = DeploymentStacksClient.DeploymentStackSnapshots.ListAtResourceGroup(resourceGroupName, stackName);

                list.AddRange(deploymentStackSnapshots.Select(stack => PSDeploymentStackSnapshot.FromAzureSDKDeploymentStack(stack)));

                while (deploymentStackSnapshots.NextPageLink != null)
                {
                    deploymentStackSnapshots =
                        DeploymentStacksClient.DeploymentStackSnapshots.ListAtResourceGroupNext(deploymentStackSnapshots.NextPageLink);
                    list.AddRange(deploymentStackSnapshots.Select(stack => PSDeploymentStackSnapshot.FromAzureSDKDeploymentStack(stack)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (!throwIfNotExists)
                    return null;

                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Body.Error.Message);

                throw ex;
            }
        }

        internal object ListSubscriptionDeploymentStackSnapshot(string stackName, bool throwIfNotExists = true)
        {
            try
            {
                var list = new List<PSDeploymentStackSnapshot>();

                var deploymentStackSnapshots = DeploymentStacksClient.DeploymentStackSnapshots.ListAtSubscription(stackName);

                list.AddRange(deploymentStackSnapshots.Select(stack => PSDeploymentStackSnapshot.FromAzureSDKDeploymentStack(stack)));

                while (deploymentStackSnapshots.NextPageLink != null)
                {
                    deploymentStackSnapshots =
                        DeploymentStacksClient.DeploymentStackSnapshots.ListAtSubscriptionNext(deploymentStackSnapshots.NextPageLink);
                    list.AddRange(deploymentStackSnapshots.Select(stack => PSDeploymentStackSnapshot.FromAzureSDKDeploymentStack(stack)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (!throwIfNotExists)
                    return null;

                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Body.Error.Message);

                throw ex;
            }
        }

        public PSDeploymentStack GetSubscriptionDeploymentStack(string stackName, bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStack = DeploymentStacksClient.DeploymentStacks.GetAtSubscription(stackName);

                return new PSDeploymentStack(deploymentStack);
            }

            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStack '{stackName}' not found in current subscription scope."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public IEnumerable<PSDeploymentStack> ListSubscriptionDeploymentStack(bool throwIfNotExists = true)
        {
            try
            {
                var list = new List<PSDeploymentStack>();

                var deploymentStacks = DeploymentStacksClient.DeploymentStacks.ListAtSubscription();

                list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));

                while (deploymentStacks.NextPageLink != null)
                {
                    deploymentStacks =
                        DeploymentStacksClient.DeploymentStacks.ListAtSubscriptionNext(deploymentStacks.NextPageLink);
                    list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (!throwIfNotExists)
                    return null;

                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Body.Error.Message);

                throw ex;
            }
        }

        public PSDeploymentStackSnapshot GetResourceGroupDeploymentStackSnapshot(string resourceGroupName, string stackName, string snapshotName, bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStackSnapshot = DeploymentStacksClient.DeploymentStackSnapshots.GetAtResourceGroup(resourceGroupName, stackName, snapshotName);
                return new PSDeploymentStackSnapshot(deploymentStackSnapshot);
            }

            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStackSnapshot '{snapshotName}' of DeploymentStack '{stackName}' in Resource Group '{resourceGroupName}' not found.."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public PSDeploymentStackSnapshot GetSubscriptionDeploymentStackSnapshot(string stackName, string snapshotName, bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStackSnapshot = DeploymentStacksClient.DeploymentStackSnapshots.GetAtSubscription(stackName, snapshotName);

                return new PSDeploymentStackSnapshot(deploymentStackSnapshot);
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStackSnapshot '{snapshotName}' of DeploymentStack '{stackName}' not found in current subscription scope."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public PSDeploymentStack ResourceGroupCreateOrUpdateDeploymentStack(
            string deploymentStackName,
            string resourceGroupName,
            string templateUri,
            string templateSpec,
            string parameterUri,
            Hashtable parameters,
            string description,
            string updateBehavior
            )
        {
            var deploymentStackModel = new DeploymentStack
            {
                Description = description,
                UpdateBehavior = updateBehavior
            };

            DeploymentStacksTemplateLink templateLink = new DeploymentStacksTemplateLink();
            if(templateSpec != null)
            {
                templateLink.Id = templateSpec;
                deploymentStackModel.TemplateLink = templateLink;
            }
            else if(Uri.IsWellFormedUriString(templateUri, UriKind.Absolute))
            {
                templateLink.Uri = templateUri;
                deploymentStackModel.TemplateLink = templateLink;
            }
            else
            {
                deploymentStackModel.Template = JObject.Parse(FileUtilities.DataStore.ReadFileAsText(templateUri));
            }

            if(Uri.IsWellFormedUriString(parameterUri, UriKind.Absolute))
            {
                DeploymentStacksParametersLink parametersLink = new DeploymentStacksParametersLink();
                parametersLink.Uri = parameterUri;
                deploymentStackModel.ParametersLink = parametersLink;
            }

            else if(parameters != null)
            {
                Dictionary<string, object> parametersDictionary = parameters?.ToDictionary(false);
                string parametersContent = parametersDictionary != null
                    ? PSJsonSerializer.Serialize(parametersDictionary)
                    : null;
                deploymentStackModel.Parameters = !string.IsNullOrEmpty(parametersContent)
                    ? JObject.Parse(parametersContent)
                    : null;
            }



            var deploymentStack = DeploymentStacksClient.DeploymentStacks.BeginCreateOrUpdateAtResourceGroup(resourceGroupName, deploymentStackName, deploymentStackModel);
            var getStackFunc = this.GetStackAction(deploymentStackName, "resourceGroup", resourceGroupName);

            var finalStack = this.waitStackCompletion(
                getStackFunc,
                "Succeeded",
                "SucceededWithFailures",
                "Failed",
                "Canceled"
                );
            return new PSDeploymentStack(finalStack);
        }

        internal void DeleteResourceGroupDeploymentStackSnapshot(string resourceGroupName, string name, string snapshotName)
        {
            var deleteResponse = DeploymentStacksClient.DeploymentStackSnapshots
                .DeleteAtResourceGroupWithHttpMessagesAsync(resourceGroupName, name, snapshotName)
                .GetAwaiter()
                .GetResult();

            if (deleteResponse.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new PSArgumentException(
                        $"DeploymentStack snapshot '{snapshotName}' of the DeploymentStack '{name}' in ResourceGroup '{resourceGroupName}' not found."
                    );
            }

            return;
        }

        internal void DeleteSubscriptionDeploymentStackSnapshot(string stackname, string snapshotName)
        {
            var deleteResponse = DeploymentStacksClient.DeploymentStackSnapshots
                .DeleteAtSubscriptionWithHttpMessagesAsync(stackname, snapshotName)
                .GetAwaiter()
                .GetResult();

            if (deleteResponse.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new PSArgumentException(
                        $"DeploymentStack snapshot '{snapshotName}' of the DeploymentStack '{stackname}' not found in the current subscription scope."
                    );
            }

            return;
        }

        internal void DeleteResourceGroupDeploymentStack(string resourceGroupName, string name)
        {
            var deleteResponse = DeploymentStacksClient.DeploymentStacks
                .DeleteAtResourceGroupWithHttpMessagesAsync(resourceGroupName, name)
                .GetAwaiter()
                .GetResult();

            if (deleteResponse.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new PSArgumentException(
                        $"DeploymentStack '{name}' in ResourceGroup '{resourceGroupName}' not found."
                    );
            }

            return;
        }

        internal void DeleteSubscriptionDeploymentStack(string name)
        {
            var deleteResponse = DeploymentStacksClient.DeploymentStacks
                .DeleteAtSubscriptionWithHttpMessagesAsync(name)
                .GetAwaiter()
                .GetResult();

            if (deleteResponse.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new PSArgumentException(
                        $"DeploymentStack '{name}' not found in the curent subscription scope."
                    );
            }

            return;
        }

        public PSDeploymentStack SubscriptionCreateOrUpdateDeploymentStack(
            string deploymentStackName,
            string location,
            string templateUri,
            string templateSpec,
            string parameterUri,
            Hashtable parameters,
            string description,
            string updateBehavior,
            string deploymentScope
        )
        {
            var deploymentStackModel = new DeploymentStack
            {
                Description = description,
                Location = location,
                UpdateBehavior = updateBehavior,
                DeploymentScope = deploymentScope
            };

            DeploymentStacksTemplateLink templateLink = new DeploymentStacksTemplateLink();
            if (templateSpec != null)
            {
                templateLink.Id = templateSpec;
                deploymentStackModel.TemplateLink = templateLink;
            }
            else if (Uri.IsWellFormedUriString(templateUri, UriKind.Absolute))
            {
                templateLink.Uri = templateUri;
                deploymentStackModel.TemplateLink = templateLink;
            }
            else
            {
                deploymentStackModel.Template = JObject.Parse(FileUtilities.DataStore.ReadFileAsText(templateUri));
            }

            if (Uri.IsWellFormedUriString(parameterUri, UriKind.Absolute))
            {
                DeploymentStacksParametersLink parametersLink = new DeploymentStacksParametersLink();
                parametersLink.Uri = parameterUri;
                deploymentStackModel.ParametersLink = parametersLink;
            }

            else if (parameters != null)
            {
                Dictionary<string, object> parametersDictionary = parameters?.ToDictionary(false);
                string parametersContent = parametersDictionary != null
                    ? PSJsonSerializer.Serialize(parametersDictionary)
                    : null;
                deploymentStackModel.Parameters = !string.IsNullOrEmpty(parametersContent)
                    ? JObject.Parse(parametersContent)
                    : null;
            }

            var deploymentStack = DeploymentStacksClient.DeploymentStacks.BeginCreateOrUpdateAtSubscription(deploymentStackName, deploymentStackModel);
            var getStackFunc = this.GetStackAction(deploymentStackName, "subscription");

            var finalStack = this.waitStackCompletion(
                getStackFunc,
                "Succeeded",
                "SucceededWithFailures",
                "Failed",
                "Canceled"
                );

            return new PSDeploymentStack(finalStack);
        }

        private DeploymentStack waitStackCompletion(Func<Task<AzureOperationResponse<DeploymentStack>>> getStack, params string[] status)
        {
            //Poll stack deployment based on RetryAfter. If no RetyrAfter is present, polling status in two phases.
            //Phase one: poll every 5 seconds for 400 seconds. If not completed in this duration, move to phase two
            //Phase two: poll every 60 seconds
            DeploymentStack stack;

            const int counterUnit = 1000;
            int step = 5;
            int phaseOne = 400;
            do
            {
                WriteVerbose(string.Format("Checking stack deployment status", step));
                TestMockSupport.Delay(step * counterUnit);

                if (phaseOne > 0)
                    phaseOne -= step;

                var getStackTask = getStack();

                using (var getResult = getStackTask.ConfigureAwait(false).GetAwaiter().GetResult())
                {
                    stack = getResult.Body;
                    var response = getResult.Response;

                    if (response != null && response.Headers.RetryAfter != null && response.Headers.RetryAfter.Delta.HasValue)
                    {
                        step = response.Headers.RetryAfter.Delta.Value.Seconds;
                    }
                    else
                    {
                        step = phaseOne > 0 ? 5 : 60;
                    }
                }

            } while (!status.Any(s => s.Equals(stack.ProvisioningState, StringComparison.OrdinalIgnoreCase)));

            return stack;
        }

        Func<Task<AzureOperationResponse<DeploymentStack>>> GetStackAction(string stackName, string scope, string rgName = null)
        {
            switch(scope)
            {
                case "subscription":
                    return () => DeploymentStacksClient.DeploymentStacks.GetAtSubscriptionWithHttpMessagesAsync(stackName);

                case "resourceGroup":
                    return () => DeploymentStacksClient.DeploymentStacks.GetAtResourceGroupWithHttpMessagesAsync(rgName, stackName);

                default:
                    throw new NotImplementedException();
            }
        }

        public PSDeploymentStack UpdateResourceGroupDeploymentStack(
            string deploymentStackName,
            string resourceGroupName,
            string templateUri,
            string templateSpec,
            string parameterUri,
            Hashtable parameters,
            string description
            )
        {
            var deploymentStackModel = new DeploymentStack
            {
                Description = description
            };

            DeploymentStacksTemplateLink templateLink = new DeploymentStacksTemplateLink();
            if (templateSpec != null)
            {
                templateLink.Id = templateSpec;
                deploymentStackModel.TemplateLink = templateLink;
            }
            else if (Uri.IsWellFormedUriString(templateUri, UriKind.Absolute))
            {
                templateLink.Uri = templateUri;
                deploymentStackModel.TemplateLink = templateLink;
            }
            else
            {
                deploymentStackModel.Template = JObject.Parse(FileUtilities.DataStore.ReadFileAsText(templateUri));
            }

            if (Uri.IsWellFormedUriString(parameterUri, UriKind.Absolute))
            {
                DeploymentStacksParametersLink parametersLink = new DeploymentStacksParametersLink();
                parametersLink.Uri = parameterUri;
                deploymentStackModel.ParametersLink = parametersLink;
            }

            else if (parameters != null)
            {
                Dictionary<string, object> parametersDictionary = parameters?.ToDictionary(false);
                string parametersContent = parametersDictionary != null
                    ? PSJsonSerializer.Serialize(parametersDictionary)
                    : null;
                deploymentStackModel.Parameters = !string.IsNullOrEmpty(parametersContent)
                    ? JObject.Parse(parametersContent)
                    : null;
            }

            var deploymentStack = DeploymentStacksClient.DeploymentStacks.BeginCreateOrUpdateAtResourceGroup(resourceGroupName, deploymentStackName, deploymentStackModel);
            return new PSDeploymentStack(deploymentStack);
        }

        private void WriteVerbose(string progress)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(progress);
            }
        }

        private void WriteWarning(string warning)
        {
            if (WarningLogger != null)
            {
                WarningLogger(warning);
            }
        }

        private void WriteError(string error)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(error);
            }
        }
    }
}
