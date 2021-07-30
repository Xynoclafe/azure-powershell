namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMageRcmFailback mobility agent details.</summary>
    public partial class InMageRcmFailbackMobilityAgentDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal
    {

        /// <summary>Backing field for <see cref="AgentVersionExpiryDate" /> property.</summary>
        private global::System.DateTime? _agentVersionExpiryDate;

        /// <summary>The agent version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? AgentVersionExpiryDate { get => this._agentVersionExpiryDate; }

        /// <summary>Backing field for <see cref="DriverVersion" /> property.</summary>
        private string _driverVersion;

        /// <summary>The driver version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DriverVersion { get => this._driverVersion; }

        /// <summary>Backing field for <see cref="DriverVersionExpiryDate" /> property.</summary>
        private global::System.DateTime? _driverVersionExpiryDate;

        /// <summary>The driver version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? DriverVersionExpiryDate { get => this._driverVersionExpiryDate; }

        /// <summary>Backing field for <see cref="IsUpgradeable" /> property.</summary>
        private string _isUpgradeable;

        /// <summary>A value indicating whether agent is upgradeable or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsUpgradeable { get => this._isUpgradeable; }

        /// <summary>Backing field for <see cref="LastHeartbeatUtc" /> property.</summary>
        private global::System.DateTime? _lastHeartbeatUtc;

        /// <summary>The time of the last heartbeat received from the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastHeartbeatUtc { get => this._lastHeartbeatUtc; }

        /// <summary>Backing field for <see cref="LatestUpgradableVersionWithoutReboot" /> property.</summary>
        private string _latestUpgradableVersionWithoutReboot;

        /// <summary>The latest upgradeable version available without reboot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LatestUpgradableVersionWithoutReboot { get => this._latestUpgradableVersionWithoutReboot; }

        /// <summary>Backing field for <see cref="LatestVersion" /> property.</summary>
        private string _latestVersion;

        /// <summary>The latest agent version available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LatestVersion { get => this._latestVersion; }

        /// <summary>Internal Acessors for AgentVersionExpiryDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.AgentVersionExpiryDate { get => this._agentVersionExpiryDate; set { {_agentVersionExpiryDate = value;} } }

        /// <summary>Internal Acessors for DriverVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.DriverVersion { get => this._driverVersion; set { {_driverVersion = value;} } }

        /// <summary>Internal Acessors for DriverVersionExpiryDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.DriverVersionExpiryDate { get => this._driverVersionExpiryDate; set { {_driverVersionExpiryDate = value;} } }

        /// <summary>Internal Acessors for IsUpgradeable</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.IsUpgradeable { get => this._isUpgradeable; set { {_isUpgradeable = value;} } }

        /// <summary>Internal Acessors for LastHeartbeatUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.LastHeartbeatUtc { get => this._lastHeartbeatUtc; set { {_lastHeartbeatUtc = value;} } }

        /// <summary>Internal Acessors for LatestUpgradableVersionWithoutReboot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.LatestUpgradableVersionWithoutReboot { get => this._latestUpgradableVersionWithoutReboot; set { {_latestUpgradableVersionWithoutReboot = value;} } }

        /// <summary>Internal Acessors for LatestVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.LatestVersion { get => this._latestVersion; set { {_latestVersion = value;} } }

        /// <summary>Internal Acessors for ReasonsBlockingUpgrade</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentUpgradeBlockedReason[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.ReasonsBlockingUpgrade { get => this._reasonsBlockingUpgrade; set { {_reasonsBlockingUpgrade = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmFailbackMobilityAgentDetailsInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="ReasonsBlockingUpgrade" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentUpgradeBlockedReason[] _reasonsBlockingUpgrade;

        /// <summary>The whether update is possible or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentUpgradeBlockedReason[] ReasonsBlockingUpgrade { get => this._reasonsBlockingUpgrade; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="InMageRcmFailbackMobilityAgentDetails" /> instance.</summary>
        public InMageRcmFailbackMobilityAgentDetails()
        {

        }
    }
    /// InMageRcmFailback mobility agent details.
    public partial interface IInMageRcmFailbackMobilityAgentDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The agent version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The agent version expiry date.",
        SerializedName = @"agentVersionExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgentVersionExpiryDate { get;  }
        /// <summary>The driver version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The driver version.",
        SerializedName = @"driverVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DriverVersion { get;  }
        /// <summary>The driver version expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The driver version expiry date.",
        SerializedName = @"driverVersionExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DriverVersionExpiryDate { get;  }
        /// <summary>A value indicating whether agent is upgradeable or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A value indicating whether agent is upgradeable or not.",
        SerializedName = @"isUpgradeable",
        PossibleTypes = new [] { typeof(string) })]
        string IsUpgradeable { get;  }
        /// <summary>The time of the last heartbeat received from the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time of the last heartbeat received from the agent.",
        SerializedName = @"lastHeartbeatUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastHeartbeatUtc { get;  }
        /// <summary>The latest upgradeable version available without reboot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The latest upgradeable version available without reboot.",
        SerializedName = @"latestUpgradableVersionWithoutReboot",
        PossibleTypes = new [] { typeof(string) })]
        string LatestUpgradableVersionWithoutReboot { get;  }
        /// <summary>The latest agent version available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The latest agent version available.",
        SerializedName = @"latestVersion",
        PossibleTypes = new [] { typeof(string) })]
        string LatestVersion { get;  }
        /// <summary>The whether update is possible or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The whether update is possible or not.",
        SerializedName = @"reasonsBlockingUpgrade",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentUpgradeBlockedReason) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentUpgradeBlockedReason[] ReasonsBlockingUpgrade { get;  }
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The agent version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// InMageRcmFailback mobility agent details.
    internal partial interface IInMageRcmFailbackMobilityAgentDetailsInternal

    {
        /// <summary>The agent version expiry date.</summary>
        global::System.DateTime? AgentVersionExpiryDate { get; set; }
        /// <summary>The driver version.</summary>
        string DriverVersion { get; set; }
        /// <summary>The driver version expiry date.</summary>
        global::System.DateTime? DriverVersionExpiryDate { get; set; }
        /// <summary>A value indicating whether agent is upgradeable or not.</summary>
        string IsUpgradeable { get; set; }
        /// <summary>The time of the last heartbeat received from the agent.</summary>
        global::System.DateTime? LastHeartbeatUtc { get; set; }
        /// <summary>The latest upgradeable version available without reboot.</summary>
        string LatestUpgradableVersionWithoutReboot { get; set; }
        /// <summary>The latest agent version available.</summary>
        string LatestVersion { get; set; }
        /// <summary>The whether update is possible or not.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentUpgradeBlockedReason[] ReasonsBlockingUpgrade { get; set; }
        /// <summary>The agent version.</summary>
        string Version { get; set; }

    }
}