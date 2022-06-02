using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToolsQATestProject.Driver;

namespace ToolsQATestProject.Tests
{
    [TestClass]
    public class FormsTest
    {
        [TestMethod]
        public void PracticeForm()
        {
            BaseDriver.DriverStart("https://demoqa.com/automation-practice-form");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='firstName']")).SendKeys("Sefa");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='lastName']")).SendKeys("Küçükarslan");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys("sefak.arslan96@gmail.com");
            BaseDriver.driver.FindElement(By.XPath("//label[@for='gender-radio-1']")).Click();
            BaseDriver.driver.FindElement(By.XPath("//input[@id='userNumber']")).SendKeys("1234567890");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")).SendKeys("1234567890");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")).Click();
            IWebElement monthElement = BaseDriver.driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement selectMonth = new SelectElement(monthElement);
            selectMonth.SelectByIndex(1);

            IWebElement yearElement = BaseDriver.driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement selectYear = new SelectElement(yearElement);
            selectYear.SelectByText("1996");

            BaseDriver.driver.FindElement(By.XPath("//div[@aria-label='Choose Saturday, February 10th, 1996']")).Click();

            IWebElement element = BaseDriver.driver.FindElement(By.XPath("//input[@id='subjectsInput']"));
            element.Click();
            element.SendKeys("Test Automation");

            BaseDriver.driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']")).Click();
            BaseDriver.driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-2']")).Click();
            BaseDriver.driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-3']")).Click();
            BaseDriver.driver.FindElement(By.XPath("//textarea[@id='currentAddress']")).SendKeys("Sakarya, Turkey");
            IWebElement state = BaseDriver.driver.FindElement(By.XPath("//div[@id='state']"));
            state.Click();
            IWebElement stateSection = BaseDriver.driver.FindElement(By.XPath("//input[@id='react-select-3-input']"));
            stateSection.SendKeys("Haryana");
            stateSection.SendKeys(Keys.Enter);

            IWebElement city = BaseDriver.driver.FindElement(By.XPath("//div[@id='city']"));
            city.Click();
            IWebElement citySection = BaseDriver.driver.FindElement(By.XPath("//input[@id='react-select-4-input']"));
            citySection.SendKeys("Panipat");
            citySection.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            BaseDriver.driver.FindElement(By.XPath("//button[@id='submit']")).Click();

            IWebElement isTrue = BaseDriver.driver.FindElement(By.XPath("//table[@class='table table-dark table-striped table-bordered table-hover']//td[text()='sefak.arslan96@gmail.com']"));
            Assert.AreEqual(isTrue, "sefak.arslan96@gmail.com");
            BaseDriver.driver.FindElement(By.XPath("//button[@id='closeLargeModal']")).Click();

            BaseDriver.DriverStop();
        }
    }
}
