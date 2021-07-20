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

		$getByNameAndResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -Name $rname 
		$provisioningState = $getByNameAndResourceGroup.provisioningState

		while ($provisioningState == "initializing" or $provisioningState == "failed"){
			$getByNameAndResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -Name $rname 
			$provisioningState = $$getByNameAndResourceGroup.provisioningState
		}

		$resourceId = $getByNameAndResourceGroup.snapshotId
		$snapshotName = ResourceIdUtility.GetResourceName($resourceId).Split('/')[0];

		#Test - GetByIdAndSnapshotName
		$getByIdAndSnapshotName = Get-AzResourceGroupDeploymentStackSnapshot -ResourceId $resourceId -SnapshotName $snapshotName

		#Assert
		Assert-AreEqual $provisioningState "succeeded"
		Assert-NotNull $getByIdAndSnapshotName

		#Test - GetByResourceGroupNameAndStackName
		Assert-AreEqual $provisioningState "succeeded"
		$getByResourceGroupNameAndStackName = Get-AzResourceGroupDeploymentStackSnapshot -ResourceGroupName $rgname -StackName $rname

		#Assert
		Assert-NotNull $getByResourceGroupNameAndStackName

		#Test - GetByResourceGroupNameAndStackNameAndSnapshotName
		Assert-AreEqual $provisioningState "succeeded"
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
Tests GET operation on deploymentStacksSnapshot at the Subscription scope
#>
function Test-GetSubscriptionDeploymentStackSnapshot
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

		$provisioningState = $deployment.provisioningState
		$stackName = $deployment.name


		while ($provisioningState == "initializing" or $provisioningState == "failed"){
			$provisioningState = $deployment.provisioningState
		}

		# Test - GetByStackName
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
Tests NEW operation on deploymentStacks at the RG scope
#>

#NEED TO CONFIRM: that the only cases for this test should be: name, rgname, templateFile or name, rgname, templateFile, paramterFile
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
		$NewByNameAndResourceGroupAndTemplateFile = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json

		#Assert
		Assert-NotNull $NewByNameAndResourceGroupAndTemplateFile

		#Clean up
		Clean-ResourceGroup $rgname

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - NewByNameAndResourceGroupAndTemplateFileAndParameterFile
		$NewByNameAndResourceGroupAndTemplateFile = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json

		#Assert
		Assert-NotNull $NewByNameAndResourceGroupAndTemplateFileAndParameterFile
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

#NEED TO CONFIRM: that the only cases for this test should be: name, location, templateFile or name, location, templateFile, paramterFile
function Test-NewSubscriptionDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - NewByNameAndResourceGroupAndTemplateFile
		$NewByNameAndResourceGroupAndTemplateFile = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json

		#Assert
		Assert-NotNull $NewByNameAndResourceGroupAndTemplateFile

		#Clean up
		Clean-ResourceGroup $rgname

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Test - NewByNameAndResourceGroupAndTemplateFileAndParameterFile
		$NewByNameAndResourceGroupAndTemplateFile = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json

		#Assert
		Assert-NotNull $NewByNameAndResourceGroupAndTemplateFileAndParameterFile
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
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - RemoveByName
		$removeByName = Remove-AzSubscriptionDeploymentStack -Name $rname 

		# Assert
		Assert-NotNull $removeByName 

		# Prepare
		New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json

		# Test - RemoveByResourceId
		$removeByResourceId = Remove-AzSubscriptionDeploymentStack -ResourceId $resourceId

		#Assert
		Assert-NotNull $removeByResourceId

	}
}

