using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumSpecfowAuto.Pages;
using SeleniumSpecfowAuto.TestData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumSpecfowAuto.Hooks
{
    public class SeleniumContext
    {
        public SeleniumContext()
        {
            this.CreateChromeDriver();
        }

        public IWebDriver webDriver { get; set; }

        public void CreateChromeDriver()
        {
            // IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("download.default_directory", (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            //IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            options.AddArgument("--incognito");
            this.webDriver = new ChromeDriver(options);
            LoginToApplication();
        }

        public void LoginToApplication()
        {
            ExcelReaderHelper helper = new ExcelReaderHelper();
            Dictionary<string, string> dicValues = helper.ReadExcelRowByRow(1);
            string BaseUrlfromExcel = dicValues["Baseurl"];
            string UserName = dicValues["Baseurl"];
            string passwrod = dicValues["Baseurl"];
            new HomeLoginPage(webDriver).Login(BaseUrlfromExcel, UserName, passwrod);
          
        }

        public void CreateFirefox()
        {

        }
    }
}