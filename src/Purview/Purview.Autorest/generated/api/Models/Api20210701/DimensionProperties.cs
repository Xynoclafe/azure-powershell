// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Extensions;

    /// <summary>properties for dimension</summary>
    public partial class DimensionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IDimensionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IDimensionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>localized display name of the dimension to customer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purview.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>dimension name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purview.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ToBeExportedForCustomer" /> property.</summary>
        private bool? _toBeExportedForCustomer;

        /// <summary>
        /// flag indicating whether this dimension should be included to the customer in Azure Monitor logs (aka Shoebox)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purview.PropertyOrigin.Owned)]
        public bool? ToBeExportedForCustomer { get => this._toBeExportedForCustomer; set => this._toBeExportedForCustomer = value; }

        /// <summary>Creates an new <see cref="DimensionProperties" /> instance.</summary>
        public DimensionProperties()
        {

        }
    }
    /// properties for dimension
    public partial interface IDimensionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.IJsonSerializable
    {
        /// <summary>localized display name of the dimension to customer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"localized display name of the dimension to customer",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>dimension name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"dimension name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// flag indicating whether this dimension should be included to the customer in Azure Monitor logs (aka Shoebox)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"flag indicating whether this dimension should be included to the customer in Azure Monitor logs (aka Shoebox)",
        SerializedName = @"toBeExportedForCustomer",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ToBeExportedForCustomer { get; set; }

    }
    /// properties for dimension
    internal partial interface IDimensionPropertiesInternal

    {
        /// <summary>localized display name of the dimension to customer</summary>
        string DisplayName { get; set; }
        /// <summary>dimension name</summary>
        string Name { get; set; }
        /// <summary>
        /// flag indicating whether this dimension should be included to the customer in Azure Monitor logs (aka Shoebox)
        /// </summary>
        bool? ToBeExportedForCustomer { get; set; }

    }
}