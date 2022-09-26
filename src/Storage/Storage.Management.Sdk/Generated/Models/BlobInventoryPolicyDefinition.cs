// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Storage.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An object that defines the blob inventory rule.
    /// </summary>
    public partial class BlobInventoryPolicyDefinition
    {
        /// <summary>
        /// Initializes a new instance of the BlobInventoryPolicyDefinition
        /// class.
        /// </summary>
        public BlobInventoryPolicyDefinition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlobInventoryPolicyDefinition
        /// class.
        /// </summary>
        /// <param name="format">This is a required field, it specifies the
        /// format for the inventory files. Possible values include: 'Csv',
        /// 'Parquet'</param>
        /// <param name="schedule">This is a required field. This field is used
        /// to schedule an inventory formation. Possible values include:
        /// 'Daily', 'Weekly'</param>
        /// <param name="objectType">This is a required field. This field
        /// specifies the scope of the inventory created either at the blob or
        /// container level. Possible values include: 'Blob',
        /// 'Container'</param>
        /// <param name="schemaFields">This is a required field. This field
        /// specifies the fields and properties of the object to be included in
        /// the inventory. The Schema field value 'Name' is always required.
        /// The valid values for this field for the 'Blob'
        /// definition.objectType include 'Name, Creation-Time, Last-Modified,
        /// Content-Length, Content-MD5, BlobType, AccessTier,
        /// AccessTierChangeTime, AccessTierInferred, Tags, Expiry-Time,
        /// hdi_isfolder, Owner, Group, Permissions, Acl, Snapshot, VersionId,
        /// IsCurrentVersion, Metadata, LastAccessTime, Tags, Etag,
        /// ContentType, ContentEncoding, ContentLanguage, ContentCRC64,
        /// CacheControl, ContentDisposition, LeaseStatus, LeaseState,
        /// LeaseDuration, ServerEncrypted, Deleted, DeletionId, DeletedTime,
        /// RemainingRetentionDays, ImmutabilityPolicyUntilDate,
        /// ImmutabilityPolicyMode, LegalHold, CopyId, CopyStatus, CopySource,
        /// CopyProgress, CopyCompletionTime, CopyStatusDescription,
        /// CustomerProvidedKeySha256, RehydratePriority, ArchiveStatus,
        /// XmsBlobSequenceNumber, EncryptionScope, IncrementalCopy, TagCount'.
        /// For Blob object type schema field value 'DeletedTime' is applicable
        /// only for Hns enabled accounts. The valid values for 'Container'
        /// definition.objectType include 'Name, Last-Modified, Metadata,
        /// LeaseStatus, LeaseState, LeaseDuration, PublicAccess,
        /// HasImmutabilityPolicy, HasLegalHold, Etag, DefaultEncryptionScope,
        /// DenyEncryptionScopeOverride, ImmutableStorageWithVersioningEnabled,
        /// Deleted, Version, DeletedTime, RemainingRetentionDays'. Schema
        /// field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions,
        /// Acl, DeletionId' are valid only for Hns enabled accounts.Schema
        /// field values 'Tags, TagCount' are only valid for Non-Hns
        /// accounts.</param>
        /// <param name="filters">An object that defines the filter
        /// set.</param>
        public BlobInventoryPolicyDefinition(string format, string schedule, string objectType, IList<string> schemaFields, BlobInventoryPolicyFilter filters = default(BlobInventoryPolicyFilter))
        {
            Filters = filters;
            Format = format;
            Schedule = schedule;
            ObjectType = objectType;
            SchemaFields = schemaFields;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets an object that defines the filter set.
        /// </summary>
        [JsonProperty(PropertyName = "filters")]
        public BlobInventoryPolicyFilter Filters { get; set; }

        /// <summary>
        /// Gets or sets this is a required field, it specifies the format for
        /// the inventory files. Possible values include: 'Csv', 'Parquet'
        /// </summary>
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets this is a required field. This field is used to
        /// schedule an inventory formation. Possible values include: 'Daily',
        /// 'Weekly'
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public string Schedule { get; set; }

        /// <summary>
        /// Gets or sets this is a required field. This field specifies the
        /// scope of the inventory created either at the blob or container
        /// level. Possible values include: 'Blob', 'Container'
        /// </summary>
        [JsonProperty(PropertyName = "objectType")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets this is a required field. This field specifies the
        /// fields and properties of the object to be included in the
        /// inventory. The Schema field value 'Name' is always required. The
        /// valid values for this field for the 'Blob' definition.objectType
        /// include 'Name, Creation-Time, Last-Modified, Content-Length,
        /// Content-MD5, BlobType, AccessTier, AccessTierChangeTime,
        /// AccessTierInferred, Tags, Expiry-Time, hdi_isfolder, Owner, Group,
        /// Permissions, Acl, Snapshot, VersionId, IsCurrentVersion, Metadata,
        /// LastAccessTime, Tags, Etag, ContentType, ContentEncoding,
        /// ContentLanguage, ContentCRC64, CacheControl, ContentDisposition,
        /// LeaseStatus, LeaseState, LeaseDuration, ServerEncrypted, Deleted,
        /// DeletionId, DeletedTime, RemainingRetentionDays,
        /// ImmutabilityPolicyUntilDate, ImmutabilityPolicyMode, LegalHold,
        /// CopyId, CopyStatus, CopySource, CopyProgress, CopyCompletionTime,
        /// CopyStatusDescription, CustomerProvidedKeySha256,
        /// RehydratePriority, ArchiveStatus, XmsBlobSequenceNumber,
        /// EncryptionScope, IncrementalCopy, TagCount'. For Blob object type
        /// schema field value 'DeletedTime' is applicable only for Hns enabled
        /// accounts. The valid values for 'Container' definition.objectType
        /// include 'Name, Last-Modified, Metadata, LeaseStatus, LeaseState,
        /// LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold,
        /// Etag, DefaultEncryptionScope, DenyEncryptionScopeOverride,
        /// ImmutableStorageWithVersioningEnabled, Deleted, Version,
        /// DeletedTime, RemainingRetentionDays'. Schema field values
        /// 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl,
        /// DeletionId' are valid only for Hns enabled accounts.Schema field
        /// values 'Tags, TagCount' are only valid for Non-Hns accounts.
        /// </summary>
        [JsonProperty(PropertyName = "schemaFields")]
        public IList<string> SchemaFields { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Format == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Format");
            }
            if (Schedule == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Schedule");
            }
            if (ObjectType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ObjectType");
            }
            if (SchemaFields == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SchemaFields");
            }
        }
    }
}
