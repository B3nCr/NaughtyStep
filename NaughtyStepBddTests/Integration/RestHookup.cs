// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System.Net;
using NaughtyStep;
using RestSharp;
using Should;

namespace NaughtyStepTests.Integration
{
    public class RestHookup : NaughtyStepRestSharpContext
    {
        public HttpStatusCode CallGetOnNavigate()
        {
            var request = new RestRequest();
            request.Resource = "http://localhost:64280/tuganet";
            request.Method = Method.GET;
            Response = PerformRequest<TuganetObject>(request);
            return Response.StatusCode;
        }

        public IRestResponse Response { get; set; }

        public void ResponseContentShouldNotBeEmpty()
        {
            var castResponse = Response as IRestResponse<TuganetObject>;
            var data = castResponse.Data;
            data.ShouldNotBeNull();
            data.TestOne.ShouldEqual("One");
            data.TestTwo.ShouldEqual("Two");

        }
    }
    public class TuganetObject
    {
        public string TestOne { get { return "One"; } }
        public string TestTwo { get { return "Two"; } }
    }
}
