// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System;

namespace NaughtyStep
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ContextSessionLifestyleAttribute : Attribute
    {
        public SessionLifestyle Lifestyle { get; set; }
    }
}