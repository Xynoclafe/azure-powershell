// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support
{

    /// <summary>The applied scope type</summary>
    public partial struct UserFriendlyAppliedScopeType :
        System.IEquatable<UserFriendlyAppliedScopeType>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType ManagementGroup = @"ManagementGroup";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType None = @"None";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType ResourceGroup = @"ResourceGroup";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType Shared = @"Shared";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType Single = @"Single";

        /// <summary>
        /// the value for an instance of the <see cref="UserFriendlyAppliedScopeType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to UserFriendlyAppliedScopeType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="UserFriendlyAppliedScopeType" />.</param>
        internal static object CreateFrom(object value)
        {
            return new UserFriendlyAppliedScopeType(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type UserFriendlyAppliedScopeType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type UserFriendlyAppliedScopeType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is UserFriendlyAppliedScopeType && Equals((UserFriendlyAppliedScopeType)obj);
        }

        /// <summary>Returns hashCode for enum UserFriendlyAppliedScopeType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for UserFriendlyAppliedScopeType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Creates an instance of the <see cref="UserFriendlyAppliedScopeType"/> Enum class.
        /// </summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private UserFriendlyAppliedScopeType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to UserFriendlyAppliedScopeType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="UserFriendlyAppliedScopeType" />.</param>

        public static implicit operator UserFriendlyAppliedScopeType(string value)
        {
            return new UserFriendlyAppliedScopeType(value);
        }

        /// <summary>Implicit operator to convert UserFriendlyAppliedScopeType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="UserFriendlyAppliedScopeType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum UserFriendlyAppliedScopeType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType e1, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum UserFriendlyAppliedScopeType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType e1, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.UserFriendlyAppliedScopeType e2)
        {
            return e2.Equals(e1);
        }
    }
}