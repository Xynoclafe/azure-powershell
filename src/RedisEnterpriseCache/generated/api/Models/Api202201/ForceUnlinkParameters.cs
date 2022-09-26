// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api202201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>
    /// Parameters for a Redis Enterprise Active Geo Replication Force Unlink operation.
    /// </summary>
    public partial class ForceUnlinkParameters :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api202201.IForceUnlinkParameters,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api202201.IForceUnlinkParametersInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string[] _id;

        /// <summary>The resource IDs of the database resources to be unlinked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string[] Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="ForceUnlinkParameters" /> instance.</summary>
        public ForceUnlinkParameters()
        {

        }
    }
    /// Parameters for a Redis Enterprise Active Geo Replication Force Unlink operation.
    public partial interface IForceUnlinkParameters :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>The resource IDs of the database resources to be unlinked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource IDs of the database resources to be unlinked.",
        SerializedName = @"ids",
        PossibleTypes = new [] { typeof(string) })]
        string[] Id { get; set; }

    }
    /// Parameters for a Redis Enterprise Active Geo Replication Force Unlink operation.
    internal partial interface IForceUnlinkParametersInternal

    {
        /// <summary>The resource IDs of the database resources to be unlinked.</summary>
        string[] Id { get; set; }

    }
}