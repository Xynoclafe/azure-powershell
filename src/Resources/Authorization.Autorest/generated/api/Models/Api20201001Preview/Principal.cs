// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Runtime.Extensions;

    /// <summary>The name of the entity last modified it</summary>
    public partial class Principal :
        Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IPrincipal,
        Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IPrincipalInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The name of the principal made changes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Origin(Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Email" /> property.</summary>
        private string _email;

        /// <summary>Email of principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Origin(Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.PropertyOrigin.Owned)]
        public string Email { get => this._email; set => this._email = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The id of the principal made changes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Origin(Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of principal such as user , group etc</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Origin(Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Principal" /> instance.</summary>
        public Principal()
        {

        }
    }
    /// The name of the entity last modified it
    public partial interface IPrincipal :
        Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Runtime.IJsonSerializable
    {
        /// <summary>The name of the principal made changes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the principal made changes",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Email of principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Email of principal",
        SerializedName = @"email",
        PossibleTypes = new [] { typeof(string) })]
        string Email { get; set; }
        /// <summary>The id of the principal made changes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the principal made changes",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Type of principal such as user , group etc</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of principal such as user , group etc",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// The name of the entity last modified it
    internal partial interface IPrincipalInternal

    {
        /// <summary>The name of the principal made changes</summary>
        string DisplayName { get; set; }
        /// <summary>Email of principal</summary>
        string Email { get; set; }
        /// <summary>The id of the principal made changes</summary>
        string Id { get; set; }
        /// <summary>Type of principal such as user , group etc</summary>
        string Type { get; set; }

    }
}