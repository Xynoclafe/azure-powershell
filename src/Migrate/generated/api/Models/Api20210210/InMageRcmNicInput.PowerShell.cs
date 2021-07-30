namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>InMageRcm NIC input.</summary>
    [System.ComponentModel.TypeConverter(typeof(InMageRcmNicInputTypeConverter))]
    public partial class InMageRcmNicInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.InMageRcmNicInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInput" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new InMageRcmNicInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.InMageRcmNicInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInput" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new InMageRcmNicInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="InMageRcmNicInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.InMageRcmNicInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal InMageRcmNicInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).NicId = (string) content.GetValueForProperty("NicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).NicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).IsPrimaryNic = (string) content.GetValueForProperty("IsPrimaryNic",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).IsPrimaryNic, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).IsSelectedForFailover = (string) content.GetValueForProperty("IsSelectedForFailover",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).IsSelectedForFailover, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TargetSubnetName = (string) content.GetValueForProperty("TargetSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TargetSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TargetStaticIPAddress = (string) content.GetValueForProperty("TargetStaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TargetStaticIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TestSubnetName = (string) content.GetValueForProperty("TestSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TestSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TestStaticIPAddress = (string) content.GetValueForProperty("TestStaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TestStaticIPAddress, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.InMageRcmNicInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal InMageRcmNicInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).NicId = (string) content.GetValueForProperty("NicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).NicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).IsPrimaryNic = (string) content.GetValueForProperty("IsPrimaryNic",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).IsPrimaryNic, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).IsSelectedForFailover = (string) content.GetValueForProperty("IsSelectedForFailover",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).IsSelectedForFailover, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TargetSubnetName = (string) content.GetValueForProperty("TargetSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TargetSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TargetStaticIPAddress = (string) content.GetValueForProperty("TargetStaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TargetStaticIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TestSubnetName = (string) content.GetValueForProperty("TestSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TestSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TestStaticIPAddress = (string) content.GetValueForProperty("TestStaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IInMageRcmNicInputInternal)this).TestStaticIPAddress, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// InMageRcm NIC input.
    [System.ComponentModel.TypeConverter(typeof(InMageRcmNicInputTypeConverter))]
    public partial interface IInMageRcmNicInput

    {

    }
}