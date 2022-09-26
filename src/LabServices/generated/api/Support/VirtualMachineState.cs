// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support
{

    /// <summary>The state of a virtual machine.</summary>
    public partial struct VirtualMachineState :
        System.IEquatable<VirtualMachineState>
    {
        /// <summary>The VM is being redeployed.</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState Redeploying = @"Redeploying";

        /// <summary>The VM is being reimaged.</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState Reimaging = @"Reimaging";

        /// <summary>The VM password is being reset.</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState ResettingPassword = @"ResettingPassword";

        /// <summary>The VM is running.</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState Running = @"Running";

        /// <summary>The VM is starting.</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState Starting = @"Starting";

        /// <summary>The VM is currently stopped.</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState Stopped = @"Stopped";

        /// <summary>The VM is stopping.</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState Stopping = @"Stopping";

        /// <summary>the value for an instance of the <see cref="VirtualMachineState" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to VirtualMachineState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualMachineState" />.</param>
        internal static object CreateFrom(object value)
        {
            return new VirtualMachineState(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type VirtualMachineState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type VirtualMachineState (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is VirtualMachineState && Equals((VirtualMachineState)obj);
        }

        /// <summary>Returns hashCode for enum VirtualMachineState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for VirtualMachineState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Creates an instance of the <see cref="VirtualMachineState" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private VirtualMachineState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Implicit operator to convert string to VirtualMachineState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="VirtualMachineState" />.</param>

        public static implicit operator VirtualMachineState(string value)
        {
            return new VirtualMachineState(value);
        }

        /// <summary>Implicit operator to convert VirtualMachineState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="VirtualMachineState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum VirtualMachineState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState e1, Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum VirtualMachineState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState e1, Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState e2)
        {
            return e2.Equals(e1);
        }
    }
}