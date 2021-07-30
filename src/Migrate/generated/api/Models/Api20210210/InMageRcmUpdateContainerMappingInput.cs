namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMageRcm update protection container mapping.</summary>
    public partial class InMageRcmUpdateContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmUpdateContainerMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmUpdateContainerMappingInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IReplicationProviderSpecificUpdateContainerMappingInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IReplicationProviderSpecificUpdateContainerMappingInput __replicationProviderSpecificUpdateContainerMappingInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.ReplicationProviderSpecificUpdateContainerMappingInput();

        /// <summary>Backing field for <see cref="EnableAgentAutoUpgrade" /> property.</summary>
        private string _enableAgentAutoUpgrade;

        /// <summary>A value indicating whether agent auto upgrade has to be enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnableAgentAutoUpgrade { get => this._enableAgentAutoUpgrade; set => this._enableAgentAutoUpgrade = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IReplicationProviderSpecificUpdateContainerMappingInputInternal)__replicationProviderSpecificUpdateContainerMappingInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IReplicationProviderSpecificUpdateContainerMappingInputInternal)__replicationProviderSpecificUpdateContainerMappingInput).InstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="InMageRcmUpdateContainerMappingInput" /> instance.</summary>
        public InMageRcmUpdateContainerMappingInput()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__replicationProviderSpecificUpdateContainerMappingInput), __replicationProviderSpecificUpdateContainerMappingInput);
            await eventListener.AssertObjectIsValid(nameof(__replicationProviderSpecificUpdateContainerMappingInput), __replicationProviderSpecificUpdateContainerMappingInput);
        }
    }
    /// InMageRcm update protection container mapping.
    public partial interface IInMageRcmUpdateContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IReplicationProviderSpecificUpdateContainerMappingInput
    {
        /// <summary>A value indicating whether agent auto upgrade has to be enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A value indicating whether agent auto upgrade has to be enabled.",
        SerializedName = @"enableAgentAutoUpgrade",
        PossibleTypes = new [] { typeof(string) })]
        string EnableAgentAutoUpgrade { get; set; }

    }
    /// InMageRcm update protection container mapping.
    internal partial interface IInMageRcmUpdateContainerMappingInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IReplicationProviderSpecificUpdateContainerMappingInputInternal
    {
        /// <summary>A value indicating whether agent auto upgrade has to be enabled.</summary>
        string EnableAgentAutoUpgrade { get; set; }

    }
}