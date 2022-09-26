// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Private endpoint which the connection belongs to.</summary>
    public partial class PrivateEndpointProperty :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IPrivateEndpointProperty,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IPrivateEndpointPropertyInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource id of the private endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="PrivateEndpointProperty" /> instance.</summary>
        public PrivateEndpointProperty()
        {

        }
    }
    /// Private endpoint which the connection belongs to.
    public partial interface IPrivateEndpointProperty :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>Resource id of the private endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource id of the private endpoint.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Private endpoint which the connection belongs to.
    internal partial interface IPrivateEndpointPropertyInternal

    {
        /// <summary>Resource id of the private endpoint.</summary>
        string Id { get; set; }

    }
}