// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System;
using System.Configuration;
using RestSharp;

namespace NaughtyStep
{
    public interface IRestClientProvider
    {
        IRestClient GetTransientClient();
        IRestClient GetSingletonClient();
    }

    public class RestClientProvider : IRestClientProvider
    {
        public IRestClient GetTransientClient()
        {
            return new RestClient(new Uri(ConfigurationManager.AppSettings["RestServiceBaseUri"]));
        }

        public IRestClient GetSingletonClient()
        {
            return SingletonRestClient.GetClient();
        }
    }
}