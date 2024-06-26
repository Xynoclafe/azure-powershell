// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.Management.Automation
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for ModuleOperations
    /// </summary>
    public static partial class ModuleOperationsExtensions
    {
        /// <summary>
        /// Delete the module by name.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='moduleName'>
        /// The module name.
        /// </param>
        public static void Delete(this IModuleOperations operations, string resourceGroupName, string automationAccountName, string moduleName)
        {
                ((IModuleOperations)operations).DeleteAsync(resourceGroupName, automationAccountName, moduleName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete the module by name.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='moduleName'>
        /// The module name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task DeleteAsync(this IModuleOperations operations, string resourceGroupName, string automationAccountName, string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, automationAccountName, moduleName, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
        /// <summary>
        /// Retrieve the module identified by module name.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='moduleName'>
        /// The module name.
        /// </param>
        public static Module Get(this IModuleOperations operations, string resourceGroupName, string automationAccountName, string moduleName)
        {
                return ((IModuleOperations)operations).GetAsync(resourceGroupName, automationAccountName, moduleName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieve the module identified by module name.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='moduleName'>
        /// The module name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Module> GetAsync(this IModuleOperations operations, string resourceGroupName, string automationAccountName, string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, automationAccountName, moduleName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Create or Update the module identified by module name.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='moduleName'>
        /// The name of module.
        /// </param>
        public static Module CreateOrUpdate(this IModuleOperations operations, string resourceGroupName, string automationAccountName, string moduleName, ModuleCreateOrUpdateParameters parameters)
        {
                return ((IModuleOperations)operations).CreateOrUpdateAsync(resourceGroupName, automationAccountName, moduleName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or Update the module identified by module name.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='moduleName'>
        /// The name of module.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Module> CreateOrUpdateAsync(this IModuleOperations operations, string resourceGroupName, string automationAccountName, string moduleName, ModuleCreateOrUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, automationAccountName, moduleName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Update the module identified by module name.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='moduleName'>
        /// The name of module.
        /// </param>
        public static Module Update(this IModuleOperations operations, string resourceGroupName, string automationAccountName, string moduleName, ModuleUpdateParameters parameters)
        {
                return ((IModuleOperations)operations).UpdateAsync(resourceGroupName, automationAccountName, moduleName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Update the module identified by module name.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='moduleName'>
        /// The name of module.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Module> UpdateAsync(this IModuleOperations operations, string resourceGroupName, string automationAccountName, string moduleName, ModuleUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, automationAccountName, moduleName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Retrieve a list of modules.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<Module> ListByAutomationAccount(this IModuleOperations operations, string resourceGroupName, string automationAccountName)
        {
                return ((IModuleOperations)operations).ListByAutomationAccountAsync(resourceGroupName, automationAccountName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieve a list of modules.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of an Azure Resource group.
        /// </param>
        /// <param name='automationAccountName'>
        /// The name of the automation account.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<Module>> ListByAutomationAccountAsync(this IModuleOperations operations, string resourceGroupName, string automationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListByAutomationAccountWithHttpMessagesAsync(resourceGroupName, automationAccountName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Retrieve a list of modules.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<Module> ListByAutomationAccountNext(this IModuleOperations operations, string nextPageLink)
        {
                return ((IModuleOperations)operations).ListByAutomationAccountNextAsync(nextPageLink).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieve a list of modules.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<Module>> ListByAutomationAccountNextAsync(this IModuleOperations operations, string nextPageLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListByAutomationAccountNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
