// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Extensions;

    /// <summary>
    /// Currency and amount that customer will be charged in customer's local currency. Tax is not included.
    /// </summary>
    public partial class CalculatePriceResponsePropertiesBillingCurrencyTotal :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculatePriceResponsePropertiesBillingCurrencyTotal,
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculatePriceResponsePropertiesBillingCurrencyTotalInternal
    {

        /// <summary>Backing field for <see cref="Amount" /> property.</summary>
        private double? _amount;

        /// <summary>Amount in pricing currency. Tax is not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public double? Amount { get => this._amount; set => this._amount = value; }

        /// <summary>Backing field for <see cref="CurrencyCode" /> property.</summary>
        private string _currencyCode;

        /// <summary>
        /// The ISO 4217 3-letter currency code for the currency used by this purchase record.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public string CurrencyCode { get => this._currencyCode; set => this._currencyCode = value; }

        /// <summary>
        /// Creates an new <see cref="CalculatePriceResponsePropertiesBillingCurrencyTotal" /> instance.
        /// </summary>
        public CalculatePriceResponsePropertiesBillingCurrencyTotal()
        {

        }
    }
    /// Currency and amount that customer will be charged in customer's local currency. Tax is not included.
    public partial interface ICalculatePriceResponsePropertiesBillingCurrencyTotal :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.IJsonSerializable
    {
        /// <summary>Amount in pricing currency. Tax is not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Amount in pricing currency. Tax is not included.",
        SerializedName = @"amount",
        PossibleTypes = new [] { typeof(double) })]
        double? Amount { get; set; }
        /// <summary>
        /// The ISO 4217 3-letter currency code for the currency used by this purchase record.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ISO 4217 3-letter currency code for the currency used by this purchase record.",
        SerializedName = @"currencyCode",
        PossibleTypes = new [] { typeof(string) })]
        string CurrencyCode { get; set; }

    }
    /// Currency and amount that customer will be charged in customer's local currency. Tax is not included.
    internal partial interface ICalculatePriceResponsePropertiesBillingCurrencyTotalInternal

    {
        /// <summary>Amount in pricing currency. Tax is not included.</summary>
        double? Amount { get; set; }
        /// <summary>
        /// The ISO 4217 3-letter currency code for the currency used by this purchase record.
        /// </summary>
        string CurrencyCode { get; set; }

    }
}