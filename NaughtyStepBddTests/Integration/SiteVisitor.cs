// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System;
using System.Threading;
using Coypu;
using NaughtyStep;
using Should;

namespace NaughtyStepTests.Integration
{
    public class SiteVisitor : NaughtyStepCoypuContext
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
            Browser.ClickLink("Documentation", new Options { Timeout = TimeSpan.FromSeconds(5) });
        }

        public void UserShouldBeAtDocumentationPage()
        {
            Browser.Location.AbsoluteUri.ShouldEqual("http://www.naughtystepbdd.org/Documentation.htm");
        }
    }
}