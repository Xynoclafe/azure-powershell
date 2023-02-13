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