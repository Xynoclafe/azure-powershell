﻿using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStackTemplateLink
    {
        public string Uri { get; set; }

        public string Id { get; set; }

        public string RelativePath { get; set; }

        public string QueryString { get; set; }

        public string ContentVersion { get; set; }

        internal PSDeploymentStackTemplateLink(DeploymentStacksTemplateLink link)
        {
            Uri = link.Uri;
            Id = link.Id;
            RelativePath = link.RelativePath;
            QueryString = link.QueryString;
            ContentVersion = link.ContentVersion; 
        }
    }
}
