using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecfowAuto.Pages
{
    public class HomeLoginPage
    {
        private readonly IWebDriver webDriver;
        //Test
        //Aganin Checking Testing
        
        //From Remote Machine or Reposiotory
        public HomeLoginPage(IWebDriver driver) => this.webDriver = driver;

        /// <summary>
        /// Gets element for select Object type/button.
        /// </summary>
        public IWebElement UserName => this.webDriver.FindElement(By.Name("username"));
        private IWebElement Password => this.webDriver.FindElement(By.Name("password"));
        private IWebElement LoginButton => this.webDriver.FindElement(By.Name("login"));

        public void Login(string userName, string password)
        {
            this.UserName.SendKeys(userName);
            this.Password.SendKeys(password);
            LoginButton.Click();
        }

        public void Login(string BaseUrl, string userName, string password)
        {
            webDriver.Navigate().GoToUrl(BaseUrl);
            this.UserName.SendKeys(userName);
            this.Password.SendKeys(password);
            LoginButton.Click();
        }
    }
}
