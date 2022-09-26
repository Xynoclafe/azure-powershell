// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Support
{

    /// <summary>AgentPoolType represents types of an agent pool.</summary>
    public partial struct AgentPoolType :
        System.IEquatable<AgentPoolType>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType AvailabilitySet = @"AvailabilitySet";

        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType VirtualMachineScaleSets = @"VirtualMachineScaleSets";

        /// <summary>the value for an instance of the <see cref="AgentPoolType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="AgentPoolType"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AgentPoolType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AgentPoolType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AgentPoolType" />.</param>
        internal static object CreateFrom(object value)
        {
            return new AgentPoolType(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AgentPoolType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AgentPoolType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AgentPoolType && Equals((AgentPoolType)obj);
        }

        /// <summary>Returns hashCode for enum AgentPoolType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AgentPoolType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AgentPoolType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AgentPoolType" />.</param>

        public static implicit operator AgentPoolType(string value)
        {
            return new AgentPoolType(value);
        }

        /// <summary>Implicit operator to convert AgentPoolType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AgentPoolType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AgentPoolType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType e1, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AgentPoolType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType e1, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType e2)
        {
            return e2.Equals(e1);
        }
    }
}