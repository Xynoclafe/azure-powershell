// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes the Machine Extension Target Version Properties</summary>
    public partial class ExtensionTargetProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IExtensionTargetProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IExtensionTargetPropertiesInternal
    {

        /// <summary>Backing field for <see cref="TargetVersion" /> property.</summary>
        private string _targetVersion;

        /// <summary>Properties for the specified Extension to Upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string TargetVersion { get => this._targetVersion; set => this._targetVersion = value; }

        /// <summary>Creates an new <see cref="ExtensionTargetProperties" /> instance.</summary>
        public ExtensionTargetProperties()
        {

        }
    }
    /// Describes the Machine Extension Target Version Properties
    public partial interface IExtensionTargetProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>Properties for the specified Extension to Upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Properties for the specified Extension to Upgrade.",
        SerializedName = @"targetVersion",
        PossibleTypes = new [] { typeof(string) })]
        string TargetVersion { get; set; }

    }
    /// Describes the Machine Extension Target Version Properties
    internal partial interface IExtensionTargetPropertiesInternal

    {
        /// <summary>Properties for the specified Extension to Upgrade.</summary>
        string TargetVersion { get; set; }

    }
}