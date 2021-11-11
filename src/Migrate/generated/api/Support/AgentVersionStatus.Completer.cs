// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support
{

    /// <summary>A value indicating whether security update required.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatusTypeConverter))]
    public partial struct AgentVersionStatus :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Supported".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'Supported'", "Supported", global::System.Management.Automation.CompletionResultType.ParameterValue, "Supported");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "NotSupported".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'NotSupported'", "NotSupported", global::System.Management.Automation.CompletionResultType.ParameterValue, "NotSupported");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Deprecated".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'Deprecated'", "Deprecated", global::System.Management.Automation.CompletionResultType.ParameterValue, "Deprecated");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "UpdateRequired".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'UpdateRequired'", "UpdateRequired", global::System.Management.Automation.CompletionResultType.ParameterValue, "UpdateRequired");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "SecurityUpdateRequired".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'SecurityUpdateRequired'", "SecurityUpdateRequired", global::System.Management.Automation.CompletionResultType.ParameterValue, "SecurityUpdateRequired");
            }
        }
    }
}