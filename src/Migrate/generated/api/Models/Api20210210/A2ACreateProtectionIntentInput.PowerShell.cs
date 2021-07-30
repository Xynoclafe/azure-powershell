namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>A2A create protection intent input.</summary>
    [System.ComponentModel.TypeConverter(typeof(A2ACreateProtectionIntentInputTypeConverter))]
    public partial class A2ACreateProtectionIntentInput
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.A2ACreateProtectionIntentInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal A2ACreateProtectionIntentInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).ProtectionProfileCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IProtectionProfileCustomDetails) content.GetValueForProperty("ProtectionProfileCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).ProtectionProfileCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.ProtectionProfileCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryStagingStorageAccountCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IStorageAccountCustomDetails) content.GetValueForProperty("PrimaryStagingStorageAccountCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryStagingStorageAccountCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.StorageAccountCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilitySetCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryAvailabilitySetCustomDetails) content.GetValueForProperty("RecoveryAvailabilitySetCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilitySetCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.RecoveryAvailabilitySetCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryVirtualNetworkCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryVirtualNetworkCustomDetails) content.GetValueForProperty("RecoveryVirtualNetworkCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryVirtualNetworkCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.RecoveryVirtualNetworkCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryProximityPlacementGroupCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryProximityPlacementGroupCustomDetails) content.GetValueForProperty("RecoveryProximityPlacementGroupCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryProximityPlacementGroupCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.RecoveryProximityPlacementGroupCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryBootDiagStorageAccount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IStorageAccountCustomDetails) content.GetValueForProperty("RecoveryBootDiagStorageAccount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryBootDiagStorageAccount, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.StorageAccountCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IDiskEncryptionInfo) content.GetValueForProperty("DiskEncryptionInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.DiskEncryptionInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).FabricObjectId = (string) content.GetValueForProperty("FabricObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).FabricObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryLocation = (string) content.GetValueForProperty("PrimaryLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryLocation = (string) content.GetValueForProperty("RecoveryLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoverySubscriptionId = (string) content.GetValueForProperty("RecoverySubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoverySubscriptionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilityType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARecoveryAvailabilityType) content.GetValueForProperty("RecoveryAvailabilityType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilityType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARecoveryAvailabilityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryResourceGroupId = (string) content.GetValueForProperty("RecoveryResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).AutoProtectionOfDataDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AutoProtectionOfDataDisk?) content.GetValueForProperty("AutoProtectionOfDataDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).AutoProtectionOfDataDisk, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AutoProtectionOfDataDisk.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).VMDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AProtectionIntentDiskInputDetails[]) content.GetValueForProperty("VMDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).VMDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AProtectionIntentDiskInputDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.A2AProtectionIntentDiskInputDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).VMManagedDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AProtectionIntentManagedDiskInputDetails[]) content.GetValueForProperty("VMManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).VMManagedDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AProtectionIntentManagedDiskInputDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.A2AProtectionIntentManagedDiskInputDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).MultiVMGroupName = (string) content.GetValueForProperty("MultiVMGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).MultiVMGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).MultiVMGroupId = (string) content.GetValueForProperty("MultiVMGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).MultiVMGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilityZone = (string) content.GetValueForProperty("RecoveryAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilityZone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.ICreateProtectionIntentProviderSpecificDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.ICreateProtectionIntentProviderSpecificDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).ProtectionProfileCustomInputResourceType = (string) content.GetValueForProperty("ProtectionProfileCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).ProtectionProfileCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryStagingStorageAccountCustomInputResourceType = (string) content.GetValueForProperty("PrimaryStagingStorageAccountCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryStagingStorageAccountCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilitySetCustomInputResourceType = (string) content.GetValueForProperty("RecoveryAvailabilitySetCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilitySetCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryVirtualNetworkCustomInputResourceType = (string) content.GetValueForProperty("RecoveryVirtualNetworkCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryVirtualNetworkCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryProximityPlacementGroupCustomInputResourceType = (string) content.GetValueForProperty("RecoveryProximityPlacementGroupCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryProximityPlacementGroupCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryBootDiagStorageAccountResourceType = (string) content.GetValueForProperty("RecoveryBootDiagStorageAccountResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryBootDiagStorageAccountResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfoDiskEncryptionKeyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IDiskEncryptionKeyInfo) content.GetValueForProperty("DiskEncryptionInfoDiskEncryptionKeyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfoDiskEncryptionKeyInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.DiskEncryptionKeyInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfoKeyEncryptionKeyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IKeyEncryptionKeyInfo) content.GetValueForProperty("DiskEncryptionInfoKeyEncryptionKeyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfoKeyEncryptionKeyInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.KeyEncryptionKeyInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionKeyInfoSecretIdentifier = (string) content.GetValueForProperty("DiskEncryptionKeyInfoSecretIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionKeyInfoSecretIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).KeyEncryptionKeyInfoKeyIdentifier = (string) content.GetValueForProperty("KeyEncryptionKeyInfoKeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).KeyEncryptionKeyInfoKeyIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionKeyInfoKeyVaultResourceArmId = (string) content.GetValueForProperty("DiskEncryptionKeyInfoKeyVaultResourceArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionKeyInfoKeyVaultResourceArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).KeyEncryptionKeyInfoKeyVaultResourceArmId = (string) content.GetValueForProperty("KeyEncryptionKeyInfoKeyVaultResourceArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).KeyEncryptionKeyInfoKeyVaultResourceArmId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.A2ACreateProtectionIntentInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal A2ACreateProtectionIntentInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).ProtectionProfileCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IProtectionProfileCustomDetails) content.GetValueForProperty("ProtectionProfileCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).ProtectionProfileCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.ProtectionProfileCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryStagingStorageAccountCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IStorageAccountCustomDetails) content.GetValueForProperty("PrimaryStagingStorageAccountCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryStagingStorageAccountCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.StorageAccountCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilitySetCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryAvailabilitySetCustomDetails) content.GetValueForProperty("RecoveryAvailabilitySetCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilitySetCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.RecoveryAvailabilitySetCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryVirtualNetworkCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryVirtualNetworkCustomDetails) content.GetValueForProperty("RecoveryVirtualNetworkCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryVirtualNetworkCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.RecoveryVirtualNetworkCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryProximityPlacementGroupCustomInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryProximityPlacementGroupCustomDetails) content.GetValueForProperty("RecoveryProximityPlacementGroupCustomInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryProximityPlacementGroupCustomInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.RecoveryProximityPlacementGroupCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryBootDiagStorageAccount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IStorageAccountCustomDetails) content.GetValueForProperty("RecoveryBootDiagStorageAccount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryBootDiagStorageAccount, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.StorageAccountCustomDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IDiskEncryptionInfo) content.GetValueForProperty("DiskEncryptionInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.DiskEncryptionInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).FabricObjectId = (string) content.GetValueForProperty("FabricObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).FabricObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryLocation = (string) content.GetValueForProperty("PrimaryLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryLocation = (string) content.GetValueForProperty("RecoveryLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoverySubscriptionId = (string) content.GetValueForProperty("RecoverySubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoverySubscriptionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilityType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARecoveryAvailabilityType) content.GetValueForProperty("RecoveryAvailabilityType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilityType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.A2ARecoveryAvailabilityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryResourceGroupId = (string) content.GetValueForProperty("RecoveryResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).AutoProtectionOfDataDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AutoProtectionOfDataDisk?) content.GetValueForProperty("AutoProtectionOfDataDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).AutoProtectionOfDataDisk, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AutoProtectionOfDataDisk.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).VMDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AProtectionIntentDiskInputDetails[]) content.GetValueForProperty("VMDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).VMDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AProtectionIntentDiskInputDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.A2AProtectionIntentDiskInputDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).VMManagedDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AProtectionIntentManagedDiskInputDetails[]) content.GetValueForProperty("VMManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).VMManagedDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2AProtectionIntentManagedDiskInputDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.A2AProtectionIntentManagedDiskInputDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).MultiVMGroupName = (string) content.GetValueForProperty("MultiVMGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).MultiVMGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).MultiVMGroupId = (string) content.GetValueForProperty("MultiVMGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).MultiVMGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilityZone = (string) content.GetValueForProperty("RecoveryAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilityZone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.ICreateProtectionIntentProviderSpecificDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.ICreateProtectionIntentProviderSpecificDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).ProtectionProfileCustomInputResourceType = (string) content.GetValueForProperty("ProtectionProfileCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).ProtectionProfileCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryStagingStorageAccountCustomInputResourceType = (string) content.GetValueForProperty("PrimaryStagingStorageAccountCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).PrimaryStagingStorageAccountCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilitySetCustomInputResourceType = (string) content.GetValueForProperty("RecoveryAvailabilitySetCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryAvailabilitySetCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryVirtualNetworkCustomInputResourceType = (string) content.GetValueForProperty("RecoveryVirtualNetworkCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryVirtualNetworkCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryProximityPlacementGroupCustomInputResourceType = (string) content.GetValueForProperty("RecoveryProximityPlacementGroupCustomInputResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryProximityPlacementGroupCustomInputResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryBootDiagStorageAccountResourceType = (string) content.GetValueForProperty("RecoveryBootDiagStorageAccountResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).RecoveryBootDiagStorageAccountResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfoDiskEncryptionKeyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IDiskEncryptionKeyInfo) content.GetValueForProperty("DiskEncryptionInfoDiskEncryptionKeyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfoDiskEncryptionKeyInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.DiskEncryptionKeyInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfoKeyEncryptionKeyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IKeyEncryptionKeyInfo) content.GetValueForProperty("DiskEncryptionInfoKeyEncryptionKeyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionInfoKeyEncryptionKeyInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.KeyEncryptionKeyInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionKeyInfoSecretIdentifier = (string) content.GetValueForProperty("DiskEncryptionKeyInfoSecretIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionKeyInfoSecretIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).KeyEncryptionKeyInfoKeyIdentifier = (string) content.GetValueForProperty("KeyEncryptionKeyInfoKeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).KeyEncryptionKeyInfoKeyIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionKeyInfoKeyVaultResourceArmId = (string) content.GetValueForProperty("DiskEncryptionKeyInfoKeyVaultResourceArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).DiskEncryptionKeyInfoKeyVaultResourceArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).KeyEncryptionKeyInfoKeyVaultResourceArmId = (string) content.GetValueForProperty("KeyEncryptionKeyInfoKeyVaultResourceArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInputInternal)this).KeyEncryptionKeyInfoKeyVaultResourceArmId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.A2ACreateProtectionIntentInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new A2ACreateProtectionIntentInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.A2ACreateProtectionIntentInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new A2ACreateProtectionIntentInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="A2ACreateProtectionIntentInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IA2ACreateProtectionIntentInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A2A create protection intent input.
    [System.ComponentModel.TypeConverter(typeof(A2ACreateProtectionIntentInputTypeConverter))]
    public partial interface IA2ACreateProtectionIntentInput

    {

    }
}