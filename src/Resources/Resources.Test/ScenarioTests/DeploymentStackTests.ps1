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
		$getByName = Get-AzDeploymentStack -Name $rname 

		# Assert
		Assert-NotNull $getByName

		# Test - GetByResourceId
		$getByResourceId = Get-AzDeploymentStack -ResourceId $resourceId

		#Assert
		Assert-NotNull $getByResourceId

		#Test - ListByResourceGroupName
		$list = Get-AzDeploymentStack

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
		$getByName = Get-AzDeploymentStack -Name $rname 

		# Assert
		Assert-NotNull $getByName

		# Test - GetByResourceId
		$getByResourceId = Get-AzDeploymentStack -ResourceId $resourceId

		#Assert
		Assert-NotNull $getByResourceId

		#Test - ListByResourceGroupName
		$list = Get-AzDeploymentStack

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
Tests NEW and SET operation on deploymentStacks at the RG scope using template specs
#>

function Test-NewAndSetResourceGroupDeploymentStackWithTemplateSpec
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		# Test - New-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateSpec $resourceId -ParameterFile "sampleTemplateParams.json"
		$id = $deployment.id

		while ($deployment.provisioningState == "initializing" or $deployment.provisioningState == "failed"){
			$deployment = Get-AzResourceGroupDeploymentStack -id $id
		}


		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks using templateSpecs
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateSpec $resourceId -ParameterFile "sampleTemplateParams.json" -updateBehavior "detach"
		$id = $deployment.id

		while ($deployment.provisioningState == "initializing" or $deployment.provisioningState == "failed"){
			$deployment = Get-AzResourceGroupDeploymentStack -id $id
		}

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

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
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$sampleTemplateJson = Get-Content -Raw -Path "subscription_level_template.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		# Test - New-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateSpec $resourceId -Location "West US 2"
		$id = $deployment.id

		while ($deployment.provisioningState == "initializing" or $deployment.provisioningState == "failed"){
			$deployment = Get-AzSubscriptionDeploymentStack -id $id
		}

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		# Test - Set-AzSubscriptionDeploymentStacks using templateSpecs
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -TemplateSpec $resourceId -ParameterFile "sampleTemplateParams.json" -Location $rglocation -updateBehavior "detach"
		$id = $deployment.id

		while ($deployment.provisioningState == "initializing" or $deployment.provisioningState == "failed"){
			$deployment = Get-AzSubscriptionDeploymentStack -id $id
		}


		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

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
	$rname = Get-ResourceName
	$location = "West US 2"

	try {

		#Test - NewByNameAndResourceGroupAndTemplateFile
		$NewByNameAndTemplateFile = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile simpleTemplate.json

		#Assert
		Assert-NotNull $NewByNameAndTemplateFile

		# Cleanup
        Clean-DeploymentAtSubscription $rname

		#Test - NewByNameAndResourceGroupAndTemplateFileAndParameterFile
		$NewByNameAndTemplateFileAndParameterFile = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json

		#Assert
		Assert-NotNull $NewByNameAndTemplateFileAndParameterFile

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
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json

		$provisioningState = $deployment.provisioningState
		$stackName = $deployment.name


		while ($provisioningState == "initializing" or $provisioningState == "failed"){
			$provisioningState = $deployment.provisioningState
		}

		$deployment = Get-AzResourceGroupDeploymentStack -stackname $stackName -ResourceGroupName $rgname
		$snapshotId = $deployment.SnapshotId;

		# Test - removeByResourceId
		$removeByResourceId = Remove_AzResourceGroupDeploymentStackSnapshot -resourceid $snapshotId

		# Assert
		Assert-NotNull $RemoveByResourceId

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json

		$provisioningState = $deployment.provisioningState
		$stackName = $deployment.name


		while ($provisioningState == "initializing" or $provisioningState == "failed"){
			$provisioningState = $deployment.provisioningState
		}

		$deployment = Get-AzResourceGroupDeploymentStack -stackname $stackName -ResourceGroupName $rgname
		$snapshotName = $deployment.SnapshotId.split('/')[-1];

		# Test - removeByNameAndSnapshotNameAndResourceGroupName
		$removeByNameAndSnapshotNameAndResourceGroupName = Remove_AzResourceGroupDeploymentStackSnapshot -name $stackName -snapshotname $snapshotName -ResourceGroupName $rgname

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

		finally
		{
		}

	}
}

<#
.SYNOPSIS
Tests REMOVE operation on deploymentStacksSnapshot at the subscription scope
#>
#This will not work because we need multiple snapshots in subscription, how would we go about testing this
function Test-RemoveSubscriptionDeploymentStackSnapshot
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json
		#?
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		$provisioningState = $deployment.provisioningState
		$stackName = $deployment.name


		while ($provisioningState == "initializing" or $provisioningState == "failed"){
			$provisioningState = $deployment.provisioningState
		}

		$deployment =  Get-AzDeploymentStack -name $stackName
		$snapshotId = $deployment.SnapshotId

		# Test - removeByResourceId
		$removeByResourceId = remove-azsubscriptiondeploymentstacksnapshot -resourceid $snapshotId

		# Assert
		Assert-NotNull $removeByResourcId 

		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json
		#?
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		$provisioningState = $deployment.provisioningState
		$stackName = $deployment.name


		while ($provisioningState == "initializing" or $provisioningState == "failed"){
			$provisioningState = $deployment.provisioningState
		}

		$deployment =  Get-AzDeploymentStack -name $stackName
		$snapshotName = ($deployment.SnapshotId).split('/')[-1]


		# Test - removeByNameandSnapshotName
		$removeByNameandSnapshotName = 	remove-azsubscriptiondeploymentstack -name $stackName -snapshotname $snapshotName

		# Assert
		Assert-NotNull $removeByNameandSnapshotName 

	}

	finally
    {
       
    }
}

<#
.SYNOPSIS
Tests Set operation on deploymentStacks at the RG scope
#>

#NEED TO CONFIRM: that the only cases for this test should be: name, rgname, templateFile or name, rgname, templateFile, paramterFile
function Test-SetResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try {
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json

		#Test - SetByNameAndResourceGroupAndTemplateFile
		$SetByNameAndResourceGroupAndTemplateFile = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json

		#Assert
		Assert-NotNull $SetByNameAndResourceGroupAndTemplateFile

		#Clean up
		Clean-ResourceGroup $rgname

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json

		#Test - SetByNameAndResourceGroupAndTemplateFileAndParameterFile
		$SetByNameAndResourceGroupAndTemplateFile = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json

		#Assert
		Assert-NotNull $SetByNameAndResourceGroupAndTemplateFileAndParameterFile
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Tests SET operation on deploymentStacks at the Subscription scope
#>

#NEED TO CONFIRM: that the only cases for this test should be: name, location, templateFile or name, location, templateFile, paramterFile
function Test-SetSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try {
		#Prepare
		New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile simpleTemplate.json

		#Test - SetByNameAndResourceGroupAndTemplateFile
		$SetByNameAndTemplateFile = Set-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile simpleTemplate.json

		#Assert
		Assert-NotNull $SetByNameAndTemplateFile

		# Cleanup
        Clean-DeploymentAtSubscription $rname

		#Prepare
		New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile simpleTemplate.json

		#Test - SetByNameAndResourceGroupAndTemplateFileAndParameterFile
		$SetByNameAndTemplateFileAndParameterFile = Set-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile simpleTemplate.json -ParameterFile simpleTemplateParams.json

		#Assert
		Assert-NotNull $SetByNameAndTemplateFileAndParameterFile

	}

	finally
    {
        # Cleanup
        Clean-DeploymentAtSubscription $rname
    }
}

