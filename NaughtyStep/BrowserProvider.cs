// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;

namespace NaughtyStep
{
    public class BrowserProvider : IBrowserProvider
    {
        public int SessionPort { get; set; }
        public BrowserType BrowserType { get; set; }

        public Browser SessionBrowser { get; set; }

        public BrowserSession GetTransientSession()
        {
            return new BrowserSession(
                new SessionConfiguration
                {
                    Port = SessionPort == 0 ? 80 : SessionPort,
                    Driver = typeof (SeleniumWebDriver),
                    Browser = SessionBrowser
                });
        }

        public BrowserSession GetSingletonSession()
        {
            return SingletonBrowser.GetBrowser();
        }
    }
}