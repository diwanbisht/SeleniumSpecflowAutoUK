using OpenQA.Selenium;
using SeleniumSpecfowAuto.Hooks;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumSpecfowAuto.Steps
{
    [Binding]
    public class WebTableSteps : BaseSteps
    {
        private SeleniumContext seleniumContext;
        public WebTableSteps(SeleniumContext seleniumContext) : base(seleniumContext)
        {
            this.seleniumContext = seleniumContext;
        }

        [When(@"I want to read the table")]
        public void WhenIWantToReadTheTable()
        {
            IWebElement tables = Driver.FindElement(By.XPath("//*[@id='table1']/tbody"));

            IReadOnlyCollection<IWebElement> TotalRowsList = tables.FindElements(By.TagName("tr"));

            IWebElement GetColumns = Driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr"));

            IReadOnlyCollection<IWebElement> TotalColumnList = GetColumns.FindElements(By.TagName("td"));

            Console.WriteLine("Number of Coloumns in the table are : " + TotalColumnList.Count);

            Console.WriteLine("Number of Rows in the table are : " + TotalRowsList.Count);

          
            for (int i = 1; i <= TotalColumnList.Count; i++)
            {
                string ColValue = Driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[4]/td[ " + i + "]")).Text;
                Console.WriteLine("Column Cell Value  : = " + i + " =====   " + ColValue.ToString());
            }

            for (int i = 1; i <= TotalRowsList.Count; i++)
            {
                string rowvalues = Driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + i + " ]")).Text;
                //Console.WriteLine(rowvalues.ToString());

                Console.WriteLine("Row Number : = " + i + " =====   " + rowvalues.ToString());
            }

           
        }



    }
}
