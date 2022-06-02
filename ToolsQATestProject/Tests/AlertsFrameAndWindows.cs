using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToolsQATestProject.Driver;

namespace ToolsQATestProject.Tests
{
    [TestClass]
    public class AlertsFrameAndWindows
    {

        [TestMethod]
        public void BrowserWindowsNewTab()
        {
            BaseDriver.DriverStart("https://demoqa.com/browser-windows");

            BaseDriver.driver.FindElement(By.XPath("//button[@id='tabButton']")).Click();
            BaseDriver.driver.SwitchTo().Window(BaseDriver.driver.WindowHandles.Last());
            WebDriverWait wait = new WebDriverWait(BaseDriver.driver, TimeSpan.FromSeconds(3));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[@id='sampleHeading']")));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            string element = BaseDriver.driver.FindElement(By.XPath("//h1[@id='sampleHeading']")).Text;
            Assert.AreEqual(element, "This is a sample page");
            BaseDriver.driver.SwitchTo().Window(BaseDriver.driver.WindowHandles.First());

            BaseDriver.DriverStop();
        }
        
        [TestMethod]
        public void Alerts()
        {
            BaseDriver.DriverStart("https://demoqa.com/alerts");

            BaseDriver.driver.FindElement(By.XPath("//button[@id='alertButton']")).Click();
            BaseDriver.driver.SwitchTo().Alert().Accept();

            BaseDriver.driver.FindElement(By.XPath("//button[@id='timerAlertButton']")).Click();
            WebDriverWait wait = new WebDriverWait(BaseDriver.driver, TimeSpan.FromSeconds(6));
            wait.Until(ExpectedConditions.AlertIsPresent());
            BaseDriver.driver.SwitchTo().Alert().Accept();

            Thread.Sleep(2000);
            BaseDriver.driver.FindElement(By.XPath("//button[@id='confirmButton']")).Click();
            string alertMessage = BaseDriver.driver.SwitchTo().Alert().Text;
            Assert.IsTrue(alertMessage.Contains("Do you confirm action?"));
            BaseDriver.driver.SwitchTo().Alert().Accept();
            string message = BaseDriver.driver.FindElement(By.XPath("//span[@id='confirmResult']")).Text;
            Assert.AreEqual(message, "You selected Ok");

            BaseDriver.driver.FindElement(By.XPath("//button[@id='promtButton']")).Click();
            IAlert alert = BaseDriver.driver.SwitchTo().Alert();
            alert.SendKeys("Sefa Küçükarslan");
            alert.Accept();
            message = BaseDriver.driver.FindElement(By.XPath("//span[@id='promptResult']")).Text;
            Assert.AreEqual(message, "You entered Sefa Küçükarslan");

            BaseDriver.DriverStop();
        }
        
        [TestMethod]
        public void Frames()
        {
            BaseDriver.DriverStart("https://demoqa.com/frames");

            BaseDriver.driver.SwitchTo().Frame("frame1");
            string heading = BaseDriver.driver.FindElement(By.Id("sampleHeading")).Text;
            Assert.AreEqual(heading, "This is a sample page");
            BaseDriver.driver.SwitchTo().ParentFrame();

            string paragraph = BaseDriver.driver.FindElement(By.XPath("//div[@id='framesWrapper']/div[1]")).Text;
            Assert.IsTrue(paragraph.StartsWith("Sample Iframe page There are 2 Iframes in this page."));

            BaseDriver.driver.SwitchTo().Frame("frame2");
            heading = BaseDriver.driver.FindElement(By.Id("sampleHeading")).Text;
            Assert.AreEqual(heading, "This is a sample page");
            BaseDriver.driver.SwitchTo().ParentFrame();

            BaseDriver.DriverStop();
        }
    }
}
