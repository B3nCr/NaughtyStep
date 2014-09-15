// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using NaughtyStep;
using NUnit.Framework;

namespace NaughtyStepTests.Integration
{

    [TestFixture]
    public class BddTestFixture : NaughtyStepCoypuFeature<SiteVisitor>
    {
        [TestFixtureSetUp]
        public new void Init()
        {
            base.Init();
        }

        [TestFixtureTearDown]
        public new void Dispose()
        {
            base.Dispose();
        }

        [Test]
        public void VisitSite()
        {
            Feature("As a tester I want to be able to prove that features of the system are working as expected", () =>
            {
                Scenario("Visit the home page", () =>
                {
                    Given("I am on the NaughtyStep homepage", () => Context.VisitHomePage());
                    And("I should see the documentation link", () => Context.DocumentationLinkExists());
                    When("I click the documentation link", () => Context.ClickDocumentationLink());
                    Then("I should now see the documentation page", () => Context.UserShouldBeAtDocumentationPage());
                });
            });
        }

        [Test]
        public void Empty()
        {
            Feature("As a tester I want to be able to prove that features of the system are working as expected", () =>
            {
                Scenario("Visit the home page", () =>
                {
                    Given("I am on the NaughtyStep homepage", () => {Assert.Pass();});
                    And("I should see the documentation link", () => { Assert.Pass(); });
                    When("I click the documentation link", () => { Assert.Pass(); });
                    Then("I should now see the documentation page", () => { Assert.Inconclusive(); });
                });
            });
        }
    }
}
