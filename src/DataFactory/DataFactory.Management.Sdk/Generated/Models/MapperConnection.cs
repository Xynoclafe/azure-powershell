// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Source connection details.
    /// </summary>
    public partial class MapperConnection
    {
        /// <summary>
        /// Initializes a new instance of the MapperConnection class.
        /// </summary>
        public MapperConnection()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MapperConnection class.
        /// </summary>
        /// <param name="linkedService">Linked service reference.</param>
        /// <param name="linkedServiceType">Type of the linked service e.g.:
        /// AzureBlobFS.</param>
        /// <param name="isInlineDataset">A boolean indicating whether linked
        /// service is of type inline dataset. Currently only inline datasets
        /// are supported.</param>
        /// <param name="commonDslConnectorProperties">List of name/value pairs
        /// for connection properties.</param>
        public MapperConnection(LinkedServiceReference linkedService = default(LinkedServiceReference), string linkedServiceType = default(string), bool? isInlineDataset = default(bool?), IList<MapperDslConnectorProperties> commonDslConnectorProperties = default(IList<MapperDslConnectorProperties>))
        {
            LinkedService = linkedService;
            LinkedServiceType = linkedServiceType;
            IsInlineDataset = isInlineDataset;
            CommonDslConnectorProperties = commonDslConnectorProperties;
            CustomInit();
        }
        /// <summary>
        /// Static constructor for MapperConnection class.
        /// </summary>
        static MapperConnection()
        {
            Type = "linkedservicetype";
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets linked service reference.
        /// </summary>
        [JsonProperty(PropertyName = "linkedService")]
        public LinkedServiceReference LinkedService { get; set; }

        /// <summary>
        /// Gets or sets type of the linked service e.g.: AzureBlobFS.
        /// </summary>
        [JsonProperty(PropertyName = "linkedServiceType")]
        public string LinkedServiceType { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether linked service is of type
        /// inline dataset. Currently only inline datasets are supported.
        /// </summary>
        [JsonProperty(PropertyName = "isInlineDataset")]
        public bool? IsInlineDataset { get; set; }

        /// <summary>
        /// Gets or sets list of name/value pairs for connection properties.
        /// </summary>
        [JsonProperty(PropertyName = "commonDslConnectorProperties")]
        public IList<MapperDslConnectorProperties> CommonDslConnectorProperties { get; set; }

        /// <summary>
        /// Type of connection via linked service or dataset.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public static string Type { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (LinkedService != null)
            {
                LinkedService.Validate();
            }
        }
    }
}
