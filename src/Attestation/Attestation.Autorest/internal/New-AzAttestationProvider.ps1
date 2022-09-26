
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
Creates a new Attestation Provider.
.Description
Creates a new Attestation Provider.
.Example
New-AzAttestationProvider -Name testprovider1 -ResourceGroupName test-rg -Location "eastus"
.Example
New-AzAttestationProvider -Name testprovider2 -ResourceGroupName test-rg -Location "eastus" -PolicySigningCertificateKeyPath .\cert1.pem

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

POLICYSIGNINGCERTIFICATEKEY <IJsonWebKey[]>: The value of the "keys" parameter is an array of JWK values. Bydefault, the order of the JWK values within the array does not implyan order of preference among them, although applications of JWK Setscan choose to assign a meaning to the order for their purposes, ifdesired.
  Kty <String>: The "kty" (key type) parameter identifies the cryptographic algorithm         family used with the key, such as "RSA" or "EC". "kty" values should         either be registered in the IANA "JSON Web Key Types" registry         established by [JWA] or be a value that contains a Collision-         Resistant Name.  The "kty" value is a case-sensitive string.
  [Alg <String>]: The "alg" (algorithm) parameter identifies the algorithm intended for         use with the key.  The values used should either be registered in the         IANA "JSON Web Signature and Encryption Algorithms" registry         established by [JWA] or be a value that contains a Collision-         Resistant Name.
  [Crv <String>]: The "crv" (curve) parameter identifies the curve type
  [D <String>]: RSA private exponent or ECC private key
  [Dp <String>]: RSA Private Key Parameter
  [Dq <String>]: RSA Private Key Parameter
  [E <String>]: RSA public exponent, in Base64
  [K <String>]: Symmetric key
  [Kid <String>]: The "kid" (key ID) parameter is used to match a specific key.  This         is used, for instance, to choose among a set of keys within a JWK Set         during key rollover.  The structure of the "kid" value is         unspecified.  When "kid" values are used within a JWK Set, different         keys within the JWK Set SHOULD use distinct "kid" values.  (One         example in which different keys might use the same "kid" value is if         they have different "kty" (key type) values but are considered to be         equivalent alternatives by the application using them.)  The "kid"         value is a case-sensitive string.
  [N <String>]: RSA modulus, in Base64
  [P <String>]: RSA secret prime
  [Q <String>]: RSA secret prime, with p < q
  [Qi <String>]: RSA Private Key Parameter
  [Use <String>]: Use ("public key use") identifies the intended use of         the public key. The "use" parameter is employed to indicate whether         a public key is used for encrypting data or verifying the signature         on data. Values are commonly "sig" (signature) or "enc" (encryption).
  [X <String>]: X coordinate for the Elliptic Curve point
  [X5C <String[]>]: The "x5c" (X.509 certificate chain) parameter contains a chain of one         or more PKIX certificates [RFC5280].  The certificate chain is         represented as a JSON array of certificate value strings.  Each         string in the array is a base64-encoded (Section 4 of [RFC4648] --         not base64url-encoded) DER [ITU.X690.1994] PKIX certificate value.         The PKIX certificate containing the key value MUST be the first         certificate.
  [Y <String>]: Y coordinate for the Elliptic Curve point
.Link
https://docs.microsoft.com/powershell/module/az.attestation/new-azattestationprovider
#>
function New-AzAttestationProvider {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ProviderName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Path')]
    [System.String]
    # Name of the attestation provider.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Body')]
    [System.String]
    # The supported Azure location where the attestation provider should be created.
    ${Location},

    [Parameter()]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api10.IJsonWebKey[]]
    # The value of the "keys" parameter is an array of JWK values.
    # Bydefault, the order of the JWK values within the array does not implyan order of preference among them, although applications of JWK Setscan choose to assign a meaning to the order for their purposes, ifdesired.
    # To construct, see NOTES section for POLICYSIGNINGCERTIFICATEKEY properties and create a hash table.
    ${PolicySigningCertificateKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationServiceCreationParamsTags]))]
    [System.Collections.Hashtable]
    # The tags that will be assigned to the attestation provider.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Attestation.Category('Runtime')]
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

        $mapping = @{
            CreateExpanded = 'Az.Attestation.private\New-AzAttestationProvider_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }

        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {

        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {

        throw
    }

}
end {
    try {
        $steppablePipeline.End()

    } catch {

        throw
    }
} 
}
