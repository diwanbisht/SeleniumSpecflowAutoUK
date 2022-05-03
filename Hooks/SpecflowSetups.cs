using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using SeleniumSpecfowAuto.Pages;
using SeleniumSpecfowAuto.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace SeleniumSpecfowAuto.Hooks
{
    [Binding]
    public class SpecflowSetups
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public static SeleniumContext seleniumContext;

        private readonly IObjectContainer _objectContainer;

        private readonly ScenarioContext _scenarioContext;




        public SpecflowSetups(IObjectContainer objectContainer)
        {
            // _scenarioContext = scenarioContext;
            this._objectContainer = objectContainer;
        }


        [AfterScenario]
        public static void Takescreenshot()
        {

        }

        [BeforeFeature]
        [Obsolete("Replaced by the automatic starter")]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }


        [BeforeTestRun]
        [Obsolete("Replaced by the automatic starter")]
        public static void RunBeforeAllTests()
        {
            string path = @"C:\Users\acbio\source\repos\SeleniumSpecfowAuto\Report\" + "ExtentReport" + DateTime.Now.ToString("MM_dd_HH_mm") + ".html";

            ExtentV3HtmlReporter htmlReporter = new ExtentV3HtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void RunAfterAllTests()
        {
            /*Driver.Close();
            Driver.Quit();*/
            extent.Flush();
        }

        [BeforeScenario]
        [Obsolete("Replaced by the automatic starter")]
        public static void RunBeforeScenario()
        {
            scenario = featureName.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        /// <summary>
        /// Used for after step feature of extent report.
        /// </summary>
        [AfterStep]
        [Obsolete("Replaced by the automatic starter")]
        public static void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>("Given " + ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>("When " + ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>("Then " + ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>("And " + ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                // var Takescreenshot = 
                //var referenceMessage = ScenarioContext.Current.TestError.Message + "<br /> <b> User: </b>" + "<br /> <b>URL: </b>" + client.Browser.Driver.Url.ToString();
                var referenceMessage = ScenarioContext.Current.TestError.Message + "<br /> <b> User: </b>" + "<br /> <b>URL: </b>";

                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>("Given " + ScenarioStepContext.Current.StepInfo.Text).Fail(referenceMessage);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>("When " + ScenarioStepContext.Current.StepInfo.Text).Fail(referenceMessage);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>("Then " + ScenarioStepContext.Current.StepInfo.Text).Fail(referenceMessage);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>("And " + ScenarioStepContext.Current.StepInfo.Text).Fail(referenceMessage);
                }
            }
        }
    }
}



