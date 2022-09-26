// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Extensions;

    /// <summary>A lab virtual machine resource.</summary>
    public partial class VirtualMachine :
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine,
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal,
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.Resource();

        /// <summary>The lab user ID (not the PUID!) of who claimed the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string ClaimedByUserId { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ClaimedByUserId; }

        /// <summary>The username used to log on to the virtual machine as admin.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string ConnectionProfileAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileAdminUsername; }

        /// <summary>The username used to log on to the virtual machine as non-admin, if one exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string ConnectionProfileNonAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileNonAdminUsername; }

        /// <summary>The private IP address of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string ConnectionProfilePrivateIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfilePrivateIPAddress; }

        /// <summary>
        /// Port and host name separated by semicolon for connecting via RDP protocol to the virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string ConnectionProfileRdpAuthority { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileRdpAuthority; }

        /// <summary>URL for connecting via RDP protocol to the virtual machine in browser.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string ConnectionProfileRdpInBrowserUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileRdpInBrowserUrl; }

        /// <summary>
        /// Port and host name separated by semicolon for connecting via SSH protocol to the virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string ConnectionProfileSshAuthority { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileSshAuthority; }

        /// <summary>URL for connecting via SSH protocol to the virtual machine in browser.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string ConnectionProfileSshInBrowserUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileSshInBrowserUrl; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for ClaimedByUserId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ClaimedByUserId { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ClaimedByUserId; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ClaimedByUserId = value; }

        /// <summary>Internal Acessors for ConnectionProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfile Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ConnectionProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfile = value; }

        /// <summary>Internal Acessors for ConnectionProfileAdminUsername</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ConnectionProfileAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileAdminUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileAdminUsername = value; }

        /// <summary>Internal Acessors for ConnectionProfileNonAdminUsername</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ConnectionProfileNonAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileNonAdminUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileNonAdminUsername = value; }

        /// <summary>Internal Acessors for ConnectionProfilePrivateIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ConnectionProfilePrivateIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfilePrivateIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfilePrivateIPAddress = value; }

        /// <summary>Internal Acessors for ConnectionProfileRdpAuthority</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ConnectionProfileRdpAuthority { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileRdpAuthority; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileRdpAuthority = value; }

        /// <summary>Internal Acessors for ConnectionProfileRdpInBrowserUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ConnectionProfileRdpInBrowserUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileRdpInBrowserUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileRdpInBrowserUrl = value; }

        /// <summary>Internal Acessors for ConnectionProfileSshAuthority</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ConnectionProfileSshAuthority { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileSshAuthority; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileSshAuthority = value; }

        /// <summary>Internal Acessors for ConnectionProfileSshInBrowserUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ConnectionProfileSshInBrowserUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileSshInBrowserUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ConnectionProfileSshInBrowserUrl = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineProperties Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.VirtualMachineProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState? Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.State { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).State = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemData Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.SystemData()); set { {_systemData = value;} } }

        /// <summary>Internal Acessors for VMType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineType? Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineInternal.VMType { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).VMType; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).VMType = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineProperties _property;

        /// <summary>Virtual machine resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.VirtualMachineProperties()); set => this._property = value; }

        /// <summary>Current provisioning state of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningState; }

        /// <summary>The current state of the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState? State { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).State; }

        /// <summary>Backing field for <see cref="SystemData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemData _systemData;

        /// <summary>System data of the Lab virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemData SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.SystemData()); }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).CreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).CreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).CreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).CreatedBy = value ?? null; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).CreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).CreatedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType)""); }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy = value ?? null; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType)""); }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal)__resource).Type; }

        /// <summary>The type of this VM resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.LabServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineType? VMType { get => ((Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachinePropertiesInternal)Property).VMType; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }

        /// <summary>Creates an new <see cref="VirtualMachine" /> instance.</summary>
        public VirtualMachine()
        {

        }
    }
    /// A lab virtual machine resource.
    public partial interface IVirtualMachine :
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResource
    {
        /// <summary>The lab user ID (not the PUID!) of who claimed the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The lab user ID (not the PUID!) of who claimed the virtual machine.",
        SerializedName = @"claimedByUserId",
        PossibleTypes = new [] { typeof(string) })]
        string ClaimedByUserId { get;  }
        /// <summary>The username used to log on to the virtual machine as admin.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The username used to log on to the virtual machine as admin.",
        SerializedName = @"adminUsername",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionProfileAdminUsername { get;  }
        /// <summary>The username used to log on to the virtual machine as non-admin, if one exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The username used to log on to the virtual machine as non-admin, if one exists.",
        SerializedName = @"nonAdminUsername",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionProfileNonAdminUsername { get;  }
        /// <summary>The private IP address of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The private IP address of the virtual machine.",
        SerializedName = @"privateIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionProfilePrivateIPAddress { get;  }
        /// <summary>
        /// Port and host name separated by semicolon for connecting via RDP protocol to the virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Port and host name separated by semicolon for connecting via RDP protocol to the virtual machine.",
        SerializedName = @"rdpAuthority",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionProfileRdpAuthority { get;  }
        /// <summary>URL for connecting via RDP protocol to the virtual machine in browser.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL for connecting via RDP protocol to the virtual machine in browser.",
        SerializedName = @"rdpInBrowserUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionProfileRdpInBrowserUrl { get;  }
        /// <summary>
        /// Port and host name separated by semicolon for connecting via SSH protocol to the virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Port and host name separated by semicolon for connecting via SSH protocol to the virtual machine.",
        SerializedName = @"sshAuthority",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionProfileSshAuthority { get;  }
        /// <summary>URL for connecting via SSH protocol to the virtual machine in browser.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL for connecting via SSH protocol to the virtual machine in browser.",
        SerializedName = @"sshInBrowserUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionProfileSshInBrowserUrl { get;  }
        /// <summary>Current provisioning state of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current provisioning state of the virtual machine.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The current state of the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current state of the virtual machine",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState) })]
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState? State { get;  }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource creation (UTC).",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that created the resource.",
        SerializedName = @"createdBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that created the resource.",
        SerializedName = @"createdByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource last modification (UTC)",
        SerializedName = @"lastModifiedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that last modified the resource.",
        SerializedName = @"lastModifiedBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that last modified the resource.",
        SerializedName = @"lastModifiedByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>The type of this VM resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of this VM resource",
        SerializedName = @"vmType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineType) })]
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineType? VMType { get;  }

    }
    /// A lab virtual machine resource.
    internal partial interface IVirtualMachineInternal :
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.IResourceInternal
    {
        /// <summary>The lab user ID (not the PUID!) of who claimed the virtual machine.</summary>
        string ClaimedByUserId { get; set; }
        /// <summary>Profile for information about connecting to the virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineConnectionProfile ConnectionProfile { get; set; }
        /// <summary>The username used to log on to the virtual machine as admin.</summary>
        string ConnectionProfileAdminUsername { get; set; }
        /// <summary>The username used to log on to the virtual machine as non-admin, if one exists.</summary>
        string ConnectionProfileNonAdminUsername { get; set; }
        /// <summary>The private IP address of the virtual machine.</summary>
        string ConnectionProfilePrivateIPAddress { get; set; }
        /// <summary>
        /// Port and host name separated by semicolon for connecting via RDP protocol to the virtual machine.
        /// </summary>
        string ConnectionProfileRdpAuthority { get; set; }
        /// <summary>URL for connecting via RDP protocol to the virtual machine in browser.</summary>
        string ConnectionProfileRdpInBrowserUrl { get; set; }
        /// <summary>
        /// Port and host name separated by semicolon for connecting via SSH protocol to the virtual machine.
        /// </summary>
        string ConnectionProfileSshAuthority { get; set; }
        /// <summary>URL for connecting via SSH protocol to the virtual machine in browser.</summary>
        string ConnectionProfileSshInBrowserUrl { get; set; }
        /// <summary>Virtual machine resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachineProperties Property { get; set; }
        /// <summary>Current provisioning state of the virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The current state of the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineState? State { get; set; }
        /// <summary>System data of the Lab virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20.ISystemData SystemData { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>The type of this VM resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.VirtualMachineType? VMType { get; set; }

    }
}