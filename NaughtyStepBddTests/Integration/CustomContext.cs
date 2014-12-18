using NaughtyStep;
using Should;

namespace NaughtyStepTests.Integration
{
    public class CustomContext : NaughtyStepCoypuContext
    {
        public void VisitHomePage()
        {
            Browser.Visit("http://www.naughtystepbdd.org/index.html");
            Browser.Location.AbsoluteUri.ShouldEqual("http://www.naughtystepbdd.org/index.html");
        }

        public void DocumentationLinkExists()
        {
            Browser.FindLink("Documentation").Exists().ShouldBeTrue();
        }

        public void ClickDocumentationLink()
        {
            Browser.FindLink("Documentation").Click();
        }

        public void UserShouldBeAtDocumentationPage()
        {
            Browser.Location.AbsoluteUri.ShouldEqual("http://www.naughtystepbdd.org/Documentation.htm");
        }
    }
}