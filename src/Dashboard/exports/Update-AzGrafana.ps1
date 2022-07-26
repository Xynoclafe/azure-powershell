
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Update a workspace for Grafana resource.
.Description
Update a workspace for Grafana resource.
.Example
Update-AzGrafana -GrafanaName azpstest-grafana -ResourceGroupName azpstest-gp -ApiKey Enabled -DeterministicOutboundIP 'Enabled' -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled' -ZoneRedundancy 'Enabled' -Tag @{"Environment"="Dev"}
.Example
Get-AzGrafana -ResourceGroupName azpstest-gp -GrafanaName azpstest-grafana | Update-AzGrafana -ApiKey Enabled -DeterministicOutboundIP 'Enabled' -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled' -ZoneRedundancy 'Enabled' -Tag @{"Environment"="Dev"}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.Api20220801.IManagedGrafana
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IDashboardIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [PrivateEndpointConnectionName <String>]: The private endpoint connection name of Azure Managed Grafana.
  [PrivateLinkResourceName <String>]: 
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.
  [WorkspaceName <String>]: The workspace name of Azure Managed Grafana.
.Link
https://docs.microsoft.com/powershell/module/az.dashboard/update-azgrafana
#>
function Update-AzGrafana {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.Api20220801.IManagedGrafana])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('GrafanaName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Path')]
    [System.String]
    # The workspace name of Azure Managed Grafana.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ApiKey])]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ApiKey]
    # The api key setting of the Grafana instance.
    ${ApiKey},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.DeterministicOutboundIP])]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.DeterministicOutboundIP]
    # Whether a Grafana instance uses deterministic outbound IPs.
    ${DeterministicOutboundIP},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ManagedServiceIdentityType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ManagedServiceIdentityType]
    # Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).
    ${IdentityType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.Api30.IUserAssignedIdentities]))]
    [System.Collections.Hashtable]
    # The set of user assigned identities associated with the resource.
    # The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
    # The dictionary values can be empty objects ({}) in requests.
    ${IdentityUserAssignedIdentity},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.PublicNetworkAccess])]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.PublicNetworkAccess]
    # Indicate the state for enable or disable traffic over the public interface.
    ${PublicNetworkAccess},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.Api20220801.IManagedGrafanaUpdateParametersTags]))]
    [System.Collections.Hashtable]
    # The new tags of the grafana resource.
    ${Tag},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ZoneRedundancy])]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Support.ZoneRedundancy]
    # The zone redundancy setting of the Grafana instance.
    ${ZoneRedundancy},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName

        if ($null -eq [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion) {
            [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion = $Host.Version.ToString()
        }         
        $preTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        if ($preTelemetryId -eq '') {
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId =(New-Guid).ToString()
            [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.module]::Instance.Telemetry.Invoke('Create', $MyInvocation, $parameterSet, $PSCmdlet)
        } else {
            $internalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
            if ($internalCalledCmdlets -eq '') {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $MyInvocation.MyCommand.Name
            } else {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets += ',' + $MyInvocation.MyCommand.Name
            }
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = 'internal'
        }

        $mapping = @{
            UpdateExpanded = 'Az.Dashboard.private\Update-AzGrafana_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.Dashboard.private\Update-AzGrafana_UpdateViaIdentityExpanded';
        }
        if (('UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }

    finally {
        $backupTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        $backupInternalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
    }

}
end {
    try {
        $steppablePipeline.End()

        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $backupTelemetryId
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $backupInternalCalledCmdlets
        if ($preTelemetryId -eq '') {
            [Microsoft.Azure.PowerShell.Cmdlets.Dashboard.module]::Instance.Telemetry.Invoke('Send', $MyInvocation, $parameterSet, $PSCmdlet)
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        }
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $preTelemetryId

    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
} 
}
