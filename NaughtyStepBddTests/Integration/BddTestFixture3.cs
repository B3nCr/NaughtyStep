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
    public class BddTestFixture3 : NaughtyStepCoypuFeature<SiteVisitor>
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
            Scenario("Visit the home page", () =>
            {
                Given("I am on the NaughtyStep homepage", () => Context.VisitHomePage());
                And("I should see the documentation link", () => Context.DocumentationLinkExists());
                When("I click the documentation link", () => Context.ClickDocumentationLink());
                Then("I should now see the documentation page", () => Context.UserShouldBeAtDocumentationPage());
            });
        }
    }
}
