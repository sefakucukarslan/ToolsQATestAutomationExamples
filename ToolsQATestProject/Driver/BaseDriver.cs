using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ToolsQATestProject.Driver
{
    static class BaseDriver
    {
        public static IWebDriver driver;

        public static void DriverStart(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static void DriverStop()
        {
            driver.Quit();
        }
    }
}
