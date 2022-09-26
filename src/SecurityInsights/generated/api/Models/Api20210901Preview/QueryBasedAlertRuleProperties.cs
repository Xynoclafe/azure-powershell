// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Extensions;

    /// <summary>Query based alert rule base property bag.</summary>
    public partial class QueryBasedAlertRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRuleProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesInternal
    {

        /// <summary>the format containing columns name(s) to override the alert description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string AlertDetailOverrideAlertDescriptionFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverrideInternal)AlertDetailsOverride).AlertDescriptionFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverrideInternal)AlertDetailsOverride).AlertDescriptionFormat = value ?? null; }

        /// <summary>the format containing columns name(s) to override the alert name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string AlertDetailOverrideAlertDisplayNameFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverrideInternal)AlertDetailsOverride).AlertDisplayNameFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverrideInternal)AlertDetailsOverride).AlertDisplayNameFormat = value ?? null; }

        /// <summary>the column name to take the alert severity from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string AlertDetailOverrideAlertSeverityColumnName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverrideInternal)AlertDetailsOverride).AlertSeverityColumnName; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverrideInternal)AlertDetailsOverride).AlertSeverityColumnName = value ?? null; }

        /// <summary>the column name to take the alert tactics from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string AlertDetailOverrideAlertTacticsColumnName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverrideInternal)AlertDetailsOverride).AlertTacticsColumnName; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverrideInternal)AlertDetailsOverride).AlertTacticsColumnName = value ?? null; }

        /// <summary>Backing field for <see cref="AlertDetailsOverride" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverride _alertDetailsOverride;

        /// <summary>The alert details override settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverride AlertDetailsOverride { get => (this._alertDetailsOverride = this._alertDetailsOverride ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AlertDetailsOverride()); set => this._alertDetailsOverride = value; }

        /// <summary>Backing field for <see cref="AlertRuleTemplateName" /> property.</summary>
        private string _alertRuleTemplateName;

        /// <summary>The Name of the alert rule template used to create this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string AlertRuleTemplateName { get => this._alertRuleTemplateName; set => this._alertRuleTemplateName = value; }

        /// <summary>Backing field for <see cref="CustomDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesCustomDetails _customDetail;

        /// <summary>Dictionary of string key-value pairs of columns to be attached to the alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesCustomDetails CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.QueryBasedAlertRulePropertiesCustomDetails()); set => this._customDetail = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of the alert rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name for alerts created by this alert rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool _enabled;

        /// <summary>Determines whether this alert rule is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public bool Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="EntityMapping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityMapping[] _entityMapping;

        /// <summary>Array of the entity mappings of the alert rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityMapping[] EntityMapping { get => this._entityMapping; set => this._entityMapping = value; }

        /// <summary>Grouping enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public bool? GroupingConfigurationEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationEnabled = value ?? default(bool); }

        /// <summary>A list of alert details to group by (when matchingMethod is Selected)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail[] GroupingConfigurationGroupByAlertDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationGroupByAlertDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationGroupByAlertDetail = value ?? null /* arrayOf */; }

        /// <summary>
        /// A list of custom details keys to group by (when matchingMethod is Selected). Only keys defined in the current alert rule
        /// may be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string[] GroupingConfigurationGroupByCustomDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationGroupByCustomDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationGroupByCustomDetail = value ?? null /* arrayOf */; }

        /// <summary>
        /// A list of entity types to group by (when matchingMethod is Selected). Only entities defined in the current alert rule
        /// may be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType[] GroupingConfigurationGroupByEntity { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationGroupByEntity; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationGroupByEntity = value ?? null /* arrayOf */; }

        /// <summary>
        /// Limit the group to alerts created within the lookback duration (in ISO 8601 duration format)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? GroupingConfigurationLookbackDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationLookbackDuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationLookbackDuration = value ?? default(global::System.TimeSpan); }

        /// <summary>
        /// Grouping matching method. When method is Selected at least one of groupByEntities, groupByAlertDetails, groupByCustomDetails
        /// must be provided and not empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod? GroupingConfigurationMatchingMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationMatchingMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationMatchingMethod = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod)""); }

        /// <summary>Re-open closed matching incidents</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public bool? GroupingConfigurationReopenClosedIncident { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationReopenClosedIncident; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfigurationReopenClosedIncident = value ?? default(bool); }

        /// <summary>Backing field for <see cref="IncidentConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfiguration _incidentConfiguration;

        /// <summary>
        /// The settings of the incidents that created from alerts triggered by this analytics rule
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfiguration IncidentConfiguration { get => (this._incidentConfiguration = this._incidentConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IncidentConfiguration()); set => this._incidentConfiguration = value; }

        /// <summary>Create incidents from alerts triggered by this analytics rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public bool? IncidentConfigurationCreateIncident { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).CreateIncident; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).CreateIncident = value ?? default(bool); }

        /// <summary>Backing field for <see cref="LastModifiedUtc" /> property.</summary>
        private global::System.DateTime? _lastModifiedUtc;

        /// <summary>The last time that this alert rule has been modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModifiedUtc { get => this._lastModifiedUtc; }

        /// <summary>Internal Acessors for AlertDetailsOverride</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverride Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesInternal.AlertDetailsOverride { get => (this._alertDetailsOverride = this._alertDetailsOverride ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AlertDetailsOverride()); set { {_alertDetailsOverride = value;} } }

        /// <summary>Internal Acessors for IncidentConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfiguration Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesInternal.IncidentConfiguration { get => (this._incidentConfiguration = this._incidentConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IncidentConfiguration()); set { {_incidentConfiguration = value;} } }

        /// <summary>Internal Acessors for IncidentConfigurationGroupingConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IGroupingConfiguration Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesInternal.IncidentConfigurationGroupingConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfigurationInternal)IncidentConfiguration).GroupingConfiguration = value; }

        /// <summary>Internal Acessors for LastModifiedUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesInternal.LastModifiedUtc { get => this._lastModifiedUtc; set { {_lastModifiedUtc = value;} } }

        /// <summary>Backing field for <see cref="Query" /> property.</summary>
        private string _query;

        /// <summary>The query that creates alerts for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string Query { get => this._query; set => this._query = value; }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity? _severity;

        /// <summary>The severity for alerts created by this alert rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity? Severity { get => this._severity; set => this._severity = value; }

        /// <summary>Backing field for <see cref="SuppressionDuration" /> property.</summary>
        private global::System.TimeSpan _suppressionDuration;

        /// <summary>
        /// The suppression (in ISO 8601 duration format) to wait since last time this alert rule been triggered.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public global::System.TimeSpan SuppressionDuration { get => this._suppressionDuration; set => this._suppressionDuration = value; }

        /// <summary>Backing field for <see cref="SuppressionEnabled" /> property.</summary>
        private bool _suppressionEnabled;

        /// <summary>Determines whether the suppression for this alert rule is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public bool SuppressionEnabled { get => this._suppressionEnabled; set => this._suppressionEnabled = value; }

        /// <summary>Backing field for <see cref="Tactic" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic[] _tactic;

        /// <summary>The tactics of the alert rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic[] Tactic { get => this._tactic; set => this._tactic = value; }

        /// <summary>Backing field for <see cref="TemplateVersion" /> property.</summary>
        private string _templateVersion;

        /// <summary>
        /// The version of the alert rule template used to create this rule - in format <a.b.c>, where all are numbers, for example
        /// 0 <1.0.2>
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string TemplateVersion { get => this._templateVersion; set => this._templateVersion = value; }

        /// <summary>Creates an new <see cref="QueryBasedAlertRuleProperties" /> instance.</summary>
        public QueryBasedAlertRuleProperties()
        {

        }
    }
    /// Query based alert rule base property bag.
    public partial interface IQueryBasedAlertRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.IJsonSerializable
    {
        /// <summary>the format containing columns name(s) to override the alert description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the format containing columns name(s) to override the alert description",
        SerializedName = @"alertDescriptionFormat",
        PossibleTypes = new [] { typeof(string) })]
        string AlertDetailOverrideAlertDescriptionFormat { get; set; }
        /// <summary>the format containing columns name(s) to override the alert name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the format containing columns name(s) to override the alert name",
        SerializedName = @"alertDisplayNameFormat",
        PossibleTypes = new [] { typeof(string) })]
        string AlertDetailOverrideAlertDisplayNameFormat { get; set; }
        /// <summary>the column name to take the alert severity from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the column name to take the alert severity from",
        SerializedName = @"alertSeverityColumnName",
        PossibleTypes = new [] { typeof(string) })]
        string AlertDetailOverrideAlertSeverityColumnName { get; set; }
        /// <summary>the column name to take the alert tactics from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the column name to take the alert tactics from",
        SerializedName = @"alertTacticsColumnName",
        PossibleTypes = new [] { typeof(string) })]
        string AlertDetailOverrideAlertTacticsColumnName { get; set; }
        /// <summary>The Name of the alert rule template used to create this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Name of the alert rule template used to create this rule.",
        SerializedName = @"alertRuleTemplateName",
        PossibleTypes = new [] { typeof(string) })]
        string AlertRuleTemplateName { get; set; }
        /// <summary>Dictionary of string key-value pairs of columns to be attached to the alert</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of string key-value pairs of columns to be attached to the alert",
        SerializedName = @"customDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesCustomDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesCustomDetails CustomDetail { get; set; }
        /// <summary>The description of the alert rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the alert rule.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The display name for alerts created by this alert rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The display name for alerts created by this alert rule.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Determines whether this alert rule is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Determines whether this alert rule is enabled or disabled.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool Enabled { get; set; }
        /// <summary>Array of the entity mappings of the alert rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of the entity mappings of the alert rule",
        SerializedName = @"entityMappings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityMapping) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityMapping[] EntityMapping { get; set; }
        /// <summary>Grouping enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Grouping enabled",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? GroupingConfigurationEnabled { get; set; }
        /// <summary>A list of alert details to group by (when matchingMethod is Selected)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of alert details to group by (when matchingMethod is Selected)",
        SerializedName = @"groupByAlertDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail[] GroupingConfigurationGroupByAlertDetail { get; set; }
        /// <summary>
        /// A list of custom details keys to group by (when matchingMethod is Selected). Only keys defined in the current alert rule
        /// may be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of custom details keys to group by (when matchingMethod is Selected). Only keys defined in the current alert rule may be used.",
        SerializedName = @"groupByCustomDetails",
        PossibleTypes = new [] { typeof(string) })]
        string[] GroupingConfigurationGroupByCustomDetail { get; set; }
        /// <summary>
        /// A list of entity types to group by (when matchingMethod is Selected). Only entities defined in the current alert rule
        /// may be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of entity types to group by (when matchingMethod is Selected). Only entities defined in the current alert rule may be used.",
        SerializedName = @"groupByEntities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType[] GroupingConfigurationGroupByEntity { get; set; }
        /// <summary>
        /// Limit the group to alerts created within the lookback duration (in ISO 8601 duration format)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Limit the group to alerts created within the lookback duration (in ISO 8601 duration format)",
        SerializedName = @"lookbackDuration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? GroupingConfigurationLookbackDuration { get; set; }
        /// <summary>
        /// Grouping matching method. When method is Selected at least one of groupByEntities, groupByAlertDetails, groupByCustomDetails
        /// must be provided and not empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Grouping matching method. When method is Selected at least one of groupByEntities, groupByAlertDetails, groupByCustomDetails must be provided and not empty.",
        SerializedName = @"matchingMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod? GroupingConfigurationMatchingMethod { get; set; }
        /// <summary>Re-open closed matching incidents</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Re-open closed matching incidents",
        SerializedName = @"reopenClosedIncident",
        PossibleTypes = new [] { typeof(bool) })]
        bool? GroupingConfigurationReopenClosedIncident { get; set; }
        /// <summary>Create incidents from alerts triggered by this analytics rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Create incidents from alerts triggered by this analytics rule",
        SerializedName = @"createIncident",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncidentConfigurationCreateIncident { get; set; }
        /// <summary>The last time that this alert rule has been modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The last time that this alert rule has been modified.",
        SerializedName = @"lastModifiedUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModifiedUtc { get;  }
        /// <summary>The query that creates alerts for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The query that creates alerts for this rule.",
        SerializedName = @"query",
        PossibleTypes = new [] { typeof(string) })]
        string Query { get; set; }
        /// <summary>The severity for alerts created by this alert rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The severity for alerts created by this alert rule.",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity? Severity { get; set; }
        /// <summary>
        /// The suppression (in ISO 8601 duration format) to wait since last time this alert rule been triggered.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The suppression (in ISO 8601 duration format) to wait since last time this alert rule been triggered.",
        SerializedName = @"suppressionDuration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan SuppressionDuration { get; set; }
        /// <summary>Determines whether the suppression for this alert rule is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Determines whether the suppression for this alert rule is enabled or disabled.",
        SerializedName = @"suppressionEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool SuppressionEnabled { get; set; }
        /// <summary>The tactics of the alert rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tactics of the alert rule",
        SerializedName = @"tactics",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic[] Tactic { get; set; }
        /// <summary>
        /// The version of the alert rule template used to create this rule - in format <a.b.c>, where all are numbers, for example
        /// 0 <1.0.2>
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of the alert rule template used to create this rule - in format <a.b.c>, where all are numbers, for example 0 <1.0.2>",
        SerializedName = @"templateVersion",
        PossibleTypes = new [] { typeof(string) })]
        string TemplateVersion { get; set; }

    }
    /// Query based alert rule base property bag.
    internal partial interface IQueryBasedAlertRulePropertiesInternal

    {
        /// <summary>the format containing columns name(s) to override the alert description</summary>
        string AlertDetailOverrideAlertDescriptionFormat { get; set; }
        /// <summary>the format containing columns name(s) to override the alert name</summary>
        string AlertDetailOverrideAlertDisplayNameFormat { get; set; }
        /// <summary>the column name to take the alert severity from</summary>
        string AlertDetailOverrideAlertSeverityColumnName { get; set; }
        /// <summary>the column name to take the alert tactics from</summary>
        string AlertDetailOverrideAlertTacticsColumnName { get; set; }
        /// <summary>The alert details override settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertDetailsOverride AlertDetailsOverride { get; set; }
        /// <summary>The Name of the alert rule template used to create this rule.</summary>
        string AlertRuleTemplateName { get; set; }
        /// <summary>Dictionary of string key-value pairs of columns to be attached to the alert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IQueryBasedAlertRulePropertiesCustomDetails CustomDetail { get; set; }
        /// <summary>The description of the alert rule.</summary>
        string Description { get; set; }
        /// <summary>The display name for alerts created by this alert rule.</summary>
        string DisplayName { get; set; }
        /// <summary>Determines whether this alert rule is enabled or disabled.</summary>
        bool Enabled { get; set; }
        /// <summary>Array of the entity mappings of the alert rule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityMapping[] EntityMapping { get; set; }
        /// <summary>Grouping enabled</summary>
        bool? GroupingConfigurationEnabled { get; set; }
        /// <summary>A list of alert details to group by (when matchingMethod is Selected)</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail[] GroupingConfigurationGroupByAlertDetail { get; set; }
        /// <summary>
        /// A list of custom details keys to group by (when matchingMethod is Selected). Only keys defined in the current alert rule
        /// may be used.
        /// </summary>
        string[] GroupingConfigurationGroupByCustomDetail { get; set; }
        /// <summary>
        /// A list of entity types to group by (when matchingMethod is Selected). Only entities defined in the current alert rule
        /// may be used.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType[] GroupingConfigurationGroupByEntity { get; set; }
        /// <summary>
        /// Limit the group to alerts created within the lookback duration (in ISO 8601 duration format)
        /// </summary>
        global::System.TimeSpan? GroupingConfigurationLookbackDuration { get; set; }
        /// <summary>
        /// Grouping matching method. When method is Selected at least one of groupByEntities, groupByAlertDetails, groupByCustomDetails
        /// must be provided and not empty.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod? GroupingConfigurationMatchingMethod { get; set; }
        /// <summary>Re-open closed matching incidents</summary>
        bool? GroupingConfigurationReopenClosedIncident { get; set; }
        /// <summary>
        /// The settings of the incidents that created from alerts triggered by this analytics rule
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentConfiguration IncidentConfiguration { get; set; }
        /// <summary>Create incidents from alerts triggered by this analytics rule</summary>
        bool? IncidentConfigurationCreateIncident { get; set; }
        /// <summary>
        /// Set how the alerts that are triggered by this analytics rule, are grouped into incidents
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IGroupingConfiguration IncidentConfigurationGroupingConfiguration { get; set; }
        /// <summary>The last time that this alert rule has been modified.</summary>
        global::System.DateTime? LastModifiedUtc { get; set; }
        /// <summary>The query that creates alerts for this rule.</summary>
        string Query { get; set; }
        /// <summary>The severity for alerts created by this alert rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity? Severity { get; set; }
        /// <summary>
        /// The suppression (in ISO 8601 duration format) to wait since last time this alert rule been triggered.
        /// </summary>
        global::System.TimeSpan SuppressionDuration { get; set; }
        /// <summary>Determines whether the suppression for this alert rule is enabled or disabled.</summary>
        bool SuppressionEnabled { get; set; }
        /// <summary>The tactics of the alert rule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic[] Tactic { get; set; }
        /// <summary>
        /// The version of the alert rule template used to create this rule - in format <a.b.c>, where all are numbers, for example
        /// 0 <1.0.2>
        /// </summary>
        string TemplateVersion { get; set; }

    }
}