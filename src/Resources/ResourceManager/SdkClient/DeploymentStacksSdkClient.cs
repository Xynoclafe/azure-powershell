using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    public class DeploymentStacksSdkClient
    {
        public IDeploymentStacksClient DeploymentStacksClient { get; set; }

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
            string deploymentStackName = null)
        {
            var deploymentStack = DeploymentStacksClient.DeploymentStacks.GetAtResourceGroup(resourceGroupName, deploymentStackName);

            return new PSDeploymentStack(deploymentStack);
        }

        public PSDeploymentStack ResourceGroupCreateOrUpdateDeploymentStack(
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
            return new PSDeploymentStack(deploymentStack);
        }

        public PSDeploymentStack SubscriptionCreateOrUpdateDeploymentStack(
            string deploymentStackName,
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

            var deploymentStack = DeploymentStacksClient.DeploymentStacks.BeginCreateOrUpdateAtSubscription(deploymentStackName, deploymentStackModel);
            return new PSDeploymentStack(deploymentStack);
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
    }
}
