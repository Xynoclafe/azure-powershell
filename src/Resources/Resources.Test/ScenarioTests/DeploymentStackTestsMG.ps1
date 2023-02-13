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
Tests GET operation on deployment stacks at the RG scope.
#>
function Test-GetManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Force
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgid/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByManagementGroupIdAndName - Success 
		$getByNameAndManagementGroup = Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgid -StackName $rname 
		Assert-NotNull $getByNameAndManagementGroup

		# Test - GetByManagementGroupIdAndName - Failure - RG NotFound
		$badManagementGroupId = "badmg1928273615"
		$exceptionMessage = "DeploymentStack '$rname' in Management Group '$badManagementGroupId' not found."
		Assert-Throws { Get-AzManagementGroupDeploymentStack -ManagementGroupId $badManagementGroupId -StackName $rname } $exceptionMessage 

		# Test - GetByManagementGroupIdAndName - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Management Group '$mgid' not found."
		Assert-Throws { Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgid -StackName $badStackName } $exceptionMessage

		# Test - GetByResourceId - Success
		$getByResourceId = Get-AzManagementGroupDeploymentStack -ResourceId $resourceId
		Assert-NotNull $getByResourceId

		# Test - GetByResourceId - Failure - Bad ID form
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /providers/Microsoft.Management/managementGroups/<managementgroupid</providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Get-AzManagementGroupDeploymentStack -ResourceId $badId } $exceptionMessage

		# Test - ListByManagementGroupId - Success
		$listByManagementGroup = Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgid
		Assert-AreNotEqual 0 $listByManagementGroup.Count
		Assert-True { $listByManagementGroup.name.contains($rname) }
	}
	finally
    {
        # Cleanup
        Remove-AzManagementGroupDeploymentStack $mgid $rname -DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests New operation on deployment stacks at the RG scope.
#>
function Test-NewManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...

		# Prepare
		New-AzManagementGroup -Name $mgid -Location $rglocation
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success (with tags)
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile blankTemplate.json -Tag @{"key1" = "value1"; "key2" = "value2"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile $missingFile -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badmgid = "badRG114172"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ManagementGroupNotFound : Resource group '$badmgid' could not be found."
		Assert-Throws { New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $badmgid -TemplateFile blankTemplate.json -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile $missingFile -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ManagementGroup $mgid
    }
}

<#
.SYNOPSIS
Tests NEW operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-NewManagementGroupDeploymentStackUnmanageActions
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzManagementGroup -Name $mgid -Location $rglocation

		# Test - Setting a blank stack with no flags set
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -DeleteResources -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources and ManagementGroups set 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -DeleteResources -DeleteManagementGroups -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -DeleteAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a stack with only DeleteManagementGroups set which should fail
		$exceptionMessage = "Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		Assert-Throws { New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -DeleteManagementGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Clean-ManagementGroup $mgid
    }
}

<#
.SYNOPSIS
Tests NEW and SET operations with deny settings on deploymentStacks at the RG scope.
#>
function Test-NewAndSetManagementGroupDeploymentStackDenySettings
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzManagementGroup -Name $mgid -Location $rglocation

		# Test - NEW - DenySettingsMode and ApplyToChildScopes
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode

		# Test - SET - DenySettingsMode and ApplyToChildScopes
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode
	}

	finally
    {
        # Cleanup
        Clean-ManagementGroup $mgid
    }
}

<#
.SYNOPSIS
Tests SET operation on deployment stacks at the RG scope.
#>
function Test-SetManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...

		# Prepare
		New-AzManagementGroup -Name $mgid -Location $rglocation
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success SET after NEW
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile blankTemplate.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile $missingFile -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badmgid = "badRG114172"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ManagementGroupNotFound : Resource group '$badmgid' could not be found."
		Assert-Throws { Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $badmgid -TemplateFile blankTemplate.json -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "The provided file $missingFile doesn't exist"
		Assert-Throws { Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile $missingFile -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ManagementGroup $mgid
    }
}

<#
.SYNOPSIS
Tests SET operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-SetManagementGroupDeploymentStackUnmanageActions
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzManagementGroup -Name $mgid -Location $rglocation

		# Test - Setting a blank stack with no flags set
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources and ManagementGroups set 
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -DeleteResources -DeleteManagementGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a stack with only DeleteManagementGroups set which should error 
		$exceptionMessage = "Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		Assert-Throws { Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile blankTemplate.json -DeleteManagementGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Clean-ManagementGroup $mgid
    }
}

<#
.SYNOPSIS
Tests NEW operation on deploymentStacks at the RG scope with bicep file.
#>
function Test-NewAndSetManagementGroupDeploymentStackWithBicep
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	
	try 
	{
		# Prepare
		New-AzManagementGroup -Name $mgid -Location $rglocation

		# Test - NewByNameAndManagementGroupAndBicepTemplateFile
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGBicepTest1.bicep -TemplateParameterFile StacksRGTemplateParams.json
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzManagementGroupDeploymentStacks
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGBicepTest2.bicep -TemplateParameterFile StacksRGTemplateParams.json
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally 
	{
        # Cleanup
        Clean-ManagementGroup $mgid
	}
}

 <#
 .SYNOPSIS
 Tests NEW, SET and EXPORT operations on deploymentStacks at the RG scope using template specs.
 #>
 function Test-NewAndSetAndExportManagementGroupDeploymentStackWithTemplateSpec
 {
 	# Setup
 	$mgid = "AzBlueprintAssignTest"
 	$stackname = Get-ResourceName
 	$rname = Get-ResourceName
 	$rglocation = "West US 2"

 	try 
	{
 		# Prepare
 		New-AzManagementGroup -Name $mgid -Location $rglocation
 		$sampleTemplateJson = Get-Content -Raw -Path StacksRGTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ManagementGroupId $mgid -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Force
 		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

 		# Test - New-AzManagementGroupDeploymentStack using templateSpecs
 		$deployment = New-AzManagementGroupDeploymentStack -Name $stackname -ManagementGroupId $mgid -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

 		# Test - Set-AzManagementGroupDeploymentStack using templateSpecs
 		$deployment = Set-AzManagementGroupDeploymentStack -Name $stackname -ManagementGroupId $mgid -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Export-AzManagementGroupDeploymentStack checking for template link
		$template = Export-AzManagementGroupDeploymentStackTemplate -Name $stackname -ManagementGroupId $mgid
		Assert-NotNull $template
		Assert-NotNull $template.TemplateLink
		Assert-Null $template.Template
 	}

 	finally
     {
         # Cleanup
         Clean-ManagementGroup $mgid
     }
 }

 <#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at RG scope.
#>
function Test-RemoveManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		New-AzManagementGroup -Name $mgid -Location $rglocation

		# --- RemoveByResourceIdParameterSetName ---

		# Test - Success
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		$resourceId = "/subscriptions/$subId/ManagementGroups/$mgid/providers/Microsoft.Resources/deploymentStacks/$rname"
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Id $resourceId -Force
		Assert-Null $deployment

		# Test - Failure - Bad ID form 
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/ManagementGroups/<mgid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Remove-AzManagementGroupDeploymentStack -Id $badId -Force } $exceptionMessage

		# --- RemoveByNameAndManagementGroupId --- 

		# Test - Failure - RG NotFound
		$badManagementGroupId = "badrg1928273615"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ManagementGroupNotFound : Resource group '$badManagementGroupId' could not be found."
		Assert-Throws { Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $badManagementGroupId -Force } $exceptionMessage

		# Test - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in ManagementGroup '$mgid' not found."
		Assert-Throws { Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgid -StackName $badStackName -Force } $exceptionMessage

		# Test - Success with PassThru - DeleteResources
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeleteResources -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteResources and DeleteManagementGroups
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeleteResources -DeleteManagementGroups -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteAll
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeleteAll -PassThru -Force
		Assert-AreEqual "true" $deployment
	}

	finally
    {
        # Cleanup
        Clean-ManagementGroup $mgid
    }
}

<#
.SYNOPSIS
Tests EXPORT operation on deployment stack templates at RG scope.
#>
function Test-ExportManagementGroupDeploymentStackTemplate
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		New-AzManagementGroup -Name $mgid -Location $rglocation 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json
		$resourceId = "/subscriptions/$subId/ManagementGroups/$mgid/providers/Microsoft.Resources/deploymentStacks/$rname"

		# --- ExportByResourceIdParameterSetName ---
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/ManagementGroups/<mgid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Export-AzManagementGroupDeploymentStackTemplate -Id $badId } $exceptionMessage

		# Test - Success
		$deployment = Export-AzManagementGroupDeploymentStackTemplate -Id $resourceId
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# --- ExportByNameAndManagementGroupId ---

		# Test - Failure - Resource Group NotFound
		$badManagementGroupId = "badrg1928273615"
		$exceptionMessage = "DeploymentStack '$rname' in Resource Group '$badManagementGroupId' not found."
		Assert-Throws { Export-AzManagementGroupDeploymentStackTemplate -Name $rname -ManagementGroupId $badManagementGroupId } $exceptionMessage
		
		# Test - Failure - Stack NotFound
		$badStackName = "badStack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Resource Group '$mgid' not found."
		Assert-Throws { Export-AzManagementGroupDeploymentStackTemplate -Name $badStackName -ManagementGroupId $mgid } $exceptionMessage

		# Test - Success
		$deployment = Export-AzManagementGroupDeploymentStackTemplate -Name $rname -ManagementGroupId $mgid
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template 
	}

	finally
    {
        # Cleanup
        Clean-ManagementGroup $mgid
    }
}