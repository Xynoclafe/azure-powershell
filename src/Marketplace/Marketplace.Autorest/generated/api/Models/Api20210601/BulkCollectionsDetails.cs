// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Runtime.Extensions;

    /// <summary>Bulk collection details</summary>
    public partial class BulkCollectionsDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.IBulkCollectionsDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.Api20210601.IBulkCollectionsDetailsInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private string _action;

        /// <summary>Action to perform (For example: EnableCollections, DisableCollections)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.Marketplace.PropertyOrigin.Owned)]
        public string Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="CollectionId" /> property.</summary>
        private string[] _collectionId;

        /// <summary>collection ids list that the action is performed on</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.Marketplace.PropertyOrigin.Owned)]
        public string[] CollectionId { get => this._collectionId; set => this._collectionId = value; }

        /// <summary>Creates an new <see cref="BulkCollectionsDetails" /> instance.</summary>
        public BulkCollectionsDetails()
        {

        }
    }
    /// Bulk collection details
    public partial interface IBulkCollectionsDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Runtime.IJsonSerializable
    {
        /// <summary>Action to perform (For example: EnableCollections, DisableCollections)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Action to perform (For example: EnableCollections, DisableCollections)",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(string) })]
        string Action { get; set; }
        /// <summary>collection ids list that the action is performed on</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"collection ids list that the action is performed on",
        SerializedName = @"collectionIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] CollectionId { get; set; }

    }
    /// Bulk collection details
    internal partial interface IBulkCollectionsDetailsInternal

    {
        /// <summary>Action to perform (For example: EnableCollections, DisableCollections)</summary>
        string Action { get; set; }
        /// <summary>collection ids list that the action is performed on</summary>
        string[] CollectionId { get; set; }

    }
}