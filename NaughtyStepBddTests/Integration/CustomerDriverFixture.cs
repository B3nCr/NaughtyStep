using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using NaughtyStep;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace NaughtyStepTests.Integration
{
    public class CustomDriverFixture : NaughtyStepCoypuFeature<CustomContext>
    {
        public BrowserSession CustomBrowserSession(string platform, string browserName, string version)
        {
            var configuration = new SessionConfiguration { Driver = typeof(SauceLabsDriver) };

            //var desiredCapabilites = new DesiredCapabilities(browserName, version, Platform.CurrentPlatform);
            //desiredCapabilites.SetCapability("platform", platform);
            //desiredCapabilites.SetCapability("username", "yourSauceLabsUsername");
            //desiredCapabilites.SetCapability("accessKey", "yourAccessKeyFromSauceLabs");
            //desiredCapabilites.SetCapability("name", TestContext.CurrentContext.Test.Name);

            DesiredCapabilities caps = DesiredCapabilities.Android();
            caps.SetCapability(CapabilityType.Platform, "Linux");
            caps.SetCapability(CapabilityType.Version, "4.4");
            caps.SetCapability("deviceName", "Google Nexus 7 HD Emulator");
            caps.SetCapability("device-orientation", "portrait");
            caps.SetCapability("username", "yourSauceLabsUsername");
            caps.SetCapability("accessKey", "yourAccessKeyFromSauceLabs");

            Driver driver = new SauceLabsDriver(Browser.Parse(browserName), caps);

            return new BrowserSession(configuration, driver);
        }

        [TestFixtureSetUp]
        public new void Init()
        {
            base.Init(CustomBrowserSession("Windows XP", "internet explorer", "6"));
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

    public class SauceLabsDriver : SeleniumWebDriver
    {
        public SauceLabsDriver(Browser browser, ICapabilities capabilities)
            : base(CustomWebDriver(capabilities), browser)
        {
        }

        private static RemoteWebDriver CustomWebDriver(ICapabilities capabilities)
        {
            var remoteAppHost = new Uri("http://ondemand.saucelabs.com:80/wd/hub");
            return new RemoteWebDriver(remoteAppHost, capabilities);
        }
    }
}
