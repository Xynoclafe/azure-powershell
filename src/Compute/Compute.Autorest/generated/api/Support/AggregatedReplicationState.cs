// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute.Support
{

    /// <summary>
    /// This is the aggregated replication status based on all the regional replication status flags.
    /// </summary>
    public partial struct AggregatedReplicationState :
        System.IEquatable<AggregatedReplicationState>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState Completed = @"Completed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState Failed = @"Failed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState InProgress = @"InProgress";

        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState Unknown = @"Unknown";

        /// <summary>
        /// the value for an instance of the <see cref="AggregatedReplicationState" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="AggregatedReplicationState" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AggregatedReplicationState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AggregatedReplicationState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AggregatedReplicationState" />.</param>
        internal static object CreateFrom(object value)
        {
            return new AggregatedReplicationState(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AggregatedReplicationState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AggregatedReplicationState (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AggregatedReplicationState && Equals((AggregatedReplicationState)obj);
        }

        /// <summary>Returns hashCode for enum AggregatedReplicationState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AggregatedReplicationState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AggregatedReplicationState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AggregatedReplicationState" />.</param>

        public static implicit operator AggregatedReplicationState(string value)
        {
            return new AggregatedReplicationState(value);
        }

        /// <summary>Implicit operator to convert AggregatedReplicationState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AggregatedReplicationState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AggregatedReplicationState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState e1, Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AggregatedReplicationState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState e1, Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState e2)
        {
            return e2.Equals(e1);
        }
    }
}