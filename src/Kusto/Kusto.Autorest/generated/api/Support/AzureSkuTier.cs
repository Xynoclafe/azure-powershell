// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support
{

    /// <summary>SKU tier.</summary>
    public partial struct AzureSkuTier :
        System.IEquatable<AzureSkuTier>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier Basic = @"Basic";

        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier Standard = @"Standard";

        /// <summary>the value for an instance of the <see cref="AzureSkuTier" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="AzureSkuTier"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AzureSkuTier(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AzureSkuTier</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureSkuTier" />.</param>
        internal static object CreateFrom(object value)
        {
            return new AzureSkuTier(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AzureSkuTier</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AzureSkuTier (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AzureSkuTier && Equals((AzureSkuTier)obj);
        }

        /// <summary>Returns hashCode for enum AzureSkuTier</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AzureSkuTier</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AzureSkuTier</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AzureSkuTier" />.</param>

        public static implicit operator AzureSkuTier(string value)
        {
            return new AzureSkuTier(value);
        }

        /// <summary>Implicit operator to convert AzureSkuTier to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AzureSkuTier" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AzureSkuTier</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier e1, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AzureSkuTier</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier e1, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier e2)
        {
            return e2.Equals(e1);
        }
    }
}