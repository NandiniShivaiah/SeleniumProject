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
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
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
            Console.WriteLine("Search product-pass");
        }

        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(3000);
            Console.WriteLine("Reload page-pass");

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
            Console.WriteLine("deal-pass");
        }

        public void SignInAccListTest()
        {
         IWebElement hellosignin = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(hellosignin == null)
            {
                throw new NoSuchElementException("Hello,Signin is not present");
            }
            IWebElement accountandlists = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if (accountandlists == null)
            {
                throw new NoSuchElementException("Hello,Signin is not present");
            }
            Assert.That(hellosignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("Hello, Sign in is present-pass");
            Assert.That(accountandlists.Text.Equals("account and lists"));
            Console.WriteLine("account and listss-pass");
        }

        public void SearchandFilterOhoneByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phone");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            driver.FindElement(By.XPath("\r\n//*[@id=\"p_89/Motorola\"]/span/a/div/label/i")).Click();
            Thread.Sleep(3000);
          
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("motorola is selected");

            driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            IWebElement xiaomi = driver.FindElement(By.XPath("//*[@id=\"p_89/Xiaomi\"]/span/a/div/label/i"));
            xiaomi.Click();
            Assert.True(driver.FindElement(By.Id("//*[@id=\"p_89/Xiaomi\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("xiaomi is selected");


        }

        /*public void SortBySelectTest()
        {
            IWebElement sbs = driver.FindElement(By.ClassName("a-native-drop"));
            SelectElement sortbyselect = (SelectElement)sortby;
        }*/








        public void Destruct()
        {
            driver.Close();
        }

    }
}
