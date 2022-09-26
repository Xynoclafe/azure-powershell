// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Extensions;

    public partial class WafMetricsResponseSeriesItem :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IWafMetricsResponseSeriesItem,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IWafMetricsResponseSeriesItemInternal
    {

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IComponents18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems[] _data;

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IComponents18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems[] Data { get => this._data; set => this._data = value; }

        /// <summary>Backing field for <see cref="Group" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IWafMetricsResponseSeriesPropertiesItemsItem[] _group;

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IWafMetricsResponseSeriesPropertiesItemsItem[] Group { get => this._group; set => this._group = value; }

        /// <summary>Backing field for <see cref="Metric" /> property.</summary>
        private string _metric;

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string Metric { get => this._metric; set => this._metric = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="WafMetricsResponseSeriesItem" /> instance.</summary>
        public WafMetricsResponseSeriesItem()
        {

        }
    }
    public partial interface IWafMetricsResponseSeriesItem :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"data",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IComponents18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IComponents18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems[] Data { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"groups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IWafMetricsResponseSeriesPropertiesItemsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IWafMetricsResponseSeriesPropertiesItemsItem[] Group { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"metric",
        PossibleTypes = new [] { typeof(string) })]
        string Metric { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    internal partial interface IWafMetricsResponseSeriesItemInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IComponents18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems[] Data { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IWafMetricsResponseSeriesPropertiesItemsItem[] Group { get; set; }

        string Metric { get; set; }

        string Unit { get; set; }

    }
}