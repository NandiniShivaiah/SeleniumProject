using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNUnit
{
    [TestFixture]
    internal class Naptool : CoreCodes
    {


        [Test]
        [Order(1)]
        public void SearchProduct()
        {
            driver.Navigate().GoToUrl("https://www.naaptol.com/");

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(150);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fluentWait.Message);

            IWebElement search = fluentWait.Until(d => d.FindElement(By.Id("header_search_text")));
            search.Click();
            search.SendKeys("eyewear");
            search.SendKeys(Keys.Enter);

            Assert.That(driver.Url.Contains("eyewear"));
            Console.WriteLine("SearchProductTest: " + "Passed");
        }


        [Test]
        [Order(2)]
        [TestCase("5")]

        public void SelectProductTest(string numOf)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fluentWait.Message);

            IWebElement select = driver.FindElement(By.Id("productItem" + numOf));
            select.Click();

            List<string> lstWindow = driver.WindowHandles.ToList();

            foreach (var i in lstWindow)
            {
                Console.WriteLine("Switching to window: " + i);
                driver.SwitchTo().Window(i);
            }
            Assert.That(driver.Url.Contains("reading"));
            Console.WriteLine("SelectProductTest: Passed");

        }

        [Test]
        [Order(3)]
        public void AddProductTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fluentWait.Message);

            IWebElement selectSize = fluentWait.Until(d => d.FindElement(By.LinkText("Black-2.50")));
            selectSize.Click();

            IWebElement addProduct = fluentWait.Until(d => d.FindElement(By.Id("cart-panel-button-0")));
            addProduct.Click();
            Assert.That(driver.Url.Contains("reading"));
            Console.WriteLine("AddProductTest: Passed");

        }
        [Test]
        [Order(4)]
        public void CartTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMicroseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fluentWait.Message);

            Thread.Sleep(1000);
            IWebElement cart = fluentWait.Until(d => d.FindElement(By.XPath("//h1[text()='My Shopping Cart: ']")));
            IWebElement productAvail = fluentWait.Until(d => d.FindElement(By.XPath("//a[text()='Reading Glasses with LED Lights (LRG4)']")));

            IWebElement popUpClose = fluentWait.Until(d => d.FindElement(By.XPath("//a[@title='Close']")));
            popUpClose.Click();
            Assert.That(driver.Url.Contains("reading"));
            Console.WriteLine("cartTest: Passed");

        }
    }
}

