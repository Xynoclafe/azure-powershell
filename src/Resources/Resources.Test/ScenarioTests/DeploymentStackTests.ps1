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

		# Test - GetByNameAndResourceGroup
		$getByNameAndResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $rname 

		Assert-NotNull $getByNameAndResourceGroup

		# Test - GetByResourceId
		$getByResourceId = Get-AzResourceGroupDeploymentStack -ResourceId $resourceId

		# Assert
		Assert-NotNull $getByResourceId

		# Test - ListByResourceGroupName
		$listByResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname

		# Assert
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
Tests NEW operation on deploymentStacks at the RG scope with bicep file.
#>
function Test-NewAndSetResourceGroupDeploymentStackWithBicep
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	
	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - NewByNameAndResourceGroupAndBicepTemplateFile
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleDeploymentBicepFile.bicep

		#Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleDeploymentBicepFile2.bicep

		# Assert
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
Tests New operation on deployment stacks at the RG scope.
#>
function Test-NewResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		New-AzResourceGroup -Name $rgname -Location $rglocation
		
		# Test - ParameterlessTemplateFileParameterSetName

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroup $rgname -TemplateFile blankTemplate.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ParameterObjectTemplateFileParameterSetName
		# ...

		# Test - ParameterFileTemplateFileParameterSetName
		
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ParameterFileTemplateUriParameterSetName
		# ...
		
		# Test - ParameterUriTemplateFileParameterSetName
		# ...
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS	
Tests Set operation on deploymentStacks at the RG scope
#>
function Test-SetResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - ParameterlessTemplateFileParameterSetName

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroup $rgname -TemplateFile blankTemplate.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ParameterObjectTemplateFileParameterSetName
		# ...

		# Test - ParameterFileTemplateFileParameterSetName
		
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ParameterFileTemplateUriParameterSetName
		# ...

		# Test - ParameterUriTemplateFileParameterSetName
		# ...
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

	try {

		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Setting a blank stack with DeleteResources set 

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "detach" $deployment.ResourceGroups

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a blank stack with DeleteAll set 

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a stack with only DeleteResourceGroups set which should error 
		
		$exceptionMessage = "New-AzResourceGroupDeploymentStack: Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		
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
Tests SET operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-SetResourceGroupDeploymentStackUnmanageActions
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Setting a blank stack with DeleteResources set 

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "detach" $deployment.ResourceGroups

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a blank stack with DeleteAll set 

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a stack with only DeleteResourceGroups set which should error 

		$exceptionMessage = "Set-AzResourceGroupDeploymentStack: Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		
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
 Tests NEW and SET operations on deploymentStacks at the RG scope using template specs.
 #>
 function Test-NewAndSetResourceGroupDeploymentStackWithTemplateSpec
 {
 	# Setup
 	$rgname = Get-ResourceGroupName
 	$stackname = Get-ResourceName
 	$rname = Get-ResourceName
 	$rglocation = "West US 2"

 	try {
 		# Prepare
 		New-AzResourceGroup -Name $rgname -Location $rglocation

 		$sampleTemplateJson = Get-Content -Raw -Path StacksRGTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Force

 		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

 		# Test - New-AzResourceGroupDeploymentStacks using templateSpecs
 		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json -Force
 		$id = $deployment.id

 		# Assert
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

 		# Test - Set-AzResourceGroupDeploymentStacks using templateSpecs
 		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json -Force
 		$id = $deployment.id

 		# Assert
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
Tests REMOVE operation on deploymentStacks at RG scope.
#>
function Test-RemoveResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try {

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - RemoveByResourceId

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Id $resourceId -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.Resources
		Assert-AreEqual "detach" $deployment.ResourceGroups

		# Test - RemoveByNameAndResourceGroupName with DeleteResources set

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "detach" $deployment.ResourceGroups

		# Test - RemoveByNameAndResourceGroupName with DeleteResources and DeleteResoueceGroups set

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - RemoveByNameAndResourceGroupName with DeleteAll set

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a stack with only DeleteResourceGroups set which should error

		$exceptionMessage = "Remove-AzResourceGroupDeploymentStack: Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		
		Assert-Throws { Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -DeleteResourceGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests EXPORT operation on deploymentStacks.
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

		# Test - Attempt to Export nonexistant template
		$errorMessage = "Export-AzResourceGroupDeploymentStackTemplate: DeploymentStack '$rname' in Resource Group '$rgname' not found."
		try 
		{
			Export-AzResourceGroupDeploymentStackTemplate -Name $rname -ResourceGroupName $rgname
		}
		catch 
		{
			# $outputMessage = $_
			# Assert-AreEqual $outputMessage $errorMessage
		}

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"
		
		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ExportByNameAndResourceGroupName
		$deployment = Export-AzResourceGroupDeploymentStackTemplate -Name $rname -ResourceGroupName $rgname 

		# Assert
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# Test - ExportByResourceId
		$deployment = Export-AzResourceGroupDeploymentStackTemplate -Id $resourceId

		# Assert
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
Tests GET operation on deploymentStacks at the Subscription scope.
#>
function Test-GetSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByName
		$getByName = Get-AzSubscriptionDeploymentStack -Name $rname 

		# Assert
		Assert-NotNull $getByName

		# Test - GetByResourceId
		$getByResourceId = Get-AzSubscriptionDeploymentStack -ResourceId $resourceId

		#Assert
		Assert-NotNull $getByResourceId

		#Test - ListByResourceGroupName
		$list = Get-AzSubscriptionDeploymentStack

		# Assert
		Assert-AreNotEqual 0 $list.Count
		Assert-True { $list.name.contains($rname) }
	}
	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
    }
}

<#
.SYNOPSIS
Tests NEW and SET operation on deploymentStacks at the subscription scope using a bicep template
#>
function Test-NewAndSetSubscriptionDeploymentStackWithBicep
{
	# Setup
	$rname = Get-ResourceName
	$rgname = Get-ResourceName
	$rglocation = "West US"

	try {
		# Test - New-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile sampleSubscriptionDeploymentBicepFile.bicep -Location $rglocation

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile sampleSubscriptionDeploymentBicepFile.bicep -Location $rglocation

		# Assert
		assert-AreEqual "succeeded" $deployment.ProvisioningState
	}
	
	finally
	{
		# Cleanup
		Clean-DeploymentAtSubscription $rname
	}
}

<#
.SYNOPSIS
Tests New operation on deploymentStacks at the Subscription scope.
#>
function Test-NewSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName

	try {
		# Test - ParameterlessTemplateFileParameterSetName

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ParameterObjectTemplateFileParameterSetName
		# ...

		# Test - ParameterFileTemplateFileParameterSetName
		
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ParameterFileTemplateUriParameterSetName
		# ...

		# Test - ParameterUriTemplateFileParameterSetName
		# ...
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rgname
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

	try {
		# Test - ParameterlessTemplateFileParameterSetName

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ParameterObjectTemplateFileParameterSetName
		# ...

		# Test - ParameterFileTemplateFileParameterSetName
		
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ParameterFileTemplateUriParameterSetName
		# ...

		# Test - ParameterUriTemplateFileParameterSetName
		# ...
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rgname
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
	$rglocation = "West US 2"

	try {

		# Test - Setting a blank stack with DeleteResources set 

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "detach" $deployment.ResourceGroups

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a blank stack with DeleteAll set 

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a stack with only DeleteResourceGroups set which should error 
		
		$exceptionMessage = "New-AzSubscriptionDeploymentStack: Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		
		Assert-Throws { New-AzResourceGroupDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResourceGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
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
	$rglocation = "West US 2"

	try {

		# Test - Setting a blank stack with DeleteResources set 

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "detach" $deployment.ResourceGroups

		# Test - Setting a blank stack with DeleteResources and ResourceGroups set 

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a blank stack with DeleteAll set 

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a stack with only DeleteResourceGroups set which should error 

		$exceptionMessage = "Set-AzSubscriptionDeploymentStack: Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		
		Assert-Throws { Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -DeleteResourceGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
		Clean-DeploymentAtSubscription $rname
    }
}

<#
.SYNOPSIS
Tests NEW and SET operation on deploymentStacks at the subscription scope using template specs.
#>
function Test-NewAndSetSubscriptionDeploymentStackWithTemplateSpec
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$stackname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$sampleTemplateJson = Get-Content -Raw -Path StacksSubTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		# Test - New-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateSpec $resourceId -TemplateParameterFile StacksSubTemplateParams.json -Location $rglocation
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateSpec $resourceId -TemplateParameterFile StacksTemplateParams.json -Location $rglocation
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
		Clean-DeploymentAtSubscription $stackname
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
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try {

		# Test - RemoveByResourceId

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Force
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Id $resourceId -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.Resources
		Assert-AreEqual "detach" $deployment.ResourceGroups

		# Test - RemoveByNameAndResourceGroupName with DeleteResources set

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "detach" $deployment.ResourceGroups

		# Test - RemoveByNameAndResourceGroupName with DeleteResources and DeleteResoueceGroups set

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - RemoveByNameAndResourceGroupName with DeleteAll set

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateWithNestedRGParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.Resources
		Assert-AreEqual "delete" $deployment.ResourceGroups

		# Test - Setting a stack with only DeleteResourceGroups set which should error

		$exceptionMessage = "Remove-AzSubscriptionDeploymentStack: Operation returned an invalid status code 'BadRequest' : DeploymentStackInvalidDeploymentStackDefinition : Deployment stack definition is invalid - ActionOnUnmanage is not correctly defined. Cannot set Resources to 'Detach' and Resource Groups to 'Delete'."
		
		Assert-Throws { Remove-AzSubscriptionDeploymentStack -Name $rname -DeleteResourceGroups -Force } $exceptionMessage
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
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
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{

		# Test - Attempt to Export nonexistant template
		$errorMessage = "Export-AzSubscriptionDeploymentStackTemplate: DeploymentStack '$rname' not found."
		try 
		{
			Export-AzSubscriptionDeploymentStackTemplate -Name $rname
		}
		catch 
		{
			# $outputMessage = $_
			# Assert-AreEqual $outputMessage $errorMessage
		}

		# Prepare
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"
		
		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - ExportByNameAndResourceGroupName
		$deployment = Export-AzSubscriptionDeploymentStackTemplate -Name $rname 

		# Assert
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# Test - ExportByResourceId
		$deployment = Export-AzSubscriptionDeploymentStackTemplate -Id $resourceId

		# Assert
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
    }
}

# ---------- Management Group Scope Tests ----------

<#
.SYNOPSIS
Tests GET operation on deploymentStacks at the Management Group scope.
#>
function Test-GetManagementGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Location $location -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByName
		$getByName = Get-AzManagementGroupDeploymentStack -Name $rname 

		# Assert
		Assert-NotNull $getByName

		# Test - GetByResourceId
		$getByResourceId = Get-AzManagementGroupDeploymentStack -ResourceId $resourceId

		#Assert
		Assert-NotNull $getByResourceId

		#Test - ListByResourceGroupName
		$list = Get-AzManagementGroupDeploymentStack

		# Assert
		Assert-AreNotEqual 0 $list.Count
		Assert-True { $list.name.contains($rname) }
	}
	finally
    {
        # Cleanup
		# TODO: Cleanup management group scope
        Clean-DeploymentAtSubscription $rname
    }
}

# ---------- Snapshot Tests ----------

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