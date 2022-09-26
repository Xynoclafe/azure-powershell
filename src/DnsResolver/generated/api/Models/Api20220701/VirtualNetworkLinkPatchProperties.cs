// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Extensions;

    /// <summary>Represents the updatable properties of the virtual network link.</summary>
    public partial class VirtualNetworkLinkPatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IVirtualNetworkLinkPatchProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IVirtualNetworkLinkPatchPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IVirtualNetworkLinkPatchPropertiesMetadata _metadata;

        /// <summary>Metadata attached to the virtual network link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IVirtualNetworkLinkPatchPropertiesMetadata Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.VirtualNetworkLinkPatchPropertiesMetadata()); set => this._metadata = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkLinkPatchProperties" /> instance.</summary>
        public VirtualNetworkLinkPatchProperties()
        {

        }
    }
    /// Represents the updatable properties of the virtual network link.
    public partial interface IVirtualNetworkLinkPatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IJsonSerializable
    {
        /// <summary>Metadata attached to the virtual network link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metadata attached to the virtual network link.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IVirtualNetworkLinkPatchPropertiesMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IVirtualNetworkLinkPatchPropertiesMetadata Metadata { get; set; }

    }
    /// Represents the updatable properties of the virtual network link.
    internal partial interface IVirtualNetworkLinkPatchPropertiesInternal

    {
        /// <summary>Metadata attached to the virtual network link.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IVirtualNetworkLinkPatchPropertiesMetadata Metadata { get; set; }

    }
}