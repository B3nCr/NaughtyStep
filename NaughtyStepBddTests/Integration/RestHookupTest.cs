// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System.Net;
using NaughtyStep;
using NUnit.Framework;
using Should;

namespace NaughtyStepTests.Integration
{
    [TestFixture]
    public class RestHookupTest : NaughtyStepRestSharpFeature<RestHookup>
    {
        [TestFixtureSetUp]
        public new void Init()
        {
            base.Init();
        }

        [Test]
        public void TryToHookup()
        {
            Scenario("Try to hit service", () =>
            {
                Given("I try to hit a service endpoint", () => Context.CallGetOnNavigate().ShouldEqual(HttpStatusCode.OK));
            });
        }

        [Test]
        public void SeeWhatWeGetBack()
        {
            Scenario("Hit service check the result", () =>
            {
                Given("I hit a service endpoint", () => Context.CallGetOnNavigate().ShouldEqual(HttpStatusCode.OK));
                Then("I should see some stuff", () => Context.ResponseContentShouldNotBeEmpty());
            });
        }
    }
}