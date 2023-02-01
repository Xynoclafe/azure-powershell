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

# ---------- Resource Group Scope Tests ----------

<#
.SYNOPSIS
Tests GET operation on deployment stacks at the RG scope.
#>
function Test-GetResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare 
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByNameAndResourceGroup - Success 
		$getByNameAndResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $rname 
		Assert-NotNull $getByNameAndResourceGroup

		# Test - GetByNameAndResourceGroup - Failure - RG NotFound
		$badResourceGroupName = "badrg1928273615"
		$exceptionMessage = "DeploymentStack '$rname' in Resource Group '$badResourceGroupName' not found."
		Assert-Throws { Get-AzResourceGroupDeploymentStack -ResourceGroupName $badResourceGroupName -StackName $rname } $exceptionMessage 

		# Test - GetByNameAndResourceGroup - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Resource Group '$rgname' not found."
		Assert-Throws { Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $badStackName } $exceptionMessage

		# Test - GetByResourceId - Success
		$getByResourceId = Get-AzResourceGroupDeploymentStack -ResourceId $resourceId
		Assert-NotNull $getByResourceId

		# Test - GetByResourceId - Failure - Bad ID form
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Get-AzResourceGroupDeploymentStack -ResourceId $badId } $exceptionMessage

		# Test - ListByResourceGroupName - Success
		$listByResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname
		Assert-AreNotEqual 0 $listByResourceGroup.Count
		Assert-True { $listByResourceGroup.name.contains($rname) }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests New operation on deployment stacks at the RG scope.
#>
function Test-NewResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success (with tags)
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile blankTemplate.json -Tag @{"key1" = "value1"; "key2" = "value2"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile $missingFile -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badRGname = "badRG114172"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ResourceGroupNotFound : Resource group '$badRGname' could not be found."
		Assert-Throws { New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $badRGname -TemplateFile blankTemplate.json -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile $missingFile -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests NEW operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-NewResourceGroupDeploymentStackUnmanageActions
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Setting a blank stack with no flags set
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a stack with only DeleteResourceGroups set which should fail
		$exceptionMessage = "Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		Assert-Throws { New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResourceGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests NEW and SET operations with deny settings on deploymentStacks at the RG scope.
#>
function Test-NewAndSetResourceGroupDeploymentStackDenySettings
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - NEW - DenySettingsMode and ApplyToChildScopes
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode

		# Test - SET - DenySettingsMode and ApplyToChildScopes
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests SET operation on deployment stacks at the RG scope.
#>
function Test-SetResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success SET after NEW
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile blankTemplate.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile $missingFile -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badRGname = "badRG114172"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ResourceGroupNotFound : Resource group '$badRGname' could not be found."
		Assert-Throws { Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $badRGname -TemplateFile blankTemplate.json -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile $missingFile -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests SET operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-SetResourceGroupDeploymentStackUnmanageActions
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Setting a blank stack with no flags set
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a stack with only DeleteResourceGroups set which should error 
		$exceptionMessage = "Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		Assert-Throws { Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResourceGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests NEW operation on deploymentStacks at the RG scope with bicep file.
#>
function Test-NewAndSetResourceGroupDeploymentStackWithBicep
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	
	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - NewByNameAndResourceGroupAndBicepTemplateFile
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGBicepTest1.bicep -TemplateParameterFile StacksRGTemplateParams.json
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGBicepTest2.bicep -TemplateParameterFile StacksRGTemplateParams.json
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally 
	{
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

 <#
 .SYNOPSIS
 Tests NEW, SET and EXPORT operations on deploymentStacks at the RG scope using template specs.
 #>
 function Test-NewAndSetAndExportResourceGroupDeploymentStackWithTemplateSpec
 {
 	# Setup
 	$rgname = Get-ResourceGroupName
 	$stackname = Get-ResourceName
 	$rname = Get-ResourceName
 	$rglocation = "West US 2"

 	try 
	{
 		# Prepare
 		New-AzResourceGroup -Name $rgname -Location $rglocation
 		$sampleTemplateJson = Get-Content -Raw -Path StacksRGTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Force
 		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

 		# Test - New-AzResourceGroupDeploymentStack using templateSpecs
 		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

 		# Test - Set-AzResourceGroupDeploymentStack using templateSpecs
 		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Export-AzResourceGroupDeploymentStack checking for template link
		$template = Export-AzResourceGroupDeploymentStackTemplate -Name $stackname -ResourceGroupName $rgname
		Assert-NotNull $template
		Assert-NotNull $template.TemplateLink
		Assert-Null $template.Template
 	}

 	finally
     {
         # Cleanup
         Clean-ResourceGroup $rgname
     }
 }

 <#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at RG scope.
#>
function Test-RemoveResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# --- RemoveByResourceIdParameterSetName ---

		# Test - Success
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Id $resourceId -Force
		Assert-Null $deployment

		# Test - Failure - Bad ID form 
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Remove-AzResourceGroupDeploymentStack -Id $badId -Force } $exceptionMessage

		# --- RemoveByNameAndResourceGroupName --- 

		# Test - Failure - RG NotFound
		$badResourceGroupName = "badrg1928273615"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ResourceGroupNotFound : Resource group '$badResourceGroupName' could not be found."
		Assert-Throws { Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $badResourceGroupName -Force } $exceptionMessage

		# Test - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in ResourceGroup '$rgname' not found."
		Assert-Throws { Remove-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $badStackName -Force } $exceptionMessage

		# Test - Success with PassThru - DeleteResources
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -DeleteResources -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteResources and DeleteResourceGroups
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -DeleteResources -DeleteResourceGroups -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteAll
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -DeleteAll -PassThru -Force
		Assert-AreEqual "true" $deployment
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests EXPORT operation on deployment stack templates at RG scope.
#>
function Test-ExportResourceGroupDeploymentStackTemplate
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		# --- ExportByResourceIdParameterSetName ---
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Export-AzResourceGroupDeploymentStackTemplate -Id $badId } $exceptionMessage

		# Test - Success
		$deployment = Export-AzResourceGroupDeploymentStackTemplate -Id $resourceId
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# --- ExportByNameAndResourceGroupName ---

		# Test - Failure - Resource Group NotFound
		$badResourceGroupName = "badrg1928273615"
		$exceptionMessage = "DeploymentStack '$rname' in Resource Group '$badResourceGroupName' not found."
		Assert-Throws { Export-AzResourceGroupDeploymentStackTemplate -Name $rname -ResourceGroupName $badResourceGroupName } $exceptionMessage
		
		# Test - Failure - Stack NotFound
		$badStackName = "badStack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Resource Group '$rgname' not found."
		Assert-Throws { Export-AzResourceGroupDeploymentStackTemplate -Name $badStackName -ResourceGroupName $rgname } $exceptionMessage

		# Test - Success
		$deployment = Export-AzResourceGroupDeploymentStackTemplate -Name $rname -ResourceGroupName $rgname
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template 
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

# ---------- Subscription Scope Tests ----------

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

# ---------- Management Group Scope Tests ----------

#TODO: Run Tests once MG Support is Ready

<#
.SYNOPSIS
Tests GET operation on deployment stacks at the RG scope.
#>
function Test-GetManagementGroupDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$mgId = "AzBlueprintAssignTest"

	try
	{
		# Prepare 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByNameAndResourceGroup - Success 
		$getByNameAndManagementGroup = Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -StackName $rname 
		Assert-NotNull $getByNameAndManagementGroup

		# Test - GetByNameAndManagementGroup - Failure - RG NotFound
		$badManagementGroupId = "badmg1928273615"
		$exceptionMessage = "does not have authorization to perform action 'Microsoft.Resources/deploymentStacks/read' over scope '/providers/Microsoft.Management/managementGroups/$badManagementGroupId"
		Assert-ThrowsContains { Get-AzManagementGroupDeploymentStack -ManagementGroupId $badManagementGroupId -StackName $rname } $exceptionMessage 

		# Test - GetByNameAndManagementGroup - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' not found in management group '$mgId'."
		Assert-Throws { Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -StackName $badStackName } $exceptionMessage

		# Test - GetByResourceId - Success
		$getByResourceId = Get-AzManagementGroupDeploymentStack -ResourceId $resourceId
		Assert-NotNull $getByResourceId

		# Test - GetByResourceId - Failure - Bad ID form
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/ManagementGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Get-AzManagementGroupDeploymentStack -ResourceId $badId } $exceptionMessage

		# Test - ListByManagementGroupId - Success
		$listByManagementGroup = Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgId
		Assert-AreNotEqual 0 $listByManagementGroup.Count
		Assert-True { $listByManagementGroup.name.contains($rname) }
	}
	finally
    {
        # Cleanup
		Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests New operation on deployment stacks at the RG scope.
#>
function Test-NewManagementGroupDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$mgId = "AzBlueprintAssignTest"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success (with tags)
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -Tag @{"key1" = "value1"; "key2" = "value2"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgId -TemplateFile $missingFile -DeploymentScopeId $subId -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badmgId = "badMG114172"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ResourceGroupNotFound : Resource group '$badmgId' could not be found."
		Assert-Throws { New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $badmgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile $missingFile -DeploymentScopeId $subId -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-NewManagementGroupDeploymentStackUnmanageActions
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$mgId = "AzBlueprintAssignTest"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $mgId -Location $rglocation

		# Test - Setting a blank stack with no flags set
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -DeleteResources -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplateWithNestedRG.json -TemplateParameterFile StacksMGTemplateWithNestedRGParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeleteResources -DeploymentScopeId $subId -DeleteResourceGroups -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplateWithNestedRG.json -TemplateParameterFile StacksMGTemplateWithNestedRGParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -DeleteAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a stack with only DeleteResourceGroups set which should fail
		$exceptionMessage = "Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		Assert-Throws { New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -DeleteResourceGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW operation with deny settings on deploymentStacks at the RG scope.
#>
function Test-NewManagementGroupDeploymentStackDenySettings
{
	# TODO: Test once deny settings changes are in PROD.
}

<#
.SYNOPSIS
Tests SET operation on deployment stacks at the RG scope.
#>
function Test-SetManagementGroupDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$mgId = "AzBlueprintAssignTest"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $mgId -TemplateFile $missingFile -DeploymentScopeId $subId -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badRGname = "badRG114172"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ResourceGroupNotFound : Resource group '$badRGname' could not be found."
		Assert-Throws { Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $badRGname -TemplateFile blankTemplate.json -DeploymentScopeId $subId -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile $missingFile -DeploymentScopeId $subId -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests SET operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-SetManagementGroupDeploymentStackUnmanageActions
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$mgId = "AzBlueprintAssignTest"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $mgId -Location $rglocation

		# Test - Setting a blank stack with no flags set
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplateWithNestedRG.json -TemplateParameterFile StacksMGTemplateWithNestedRGParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplateWithNestedRG.json -TemplateParameterFile StacksMGTemplateWithNestedRGParams.json -DeploymentScopeId $subId -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction

		# Test - Setting a stack with only DeleteResourceGroups set which should error 
		$exceptionMessage = "Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		Assert-Throws { Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile blankTemplate.json -DeploymentScopeId $subId -DeleteResourceGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests SET operation with deny settings on deploymentStacks at the RG scope.
#>
function Test-SetManagementGroupDeploymentStackDenySettings
{
	# TODO
}

<#
.SYNOPSIS
Tests NEW operation on deploymentStacks at the RG scope with bicep file.
#>
function Test-NewAndSetManagementGroupDeploymentStackWithBicep
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$mgId = "AzBlueprintAssignTest"
	
	try 
	{
		# Prepare
		New-AzResourceGroup -Name $mgId -Location $rglocation

		# Test - NewByNameAndResourceGroupAndBicepTemplateFile
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.bicep -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzManagementGroupDeploymentStacks
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.bicep -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally 
	{
        # Cleanup
        Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
	}
}

 <#
 .SYNOPSIS
 Tests NEW, SET and EXPORT operations on deploymentStacks at the RG scope using template specs.
 #>
 function Test-NewAndSetAndExportManagementGroupDeploymentStackWithTemplateSpec
 {
 	# Setup
 	$stackname = Get-ResourceName
 	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$rgname = Get-ResourceGroupName
	$mgId = "AzBlueprintAssignTest"

 	try 
	{
 		# Prepare
 		New-AzResourceGroup -Name $rgname -Location $rglocation
 		$sampleTemplateJson = Get-Content -Raw -Path StacksMGTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroup $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Force
 		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

 		# Test - New-AzManagementGroupDeploymentStack using templateSpecs
 		$deployment = New-AzManagementGroupDeploymentStack -Name $stackname -ManagementGroupId $mgId -TemplateSpec $resourceId -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

 		# Test - Set-AzManagementGroupDeploymentStack using templateSpecs
 		$deployment = Set-AzManagementGroupDeploymentStack -Name $stackname -ManagementGroupId $mgId -TemplateSpec $resourceId -TemplateParameterFile StacksMGTemplateParams.json -DeploymentScopeId $subId -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Export-AzManagementGroupDeploymentStack checking for template link
		$template = Export-AzManagementGroupDeploymentStackTemplate -Name $stackname -ManagementGroupId $mgId
		Assert-NotNull $template
		Assert-NotNull $template.TemplateLink
		Assert-Null $template.Template
 	}

 	finally
     {
         # Cleanup
		 Clean-ResourceGroup $rgname
		 Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
     }
 }

 <#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at RG scope.
#>
function Test-RemoveManagementGroupDeploymentStack
{
	# Setup
	$mgId = Get-ManagementGroupId
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# --- RemoveByResourceIdParameterSetName ---

		# Test - Success
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Force
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgId/providers/Microsoft.Resources/deploymentStacks/$rname"
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Id $resourceId -Force
		Assert-Null $deployment

		# Test - Failure - Bad ID form 
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Remove-AzManagementGroupDeploymentStack -Id $badId -Force } $exceptionMessage

		# --- RemoveByNameAndResourceGroupName --- 

		# Test - Failure - RG NotFound
		$badResourceGroupName = "badrg1928273615"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ResourceGroupNotFound : Resource group '$badResourceGroupName' could not be found."
		Assert-Throws { Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $badResourceGroupName -Force } $exceptionMessage

		# Test - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in ResourceGroup '$mgId' not found."
		Assert-Throws { Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -StackName $badStackName -Force } $exceptionMessage

		# Test - Success with PassThru - DeleteResources
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -DeleteResources -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteResources and DeleteResourceGroups
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplateWithNestedRG.json -TemplateParameterFile StacksMGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -DeleteResources -DeleteResourceGroups -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteAll
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplateWithNestedRG.json -TemplateParameterFile StacksMGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -DeleteAll -PassThru -Force
		Assert-AreEqual "true" $deployment
	}

	finally
    {
        # Cleanup
        Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests EXPORT operation on deployment stack templates at RG scope.
#>
function Test-ExportManagementGroupDeploymentStackTemplate
{
	# Setup
	$mgId = Get-ManagementGroupId
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# --- ExportByResourceIdParameterSetName ---
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Export-AzManagementGroupDeploymentStackTemplate -Id $badId } $exceptionMessage

		# Test - Success
		$deployment = Export-AzManagementGroupDeploymentStackTemplate -Id $resourceId
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# --- ExportByNameAndResourceGroupName ---

		# Test - Failure - Resource Group NotFound
		$badResourceGroupName = "badrg1928273615"
		$exceptionMessage = "DeploymentStack '$rname' in Resource Group '$badResourceGroupName' not found."
		Assert-Throws { Export-AzManagementGroupDeploymentStackTemplate -Name $rname -ManagementGroupId $badResourceGroupName } $exceptionMessage
		
		# Test - Failure - Stack NotFound
		$badStackName = "badStack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Resource Group '$mgId' not found."
		Assert-Throws { Export-AzManagementGroupDeploymentStackTemplate -Name $badStackName -ManagementGroupId $mgId } $exceptionMessage

		# Test - Success
		$deployment = Export-AzManagementGroupDeploymentStackTemplate -Name $rname -ManagementGroupId $mgId
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template 
	}

	finally
    {
        # Cleanup
        Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgId -Name $rname -DeleteAll -Force
    }
}

# ----------  (Deprecated) Snapshot Tests ----------

<#
.SYNOPSIS
Tests GET operation on deploymentStacksSnapshots at the RG scope

function Test-GetResourceGroupDeploymentStackSnapshot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare 
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -TemplateParameterFile simpleTemplateParams.json
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		$getByNameAndResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $rname 
		$provisioningState = $getByNameAndResourceGroup.provisioningState

		#Assert
		Assert-AreEqual $provisioningState "succeeded"

		$resourceId = $getByNameAndResourceGroup.SnapshotId
		$snapshotName = $resourceId.Split("/")[-1]

		#Test - GetByIdAndSnapshotName
		$getByIdAndSnapshotName = Get-AzResourceGroupDeploymentStackSnapshot -ResourceId $resourceId

		#Assert
		Assert-NotNull $getByIdAndSnapshotName

		#Test - ListSnapshots
		$getByResourceGroupNameAndStackName = Get-AzResourceGroupDeploymentStackSnapshot -ResourceGroupName $rgname -StackName $rname

		#Assert
		Assert-NotNull $getByResourceGroupNameAndStackName

		#Test - GetByResourceGroupNameAndStackNameAndSnapshotName
		$getByResourceGroupNameAndStackName = Get-AzResourceGroupDeploymentStackSnapshot -ResourceGroupName $rgname -StackName $rname -SnapshotName $snapshotName

		#Assert
		Assert-NotNull = $getByResourceGroupNameAndStackName
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
#>

<#
.SYNOPSIS
Tests GET operation on deploymentStacksSnapshot at the Subscription scope

function Test-GetSubscriptionDeploymentStackSnapshot
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		$getByName = Get-AzSubscriptionDeploymentStack -Name $rname 
		$provisioningState = $getByName.provisioningState

		#Assert
		Assert-AreEqual $provisioningState "succeeded"

		$resourceId = $getByName.SnapshotId
		$snapshotName = $resourceId.Split("/")[-1]

		# Test - GetByStackAndSnapshotName
		$getByName = Get-AzSubscriptionDeploymentStackSnapshot -StackName $rname -Name $snapshotName

		# Assert
		Assert-NotNull $getByName

		# Test - GetByResourceId
		$getByResourceId = Get-AzSubscriptionDeploymentStackSnapshot -ResourceId $resourceId

		#Assert
		Assert-NotNull $getByResourceId

		#Test - ListByResourceGroupName
		$list = Get-AzSubscriptionDeploymentStackSnapshot -StackName $rname

		# Assert
		Assert-AreNotEqual 0 $list.Count
		Assert-True { $list[0].name.contains($snapshotName) }
	}
	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
    }
}
#>

<#
.SYNOPSIS
Tests REMOVE operation on deploymentStacksSnapshot

#Does this delete the snapshot for this deplpyment or also the deployment
#backlog until new command works
function Test-RemoveResourceGroupDeploymentStackSnapshot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

	try
	{
		# Prepare 
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json

		$deploymentSet = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json -UpdateBehavior "detachResources" -force


		$snapshotId = $deployment.SnapshotId;

		# Test - removeByResourceId
		$removeByResourceId = Remove-AzResourceGroupDeploymentStackSnapshot -resourceid $snapshotId -force

		# Assert
		Assert-NotNull $RemoveByResourceId

		# Cleanup
        Clean-ResourceGroup $rgname

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json -force

		$deploymentSet = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json -UpdateBehavior "detachResources" -force

		$stackName = $deployment.name

		$snapshotId = $deployment.SnapshotId;
		$snapshotName = $snapshotId.split('/')[-1]

		# Test - removeByNameAndSnapshotNameAndResourceGroupName
		$removeByNameAndSnapshotNameAndResourceGroupName = Remove-AzResourceGroupDeploymentStackSnapshot -StackName $stackName -Name $snapshotName -ResourceGroupName $rgname -force

		# Assert
		Assert-NotNull $removeByNameAndSnapshotNameAndResourceGroupName
	}

	finally
	{
		# Cleanup
        Clean-ResourceGroup $rgname
	}
}
#>

<#
.SYNOPSIS
Tests REMOVE operation on deploymentStacksSnapshot

function Test-RemoveSubscriptionDeploymentStackSnapshot
{
	# Setup
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -location $rglocation

		Assert-AreEqual $deployment.provisioningState "succeeded"

		$deploymentSet = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -UpdateBehavior "detachResources" -force -location $rglocation

		Assert-AreEqual $deploymentSet.provisioningState "succeeded"

		$snapshotId = $deployment.SnapshotId;

		# Test - removeByResourceId
		$removeByResourceId = Remove-AzSubscriptionDeploymentStackSnapshot -resourceId $snapshotId -force

		# Assert
		Assert-NotNull $RemoveByResourceId

		# Cleanup
        Clean-DeploymentAtSubscription $rname

		# Prepare
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -force -location $rglocation

		Assert-AreEqual $deployment.provisioningState "succeeded"

		$deploymentSet = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -UpdateBehavior "detachResources" -force -location $rglocation

		Assert-AreEqual $deploymentSet.provisioningState "succeeded"

		$stackName = $deployment.Name

		$snapshotId = $deployment.SnapshotId;
		$snapshotName = $snapshotId.split('/')[-1]

		# Test - removeByNameAndSnapshotName
		$removeByNameAndSnapshotName = Remove-AzSubscriptionDeploymentStackSnapshot -StackName $stackName -Name $snapshotName -force

		# Assert
		Assert-NotNull $removeByNameAndSnapshotName

		
	}

	finally
	{
		# Cleanup
        Clean-DeploymentAtSubscription $rname
	}
}
#>