// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Extensions;

    /// <summary>Information of backup file</summary>
    public partial class SqlBackupFileInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfo,
        Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal
    {

        /// <summary>Backing field for <see cref="CopyDuration" /> property.</summary>
        private int? _copyDuration;

        /// <summary>Copy Duration in seconds</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public int? CopyDuration { get => this._copyDuration; }

        /// <summary>Backing field for <see cref="CopyThroughput" /> property.</summary>
        private double? _copyThroughput;

        /// <summary>Copy throughput in KBps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public double? CopyThroughput { get => this._copyThroughput; }

        /// <summary>Backing field for <see cref="DataRead" /> property.</summary>
        private long? _dataRead;

        /// <summary>Bytes read</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public long? DataRead { get => this._dataRead; }

        /// <summary>Backing field for <see cref="DataWritten" /> property.</summary>
        private long? _dataWritten;

        /// <summary>Bytes written</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public long? DataWritten { get => this._dataWritten; }

        /// <summary>Backing field for <see cref="FamilySequenceNumber" /> property.</summary>
        private int? _familySequenceNumber;

        /// <summary>Media family sequence number</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public int? FamilySequenceNumber { get => this._familySequenceNumber; }

        /// <summary>Backing field for <see cref="FileName" /> property.</summary>
        private string _fileName;

        /// <summary>File name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public string FileName { get => this._fileName; }

        /// <summary>Internal Acessors for CopyDuration</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal.CopyDuration { get => this._copyDuration; set { {_copyDuration = value;} } }

        /// <summary>Internal Acessors for CopyThroughput</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal.CopyThroughput { get => this._copyThroughput; set { {_copyThroughput = value;} } }

        /// <summary>Internal Acessors for DataRead</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal.DataRead { get => this._dataRead; set { {_dataRead = value;} } }

        /// <summary>Internal Acessors for DataWritten</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal.DataWritten { get => this._dataWritten; set { {_dataWritten = value;} } }

        /// <summary>Internal Acessors for FamilySequenceNumber</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal.FamilySequenceNumber { get => this._familySequenceNumber; set { {_familySequenceNumber = value;} } }

        /// <summary>Internal Acessors for FileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal.FileName { get => this._fileName; set { {_fileName = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for TotalSize</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20220330Preview.ISqlBackupFileInfoInternal.TotalSize { get => this._totalSize; set { {_totalSize = value;} } }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>
        /// Status of the file. (Initial, Uploading, Uploaded, Restoring, Restored or Skipped)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Backing field for <see cref="TotalSize" /> property.</summary>
        private long? _totalSize;

        /// <summary>File size in bytes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.PropertyOrigin.Owned)]
        public long? TotalSize { get => this._totalSize; }

        /// <summary>Creates an new <see cref="SqlBackupFileInfo" /> instance.</summary>
        public SqlBackupFileInfo()
        {

        }
    }
    /// Information of backup file
    public partial interface ISqlBackupFileInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.IJsonSerializable
    {
        /// <summary>Copy Duration in seconds</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Copy Duration in seconds",
        SerializedName = @"copyDuration",
        PossibleTypes = new [] { typeof(int) })]
        int? CopyDuration { get;  }
        /// <summary>Copy throughput in KBps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Copy throughput in KBps",
        SerializedName = @"copyThroughput",
        PossibleTypes = new [] { typeof(double) })]
        double? CopyThroughput { get;  }
        /// <summary>Bytes read</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Bytes read",
        SerializedName = @"dataRead",
        PossibleTypes = new [] { typeof(long) })]
        long? DataRead { get;  }
        /// <summary>Bytes written</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Bytes written",
        SerializedName = @"dataWritten",
        PossibleTypes = new [] { typeof(long) })]
        long? DataWritten { get;  }
        /// <summary>Media family sequence number</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Media family sequence number",
        SerializedName = @"familySequenceNumber",
        PossibleTypes = new [] { typeof(int) })]
        int? FamilySequenceNumber { get;  }
        /// <summary>File name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"File name.",
        SerializedName = @"fileName",
        PossibleTypes = new [] { typeof(string) })]
        string FileName { get;  }
        /// <summary>
        /// Status of the file. (Initial, Uploading, Uploaded, Restoring, Restored or Skipped)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the file. (Initial, Uploading, Uploaded, Restoring, Restored or Skipped)",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }
        /// <summary>File size in bytes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"File size in bytes",
        SerializedName = @"totalSize",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalSize { get;  }

    }
    /// Information of backup file
    internal partial interface ISqlBackupFileInfoInternal

    {
        /// <summary>Copy Duration in seconds</summary>
        int? CopyDuration { get; set; }
        /// <summary>Copy throughput in KBps</summary>
        double? CopyThroughput { get; set; }
        /// <summary>Bytes read</summary>
        long? DataRead { get; set; }
        /// <summary>Bytes written</summary>
        long? DataWritten { get; set; }
        /// <summary>Media family sequence number</summary>
        int? FamilySequenceNumber { get; set; }
        /// <summary>File name.</summary>
        string FileName { get; set; }
        /// <summary>
        /// Status of the file. (Initial, Uploading, Uploaded, Restoring, Restored or Skipped)
        /// </summary>
        string Status { get; set; }
        /// <summary>File size in bytes</summary>
        long? TotalSize { get; set; }

    }
}