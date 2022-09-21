using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks
{
    public class PSActionOnUnmanage
    {
        public string Resources { get; set; }

        public string ResourceGroups { get; set; }

        public string ManagementGroups { get; set; }
    }
}
