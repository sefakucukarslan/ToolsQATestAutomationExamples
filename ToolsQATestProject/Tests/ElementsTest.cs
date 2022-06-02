using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using ToolsQATestProject.Driver;

namespace ToolsQATestProject.Tests
{
    [TestClass]
    public class ElementsTest
    {

        [TestMethod]
        public void TextBoxTest()
        {
            BaseDriver.DriverStart("https://demoqa.com/text-box");

            BaseDriver.driver.FindElement(By.XPath("//input[@id='userName']")).SendKeys("Sefa Küçükarslan");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys("sefak.arslan96@gmail.com");
            BaseDriver.driver.FindElement(By.XPath("//textarea[@id='currentAddress']")).SendKeys("Sakarya, Turkey");
            BaseDriver.driver.FindElement(By.XPath("//textarea[@id='permanentAddress']")).SendKeys("Adıyaman, Turkey");
            BaseDriver.driver.FindElement(By.XPath("//button[@id='submit']")).Click();

            string name = BaseDriver.driver.FindElement(By.XPath("//p[@id='name']")).Text;
            string email = BaseDriver.driver.FindElement(By.XPath("//p[@id='email']")).Text;
            string currentAdress = BaseDriver.driver.FindElement(By.XPath("//p[@id='currentAddress']")).Text;
            string permanetAdress = BaseDriver.driver.FindElement(By.XPath("//p[@id='permanentAddress']")).Text;

            Assert.IsTrue(name.Equals("Name:Sefa Küçükarslan"));
            Assert.AreEqual(email, "Email:sefak.arslan96@gmail.com");
            Assert.IsTrue(currentAdress.Equals("Current Address :Sakarya, Turkey"));
            Assert.AreEqual(permanetAdress, "Permananet Address :Adıyaman, Turkey");

            BaseDriver.DriverStop();

        }

        [TestMethod]
        public void TextBoxEmailFailControlTest()
        {
            BaseDriver.DriverStart("https://demoqa.com/text-box");

            BaseDriver.driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys("sefak.arslan96gmail.com");
            BaseDriver.driver.FindElement(By.XPath("//button[@id='submit']")).Click();
            try
            {
                BaseDriver.driver.FindElement(By.XPath("//input[@id='userEmail' and @class='mr-sm-2 field-error form-control']"));
            }
            catch (Exception)
            {
                Assert.Fail("Email'de hata alınmadı...");
            }

            BaseDriver.DriverStop();

        }
        
        [TestMethod]
        public void CheckBoxTest()
        {
            BaseDriver.DriverStart("https://demoqa.com/checkbox");

            BaseDriver.driver.FindElement(By.XPath("//label[@for='tree-node-home']/../button")).Click();
            BaseDriver.driver.FindElement(By.XPath("//label[@for='tree-node-desktop']/../button")).Click();
            BaseDriver.driver.FindElement(By.XPath("//label[@for='tree-node-documents']/../button")).Click();
            BaseDriver.driver.FindElement(By.XPath("//label[@for='tree-node-downloads']/../button")).Click();
            BaseDriver.driver.FindElement(By.XPath("//label[@for='tree-node-notes']")).Click();
            BaseDriver.driver.FindElement(By.XPath("//label[@for='tree-node-office']")).Click();
            BaseDriver.driver.FindElement(By.XPath("//label[@for='tree-node-wordFile']")).Click();
            ReadOnlyCollection<IWebElement> elements =  BaseDriver.driver.FindElements(By.XPath("//div[@id='result']/span[@class='text-success']"));
            Assert.AreEqual(elements[0].Text, "notes");
            Assert.AreEqual(elements[1].Text, "office");
            Assert.AreEqual(elements[2].Text, "public");
            Assert.AreEqual(elements[3].Text, "private");
            Assert.AreEqual(elements[4].Text, "classified");
            Assert.AreEqual(elements[5].Text, "general");
            Assert.AreEqual(elements[6].Text, "wordFile");

            BaseDriver.DriverStop();

        }
        
        [TestMethod]
        public void RadioButtonTest()
        {
            BaseDriver.DriverStart("https://demoqa.com/radio-button");

            bool isSelectedYes = BaseDriver.driver.FindElement(By.XPath("//input[@id='yesRadio']")).Selected;
            Assert.IsFalse(isSelectedYes);
            bool isEnableYes = BaseDriver.driver.FindElement(By.XPath("//input[@id='yesRadio']")).Enabled;
            Assert.IsTrue(isEnableYes);
            BaseDriver.driver.FindElement(By.XPath("//label[@for='yesRadio']")).Click();
            isSelectedYes = BaseDriver.driver.FindElement(By.XPath("//input[@id='yesRadio']")).Selected;
            Assert.IsTrue(isSelectedYes);


            bool isSelectedImpressive = BaseDriver.driver.FindElement(By.XPath("//input[@id='impressiveRadio']")).Selected;
            Assert.IsFalse(isSelectedImpressive);
            bool isEnableImpressive = BaseDriver.driver.FindElement(By.XPath("//input[@id='impressiveRadio']")).Enabled;
            Assert.IsTrue(isEnableImpressive);
            BaseDriver.driver.FindElement(By.XPath("//label[@for='impressiveRadio']")).Click();
            isSelectedImpressive = BaseDriver.driver.FindElement(By.XPath("//input[@id='impressiveRadio']")).Selected;
            Assert.IsTrue(isSelectedImpressive);

            bool isSelectedNo = BaseDriver.driver.FindElement(By.XPath("//input[@id='noRadio']")).Selected;
            Assert.IsFalse(isSelectedNo);
            bool isEnableNo = BaseDriver.driver.FindElement(By.XPath("//input[@id='noRadio']")).Enabled;
            Assert.IsFalse(isEnableNo);

            BaseDriver.DriverStop();
        }
        
        [TestMethod]
        public void WebTablesRowCountTest()
        {
            BaseDriver.DriverStart("https://demoqa.com/webtables");

            int rowCount = BaseDriver.driver.FindElements(By.XPath("//div[@class='rt-tbody']/div")).Count;
            Assert.AreEqual(10, rowCount);

            var selectElement = new SelectElement(BaseDriver.driver.FindElement(By.XPath("//select[@aria-label='rows per page']")));
            selectElement.SelectByText("5 rows");
            rowCount = BaseDriver.driver.FindElements(By.XPath("//div[@class='rt-tbody']/div")).Count;
            Thread.Sleep(2000);
            Assert.AreEqual(5, rowCount);

            BaseDriver.DriverStop();
        }
        
        [TestMethod]
        public void WebTablesAddItemTest()
        {
            BaseDriver.DriverStart("https://demoqa.com/webtables");

            BaseDriver.driver.FindElement(By.XPath("//button[@id='addNewRecordButton']")).Click();
            BaseDriver.driver.FindElement(By.XPath("//input[@id='firstName']")).SendKeys("Sefa");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='lastName']")).SendKeys("Küçükarslan");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys("sefak.arslan96@gmail.com");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='age']")).SendKeys("26");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='salary']")).SendKeys("8000");
            BaseDriver.driver.FindElement(By.XPath("//input[@id='department']")).SendKeys("QA");
            BaseDriver.driver.FindElement(By.XPath("//button[@id='submit']")).Click();
            ReadOnlyCollection<IWebElement> elements = BaseDriver.driver.FindElements(By.XPath("//div[@class='rt-td' and text()='Sefa']/../div"));
            Assert.AreEqual(elements[0].Text, "Sefa");
            Assert.AreEqual(elements[1].Text, "Küçükarslan");
            Assert.AreEqual(elements[2].Text, "26");
            Assert.AreEqual(elements[3].Text, "sefak.arslan96@gmail.com");
            Assert.AreEqual(elements[4].Text, "8000");
            Assert.AreEqual(elements[5].Text, "QA");

            BaseDriver.DriverStop();
        }
        
        [TestMethod]
        public void ButtonsTest()
        {
            BaseDriver.DriverStart("https://demoqa.com/buttons");  
            
            Actions action = new Actions(BaseDriver.driver);
            action.DoubleClick(BaseDriver.driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"))).Perform();            
            action.ContextClick(BaseDriver.driver.FindElement(By.XPath("//button[@id='rightClickBtn']"))).Perform();
            action.Click(BaseDriver.driver.FindElement(By.XPath("//button[@class='btn btn-primary' and text()='Click Me']"))).Perform();

            string doubleClick = BaseDriver.driver.FindElement(By.XPath("//p[@id='doubleClickMessage']")).Text;
            Assert.AreEqual(doubleClick, "You have done a double click");
            string rightClick = BaseDriver.driver.FindElement(By.XPath("//p[@id='rightClickMessage']")).Text;
            Assert.AreEqual(rightClick, "You have done a right click");
            string click = BaseDriver.driver.FindElement(By.XPath("//p[@id='dynamicClickMessage']")).Text;
            Assert.AreEqual(click, "You have done a dynamic click");

            BaseDriver.DriverStop();
        }

    }
}
