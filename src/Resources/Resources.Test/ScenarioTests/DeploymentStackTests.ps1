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
Tests GET operation on deploymentStacks at the RG scope
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

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -TemplateParameterFile simpleTemplateParams.json
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
Tests GET operation on deploymentStacksSnapshots at the RG scope
#>
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

<#
.SYNOPSIS
Tests GET operation on deploymentStacks at the Subscription scope
#>
function Test-GetSubscriptionDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json
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
Tests GET operation on deploymentStacksSnapshot at the Subscription scope
#>
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

<#
.SYNOPSIS
Tests NEW operation on deploymentStacks at the RG scope
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

		#Test - NewByNameAndResourceGroupAndTemplateFile
		$NewByNameAndResourceGroupAndTemplateFile = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json

		#Assert
		Assert-NotNull $NewByNameAndResourceGroupAndTemplateFile
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests NEW and SET operation on deploymentStacks at the RG scope using template specs
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

		$sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		# Test - New-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile "sampleTemplateParams.json"
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile "sampleTemplateParams.json" -updateBehavior "detachResources"
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

		$sampleTemplateJson = Get-Content -Raw -Path "subscription_level_template.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		# Test - New-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateSpec $resourceId -TemplateParameterFile "subscription_level_parameters.json" -Location $rglocation
		$id = $deployment.id

		# Assert
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateSpec $resourceId -TemplateParameterFile "subscription_level_parameters.json" -Location $rglocation -updateBehavior "detachResources"
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
Tests NEW operation on deploymentStacks at the Subscription scope
#>
function Test-NewSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try {

		# Test - NewByNameAndTemplateFile
		$NewByNameAndTemplateFile = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json

		# Assert
		Assert-NotNull $NewByNameAndTemplateFile

	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
    }
}

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
Tests REMOVE operation on deploymentStacksSnapshot
#>
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
Tests REMOVE operation on deploymentStacksSnapshot
#>
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
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		#Test - SetByNameAndResourceGroupAndTemplateFile
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json -UpdateBehavior "detachResources" -force

		#Assert
		Assert-NotNull $deployment

		#Clean up
		Clean-ResourceGroup $rgname

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - SetByNameAndResourceGroupAndTemplateFileAndTemplateParameterFile
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json -UpdateBehavior "detachResources" -force

		#Assert
		Assert-NotNull $deployment
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
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
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -UpdateBehavior "detachResources" -force -location $location

		#Assert
		Assert-NotNull $deployment

		#Clean up
		Clean-DeploymentAtSubscription $rname

		# Prepare

		#Test - SetByNameAndTemplateFileAndTemplateParameterFile
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -UpdateBehavior "detachResources" -force -location $location

		#Assert
		Assert-NotNull $deployment
	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
    }
}