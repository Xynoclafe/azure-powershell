// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Extensions;

    /// <summary>The connection information for the virtual machine</summary>
    public partial class VirtualMachineConnectionProfile :
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfile,
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfileInternal
    {

        /// <summary>Backing field for <see cref="AdminUsername" /> property.</summary>
        private string _adminUsername;

        /// <summary>The username used to log on to the virtual machine as admin.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        public string AdminUsername { get => this._adminUsername; }

        /// <summary>Internal Acessors for AdminUsername</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfileInternal.AdminUsername { get => this._adminUsername; set { {_adminUsername = value;} } }

        /// <summary>Internal Acessors for NonAdminUsername</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfileInternal.NonAdminUsername { get => this._nonAdminUsername; set { {_nonAdminUsername = value;} } }

        /// <summary>Internal Acessors for PrivateIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfileInternal.PrivateIPAddress { get => this._privateIPAddress; set { {_privateIPAddress = value;} } }

        /// <summary>Internal Acessors for RdpAuthority</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfileInternal.RdpAuthority { get => this._rdpAuthority; set { {_rdpAuthority = value;} } }

        /// <summary>Internal Acessors for RdpInBrowserUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfileInternal.RdpInBrowserUrl { get => this._rdpInBrowserUrl; set { {_rdpInBrowserUrl = value;} } }

        /// <summary>Internal Acessors for SshAuthority</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfileInternal.SshAuthority { get => this._sshAuthority; set { {_sshAuthority = value;} } }

        /// <summary>Internal Acessors for SshInBrowserUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfileInternal.SshInBrowserUrl { get => this._sshInBrowserUrl; set { {_sshInBrowserUrl = value;} } }

        /// <summary>Backing field for <see cref="NonAdminUsername" /> property.</summary>
        private string _nonAdminUsername;

        /// <summary>The username used to log on to the virtual machine as non-admin, if one exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        public string NonAdminUsername { get => this._nonAdminUsername; }

        /// <summary>Backing field for <see cref="PrivateIPAddress" /> property.</summary>
        private string _privateIPAddress;

        /// <summary>The private IP address of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        public string PrivateIPAddress { get => this._privateIPAddress; }

        /// <summary>Backing field for <see cref="RdpAuthority" /> property.</summary>
        private string _rdpAuthority;

        /// <summary>
        /// Port and host name separated by semicolon for connecting via RDP protocol to the virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        public string RdpAuthority { get => this._rdpAuthority; }

        /// <summary>Backing field for <see cref="RdpInBrowserUrl" /> property.</summary>
        private string _rdpInBrowserUrl;

        /// <summary>URL for connecting via RDP protocol to the virtual machine in browser.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        public string RdpInBrowserUrl { get => this._rdpInBrowserUrl; }

        /// <summary>Backing field for <see cref="SshAuthority" /> property.</summary>
        private string _sshAuthority;

        /// <summary>
        /// Port and host name separated by semicolon for connecting via SSH protocol to the virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        public string SshAuthority { get => this._sshAuthority; }

        /// <summary>Backing field for <see cref="SshInBrowserUrl" /> property.</summary>
        private string _sshInBrowserUrl;

        /// <summary>URL for connecting via SSH protocol to the virtual machine in browser.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        public string SshInBrowserUrl { get => this._sshInBrowserUrl; }

        /// <summary>Creates an new <see cref="VirtualMachineConnectionProfile" /> instance.</summary>
        public VirtualMachineConnectionProfile()
        {

        }
    }
    /// The connection information for the virtual machine
    public partial interface IVirtualMachineConnectionProfile :
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.IJsonSerializable
    {
        /// <summary>The username used to log on to the virtual machine as admin.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The username used to log on to the virtual machine as admin.",
        SerializedName = @"adminUsername",
        PossibleTypes = new [] { typeof(string) })]
        string AdminUsername { get;  }
        /// <summary>The username used to log on to the virtual machine as non-admin, if one exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The username used to log on to the virtual machine as non-admin, if one exists.",
        SerializedName = @"nonAdminUsername",
        PossibleTypes = new [] { typeof(string) })]
        string NonAdminUsername { get;  }
        /// <summary>The private IP address of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The private IP address of the virtual machine.",
        SerializedName = @"privateIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get;  }
        /// <summary>
        /// Port and host name separated by semicolon for connecting via RDP protocol to the virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Port and host name separated by semicolon for connecting via RDP protocol to the virtual machine.",
        SerializedName = @"rdpAuthority",
        PossibleTypes = new [] { typeof(string) })]
        string RdpAuthority { get;  }
        /// <summary>URL for connecting via RDP protocol to the virtual machine in browser.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL for connecting via RDP protocol to the virtual machine in browser.",
        SerializedName = @"rdpInBrowserUrl",
        PossibleTypes = new [] { typeof(string) })]
        string RdpInBrowserUrl { get;  }
        /// <summary>
        /// Port and host name separated by semicolon for connecting via SSH protocol to the virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Port and host name separated by semicolon for connecting via SSH protocol to the virtual machine.",
        SerializedName = @"sshAuthority",
        PossibleTypes = new [] { typeof(string) })]
        string SshAuthority { get;  }
        /// <summary>URL for connecting via SSH protocol to the virtual machine in browser.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL for connecting via SSH protocol to the virtual machine in browser.",
        SerializedName = @"sshInBrowserUrl",
        PossibleTypes = new [] { typeof(string) })]
        string SshInBrowserUrl { get;  }

    }
    /// The connection information for the virtual machine
    internal partial interface IVirtualMachineConnectionProfileInternal

    {
        /// <summary>The username used to log on to the virtual machine as admin.</summary>
        string AdminUsername { get; set; }
        /// <summary>The username used to log on to the virtual machine as non-admin, if one exists.</summary>
        string NonAdminUsername { get; set; }
        /// <summary>The private IP address of the virtual machine.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>
        /// Port and host name separated by semicolon for connecting via RDP protocol to the virtual machine.
        /// </summary>
        string RdpAuthority { get; set; }
        /// <summary>URL for connecting via RDP protocol to the virtual machine in browser.</summary>
        string RdpInBrowserUrl { get; set; }
        /// <summary>
        /// Port and host name separated by semicolon for connecting via SSH protocol to the virtual machine.
        /// </summary>
        string SshAuthority { get; set; }
        /// <summary>URL for connecting via SSH protocol to the virtual machine in browser.</summary>
        string SshInBrowserUrl { get; set; }

    }
}