using AventStack.ExtentReports;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjecttest.Steps
{
    [Binding]
    public class API1TestSteps
    {
        private ExtentTest test;
        public API1TestSteps(ExtentTest Test)
        {
            test = Test;
        }

        private RestClient client;
        private RestRequest request;
        private RestResponse response;

        [Given(@"Get api given")]
        public void GivenGetApiGiven()
        {
            // Set your API endpoint
            client = new RestClient("https://reqres.in/api/users?page=2");
            Console.WriteLine("Given function");
            test.Log(Status.Pass, "Given function");
        }
        
        [Given(@"Get api and")]
        public void GivenGetApiAnd()
        {
            // Create a GET request
            request = new RestRequest("API1", Method.Get);

            // Execute the request
            response = client.Execute(request);
        }
        
        [When(@"Get api when")]
        public void WhenGetApiWhen()
        {
            Console.WriteLine("When function");
            test.Log(Status.Pass, "When function");
        }
        
        [Then(@"Get api then")]
        public void ThenGetApiThen()
        {
            int expectedStatusCode = 200;
            Assert.AreEqual(expectedStatusCode, (int)response.StatusCode);
        }
    }
}
