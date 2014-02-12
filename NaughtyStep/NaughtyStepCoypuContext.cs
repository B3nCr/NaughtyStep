// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using Coypu;
using Coypu.Drivers;
using System;
using System.Configuration;

namespace NaughtyStep
{
    /// <summary>
    /// Derive classes from this, which will become your user contexts.
    /// For this context the browser is disposed as long as you call
    /// the dispose method on the feature.
    /// </summary>
    public abstract class NaughtyStepCoypuContext : IDisposable
    {
        private readonly IBrowserProvider _browserProvider;
        private BrowserSettingsAttribute _browserSettings;
        private int _port;
        private Browser _browser;
        private ContextSessionLifestyleAttribute _sessionLifestyle;
        private BrowserType _browserType;
        protected BrowserSession Browser { get; private set; }

        public NaughtyStepCoypuContext() :
            this(new BrowserProvider())
        {

        }

        public NaughtyStepCoypuContext(IBrowserProvider browserProvider)
        {
            _browserProvider = browserProvider;
            _sessionLifestyle = (ContextSessionLifestyleAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(ContextSessionLifestyleAttribute));
            _browserSettings = (BrowserSettingsAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(BrowserSettingsAttribute));
        }

        /// <summary>
        /// Initialises the browser to be used for testing.
        /// </summary>
        public virtual void Init()
        {
            ConfigureFromAppSettings();
            ConfigureFromAttribute();
            if (_sessionLifestyle == null ||  _sessionLifestyle.Lifestyle == SessionLifestyle.Transient)
            {
                Browser = _browserProvider.GetTransientSession();
                return;
            }
            Browser = _browserProvider.GetSingletonSession();
        }

        private void ConfigureFromAppSettings()
        {
            BrowserType t;
            if (ConfigurationManager.AppSettings["NaughtyStepBrowser"] != null)
            {
                Enum.TryParse(ConfigurationManager.AppSettings["NaughtyStepBrowser"], out t);
                _browserProvider.BrowserType = t;
            }

            if (ConfigurationManager.AppSettings["NaughtyStepPort"] != null)
            {
                _browserProvider.SessionPort = int.Parse(ConfigurationManager.AppSettings["NaughtyStepPort"]);
            }
        }

        private void ConfigureFromAttribute()
        {
            if (_browserSettings != null)
            {
                _browserProvider.BrowserType = _browserSettings.Browser;
                _browserProvider.SessionPort = _browserSettings.Port;
            }
            switch (_browserProvider.BrowserType)
            {
                case BrowserType.Firefox:
                    _browserProvider.SessionBrowser = Coypu.Drivers.Browser.Firefox;
                    break;
                case BrowserType.InternetExplorer:
                    _browserProvider.SessionBrowser = Coypu.Drivers.Browser.InternetExplorer;
                    break;
                case BrowserType.Chrome:
                    _browserProvider.SessionBrowser = Coypu.Drivers.Browser.Chrome;
                    break;
                default:
                    _browserProvider.SessionBrowser = Coypu.Drivers.Browser.PhantomJS;
                    break;
            }
        }

        public virtual void Dispose()
        {
                Browser.Dispose();
        }
    }
}