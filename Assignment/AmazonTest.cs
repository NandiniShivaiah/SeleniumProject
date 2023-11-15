
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class AmazonTest
    {

        IWebDriver? driver;

        public void ChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com/";
            
            driver.Manage().Window.Maximize();
        }

        public void TitleTest()
        {
            Thread.Sleep(2000);
            string title = driver.Title;
            Console.WriteLine("Title"+driver.Title);
            // Assert.AreEqual("Amazon", title);
            Assert.That(driver.Url.Contains("amazon"));
            Console.WriteLine("Title test - Pass");

        }
        public void AmazonLinkTest()
        {
            Thread.Sleep(1000);
            Assert.That(driver.Url.Contains(".com"));
           
            Console.WriteLine("Amazon link-pass");
        }

        public void Destruct()
        {
            driver.Close();
        }
       
           
        }
    }

