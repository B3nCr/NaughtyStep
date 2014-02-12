// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using Coypu;
using Coypu.Drivers;

namespace NaughtyStep
{
    public interface IBrowserProvider
    {
        int SessionPort { get; set; }

        BrowserType BrowserType { get; set; }
        Browser SessionBrowser { get; set; }
        BrowserSession GetTransientSession();
        BrowserSession GetSingletonSession();
    }
}