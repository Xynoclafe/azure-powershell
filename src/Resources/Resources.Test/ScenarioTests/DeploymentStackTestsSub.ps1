# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Tests GET operation on deployment stacks at the SUB scope.
#>
function Test-GetSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Force
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByName - Success 
		$getByName = Get-AzSubscriptionDeploymentStack -StackName $rname 
		Assert-NotNull $getByName

		# Test - GetByName - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' not found in current subscription scope."
		Assert-Throws { Get-AzSubscriptionDeploymentStack -StackName $badStackName } $exceptionMessage

		# Test - GetByResourceId - Success
		$getByResourceId = Get-AzSubscriptionDeploymentStack -ResourceId $resourceId
		Assert-NotNull $getByResourceId

		# Test - GetByResourceId - Failure - Bad ID form
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Get-AzSubscriptionDeploymentStack -ResourceId $badId } $exceptionMessage

		# Test - ListBySubscription - Success
		$listBySubscription = Get-AzSubscriptionDeploymentStack
		Assert-AreNotEqual 0 $listBySubscription.Count
		Assert-True { $listBySubscription.name.contains($rname) }
	}
	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW operation on deployment stacks at the SUB scope.
#>
function Test-NewSubscriptionDeploymentStack
{
	# Setup
	$rname = "DanteStack1234"
	$location = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success (with tags)
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile blankTemplate.json -Location $location -Tag @{"key1" = "value1"; "key2" = "value2"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile $missingFile  -Location $location -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile $missingFile -Location $location -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterObject @{location = "westus"} -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW operation with unmanage action parameters on deploymentStacks at the Sub scope.
#>
function Test-NewSubscriptionDeploymentStackUnmanageActions
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# Test - Setting a blank stack with no flags set
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResources -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteAll -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a stack with only DeleteResourceGroups set which should fail
		$exceptionMessage = "Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		Assert-Throws { New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResourceGroups -Location $location -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW and SET operations with deny settings on deploymentStacks at the Sub scope.
#>
function Test-NewAndSetSubscriptionDeploymentStackDenySettings
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# Test - NEW- DenySettingsMode and ApplyToChildScopes
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode

		# Test - SET - DenySettingsMode and ApplyToChildScopes
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force
    }
}
<#
.SYNOPSIS
Tests SET operation on deployment stacks at the Sub scope.
#>
function Test-SetSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try {
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile blankTemplate.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile $missingFile -Location $location -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile $missingFile -Location $location -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -Location $location -TemplateParameterObject @{location = "westus"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests SET operation with unmanage action parameters on deploymentStacks at the Sub scope.
#>
function Test-SetSubscriptionDeploymentStackUnmanageActions
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# Test - Setting a blank stack with no flags set
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResources -Location $location -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Location $location -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteAll -Location $location -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a stack with only DeleteResourceGroups set which should error 
		$exceptionMessage = "Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		Assert-Throws { Set-AzSubscriptionDeploymentStack -Name $rname  -TemplateFile blankTemplate.json -DeleteResourceGroups -Location $location -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW and SET operations on deploymentStacks at the Sub scope with bicep file.
#>
function Test-NewAndSetSubscriptionDeploymentStackWithBicep
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"
	
	try 
	{
		# Test - NewByNameAndResourceGroupAndBicepTemplateFile
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubBicepTest1.bicep -TemplateParameterFile StacksSubTemplateParams.json -Location $location
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzSubscriptionDeploymentStacks
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubBicepTest2.bicep -TemplateParameterFile StacksSubTemplateParams.json -Location $location
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally 
	{
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force
	}
}

 <#
 .SYNOPSIS
 Tests NEW, SET, and EXPORT operations on deploymentStacks at the Sub scope using template specs.
 #>
 function Test-NewAndSetAndExportSubscriptionDeploymentStackWithTemplateSpec
 {
 	# Setup
 	$rgname = Get-ResourceGroupName
 	$rname = Get-ResourceName
 	$stackname = Get-ResourceName
 	$rglocation = "West US 2"
	$location = "West US 2"

 	try 
	{
 		# Prepare
 		New-AzResourceGroup -Name $rgname -Location $rglocation
 		$sampleTemplateJson = Get-Content -Raw -Path StacksSubTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Location $rgLocation -Name $rname -Version "v1" -TemplateJson $sampleTemplateJson -Force
 		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

 		# Test - New-AzSubscriptionDeploymentStacks using templateSpecs
 		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateSpec $resourceId -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

 		# Test - Set-AzSubscriptionDeploymentStacks using templateSpecs
 		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateSpec $resourceId -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Export-AzSubscriptionDeploymentStack checking for template link
		$template = Export-AzSubscriptionDeploymentStackTemplate -Name $stackname
		Assert-NotNull $template
		Assert-NotNull $template.TemplateLink
		Assert-Null $template.Template
 	}

 	finally
     {
         # Cleanup
         Clean-ResourceGroup $rgname
		 Remove-AzSubscriptionDeploymentStack -Name $stackname -DeleteAll -Force
     }
 }

 <#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at Sub scope.
#>
function Test-RemoveSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try {
		# --- RemoveByResourceIdParameterSetName ---

		# Test - Success
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Id $resourceId -Force
		Assert-Null $deployment

		# Test - Failure - Bad ID form 
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Remove-AzSubscriptionDeploymentStack -Id $badId -Force } $exceptionMessage

		# --- RemoveByNameParameterSetName --- 

		# Test - Failure - Stack NotFound
		# TODO: Bug in subscription stack export not returning NotFound
		# $badStackName = "badstack1928273615"
		# $exceptionMessage = "DeploymentStack '$badStackName' not found in the curent subscription scope."
		# Assert-Throws { Remove-AzSubscriptionDeploymentStack -StackName $badStackName -Force } $exceptionMessage

		# Test - Success with PassThru - DeleteResources
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteResources -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteResources and DeleteResourceGroups
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteResources -DeleteResourceGroups -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteAll
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -PassThru -Force
		Assert-AreEqual "true" $deployment
	}
	finally
	{
		# No need to cleanup as we already deleted stack.
	}
}

<#
.SYNOPSIS
Tests EXPORT operation on deploymentStacks.
#>
function Test-ExportSubscriptionDeploymentStackTemplate
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# Prepare
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -Force
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# --- ExportByResourceIdParameterSetName ---
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Export-AzSubscriptionDeploymentStackTemplate -Id $badId } $exceptionMessage

		# Test - Success
		$deployment = Export-AzSubscriptionDeploymentStackTemplate -Id $resourceId
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# --- ExportByNameParameterSetName ---
		
		# Test - Failure - Stack NotFound
		# TODO: Bug in subscription stack export not returning NotFound
		#$badStackName = "badStack1928273615"
		#$exceptionMessage = "DeploymentStack '$badStackName' not found in the curent subscription scope."
		#Assert-Throws { Export-AzSubscriptionDeploymentStackTemplate -Name $badStackName } $exceptionMessage

		# Test - Success
		$deployment = Export-AzSubscriptionDeploymentStackTemplate -Name $rname
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template 
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force
    }
}

