// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System;

namespace NaughtyStep
{
    /// <summary>
    /// Allows the selection of the browser that will be used by a NaughtyStepCoypuContext to run the tests.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class BrowserSettingsAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the port (Not required)
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The browser to be used (defaults to PhantomJS)
        /// </summary>
        public BrowserType  Browser { get; set; }
    }
}