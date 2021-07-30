namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMageRcm disk input.</summary>
    public partial class InMageRcmDisksDefaultInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmDisksDefaultInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmDisksDefaultInputInternal
    {

        /// <summary>Backing field for <see cref="DiskEncryptionSetId" /> property.</summary>
        private string _diskEncryptionSetId;

        /// <summary>The DiskEncryptionSet ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskEncryptionSetId { get => this._diskEncryptionSetId; set => this._diskEncryptionSetId = value; }

        /// <summary>Backing field for <see cref="DiskType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType _diskType;

        /// <summary>The disk type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType DiskType { get => this._diskType; set => this._diskType = value; }

        /// <summary>Backing field for <see cref="LogStorageAccountId" /> property.</summary>
        private string _logStorageAccountId;

        /// <summary>The log storage account ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LogStorageAccountId { get => this._logStorageAccountId; set => this._logStorageAccountId = value; }

        /// <summary>Creates an new <see cref="InMageRcmDisksDefaultInput" /> instance.</summary>
        public InMageRcmDisksDefaultInput()
        {

        }
    }
    /// InMageRcm disk input.
    public partial interface IInMageRcmDisksDefaultInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The DiskEncryptionSet ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DiskEncryptionSet ARM Id.",
        SerializedName = @"diskEncryptionSetId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionSetId { get; set; }
        /// <summary>The disk type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The disk type.",
        SerializedName = @"diskType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType DiskType { get; set; }
        /// <summary>The log storage account ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The log storage account ARM Id.",
        SerializedName = @"logStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string LogStorageAccountId { get; set; }

    }
    /// InMageRcm disk input.
    internal partial interface IInMageRcmDisksDefaultInputInternal

    {
        /// <summary>The DiskEncryptionSet ARM Id.</summary>
        string DiskEncryptionSetId { get; set; }
        /// <summary>The disk type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType DiskType { get; set; }
        /// <summary>The log storage account ARM Id.</summary>
        string LogStorageAccountId { get; set; }

    }
}