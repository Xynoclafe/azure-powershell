param location string
param rgName string = 'StacksTestRG${uniqueString(subscription().id)}'
param rgName2 string = 'StacksTestRG2${uniqueString(subscription().id)}'
targetScope = 'subscription'

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: rgName
  location: location
}

resource rg2 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: rgName2
  location: location
}