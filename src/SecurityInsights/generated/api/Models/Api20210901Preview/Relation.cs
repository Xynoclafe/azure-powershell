// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Extensions;

    /// <summary>Represents a relation between two resources</summary>
    public partial class Relation :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelation,
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20.IResourceWithEtag"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20.IResourceWithEtag __resourceWithEtag = new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20.ResourceWithEtag();

        /// <summary>Etag of the azure resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public string Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20.IResourceWithEtagInternal)__resourceWithEtag).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20.IResourceWithEtagInternal)__resourceWithEtag).Etag = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Id; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationProperties Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.RelationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RelatedResourceKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationInternal.RelatedResourceKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceKind = value; }

        /// <summary>Internal Acessors for RelatedResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationInternal.RelatedResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceName = value; }

        /// <summary>Internal Acessors for RelatedResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationInternal.RelatedResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceType = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.ISystemData Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationProperties _property;

        /// <summary>Relation properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.RelationProperties()); set => this._property = value; }

        /// <summary>The resource ID of the related resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string RelatedResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceId = value ?? null; }

        /// <summary>The resource kind of the related resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string RelatedResourceKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceKind; }

        /// <summary>The name of the related resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string RelatedResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceName; }

        /// <summary>The resource type of the related resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string RelatedResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationPropertiesInternal)Property).RelatedResourceType; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemData; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataCreatedBy = value ?? null; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataCreatedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.CreatedByType)""); }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.CreatedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).SystemDataLastModifiedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.CreatedByType)""); }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api30.IResourceInternal)__resourceWithEtag).Type; }

        /// <summary>Creates an new <see cref="Relation" /> instance.</summary>
        public Relation()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resourceWithEtag), __resourceWithEtag);
            await eventListener.AssertObjectIsValid(nameof(__resourceWithEtag), __resourceWithEtag);
        }
    }
    /// Represents a relation between two resources
    public partial interface IRelation :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20.IResourceWithEtag
    {
        /// <summary>The resource ID of the related resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource ID of the related resource",
        SerializedName = @"relatedResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string RelatedResourceId { get; set; }
        /// <summary>The resource kind of the related resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource kind of the related resource",
        SerializedName = @"relatedResourceKind",
        PossibleTypes = new [] { typeof(string) })]
        string RelatedResourceKind { get;  }
        /// <summary>The name of the related resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the related resource",
        SerializedName = @"relatedResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string RelatedResourceName { get;  }
        /// <summary>The resource type of the related resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource type of the related resource",
        SerializedName = @"relatedResourceType",
        PossibleTypes = new [] { typeof(string) })]
        string RelatedResourceType { get;  }

    }
    /// Represents a relation between two resources
    internal partial interface IRelationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20.IResourceWithEtagInternal
    {
        /// <summary>Relation properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelationProperties Property { get; set; }
        /// <summary>The resource ID of the related resource</summary>
        string RelatedResourceId { get; set; }
        /// <summary>The resource kind of the related resource</summary>
        string RelatedResourceKind { get; set; }
        /// <summary>The name of the related resource</summary>
        string RelatedResourceName { get; set; }
        /// <summary>The resource type of the related resource</summary>
        string RelatedResourceType { get; set; }

    }
}