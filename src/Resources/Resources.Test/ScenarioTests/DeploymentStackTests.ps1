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
Tests GET operation on deploymentStacks at the RG scope.
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

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByNameAndResourceGroup
		$getByNameAndResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $rname 

		# Assert
		Assert-NotNull $getByNameAndResourceGroup

		# Test - GetByResourceId
		$getByResourceId = Get-AzResourceGroupDeploymentStack -ResourceId $resourceId

		#Assert
		Assert-NotNull $getByResourceId

		#Test - ListByResourceGroupName
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
Tests NEW operation on deploymentStacks at the RG scope.
#>
function Test-NewResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - NewByNameAndResourceGroupAndTemplateFile TODO: Add more combinations
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json

		#Assert
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
Tests Set operation on deploymentStacks at the RG scope
#>
function Test-SetResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try {
		
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - SetByNameAndResourceGroupAndTemplateFile ----------
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		#Test - Setting a stack with additional resources ---------
		
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithAdditionalResource.json -TemplateParameterFile StacksRGTemplateParams.json -Force
		
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		#Test - Setting a blank stack with DeleteResources set ----------

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		#Test - Setting a blank stack with DeleteResources and ResourceGroups set ----------

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		#Test - Setting a blank stack with DeleteAll set ----------

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		#Test - Setting a stack with only DeleteResourceGroups set which should error ----------

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResourceGroups -Force

		Assert-IsNull $deployment
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests NEW operation on deploymentStacks at the RG scope using template specs.
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
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		# Test - New-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json
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
Tests NEW and SET operation on deploymentStacks at the RG scope with the stack being SET having an additional resource.
#>
function Test-NewAndSetResourceGroupDeploymentStackWithAdditionalResource
{
	# Setup
	$rgname = Get-ResourceGroupName
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzResourceGroupDeploymentStacks
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using additional stack that has been modified with an additional resource
		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithAdditionalResource.json -TemplateParameterFile  StacksRGTemplateParams.json
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
Tests NEW and NEW operation on deploymentStacks at the RG scope with deletion of resources when they become unmanaged.
#>
function Test-NewAndNewResourceGroupDeploymentStackDeleteStackResources
{
	# Setup
	$rgname = Get-ResourceGroupName
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzResourceGroupDeploymentStacks
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - New-AzResourceGroupDeploymentStacks using empty stack to unmanage all resources
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -Force
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
Tests NEW and SET operation on deploymentStacks at the RG scope with deletion of resources.
#>
function Test-NewAndSetResourceGroupDeploymentStackDeleteStackResources
{
	# Setup
	$rgname = Get-ResourceGroupName
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzResourceGroupDeploymentStacks
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using empty stack to unmanage all resources
		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources
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
Tests NEW and SET operation on deploymentStacks at the RG scope with deletion of resources and resource groups.
#>
function Test-NewAndSetResourceGroupDeploymentStackDeleteStackResourcesAndStackResourceGroups
{
	# Setup
	$rgname = Get-ResourceGroupName
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzResourceGroupDeploymentStacks
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using empty stack to unmanage all resources
		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups
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
Tests NEW and SET operation on deploymentStacks at the RG scope with deletion of everything tracked by stack.
#>
function Test-NewAndSetResourceGroupDeploymentStackDeleteAll
{
	# Setup
	$rgname = Get-ResourceGroupName
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzResourceGroupDeploymentStacks
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile StacksRGTemplateWithNestedRG.json -TemplateParameterFile StacksRGTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using empty stack to unmanage all resources
		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DeleteAll
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
Tests NEW operation on deploymentStacks at the RG scope with DeleteResourceGroups parameter that should fail without DeleteResources being set as well. 
#>
function Test-NewResourceGroupDeploymentStackDeleteResourceGroupsFailure
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - NewByNameAndResourceGroupAndTemplateFile with only DeleteResourceGroups 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DeleteResourceGroups

		#Assert
		Assert-Null $deployment
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests SET operation on deploymentStacks at the RG scope with DeleteResourceGroups parameter that should fail without DeleteResources being set as well. 
#>
function Test-SetResourceGroupDeploymentStackDeleteResourceGroupsFailure
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - NewByNameAndResourceGroupAndTemplateFile with only DeleteResourceGroups 
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DeleteResourceGroups

		#Assert
		Assert-Null $deployment
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

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - NewByNameAndResourceGroupAndTemplateFile with only DeleteResourceGroups 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DeleteResourceGroups

		#Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Export-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname 

		#Assert
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
Tests NEW operation on deploymentStacks at the Subscription scope
#>
function Test-NewSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try {

		# Test - NewByNameAndTemplateFile
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json

		#Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
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
Tests Set operation on deploymentStacks at the Subscription scope
#>
function Test-SetSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId


	try {
		# Prepare
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		#Test - SetByNameAndTemplateFile
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -force -location $location

		#Assert
		Assert-NotNull $deployment

		#Clean up
		Clean-DeploymentAtSubscription $rname

		# Prepare

		#Test - SetByNameAndTemplateFileAndTemplateParameterFile
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -force -location $location

		#Assert
		Assert-NotNull $deployment
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
    }
}

<#
.SYNOPSIS
Tests NEW and SET operation on deploymentStacks at the subscription scope using template specs
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
Tests NEW and SET operation on deploymentStacks at the Sub scope with the stack being SET having an additional resource.
#>
function Test-NewAndSetSubscriptionDeploymentStackWithAdditionalResource
{
	# Setup
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Test - New-AzResourceGroupDeploymentStacks
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using additional stack that has been modified with an additional resource
		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -TemplateFile StacksSubTemplateWithAdditionalResource.json -TemplateParameterFile  StacksSubTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
    }
}

<#
.SYNOPSIS
Tests NEW and NEW operation on deploymentStacks at the Sub scope with deletion of resources.
#>

function Test-NewAndNewSubscriptionDeploymentStackDeleteStackResources
{
	# Setup
	$stackname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - New-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile blankTemplate.json -DeleteResources -Force
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
         Clean-DeploymentAtSubscription $stackname
    }
}


<#
.SYNOPSIS
Tests NEW and SET operation on deploymentStacks at the Sub scope with deletion of resources.
#>

function Test-NewAndSetSubscriptionDeploymentStackDeleteStackResources
{
	# Setup
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - New-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile blankTemplate.json -DeleteResources
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
       Clean-DeploymentAtSubscription $stackname
    }
}

<#
.SYNOPSIS
Tests NEW and SET operation on deploymentStacks at the Sub scope with deletion of resources.
#>

function Test-NewAndSetSubscriptionDeploymentStackDeleteStackResources
{
	# Setup
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile blankTemplate.json -DeleteResources
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
		Clean-DeploymentAtSubscription $stackname
    }
}


<#
.SYNOPSIS
Tests NEW and SET operation on deploymentStacks at the RG scope with deletion of resources and resource groups.
#>

function Test-NewAndSetSubscriptionDeploymentStackDeleteStackResourcesAndResourceGroups
{
	# Setup
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile blankTemplate.json -DeleteResources -DeleteResourceGroups
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $stackname

    }
}

<#
.SYNOPSIS
Tests NEW and SET operation on deploymentStacks at the Sub scope with deletion of everything tracked by stack.
#>
function Test-NewAndSetSubscriptionDeploymentStackDeleteAll
{
	# Setup
	$stackname = Get-ResourceName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Test - New-AzResourceGroupDeploymentStacks
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile StacksSubTemplateWithNestedRG.json -TemplateParameterFile StacksSubTemplateParams.json
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using empty stack to unmanage all resources
		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile blankTemplate.json -DeleteAll
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $stackname
    }
}

<#
.SYNOPSIS
Tests NEW operation on deploymentStacks at the Sub scope with DeleteResourceGroups parameter that should fail without DeleteResources being set as well. 
#>
function Test-NewSubsciptionDeploymentStackDeleteResourceGroupsFailure
{
	# Setup
	$stackname = Get-ResourceName
	$rglocation = "West US 2"

	try {

		#Test - New-AzSubscriptionDeploymentStack with only DeleteResourceGroups 
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DeleteResourceGroups

		#Assert
		Assert-Null $deployment
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $stackname
    }
}

<#
.SYNOPSIS
Tests SET operation on deploymentStacks at the Sub scope with DeleteResourceGroups parameter that should fail without DeleteResources being set as well. 
#>
function Test-NewSubsciptionDeploymentStackDeleteResourceGroupsFailure
{
	# Setup
	$stackname = Get-ResourceName
	$rglocation = "West US 2"

	try {

		#Test - Set-AzSubscriptionDeploymentStack with only DeleteResourceGroups 
		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DeleteResourceGroups

		#Assert
		Assert-Null $deployment
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $stackname
    }
}

<#
.SYNOPSIS
Tests EXPORT operation on deploymentStacks.
#>
function Test-ExportSubscriptionDeploymentStackTemplate
{
	# Setup
	$stackname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		#Test - NewByNameAndResourceGroupAndTemplateFile with only DeleteResourceGroups 
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DeleteResourceGroups

		#Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Export-AzSubscriptionDeploymentStack -Name $stackname

		#Assert
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $stackname
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
		#TODO: Need some sort of cleanup for management group deployments
        Clean-DeploymentAtSubscription $rname
    }
}


#----------------------------------------Delete Tests---------------------------------

<#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks 
#>
function Test-RemoveResourceGroupDeploymentStack
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


		# Test - removeByResourceId
		$removeByResourceId = Remove-AzResourceGroupDeploymentStack -ResourceId $resourceId -force

		# Assert
		Assert-NotNull $removeByResourceId

		#Prepare
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json -force


		# Test - removeByResourceNameAndResourceGroupName
		$removeByResourceNameAndResourceGroupName = Remove-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -Name $rname -force

		#Assert
		Assert-NotNull $removeByResourceNameAndResourceGroupName

	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks 
#>
function Test-RemoveResourceGroupDeploymentStackDeleteResources
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


		# Test - removeByResourceId
		$removeByResourceId = Remove-AzResourceGroupDeploymentStack -ResourceId $resourceId -force

		# Assert
		Assert-NotNull $removeByResourceId

		#Prepare
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json -force


		# Test - removeByResourceNameAndResourceGroupName
		$removeByResourceNameAndResourceGroupName = Remove-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -Name $rname -force

		#Assert
		Assert-NotNull $removeByResourceNameAndResourceGroupName

	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
} 

<#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at the subscription scope
#>
function Test-RemoveSubscriptionDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -location $rglocation
		$resourceid = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - RemoveByName
		$removeByName = Remove-AzSubscriptionDeploymentStack -Name $rname -force

		# Assert
		Assert-NotNull $removeByName 

		# Prepare
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -location $rglocation -force

		# Test - RemoveByResourceId
		$removeByResourceId = Remove-AzSubscriptionDeploymentStack -ResourceId $resourceid -force

		#Assert
		Assert-NotNull $removeByResourceId
	}

	finally
	{
		Clean-DeploymentAtSubscription $rname
	}

}

<#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at the subscription scope
#>
function Test-RemoveSubscriptionDeploymentStackDeleteResources
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -location $rglocation
		$resourceid = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - RemoveByName
		$removeByName = Remove-AzSubscriptionDeploymentStack -Name $rname -force

		# Assert
		Assert-NotNull $removeByName 

		# Prepare
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -location $rglocation -force

		# Test - RemoveByResourceId
		$removeByResourceId = Remove-AzSubscriptionDeploymentStack -ResourceId $resourceid -force

		#Assert
		Assert-NotNull $removeByResourceId
	}

	finally
	{
		Clean-DeploymentAtSubscription $rname
	}

}


<#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at the subscription scope
#>
function Test-RemoveSubscriptionDeploymentStackDeleteResourcesAndResourceGroups
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -location $rglocation
		$resourceid = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - RemoveByName
		$removeByName = Remove-AzSubscriptionDeploymentStack -Name $rname -force

		# Assert
		Assert-NotNull $removeByName 

		# Prepare
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -location $rglocation -force

		# Test - RemoveByResourceId
		$removeByResourceId = Remove-AzSubscriptionDeploymentStack -ResourceId $resourceid -force

		#Assert
		Assert-NotNull $removeByResourceId
	}

	finally
	{
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