// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Extensions;

    /// <summary>Details of node to be deleted.</summary>
    public partial class DeleteNode :
        Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.IDeleteNode,
        Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.IDeleteNodeInternal
    {

        /// <summary>Backing field for <see cref="IntegrationRuntimeName" /> property.</summary>
        private string _integrationRuntimeName;

        /// <summary>The name of integration runtime.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public string IntegrationRuntimeName { get => this._integrationRuntimeName; set => this._integrationRuntimeName = value; }

        /// <summary>Backing field for <see cref="NodeName" /> property.</summary>
        private string _nodeName;

        /// <summary>The name of node to delete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public string NodeName { get => this._nodeName; set => this._nodeName = value; }

        /// <summary>Creates an new <see cref="DeleteNode" /> instance.</summary>
        public DeleteNode()
        {

        }
    }
    /// Details of node to be deleted.
    public partial interface IDeleteNode :
        Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.IJsonSerializable
    {
        /// <summary>The name of integration runtime.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of integration runtime.",
        SerializedName = @"integrationRuntimeName",
        PossibleTypes = new [] { typeof(string) })]
        string IntegrationRuntimeName { get; set; }
        /// <summary>The name of node to delete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of node to delete.",
        SerializedName = @"nodeName",
        PossibleTypes = new [] { typeof(string) })]
        string NodeName { get; set; }

    }
    /// Details of node to be deleted.
    internal partial interface IDeleteNodeInternal

    {
        /// <summary>The name of integration runtime.</summary>
        string IntegrationRuntimeName { get; set; }
        /// <summary>The name of node to delete.</summary>
        string NodeName { get; set; }

    }
}