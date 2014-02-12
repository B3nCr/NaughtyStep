// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using RestSharp;

namespace NaughtyStep
{
    public sealed class SingletonRestClient
    {
        private static IRestClient _session = new RestClient();

        private SingletonRestClient()
        {
        }

        public static IRestClient GetClient()
        {
            return _session;
        }
    }
}