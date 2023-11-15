using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExamples
{
    internal class AmazonPageTest
    {

        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {

            driver = new EdgeDriver();
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();

            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }


        public void TitleTest()
        {
            Thread.Sleep(2000);
            string title = driver.Title;
            //Console.WriteLine("Title"+driver.Title);
            // Console.WriteLine("Title Length"+driver.Title.Length);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", title);
            Console.WriteLine("Title test - Pass");

        }

        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend more. Smile more.", driver.Title);
                 //Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine("Amazon Test-Pass");

        }

        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(driver.Title.Equals("Amazon.com : mobiles") 
                && (driver.Url.Contains("mobiles")));
        }

        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(3000);

        }

        public void TodaysDealTest()
        {
            IWebElement todaysdeal = driver.FindElement(By.LinkText("Today's Deals"));
            if (todaysdeal == null)
            {
                throw new NoSuchElementException("Todays deal not present");
            }

            todaysdeal.Click();
            Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deal"));
                }
            

        public void Destruct()
        {
            driver.Close();
        }

    }
}
