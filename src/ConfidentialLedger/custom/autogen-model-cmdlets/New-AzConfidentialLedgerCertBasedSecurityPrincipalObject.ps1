
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
Create an in-memory object for CertBasedSecurityPrincipal.
.Description
Create an in-memory object for CertBasedSecurityPrincipal.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.CertBasedSecurityPrincipal
.Link
https://docs.microsoft.com/powershell/module/az.ConfidentialLedger/new-AzConfidentialLedgerCertBasedSecurityPrincipalObject
#>
function New-AzConfidentialLedgerCertBasedSecurityPrincipalObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.CertBasedSecurityPrincipal')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Public key of the user cert (.pem or .cer).")]
        [string]
        $Cert,
        [Parameter(HelpMessage="LedgerRole associated with the Security Principal of Ledger.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Support.LedgerRoleName])]
        [Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Support.LedgerRoleName]
        $LedgerRoleName
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.CertBasedSecurityPrincipal]::New()

        if ($PSBoundParameters.ContainsKey('Cert')) {
            $Object.Cert = $Cert
        }
        if ($PSBoundParameters.ContainsKey('LedgerRoleName')) {
            $Object.LedgerRoleName = $LedgerRoleName
        }
        return $Object
    }
}

