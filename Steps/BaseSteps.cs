using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumSpecfowAuto.Hooks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;


namespace SeleniumSpecfowAuto.Steps
{
    public class BaseSteps
    {

        protected IWebDriver driver;

        public readonly SeleniumContext seleniumContext;

        public BaseSteps(SeleniumContext seleniumContext)
        {
            this.seleniumContext = seleniumContext;
        }

        protected IWebDriver Driver
        {
            get { return this.seleniumContext.webDriver; }
        }

    }
}
