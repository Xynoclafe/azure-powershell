namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Zone details data.</summary>
    public partial class A2AZoneDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AZoneDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AZoneDetailsInternal
    {

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>Source zone info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>The target zone info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Target { get => this._target; set => this._target = value; }

        /// <summary>Creates an new <see cref="A2AZoneDetails" /> instance.</summary>
        public A2AZoneDetails()
        {

        }
    }
    /// Zone details data.
    public partial interface IA2AZoneDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Source zone info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source zone info.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }
        /// <summary>The target zone info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target zone info.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    /// Zone details data.
    internal partial interface IA2AZoneDetailsInternal

    {
        /// <summary>Source zone info.</summary>
        string Source { get; set; }
        /// <summary>The target zone info.</summary>
        string Target { get; set; }

    }
}