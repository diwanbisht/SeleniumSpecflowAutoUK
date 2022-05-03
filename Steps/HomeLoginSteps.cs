using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumSpecfowAuto.Hooks;
using SeleniumSpecfowAuto.Pages;
using SeleniumSpecfowAuto.TestData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumSpecfowAuto.Steps
{
    [Binding]
    public class HomeLoginSteps : BaseSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public readonly HotelSearchSteps hotelSearchSteps;
        private SeleniumContext seleniumContext;
        ExcelReaderHelper helper = new ExcelReaderHelper();
       
        public HomeLoginSteps(SeleniumContext seleniumContext) : base(seleniumContext)
        {
            this.seleniumContext = seleniumContext;
        }

        [Given(@"I navigate to '(.*)' page")]
        public void GivenINavigateToPage(string pageNavigation)
        {

            // driver.Manage().Window.Maximize();
            //Driver.Navigate().GoToUrl(pageNavigation);            
            Dictionary<string, string> dicValues = helper.ReadExcelRowByRow(1);
            string BaseUrlfromExcel = dicValues["Baseurl"];
            Driver.Navigate().GoToUrl(BaseUrlfromExcel);
        }

        [When(@"I enter '(.*)' and '(.*)' to login to web Application")]
        public void WhenIEnterAndToLoginToWebApplication(string userName, string password)
        {
            new HomeLoginPage(Driver).Login(userName, password);
        }


       [When(@"I enter '(.*)' in user name field")]
        public void WhenIEnterInUserNameField(string userName)
        {
            Dictionary<string, string> dicValues = helper.ReadExcelRowByRow(1);
            string UserName = dicValues["UserName"];
            Driver.FindElement(By.Name("username")).SendKeys(UserName);
        }

        [When(@"I enter '(.*)' in password field")]
        public void WhenIEnterInPasswordField(string password)
        {
            Driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            Driver.FindElement(By.Name("login")).Click();
        }

        [When(@"I click on ChooseFile button")]
        public void WhenIClickOnChooseFileButton()
        {
            System.Threading.Thread.Sleep(5000);

            IWebElement choose = Driver.FindElement(By.XPath("//input[@name='file']"));
            choose.Click();

            Actions actionProvider = new Actions(driver);
            IAction keydown = actionProvider.KeyDown(Keys.Control).SendKeys("a").Build();
            keydown.Perform();


            System.Threading.Thread.Sleep(5000);
        }

        [When(@"I selects the file")]
        public void WhenISelectsTheFile()
        {
            string filename = "TestFile.txt";
            string filePath = @"C:\Users\acbio\source\repos\SeleniumSpecfowAuto\UploadFile" + filename;

            Driver.FindElement(By.Id("file-upload")).SendKeys(filePath);

        }

        [When(@"I click on upload button")]
        public void WhenIClickOnUploadButton()
        {
            Driver.FindElement(By.Id("file-submit")).Click();
        }


        [When(@"I drag from Sourse to distination location")]
        public void WhenIDragFromSourseToDistinationLocation()
        {
            Actions actionProvider = new Actions(Driver);
            /*    IAction keydown = actionProvider.KeyDown(Keys.Control).SendKeys("a").Build();
                keydown.Perform();*/

           
            IWebElement from = Driver.FindElement(By.Id("column-b"));
            IWebElement to = Driver.FindElement(By.Id("column-a"));
           // actionProvider.DragAndDrop(from, to).Build().Perform();

          

            IAction builder = new Actions(Driver);

            //Building a drag and drop action
            IAction dragAndDrop = actionProvider.ClickAndHold(from)
            .MoveToElement(to).Release(to).Build();
           

            //Performing the drag and drop action
            dragAndDrop.Perform();



        }


    }
}


