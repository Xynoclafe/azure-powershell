// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support
{

    /// <summary>
    /// Provisioning substate shows the progress of custom HTTPS enabling/disabling process step by step. DCV stands for DomainControlValidation.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DomainValidationStateTypeConverter))]
    public partial struct DomainValidationState :
        System.Management.Automation.IArgumentCompleter
    {

        /// <summary>
        /// Implementations of this function are called by PowerShell to complete arguments.
        /// </summary>
        /// <param name="commandName">The name of the command that needs argument completion.</param>
        /// <param name="parameterName">The name of the parameter that needs argument completion.</param>
        /// <param name="wordToComplete">The (possibly empty) word being completed.</param>
        /// <param name="commandAst">The command ast in case it is needed for completion.</param>
        /// <param name="fakeBoundParameters">This parameter is similar to $PSBoundParameters, except that sometimes PowerShell cannot
        /// or will not attempt to evaluate an argument, in which case you may need to use commandAst.</param>
        /// <returns>
        /// A collection of completion results, most like with ResultType set to ParameterValue.
        /// </returns>
        public global::System.Collections.Generic.IEnumerable<global::System.Management.Automation.CompletionResult> CompleteArgument(global::System.String commandName, global::System.String parameterName, global::System.String wordToComplete, global::System.Management.Automation.Language.CommandAst commandAst, global::System.Collections.IDictionary fakeBoundParameters)
        {
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Unknown".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'Unknown'", "Unknown", global::System.Management.Automation.CompletionResultType.ParameterValue, "Unknown");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Submitting".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'Submitting'", "Submitting", global::System.Management.Automation.CompletionResultType.ParameterValue, "Submitting");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Pending".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'Pending'", "Pending", global::System.Management.Automation.CompletionResultType.ParameterValue, "Pending");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Rejected".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'Rejected'", "Rejected", global::System.Management.Automation.CompletionResultType.ParameterValue, "Rejected");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TimedOut".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'TimedOut'", "TimedOut", global::System.Management.Automation.CompletionResultType.ParameterValue, "TimedOut");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PendingRevalidation".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'PendingRevalidation'", "PendingRevalidation", global::System.Management.Automation.CompletionResultType.ParameterValue, "PendingRevalidation");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Approved".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'Approved'", "Approved", global::System.Management.Automation.CompletionResultType.ParameterValue, "Approved");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RefreshingValidationToken".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'RefreshingValidationToken'", "RefreshingValidationToken", global::System.Management.Automation.CompletionResultType.ParameterValue, "RefreshingValidationToken");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InternalError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InternalError'", "InternalError", global::System.Management.Automation.CompletionResultType.ParameterValue, "InternalError");
            }
        }
    }
}