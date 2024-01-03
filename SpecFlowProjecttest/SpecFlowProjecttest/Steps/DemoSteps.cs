using AventStack.ExtentReports;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProjecttest.Steps
{
    [Binding]
    public class DemoSteps
    {
        private ExtentTest test;
        public DemoSteps(ExtentTest Test)
        {
            test = Test;
        }

        private RestClient client;
        private RestRequest request;
        private RestResponse response;

        private String URI;
        private String requeststr;

        [Given(@"Set The API URL AS '(.*)'")]
        public void GivenSetTheAPIURLAS(string uri)
        {
            if (uri != null)
            {
                URI = uri;
            }
            else test.Log(Status.Fail, "API uri is not set " + uri);
            test.Log(Status.Pass, "API uri is set " + uri);
        }
        
        [Given(@"Set The API End Point As '(.*)'")]
        public void GivenSetTheAPIEndPointAs(string endpoint)
        {
            requeststr = URI + "/" + endpoint;
            client = new RestClient(requeststr);
            test.Log(Status.Pass, "API request endpoints are set " + requeststr);

        }

        [Given(@"Set the Parameter Key and Value")]
        public void GivenSetTheParameterKeyAndValue(Table table)
        {
            foreach (var row in table.Rows)
            {
                string parameterName = row["QueryParameterName"];
                string parameterValue = row["QueryParameterValue"];

                client.AddDefaultParameter(parameterName, parameterValue);
                test.Log(Status.Pass, "API Parameter " + parameterName + " has value as " + parameterValue);
            }
        }

        [Given(@"Set the user id")]
        public void GivenSetTheUserId(Table table)
        {
            string userid = null ;
            foreach (var row in table.Rows) 
            {
                userid = row["id"];
            }
            requeststr = requeststr + "/" + userid;
            client = new RestClient(requeststr);
            test.Log(Status.Pass, "API request user id is set " + requeststr);
        }


        [When(@"Send a GET request")]
        public void WhenSendAGETRequest()
        {
            request = new RestRequest("", Method.Get);
            String temp = client.BuildUri(request).AbsoluteUri;
            test.Log(Status.Pass, "API request is set " + temp);
            response = client.Execute(request);
            test.Log(Status.Pass, "API request is sent ");

            
        }

        [Then(@"The response status code should be expected Status Code")]
        public void ThenTheResponseStatusCodeShouldBeExpectedStatusCode(Table table)
        {
            string expectedStatusCode = null;
            foreach (var row in table.Rows)
            {
                expectedStatusCode = row["expectedStatusCode"];
            }
            test.Log(Status.Pass, "API responce is " + response.Content);
            Assert.AreEqual(int.Parse(expectedStatusCode), (int)response.StatusCode);
            test.Log(Status.Pass, "API responce is verified with status code as " + expectedStatusCode);
        }

        [Given(@"the request body is:")]
        public void GivenTheRequestBodyIs(string requestBody)
        {
            request = new RestRequest("", Method.Post);
            String temp = client.BuildUri(request).AbsoluteUri;
            test.Log(Status.Pass, "API request is set " + temp);
            request.AddJsonBody(requestBody);
        }

        [When(@"Send a Post request")]
        public void WhenSendAPostRequest()
        {
            
            response = client.Execute(request);
            test.Log(Status.Pass, "API request is sent ");
        }

    }
}
