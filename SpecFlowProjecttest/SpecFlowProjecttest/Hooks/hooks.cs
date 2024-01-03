using AventStack.ExtentReports;
using BoDi;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowProjecttest.Base;

namespace SpecFlowProjecttest.Hooks
{
    [Binding]
    class hooks
    {

        private readonly IObjectContainer _objectContainer;

        private ExtentTest test;
        private static ExtentReports rep;

        public hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            rep = BaseClass.ExtentManager();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var FeatureTitle = ScenarioContext.Current.ScenarioInfo.Title;
            test = rep.CreateTest(FeatureTitle);
            _objectContainer.RegisterInstanceAs<ExtentTest>(test);
            test.Log(Status.Pass, "Test Started");

        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                test.Log(Status.Fail, ScenarioContext.Current.TestError.Message.Trim());
            }
            test.Log(Status.Pass, "Test Completed successfully");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            rep.Flush();
            BaseClass.SaveReport();
        }
           
    }
}
