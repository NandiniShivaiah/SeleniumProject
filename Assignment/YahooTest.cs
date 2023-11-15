using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment
{
    internal class YahooTest
    {
        IWebDriver? driver;

        public void ChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";

            driver.Manage().Window.Maximize();
        }

        public void NavigateTest()
        {
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.Navigate().Forward();
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("APjFqb")).SendKeys("What's new for Diwali 2023");
            Thread.Sleep(2000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));  //Name("btnK"));
            gsbutton.Click();
            Assert.That(driver.Title.Contains("What's new for Diwali 2023"));
            Console.WriteLine("Passed");

        }

        public void Destruct()
        {
            driver.Close();
        }
    }
}
