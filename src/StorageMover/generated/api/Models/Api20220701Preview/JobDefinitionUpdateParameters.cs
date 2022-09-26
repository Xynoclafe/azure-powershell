// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Runtime.Extensions;

    /// <summary>The Job Definition resource.</summary>
    [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.DoNotFormat]
    public partial class JobDefinitionUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdateParametersInternal
    {

        /// <summary>Name of the Agent to assign for new Job Runs of this Job Definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageMover.PropertyOrigin.Inlined)]
        public string AgentName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdatePropertiesInternal)Property).AgentName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdatePropertiesInternal)Property).AgentName = value ?? null; }

        /// <summary>Strategy to use for copy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Support.CopyMode? CopyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdatePropertiesInternal)Property).CopyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdatePropertiesInternal)Property).CopyMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Support.CopyMode)""); }

        /// <summary>A description for the Job Definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageMover.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdatePropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdatePropertiesInternal)Property).Description = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.JobDefinitionUpdateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdateProperties _property;

        /// <summary>Job definition properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.JobDefinitionUpdateProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="JobDefinitionUpdateParameters" /> instance.</summary>
        public JobDefinitionUpdateParameters()
        {

        }
    }
    /// The Job Definition resource.
    public partial interface IJobDefinitionUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Runtime.IJsonSerializable
    {
        /// <summary>Name of the Agent to assign for new Job Runs of this Job Definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Agent to assign for new Job Runs of this Job Definition.",
        SerializedName = @"agentName",
        PossibleTypes = new [] { typeof(string) })]
        string AgentName { get; set; }
        /// <summary>Strategy to use for copy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Strategy to use for copy.",
        SerializedName = @"copyMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Support.CopyMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Support.CopyMode? CopyMode { get; set; }
        /// <summary>A description for the Job Definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A description for the Job Definition.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }

    }
    /// The Job Definition resource.
    internal partial interface IJobDefinitionUpdateParametersInternal

    {
        /// <summary>Name of the Agent to assign for new Job Runs of this Job Definition.</summary>
        string AgentName { get; set; }
        /// <summary>Strategy to use for copy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Support.CopyMode? CopyMode { get; set; }
        /// <summary>A description for the Job Definition.</summary>
        string Description { get; set; }
        /// <summary>Job definition properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20220701Preview.IJobDefinitionUpdateProperties Property { get; set; }

    }
}