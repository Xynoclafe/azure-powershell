// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>The properties of a cluster</summary>
    public partial class ClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.IClusterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.IClusterPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterProperties __commonClusterProperties = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.CommonClusterProperties();

        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public int? ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).ClusterId; }

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public int? ClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).ClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).ClusterSize = value ?? default(int); }

        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string[] Host { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).Host; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).Host = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ClusterId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal.ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).ClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).ClusterId = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).ProvisioningState = value; }

        /// <summary>The state of the cluster provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal)__commonClusterProperties).ProvisioningState; }

        /// <summary>Creates an new <see cref="ClusterProperties" /> instance.</summary>
        public ClusterProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__commonClusterProperties), __commonClusterProperties);
            await eventListener.AssertObjectIsValid(nameof(__commonClusterProperties), __commonClusterProperties);
        }
    }
    /// The properties of a cluster
    public partial interface IClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterProperties
    {

    }
    /// The properties of a cluster
    internal partial interface IClusterPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ICommonClusterPropertiesInternal
    {

    }
}