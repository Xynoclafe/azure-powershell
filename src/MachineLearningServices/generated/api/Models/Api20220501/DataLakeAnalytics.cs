// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Extensions;

    /// <summary>A DataLakeAnalytics compute.</summary>
    public partial class DataLakeAnalytics :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalytics,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.ICompute"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.ICompute __compute = new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.Compute();

        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchema"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchema __dataLakeAnalyticsSchema = new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.DataLakeAnalyticsSchema();

        /// <summary>The time at which the compute was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public global::System.DateTime? CreatedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).CreatedOn; }

        /// <summary>DataLake Store Account Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string DataLakeStoreAccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchemaInternal)__dataLakeAnalyticsSchema).DataLakeStoreAccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchemaInternal)__dataLakeAnalyticsSchema).DataLakeStoreAccountName = value ?? null; }

        /// <summary>The description of the Machine Learning compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).Description = value ?? null; }

        /// <summary>
        /// Opt-out of local authentication and ensure customers can use only MSI and AAD exclusively for authentication.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public bool? DisableLocalAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).DisableLocalAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).DisableLocalAuth = value ?? default(bool); }

        /// <summary>
        /// Indicating whether the compute was provisioned by user and brought from outside if true, or machine learning service provisioned
        /// it if false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public bool? IsAttachedCompute { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).IsAttachedCompute; }

        /// <summary>Location for the underlying compute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).Location; }

        /// <summary>Internal Acessors for CreatedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal.CreatedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).CreatedOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).CreatedOn = value; }

        /// <summary>Internal Acessors for IsAttachedCompute</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal.IsAttachedCompute { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).IsAttachedCompute; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).IsAttachedCompute = value; }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal.Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).Location = value; }

        /// <summary>Internal Acessors for ModifiedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal.ModifiedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ModifiedOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ModifiedOn = value; }

        /// <summary>Internal Acessors for ProvisioningError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api30.IErrorResponse[] Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal.ProvisioningError { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ProvisioningError; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ProvisioningError = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ProvisioningState = value; }

        /// <summary>The time at which the compute was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public global::System.DateTime? ModifiedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ModifiedOn; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchemaProperties Property { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchemaInternal)__dataLakeAnalyticsSchema).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchemaInternal)__dataLakeAnalyticsSchema).Property = value ?? null /* model class */; }

        /// <summary>Errors during provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api30.IErrorResponse[] ProvisioningError { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ProvisioningError; }

        /// <summary>
        /// The provision state of the cluster. Valid values are Unknown, Updating, Provisioning, Succeeded, and Failed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ProvisioningState; }

        /// <summary>ARM resource id of the underlying compute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string ResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).ResourceId = value ?? null; }

        /// <summary>The type of compute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ComputeType Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal)__compute).Type = value ; }

        /// <summary>Creates an new <see cref="DataLakeAnalytics" /> instance.</summary>
        public DataLakeAnalytics()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__compute), __compute);
            await eventListener.AssertObjectIsValid(nameof(__compute), __compute);
            await eventListener.AssertNotNull(nameof(__dataLakeAnalyticsSchema), __dataLakeAnalyticsSchema);
            await eventListener.AssertObjectIsValid(nameof(__dataLakeAnalyticsSchema), __dataLakeAnalyticsSchema);
        }
    }
    /// A DataLakeAnalytics compute.
    public partial interface IDataLakeAnalytics :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.ICompute,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchema
    {

    }
    /// A DataLakeAnalytics compute.
    internal partial interface IDataLakeAnalyticsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IComputeInternal,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDataLakeAnalyticsSchemaInternal
    {

    }
}