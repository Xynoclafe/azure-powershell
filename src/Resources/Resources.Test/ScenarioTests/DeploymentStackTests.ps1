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

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByNameAndResourceGroup
		$getByNameAndResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -Name $rname 

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
	#Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	$vmName = "MyVM"
	$snapshotName = "snapshot"


	try
	{
		#Prepare
		New-AzVm -ResourceGroupName $rgname -Name $vmName -Location $rglocation -VirtualNetworkName "myVnet" -SubnetName "mySubnet" -SecurityGroupName "myNetworkSecurityGroup" -PublicIpAddressName "myPublicIpAddress" -OpenPorts 80,3389
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmName
		$snapshot =  New-AzSnapshotConfig -SourceUri $vm.StorageProfile.OsDisk.ManagedDisk.Id -Location $rglocation -CreateOption copy
		New-AzSnapshot -Snapshot $snapshot -SnapshotName $snapshotName -ResourceGroupName $rgname 

		New-AzResourceGroup -Name $rgname -Location $rglocation
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.js
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname/snapshots/$snapshotName"

		#Test - GetByIdAndSnapshotName
		$getByIdAndSnapshotName = Get-AzResourceGroupDeploymentStackSnapshot -ResourceId $resourceId -SnapshotName $snapshotName

		#Assert
		Assert-NotNull $getByIdAndSnapshotName

		#Test - GetByResourceGroupNameAndStackName
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
	$rglocation = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json
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
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json
		

		# Test - removeByResourceId
		$removeByResourceId = Remove-AzResourceGroupDeploymentStack -ResourceId $resourceId 

		# Assert
		Assert-NotNull $removeByResourceId

		#Prepare
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json


		# Test - removeByResourceNameAndResourceGroupName
		$removeByResourceNameAndResouceGroupName = Remove-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -Name $rname

		#Assert
		Assert-NotNull $removeByResourceNameAndResouceGroupName

	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}