param location string
param rgName string = 'StacksTest2RG${uniqueString(subscription().id)}'
targetScope = 'subscription'

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: rgName
  location: location
}
