// ----------------------------------------------------------------------------------
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
        public void TestResourceGroupDeploymentStackGet()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStack");
        }

/*      [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResourceGroupDeploymentStackSnapshotGet()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStackSnapshot");
        }*/

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSubscriptionDeploymentStackGet()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStack");
        }

/*      [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSubscriptionDeploymentStackSnapshotGet()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStackSnapshot");
        }*/

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetResourceGroupDeploymentStackWithBicep()
        {
            TestRunner.RunTestScript("Test-NewAndSetResourceGroupDeploymentStackWithBicep");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetResourceGroupDeploymentStackWithTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewAndSetResourceGroupDeploymentStackWithTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetSubscriptionDeploymentStackWithBicep()
        {
            TestRunner.RunTestScript("Test-NewAndSetSubscriptionDeploymentStackWithBicep");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetSubscriptionDeploymentStackWithTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewAndSetSubscriptionDeploymentStackWithTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResourceGroupDeploymentStackDelete()
        {
            TestRunner.RunTestScript("Test-RemoveResourceGroupDeploymentStack");
        }

/*      [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResourceGroupDeploymentStackSnapshotDelete()
        {
            TestRunner.RunTestScript("Test-RemoveResourceGroupDeploymentStackSnapshot");
        }*/

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSubscriptionDeploymentStackDelete()
        {
            TestRunner.RunTestScript("Test-RemoveSubscriptionDeploymentStack");
        }

/*      [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSubscriptionDeploymentStackSnapshotDelete()
        {
            TestRunner.RunTestScript("Test-RemoveSubscriptionDeploymentStackSnapshot");
        }*/

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-SetResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-SetSubscriptionDeploymentStack");
        }

    }
}
