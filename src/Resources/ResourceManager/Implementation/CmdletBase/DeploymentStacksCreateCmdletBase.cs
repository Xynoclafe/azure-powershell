using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase
{
    public class DeploymentStacksTemplateDeploymentCmdletBase : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        protected RuntimeDefinedParameterDictionary dynamicParameters;

        private string templateFile;

        private string templateUri;

        private string templateSpecId;

        protected string protectedTemplateUri;

        private ITemplateSpecsClient templateSpecsClient;

        protected DeploymentStacksTemplateDeploymentCmdletBase()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
        }

        internal const string ParameterlessTemplateFileParameterSetName = "ByTemplateFileWithNoParameters";
        internal const string ParameterlessTemplateUriParameterSetName = "ByTemplateUriWithNoParameters";
        internal const string ParameterlessTemplateSpecParameterSetName = "ByTemplateSpecWithNoParameters";

        internal const string ParameterFileTemplateFileParameterSetName = "ByTemplateFileWithParameterFile";
        internal const string ParameterFileTemplateUriParameterSetName = "ByTemplateUriWithParameterFile";
        internal const string ParameterFileTemplateSpecParameterSetName = "ByTemplateSpecWithParameterFile";

        internal const string ParameterUriTemplateFileParameterSetName = "ByTemplateFileWithParameterUri";
        internal const string ParameterUriTemplateUriParameterSetName = "ByTemplateUriWithParameterUri";
        internal const string ParameterUriTemplateSpecParameterSetName = "ByTemplateSpecWithParameterUri";

        internal const string ParameterObjectTemplateFileParameterSetName = "ByTemplateFileWithParameterObject";
        internal const string ParameterObjectTemplateUriParameterSetName = "ByTemplateUriWithParameterObject";
        internal const string ParameterObjectTemplateSpecParameterSetName = "ByTemplateSpecWithParameterObject";

        [Parameter(ParameterSetName = ParameterFileTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterlessTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack.")]
        public string TemplateFile { get; set; }

        [Parameter(ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterlessTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack.")]
        public string TemplateUri { get; set; }

        [Parameter(ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterlessTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack.")]
        public string TemplateSpecId { get; set; }

        [Parameter(ParameterSetName = ParameterFileTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        public string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template.")]
        public string TemplateParameterUri { get; set; }

        [Parameter(ParameterSetName = ParameterObjectTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public Hashtable TemplateParameterObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Skips the PowerShell dynamic parameter processing that checks if the provided template parameter contains all necessary parameters used by the template. " +
                                            "This check would prompt the user to provide a value for the missing parameters, but providing the -SkipTemplateParameterPrompt will ignore this prompt and " +
                                            "error out immediately if a parameter was found not to be bound in the template. For non-interactive scripts, -SkipTemplateParameterPrompt can be provided " +
                                            "to provide a better error message in the case where not all required parameters are satisfied.")]
        public SwitchParameter SkipTemplateParameterPrompt { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The query string (for example, a SAS token) to be used with the TemplateUri parameter. Would be used in case of linked templates")]
        public string QueryString { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the Template Specs Azure SDK client.
        /// </summary>
        public ITemplateSpecsClient TemplateSpecsClient
        {
            get
            {
                if (this.templateSpecsClient == null)
                {
                    this.templateSpecsClient =
                        AzureSession.Instance.ClientFactory.CreateArmClient<TemplateSpecsClient>(
                            DefaultContext,
                            AzureEnvironment.Endpoint.ResourceManager
                        );
                }

                return this.templateSpecsClient;
            }

            set { this.templateSpecsClient = value; }
        }

        protected override void OnBeginProcessing()
        {
            TemplateFile = this.ResolvePath(TemplateFile);
            TemplateParameterFile = this.ResolvePath(TemplateParameterFile);
            base.OnBeginProcessing();
        }

        public new virtual object GetDynamicParameters()
        {
            if (!this.IsParameterBound(c => c.SkipTemplateParameterPrompt))
            {
                // Resolve the static parameter names for this cmdlet:
                string[] staticParameterNames = this.GetStaticParameterNames();

                // TODO: If bicep file checksum is the same, should not reload parameters.
                if (!string.IsNullOrEmpty(TemplateFile) &&
                    !TemplateFile.Equals(templateFile, StringComparison.OrdinalIgnoreCase))
                {
                    // Build if template file is a bicep file.
                    if (BicepUtility.IsBicepFile(TemplateFile))
                    {
                        BuildAndUseBicepTemplate();
                    }

                    templateFile = TemplateFile;
                    if (string.IsNullOrEmpty(TemplateParameterUri))
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            this.ResolvePath(TemplateFile),
                            TemplateParameterObject,
                            this.ResolvePath(TemplateParameterFile),
                            staticParameterNames);
                    }
                    else
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            this.ResolvePath(TemplateFile),
                            TemplateParameterObject,
                            TemplateParameterUri,
                            staticParameterNames);
                    }
                }
                else if (!string.IsNullOrEmpty(TemplateUri) &&
                    !TemplateUri.Equals(templateUri, StringComparison.OrdinalIgnoreCase))
                {
                    // Check for invalid bicep Template URI. 
                    if (BicepUtility.IsBicepFile(TemplateUri))
                    {
                        throw new NotSupportedException($"'-TemplateUri {TemplateUri}' is not supported. Please download the bicep file and pass it using -TemplateFile.");
                    }

                    if (!string.IsNullOrEmpty(QueryString))
                    {
                        if (QueryString.Substring(0, 1) == "?")
                            protectedTemplateUri = TemplateUri + QueryString;
                        else
                            protectedTemplateUri = TemplateUri + "?" + QueryString;
                    }

                    if (string.IsNullOrEmpty(protectedTemplateUri))
                    {
                        templateUri = TemplateUri;
                    }
                    else
                    {
                        templateUri = protectedTemplateUri;
                    }
                    if (string.IsNullOrEmpty(TemplateParameterUri))
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            templateUri,
                            TemplateParameterObject,
                            this.ResolvePath(TemplateParameterFile),
                            staticParameterNames);
                    }
                    else
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        templateUri,
                        TemplateParameterObject,
                            TemplateParameterUri,
                            staticParameterNames);
                    }
                }
                else if (!string.IsNullOrEmpty(TemplateSpecId) &&
                    !TemplateSpecId.Equals(templateSpecId, StringComparison.OrdinalIgnoreCase))
                {
                    templateSpecId = TemplateSpecId;
                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(templateSpecId);
                    if (!resourceIdentifier.ResourceType.Equals("Microsoft.Resources/templateSpecs/versions", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException("No version found in Resource ID");
                    }

                    if (!string.IsNullOrEmpty(resourceIdentifier.Subscription) &&
                        TemplateSpecsClient.SubscriptionId != resourceIdentifier.Subscription)
                    {
                        // The template spec is in a different subscription than our default
                        // context. Force the client to use that subscription:
                        TemplateSpecsClient.SubscriptionId = resourceIdentifier.Subscription;
                    }
                    JObject templateObj = (JObject)null;
                    try
                    {
                        var templateSpecVersion = TemplateSpecsClient.TemplateSpecVersions.Get(
                            ResourceIdUtility.GetResourceGroupName(templateSpecId),
                            ResourceIdUtility.GetResourceName(templateSpecId).Split('/')[0],
                            resourceIdentifier.ResourceName);

                        if (!(templateSpecVersion.MainTemplate is JObject))
                        {
                            throw new InvalidOperationException("Unexpected type."); // Sanity check
                        }
                        templateObj = (JObject)templateSpecVersion.MainTemplate;
                    }
                    catch (TemplateSpecsErrorException e)
                    {
                        //If the templateSpec resourceID is pointing to a non existant resource
                        if (e.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                        {
                            //By returning null, we are introducing parity in the way templateURI and templateSpecId are validated. Gives a cleaner error message in line with the error message for invalid templateURI
                            return null;
                        }
                        //Throw for any other error that is not due to a 404 for the template resource.
                        throw;
                    }

                    if (string.IsNullOrEmpty(TemplateParameterUri))
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            templateObj,
                            TemplateParameterObject,
                            this.ResolvePath(TemplateParameterFile),
                            staticParameterNames);
                    }
                    else
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            templateObj,
                            TemplateParameterObject,
                            TemplateParameterUri,
                            staticParameterNames);
                    }
                }
            }
            
            RegisterDynamicParameters(dynamicParameters);

            return dynamicParameters;
        }

        /// <summary>
        /// Gets the names of the static parameters defined for this cmdlet.
        /// </summary>
        protected string[] GetStaticParameterNames()
        {
            if (MyInvocation.MyCommand != null)
            {
                // We're running inside the shell... parameter information will already
                // be resolved for us:
                return MyInvocation.MyCommand.Parameters.Keys.ToArray();
            }

            // This invocation is internal (e.g: through a unit test), fallback to
            // collecting the command/parameter info explicitly from our current type:

            CmdletAttribute cmdletAttribute = (CmdletAttribute)this.GetType()
                .GetCustomAttributes(typeof(CmdletAttribute), true)
                .FirstOrDefault();

            if (cmdletAttribute == null)
            {
                throw new InvalidOperationException(
                    $"Expected type '{this.GetType().Name}' to have CmdletAttribute."
                );
            }

            // The command name we provide for the temporary CmdletInfo isn't consumed
            // anywhere other than instantiation, but let's resolve it anyway:
            string commandName = $"{cmdletAttribute.VerbName}-{cmdletAttribute.NounName}";

            CmdletInfo cmdletInfo = new CmdletInfo(commandName, this.GetType());
            return cmdletInfo.Parameters.Keys.ToArray();
        }

        protected Hashtable GenerateParameterObject()
        {
            // NOTE(jogao): create a new Hashtable so that user can re-use the templateParameterObject.
            var parameterObject = new Hashtable();
            
            // Load parameters from parameter oject.
            if (TemplateParameterObject != null)
            {
                foreach (var parameterKey in TemplateParameterObject.Keys)
                {
                    // Let default behavior of a value parameter if not a KeyVault reference Hashtable
                    var hashtableParameter = TemplateParameterObject[parameterKey] as Hashtable;
                    if (hashtableParameter != null && hashtableParameter.ContainsKey("reference"))
                    {
                        parameterObject[parameterKey] = TemplateParameterObject[parameterKey];
                    }
                    else
                    {
                        parameterObject[parameterKey] = new Hashtable { { "value", TemplateParameterObject[parameterKey] } };
                    }
                }
            }

            // Load parameters from the file.
            string parameterFilePath = this.ResolvePath(TemplateParameterFile);
            if (parameterFilePath != null)
            {
                // Check whether templateParameterFilePath exists
                if (FileUtilities.DataStore.FileExists(parameterFilePath))
                {
                    var parametersFromFile = TemplateUtility.ParseTemplateParameterFileContents(TemplateParameterFile);
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

                        parameterObject[dp.Key] = parameter;
                    });
                }
            }

            // Load dynamic parameters.
            IEnumerable<RuntimeDefinedParameter> parameters = PowerShellUtilities.GetUsedDynamicParameters(this.AsJobDynamicParameters, MyInvocation);
            if (parameters.Any())
            {
                parameters.ForEach(dp => parameterObject[((ParameterAttribute)dp.Attributes[0]).HelpMessage] = new Hashtable { { "value", dp.Value } });
            }

            return parameterObject;
        }

        protected void BuildAndUseBicepTemplate()
        {
            TemplateFile = BicepUtility.BuildFile(this.ResolvePath(TemplateFile), this.WriteVerbose, this.WriteWarning);
        }
    }
}