namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Existing recovery proximity placement group input.</summary>
    public partial class ExistingRecoveryProximityPlacementGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IExistingRecoveryProximityPlacementGroup,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IExistingRecoveryProximityPlacementGroupInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryProximityPlacementGroupCustomDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryProximityPlacementGroupCustomDetails __recoveryProximityPlacementGroupCustomDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.RecoveryProximityPlacementGroupCustomDetails();

        /// <summary>Backing field for <see cref="RecoveryProximityPlacementGroupId" /> property.</summary>
        private string _recoveryProximityPlacementGroupId;

        /// <summary>
        /// The recovery proximity placement group Id. Will throw error, if resource does not exist.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryProximityPlacementGroupId { get => this._recoveryProximityPlacementGroupId; set => this._recoveryProximityPlacementGroupId = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string ResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryProximityPlacementGroupCustomDetailsInternal)__recoveryProximityPlacementGroupCustomDetails).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryProximityPlacementGroupCustomDetailsInternal)__recoveryProximityPlacementGroupCustomDetails).ResourceType = value ?? null; }

        /// <summary>Creates an new <see cref="ExistingRecoveryProximityPlacementGroup" /> instance.</summary>
        public ExistingRecoveryProximityPlacementGroup()
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
            await eventListener.AssertNotNull(nameof(__recoveryProximityPlacementGroupCustomDetails), __recoveryProximityPlacementGroupCustomDetails);
            await eventListener.AssertObjectIsValid(nameof(__recoveryProximityPlacementGroupCustomDetails), __recoveryProximityPlacementGroupCustomDetails);
        }
    }
    /// Existing recovery proximity placement group input.
    public partial interface IExistingRecoveryProximityPlacementGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryProximityPlacementGroupCustomDetails
    {
        /// <summary>
        /// The recovery proximity placement group Id. Will throw error, if resource does not exist.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery proximity placement group Id. Will throw error, if resource does not exist.",
        SerializedName = @"recoveryProximityPlacementGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryProximityPlacementGroupId { get; set; }

    }
    /// Existing recovery proximity placement group input.
    internal partial interface IExistingRecoveryProximityPlacementGroupInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IRecoveryProximityPlacementGroupCustomDetailsInternal
    {
        /// <summary>
        /// The recovery proximity placement group Id. Will throw error, if resource does not exist.
        /// </summary>
        string RecoveryProximityPlacementGroupId { get; set; }

    }
}