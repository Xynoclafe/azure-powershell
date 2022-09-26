// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container Http Get settings, for liveness or readiness probe</summary>
    public partial class ContainerHttpGet :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.IContainerHttpGet,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.IContainerHttpGetInternal
    {

        /// <summary>Backing field for <see cref="HttpHeader" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.IHttpHeader[] _httpHeader;

        /// <summary>The HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.IHttpHeader[] HttpHeader { get => this._httpHeader; set => this._httpHeader = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int _port;

        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="Scheme" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? _scheme;

        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? Scheme { get => this._scheme; set => this._scheme = value; }

        /// <summary>Creates an new <see cref="ContainerHttpGet" /> instance.</summary>
        public ContainerHttpGet()
        {

        }
    }
    /// The container Http Get settings, for liveness or readiness probe
    public partial interface IContainerHttpGet :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The HTTP headers.",
        SerializedName = @"httpHeaders",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.IHttpHeader) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.IHttpHeader[] HttpHeader { get; set; }
        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to probe.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The port number to probe.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int Port { get; set; }
        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scheme.",
        SerializedName = @"scheme",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? Scheme { get; set; }

    }
    /// The container Http Get settings, for liveness or readiness probe
    internal partial interface IContainerHttpGetInternal

    {
        /// <summary>The HTTP headers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210901.IHttpHeader[] HttpHeader { get; set; }
        /// <summary>The path to probe.</summary>
        string Path { get; set; }
        /// <summary>The port number to probe.</summary>
        int Port { get; set; }
        /// <summary>The scheme.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? Scheme { get; set; }

    }
}