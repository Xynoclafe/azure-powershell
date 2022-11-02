﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DeploymentStackTests : ResourcesTestRunner
    {
        public DeploymentStackTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStack");
        }
    
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStackDenySettings()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStackDenySettings");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResourceGroupDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResourceGroupDeploymentStackDenySettings()
        {
            TestRunner.RunTestScript("Test-SetResourceGroupDeploymentStackDenySettings");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetAndExportResourceGroupDeploymentStackWithTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewAndSetAndExportResourceGroupDeploymentStackWithTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetResourceGroupDeploymentStackWithBicep()
        {
            TestRunner.RunTestScript("Test-NewAndSetResourceGroupDeploymentStackWithBicep");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportResourceGroupDeploymentStackTemplate()
        {
            TestRunner.RunTestScript("Test-ExportResourceGroupDeploymentStackTemplate");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-RemoveResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStackDenySettings()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStackDenySettings");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSubscriptionDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSubscriptionDeploymentStackDenySettings()
        {
            TestRunner.RunTestScript("Test-SetSubscriptionDeploymentStackDenySettings");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetSubscriptionDeploymentStackWithTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewAndSetSubscriptionDeploymentStackWithTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetSubscriptionDeploymentStackWithBicep()
        {
            TestRunner.RunTestScript("Test-NewAndSetSubscriptionDeploymentStackWithBicep");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportSubscriptionDeploymentStackTemplate()
        {
            TestRunner.RunTestScript("Test-ExportSubscriptionDeploymentStackTemplate");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-RemoveSubscriptionDeploymentStack");
        }
    }
}
