// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System;
using System.Configuration;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;

namespace NaughtyStep
{
    public sealed class SingletonBrowser
    {
        private static BrowserSession _session = Init();

        private SingletonBrowser()
        { }

        public static BrowserSession GetBrowser()
        {
            return _session;
        }

        private static BrowserSession Init()
        {
            int browserPort = 0;
            Browser browser;
            BrowserType browserType = BrowserType.PhantomJS;
            if (ConfigurationManager.AppSettings["NaughtyStepBrowser"] != null)
            {
                Enum.TryParse(ConfigurationManager.AppSettings["NaughtyStepBrowser"], out browserType);
            }

            if (ConfigurationManager.AppSettings["NaughtyStepPort"] != null)
            {
                browserPort = int.Parse(ConfigurationManager.AppSettings["NaughtyStepPort"]);
            }
            switch (browserType)
            {
                case BrowserType.Firefox:
                    browser = Browser.Firefox;
                    break;
                case BrowserType.InternetExplorer:
                    browser = Browser.InternetExplorer;
                    break;
                case BrowserType.Chrome:
                    browser = Browser.Chrome;
                    break;
                default:
                    browser = Browser.PhantomJS;
                    break;
            }
            return new BrowserSession(new SessionConfiguration
            {
                Port = browserPort,
                Driver = typeof (SeleniumWebDriver),
                Browser = browser
            });
        }
    }
}