// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Security.Models
{
    using System.Linq;

    /// <summary>
    /// describes the custom entity store assignment properties
    /// </summary>
    public partial class CustomEntityStoreAssignmentProperties
    {
        /// <summary>
        /// Initializes a new instance of the CustomEntityStoreAssignmentProperties class.
        /// </summary>
        public CustomEntityStoreAssignmentProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CustomEntityStoreAssignmentProperties class.
        /// </summary>

        /// <param name="principal">The principal assigned with entity store. Format of principal is: [AAD
        /// type]=[PrincipalObjectId];[TenantId]
        /// </param>

        /// <param name="entityStoreDatabaseLink">The link to entity store database.
        /// </param>
        public CustomEntityStoreAssignmentProperties(string principal = default(string), string entityStoreDatabaseLink = default(string))

        {
            this.Principal = principal;
            this.EntityStoreDatabaseLink = entityStoreDatabaseLink;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the principal assigned with entity store. Format of principal
        /// is: [AAD type]=[PrincipalObjectId];[TenantId]
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "principal")]
        public string Principal {get; set; }

        /// <summary>
        /// Gets or sets the link to entity store database.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "entityStoreDatabaseLink")]
        public string EntityStoreDatabaseLink {get; set; }
    }
}