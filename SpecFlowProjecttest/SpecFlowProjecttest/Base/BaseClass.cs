using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpecFlowProjecttest.Base
{
    class BaseClass
    {

        //================================================================================================================================
        //-----------------------------------------------------Extend Report Set up--------------------------------------------------------------
        //================================================================================================================================


        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        //public static ExtentTest test;
        public static string HTMLReportPath;

        public static String datetime()
        {
            var time = DateTime.Now;
            string formattedTime = time.ToString("MM, dd, yyyy, hh, mm, ss");
            formattedTime = formattedTime.Replace(",", "_");
            return formattedTime;
        }

        public static string GetParentDirectory()
        {
            System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            myDirectory = myDirectory.Parent;
            myDirectory = myDirectory.Parent;
            String parentDirectory = myDirectory.Parent.FullName;
            return parentDirectory;
        }

        public static ExtentReports ExtentManager()
        {
            if (extent == null)
            {
                String currentdatetime = datetime();

                HTMLReportPath = GetParentDirectory() + "\\Reports\\AutomationTestReport" + "_" + currentdatetime + ".html";
                htmlReporter = new ExtentHtmlReporter(HTMLReportPath);
                extent = new ExtentReports();
                htmlReporter.Config.DocumentTitle = "Automation status report";
                htmlReporter.Config.Theme = Theme.Dark;
                htmlReporter.Start();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("Host Name", "Nik");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("UserName", "Nikunj Jambucha");

            }
            return extent;
        }

        public static void SaveReport()
        {
            System.IO.File.Move(GetParentDirectory() + "\\Reports\\index.html", HTMLReportPath);
        }
    }
}
