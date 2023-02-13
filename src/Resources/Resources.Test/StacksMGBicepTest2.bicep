param subId string
param location string
param rgName string
param modName string
targetScope = 'managementGroup'

module mod 'StacksSubBicepTest1.bicep' = {
  name: modName
  scope: subscription(subId)
  params: {
    rgName: rgName
    location: location
  }
}