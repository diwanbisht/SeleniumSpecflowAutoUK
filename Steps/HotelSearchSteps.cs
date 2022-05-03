using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumSpecfowAuto.Hooks;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumSpecfowAuto.Steps
{
    [Binding]
    public class HotelSearchSteps : BaseSteps
    {
        private SeleniumContext seleniumContext;

        public HotelSearchSteps(SeleniumContext seleniumContext) : base(seleniumContext)
        {
            this.seleniumContext = seleniumContext;
        }


        [Then(@"I am directed to the booking page")]
        public void ThenIAmDirectedToTheBookingPage()
        {
            string expectedValue = "Hello Aghate123!";

            IWebElement actualResult = Driver.FindElement(By.Name("username_show"));
            //string actualvalue =  actualResult.Text;
            string actualvalue = actualResult.GetAttribute("value");

            Assert.AreEqual(expectedValue, actualvalue, "Testing Failed, because Expected and Actual does not match");

            //driver.Quit();
        }

        [When(@"I select '(.*)' from the Location drop downbox")]
        public void WhenISelectFromTheLocationDropDownbox(string locationValue)
        {
            IWebElement location1 = Driver.FindElement(By.Name("location"));
            SelectElement locationElement = new SelectElement(location1);
            locationElement.SelectByValue("New York");


            //OtherWay
            SelectElement location = new SelectElement(Driver.FindElement(By.Name("location")));
            location.SelectByValue(locationValue);

            // List<IWebElement> locCount = (List<IWebElement>)location.Options;
            IReadOnlyCollection<IWebElement> Countcollection = (IReadOnlyCollection<IWebElement>)location.Options;
            foreach (var item in Countcollection)
            {
                Console.WriteLine(item.Text);
            }
        }



        [When(@"I select '(.*)' in Hotel dropdown list")]
        public void WhenISelectInHotelDropdownList(string hotelName)
        {
            SelectElement hotel = new SelectElement(Driver.FindElement(By.Name("hotels")));
            hotel.SelectByValue(hotelName);
        }

        [When(@"I select '(.*)' in Room type dropdown list")]
        public void WhenISelectInRoomTypeDropdownList(string roomType)
        {
            SelectElement roomTypes = new SelectElement(Driver.FindElement(By.Name("room_type")));
            roomTypes.SelectByValue(roomType);
        }

        [When(@"I select '(.*)' in Number of Room dropdown list")]
        public void WhenISelectInNumberOfRoomDropdownList(string room)
        {
            SelectElement roomNumber = new SelectElement(Driver.FindElement(By.Id("room_nos")));
            // roomNumber.SelectByValue(room);

            roomNumber.SelectByIndex(5);
            roomNumber.SelectByText(room);
        }

        [When(@"I enter'(.*)' in the check in date field")]
        public void WhenIEnterInTheCheckInDateField(string checkInDate)
        {
            IWebElement checkIn = Driver.FindElement(By.Name("datepick_in"));
            checkIn.Clear();
            checkIn.SendKeys(checkInDate);
        }

        [When(@"I enter '(.*)' in the check out date field")]
        public void WhenIEnterInTheCheckOutDateField(string checkOutDate)
        {
            IWebElement checkOut = Driver.FindElement(By.Name("datepick_out"));
            checkOut.Clear();
            checkOut.SendKeys(checkOutDate);
        }

        [When(@"I select '(.*)' in the Adult per room dropdown list")]
        public void WhenISelectInTheAdultPerRoomDropdownList(string adult)
        {
            SelectElement adultNumber = new SelectElement(Driver.FindElement(By.Name("adult_room")));
            //adultNumber.SelectByValue(adult);
            adultNumber.SelectByText(adult);
        }

        [When(@"I select '(.*)' in the Children per room dropdown list")]
        public void WhenISelectInTheChildrenPerRoomDropdownList(string children)
        {
            SelectElement childNumber = new SelectElement(Driver.FindElement(By.Name("child_room")));
            childNumber.SelectByText(children);

        }
        /*
                [When(@"I click on the Search button")]
                public void WhenIClickOnTheSearchButton()
                {
                    IWebElement searchButton = Driver.FindElement(By.Name("Submit"));
                }*/

        [When(@"I click on the '(.*)' button")]
        public void WhenIClickOnTheButton(string buttonName)
        {
            if (buttonName != "Book Now")
            {
                Driver.FindElement(By.XPath("//*[@type='submit' or @name=   '" + buttonName + "']")).Click();

            }
            else
            {
                Driver.FindElement(By.XPath("//*[@type='button' or @value= '" + buttonName + "']")).Click();
            }



        }


        [Then(@"I should be able to see a list of hotels matching my criteria")]
        public void ThenIShouldBeAbleToSeeAListOfHotelsMatchingMyCriteria()
        {
            IWebElement selectHolelScreen = Driver.FindElement(By.XPath("(//*[contains(text(),'Select Hotel')])[2]"));
            string actualValue = selectHolelScreen.Text;
            string expectedValue = "Select Hotel";
            Assert.AreEqual(actualValue, expectedValue, "Testing Fails.......");
        }

        [When(@"I click on Select Hotel radio button")]
        public void WhenIClickOnSelectHotelRadioButton()
        {
            Driver.FindElement(By.XPath("//*[@name='radiobutton_0']")).Click();
        }

        [When(@"I enter the '(.*)' First Name")]
        public void WhenIEnterTheFirstName(string firstName)
        {
            Driver.FindElement(By.Name("first_name")).SendKeys(firstName);
        }

        [When(@"I enter the '(.*)'Last Name")]
        public void WhenIEnterTheLastName(string lastName)
        {
            Driver.FindElement(By.Name("last_name")).SendKeys(lastName);
        }

        [When(@"I enter the '(.*)'Billing Address")]
        public void WhenIEnterTheBillingAddress(string address)
        {
            Driver.FindElement(By.Name("address")).SendKeys(address);
        }

        [When(@"I enter the '(.*)'Card Number")]
        public void WhenIEnterTheCardNumber(Decimal cardNumber)
        {
            Driver.FindElement(By.Name("cc_num")).SendKeys(cardNumber.ToString());
        }

        [When(@"I select '(.*)' CardType")]
        public void WhenISelectCardType(string cardType)
        {
            new SelectElement(Driver.FindElement(By.Name("cc_type"))).SelectByText(cardType.ToUpper());
        }

        [When(@"I select '(.*)' Expiry Month")]
        public void WhenISelectExpiryMonth(string expiryMonth)
        {
            new SelectElement(Driver.FindElement(By.Name("cc_exp_month"))).SelectByText(expiryMonth);
        }

        [When(@"I select '(.*)' Expirty Year")]
        public void WhenISelectExpirtyYear(int expiryYear)
        {
            new SelectElement(Driver.FindElement(By.Name("cc_exp_year"))).SelectByText(expiryYear.ToString());
        }

        [When(@"I enter the '(.*)' Number")]
        public void WhenIEnterTheNumber(int cVV)
        {
            Driver.FindElement(By.Name("cc_cvv")).SendKeys(cVV.ToString());
        }

        [Then(@"I shold see the random Order Number")]
        public void ThenISholdSeeTheRandomOrderNumber()
        {
            System.Threading.Thread.Sleep(5000);
            IWebElement orderNumber = Driver.FindElement(By.XPath("//*[@id='order_no']"));
            string order1 = orderNumber.GetAttribute("value");
            Console.WriteLine(order1.ToString());
            Assert.IsTrue(order1 != null);
            Assert.That(order1 != null);


        }

    }
}
