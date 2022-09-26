// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Extensions;

    /// <summary>The roll up count summary of reservations in each state</summary>
    public partial class ReservationSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummaryInternal
    {

        /// <summary>Backing field for <see cref="CancelledCount" /> property.</summary>
        private float? _cancelledCount;

        /// <summary>The number of reservation in Cancelled state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public float? CancelledCount { get => this._cancelledCount; }

        /// <summary>Backing field for <see cref="ExpiredCount" /> property.</summary>
        private float? _expiredCount;

        /// <summary>The number of reservation in Expired state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public float? ExpiredCount { get => this._expiredCount; }

        /// <summary>Backing field for <see cref="ExpiringCount" /> property.</summary>
        private float? _expiringCount;

        /// <summary>The number of reservation in Expiring state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public float? ExpiringCount { get => this._expiringCount; }

        /// <summary>Backing field for <see cref="FailedCount" /> property.</summary>
        private float? _failedCount;

        /// <summary>The number of reservation in Failed state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public float? FailedCount { get => this._failedCount; }

        /// <summary>Internal Acessors for CancelledCount</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummaryInternal.CancelledCount { get => this._cancelledCount; set { {_cancelledCount = value;} } }

        /// <summary>Internal Acessors for ExpiredCount</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummaryInternal.ExpiredCount { get => this._expiredCount; set { {_expiredCount = value;} } }

        /// <summary>Internal Acessors for ExpiringCount</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummaryInternal.ExpiringCount { get => this._expiringCount; set { {_expiringCount = value;} } }

        /// <summary>Internal Acessors for FailedCount</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummaryInternal.FailedCount { get => this._failedCount; set { {_failedCount = value;} } }

        /// <summary>Internal Acessors for PendingCount</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummaryInternal.PendingCount { get => this._pendingCount; set { {_pendingCount = value;} } }

        /// <summary>Internal Acessors for ProcessingCount</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummaryInternal.ProcessingCount { get => this._processingCount; set { {_processingCount = value;} } }

        /// <summary>Internal Acessors for SucceededCount</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationSummaryInternal.SucceededCount { get => this._succeededCount; set { {_succeededCount = value;} } }

        /// <summary>Backing field for <see cref="PendingCount" /> property.</summary>
        private float? _pendingCount;

        /// <summary>The number of reservation in Pending state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public float? PendingCount { get => this._pendingCount; }

        /// <summary>Backing field for <see cref="ProcessingCount" /> property.</summary>
        private float? _processingCount;

        /// <summary>The number of reservation in Processing state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public float? ProcessingCount { get => this._processingCount; }

        /// <summary>Backing field for <see cref="SucceededCount" /> property.</summary>
        private float? _succeededCount;

        /// <summary>The number of reservation in Succeeded state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public float? SucceededCount { get => this._succeededCount; }

        /// <summary>Creates an new <see cref="ReservationSummary" /> instance.</summary>
        public ReservationSummary()
        {

        }
    }
    /// The roll up count summary of reservations in each state
    public partial interface IReservationSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.IJsonSerializable
    {
        /// <summary>The number of reservation in Cancelled state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of reservation in Cancelled state",
        SerializedName = @"cancelledCount",
        PossibleTypes = new [] { typeof(float) })]
        float? CancelledCount { get;  }
        /// <summary>The number of reservation in Expired state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of reservation in Expired state",
        SerializedName = @"expiredCount",
        PossibleTypes = new [] { typeof(float) })]
        float? ExpiredCount { get;  }
        /// <summary>The number of reservation in Expiring state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of reservation in Expiring state",
        SerializedName = @"expiringCount",
        PossibleTypes = new [] { typeof(float) })]
        float? ExpiringCount { get;  }
        /// <summary>The number of reservation in Failed state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of reservation in Failed state",
        SerializedName = @"failedCount",
        PossibleTypes = new [] { typeof(float) })]
        float? FailedCount { get;  }
        /// <summary>The number of reservation in Pending state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of reservation in Pending state",
        SerializedName = @"pendingCount",
        PossibleTypes = new [] { typeof(float) })]
        float? PendingCount { get;  }
        /// <summary>The number of reservation in Processing state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of reservation in Processing state",
        SerializedName = @"processingCount",
        PossibleTypes = new [] { typeof(float) })]
        float? ProcessingCount { get;  }
        /// <summary>The number of reservation in Succeeded state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of reservation in Succeeded state",
        SerializedName = @"succeededCount",
        PossibleTypes = new [] { typeof(float) })]
        float? SucceededCount { get;  }

    }
    /// The roll up count summary of reservations in each state
    internal partial interface IReservationSummaryInternal

    {
        /// <summary>The number of reservation in Cancelled state</summary>
        float? CancelledCount { get; set; }
        /// <summary>The number of reservation in Expired state</summary>
        float? ExpiredCount { get; set; }
        /// <summary>The number of reservation in Expiring state</summary>
        float? ExpiringCount { get; set; }
        /// <summary>The number of reservation in Failed state</summary>
        float? FailedCount { get; set; }
        /// <summary>The number of reservation in Pending state</summary>
        float? PendingCount { get; set; }
        /// <summary>The number of reservation in Processing state</summary>
        float? ProcessingCount { get; set; }
        /// <summary>The number of reservation in Succeeded state</summary>
        float? SucceededCount { get; set; }

    }
}