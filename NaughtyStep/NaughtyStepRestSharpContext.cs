// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System.Configuration;
using RestSharp;
using System;

namespace NaughtyStep
{
    /// <summary>
    /// Derive classes from this, which will become your user contexts.
    /// For this context the browser is disposed as long as you call
    /// the dispose method on the feature.
    /// </summary>
    public abstract class NaughtyStepRestSharpContext : IDisposable
    {
        private readonly IRestClientProvider _clientProvider;
        private ContextSessionLifestyleAttribute _sessionLifestyle;

        public NaughtyStepRestSharpContext()
            :this(new RestClientProvider())
        {
            
        }
        public NaughtyStepRestSharpContext(IRestClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
            _sessionLifestyle = (ContextSessionLifestyleAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(ContextSessionLifestyleAttribute));
        }

        protected IRestClient Client { get; private set; }

        public virtual void Init()
        {
            if (_sessionLifestyle == null || _sessionLifestyle.Lifestyle == SessionLifestyle.Transient)
            {
                Client = _clientProvider.GetTransientClient();
                return;
            }
            Client = _clientProvider.GetSingletonClient();
        }

        public virtual IRestResponse PerformRequest<T>(RestRequest request) where T : class, new()
        {
            return Client.Execute<T>(request);
        }

        public virtual void Dispose()
        {
        }
    }
}