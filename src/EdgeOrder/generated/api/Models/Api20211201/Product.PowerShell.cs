// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201
{
    using Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Runtime.PowerShell;

    /// <summary>List of Products</summary>
    [System.ComponentModel.TypeConverter(typeof(ProductTypeConverter))]
    public partial class Product
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.Product"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProduct" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProduct DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Product(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.Product"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProduct" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProduct DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Product(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Product" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProduct FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.Product"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Product(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ProductPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Description = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IDescription) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Description, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.DescriptionTypeConverter.ConvertFrom);
            }
            if (content.Contains("CostInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformation = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ICostInformation) content.GetValueForProperty("CostInformation",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformation, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.CostInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("AvailabilityInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformation = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IAvailabilityInformation) content.GetValueForProperty("AvailabilityInformation",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformation, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.AvailabilityInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("HierarchyInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).HierarchyInformation = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IHierarchyInformation) content.GetValueForProperty("HierarchyInformation",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).HierarchyInformation, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.HierarchyInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("DescriptionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionType = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.DescriptionType?) content.GetValueForProperty("DescriptionType",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionType, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.DescriptionType.CreateFrom);
            }
            if (content.Contains("DescriptionShortDescription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionShortDescription = (string) content.GetValueForProperty("DescriptionShortDescription",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionShortDescription, global::System.Convert.ToString);
            }
            if (content.Contains("DescriptionLongDescription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionLongDescription = (string) content.GetValueForProperty("DescriptionLongDescription",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionLongDescription, global::System.Convert.ToString);
            }
            if (content.Contains("DescriptionKeyword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionKeyword = (string[]) content.GetValueForProperty("DescriptionKeyword",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionKeyword, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DescriptionAttribute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionAttribute = (string[]) content.GetValueForProperty("DescriptionAttribute",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionAttribute, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DescriptionLink"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionLink = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ILink[]) content.GetValueForProperty("DescriptionLink",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionLink, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ILink>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.LinkTypeConverter.ConvertFrom));
            }
            if (content.Contains("AvailabilityInformationAvailabilityStage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationAvailabilityStage = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.AvailabilityStage?) content.GetValueForProperty("AvailabilityInformationAvailabilityStage",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationAvailabilityStage, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.AvailabilityStage.CreateFrom);
            }
            if (content.Contains("AvailabilityInformationDisabledReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationDisabledReason = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.DisabledReason?) content.GetValueForProperty("AvailabilityInformationDisabledReason",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationDisabledReason, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.DisabledReason.CreateFrom);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("ImageInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).ImageInformation = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IImageInformation[]) content.GetValueForProperty("ImageInformation",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).ImageInformation, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IImageInformation>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ImageInformationTypeConverter.ConvertFrom));
            }
            if (content.Contains("FilterableProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).FilterableProperty = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IFilterableProperty[]) content.GetValueForProperty("FilterableProperty",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).FilterableProperty, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IFilterableProperty>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.FilterablePropertyTypeConverter.ConvertFrom));
            }
            if (content.Contains("Configuration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Configuration = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfiguration[]) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Configuration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("CostInformationBillingMeterDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformationBillingMeterDetail = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IBillingMeterDetails[]) content.GetValueForProperty("CostInformationBillingMeterDetail",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformationBillingMeterDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IBillingMeterDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.BillingMeterDetailsTypeConverter.ConvertFrom));
            }
            if (content.Contains("CostInformationBillingInfoUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformationBillingInfoUrl = (string) content.GetValueForProperty("CostInformationBillingInfoUrl",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformationBillingInfoUrl, global::System.Convert.ToString);
            }
            if (content.Contains("AvailabilityInformationDisabledReasonMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationDisabledReasonMessage = (string) content.GetValueForProperty("AvailabilityInformationDisabledReasonMessage",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationDisabledReasonMessage, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.Product"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Product(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ProductPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Description = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IDescription) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Description, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.DescriptionTypeConverter.ConvertFrom);
            }
            if (content.Contains("CostInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformation = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ICostInformation) content.GetValueForProperty("CostInformation",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformation, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.CostInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("AvailabilityInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformation = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IAvailabilityInformation) content.GetValueForProperty("AvailabilityInformation",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformation, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.AvailabilityInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("HierarchyInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).HierarchyInformation = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IHierarchyInformation) content.GetValueForProperty("HierarchyInformation",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).HierarchyInformation, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.HierarchyInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("DescriptionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionType = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.DescriptionType?) content.GetValueForProperty("DescriptionType",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionType, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.DescriptionType.CreateFrom);
            }
            if (content.Contains("DescriptionShortDescription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionShortDescription = (string) content.GetValueForProperty("DescriptionShortDescription",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionShortDescription, global::System.Convert.ToString);
            }
            if (content.Contains("DescriptionLongDescription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionLongDescription = (string) content.GetValueForProperty("DescriptionLongDescription",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionLongDescription, global::System.Convert.ToString);
            }
            if (content.Contains("DescriptionKeyword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionKeyword = (string[]) content.GetValueForProperty("DescriptionKeyword",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionKeyword, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DescriptionAttribute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionAttribute = (string[]) content.GetValueForProperty("DescriptionAttribute",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionAttribute, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DescriptionLink"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionLink = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ILink[]) content.GetValueForProperty("DescriptionLink",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DescriptionLink, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ILink>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.LinkTypeConverter.ConvertFrom));
            }
            if (content.Contains("AvailabilityInformationAvailabilityStage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationAvailabilityStage = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.AvailabilityStage?) content.GetValueForProperty("AvailabilityInformationAvailabilityStage",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationAvailabilityStage, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.AvailabilityStage.CreateFrom);
            }
            if (content.Contains("AvailabilityInformationDisabledReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationDisabledReason = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.DisabledReason?) content.GetValueForProperty("AvailabilityInformationDisabledReason",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationDisabledReason, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.DisabledReason.CreateFrom);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("ImageInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).ImageInformation = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IImageInformation[]) content.GetValueForProperty("ImageInformation",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).ImageInformation, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IImageInformation>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ImageInformationTypeConverter.ConvertFrom));
            }
            if (content.Contains("FilterableProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).FilterableProperty = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IFilterableProperty[]) content.GetValueForProperty("FilterableProperty",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).FilterableProperty, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IFilterableProperty>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.FilterablePropertyTypeConverter.ConvertFrom));
            }
            if (content.Contains("Configuration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Configuration = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfiguration[]) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).Configuration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("CostInformationBillingMeterDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformationBillingMeterDetail = (Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IBillingMeterDetails[]) content.GetValueForProperty("CostInformationBillingMeterDetail",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformationBillingMeterDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IBillingMeterDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.BillingMeterDetailsTypeConverter.ConvertFrom));
            }
            if (content.Contains("CostInformationBillingInfoUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformationBillingInfoUrl = (string) content.GetValueForProperty("CostInformationBillingInfoUrl",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).CostInformationBillingInfoUrl, global::System.Convert.ToString);
            }
            if (content.Contains("AvailabilityInformationDisabledReasonMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationDisabledReasonMessage = (string) content.GetValueForProperty("AvailabilityInformationDisabledReasonMessage",((Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IProductInternal)this).AvailabilityInformationDisabledReasonMessage, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// List of Products
    [System.ComponentModel.TypeConverter(typeof(ProductTypeConverter))]
    public partial interface IProduct

    {

    }
}