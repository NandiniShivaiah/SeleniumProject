using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExamples
{
    internal class GHPTest
    {

        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
           
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
           
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }


        public void TitleTest()
        {
            Thread.Sleep(2000);
            string title = driver.Title;
            //Console.WriteLine("Title"+driver.Title);
           // Console.WriteLine("Title Length"+driver.Title.Length);
            Assert.AreEqual("Google", title);
            Console.WriteLine("Title test - Pass");

        }

        /*public void PageSourceTest()
        {
            Console.WriteLine("PageSource"+driver.PageSource);
            Console.WriteLine("PageSource length"+driver.PageSource.Length);
        }
        */
public void PageSourceURLTest()
{
    //Console.WriteLine("PageSource"+driver.Url);
    //Console.WriteLine("PageSource length"+driver.PageSource.Length);
            Assert.AreEqual("https://www.google.com/",driver.Url);
            Console.WriteLine("URL Test-pass");
}

        public void GSTest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));  //Name("btnK"));
            gsbutton.Click();
            Assert.AreEqual("hp laptop - Google Search",driver.Title);
            Console.WriteLine("GS Test-Pass");

        }
        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
            Thread.Sleep(3000);
            //string title= driver.Title;
            // Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine("Gmail link-pass");
        }

        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(3000);
            //string title= driver.Title;
            // Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("Images link-pass");
        }

        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string loc=driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(3000);
           
            Assert.That(loc.Equals("India"));
            Console.WriteLine("Loc-pass");

        }

        public void GAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            driver.FindElement(By.CssSelector("#yDmH0d > c-wiz > div > div > c-wiz > div > div > div.v7bWUd > div.o83JEf > div:nth-child(1) > ul > li:nth-child(4) > a > div > span")).Click();
                Thread.Sleep(3000);
            Assert.That("Youtube".Equals(driver.Title));
        }


        public void Destruct()
{
    driver.Close();
}
}
}
