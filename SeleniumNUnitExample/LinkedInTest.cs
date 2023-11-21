using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    [TestFixture]
    internal class LinkedInTest : CoreCodes
    {
        [Test]
        [Author("Nandini", "nan73@abc.com")]
        [Description("Check for Valid login")]
        [Category("Regression Testing")]
        public void Login1Test()
        {
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(3);

            // IWebElement emailInput = driver.FindElement(By.Id("session_key"));
            //IWebElement passwordInput=driver.FindElement(By.Id("session_password"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            /*IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
           
            IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));*/


            /* IWebElement emailInput = wait.Until(driv=>driv.FindElement(By.Id("session_key")));
             IWebElement passwordInput = wait.Until(driv=>driv.FindElement(By.Id("session_password")));
            */


            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(150);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not found";
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));


            emailInput.SendKeys("nan@xyz.com");
            passwordInput.SendKeys("2468");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        }

        /* [Test]
         [Author("Nandini", "nan73@abc.com")]
         [Description("Check for InValid login")]
         [Category("Smoke Testing")]

         public void Login1TestWithInvalidCred()
         {
             DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
             fluentWait.Timeout = TimeSpan.FromSeconds(5);
             fluentWait.PollingInterval = TimeSpan.FromMilliseconds(150);
             fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
             fluentWait.Message = "Element Not found";
             IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
             IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));


             emailInput.SendKeys("nam@xyz.com");
             passwordInput.SendKeys("112468");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);

             emailInput.SendKeys("sam@xyz.com");
             passwordInput.SendKeys("3452468");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);


             emailInput.SendKeys("jam@xyz.com");
             passwordInput.SendKeys("78468");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);


             Thread.Sleep(3000);




         }*/
        void ClearForm(IWebElement element)
        {
            element.Clear();

        }

        /*  [Test]
          [Author("Jungkook", "jungkook73@abc.com")]
          [Description("Check for InValid login")]
          [Category("Regression Testing")]
          [TestCase("nam@xyz.com","112468")]
          [TestCase("sam@xyz.com", "3452468")]
          [TestCase("jam@xyz.com", "78468")]


          public void Login1TestWithInvalidCred(string email,string pwd)
          {
              DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
              fluentWait.Timeout = TimeSpan.FromSeconds(5);
              fluentWait.PollingInterval = TimeSpan.FromMilliseconds(150);
              fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
              fluentWait.Message = "Element Not found";
              IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
              IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

              emailInput.SendKeys(email);
              passwordInput.SendKeys(pwd);
              ClearForm(emailInput);
              ClearForm(passwordInput);
              Thread.Sleep(3000);*/

        [Test]
        [Author("Jungkook", "jungkook73@abc.com")]
        [Description("Check for InValid login")]
        [Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLoginData))]


        public void Login1TestWithInvalidCred(string email, string pwd)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(150);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not found";
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            TakeScreenShot();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("ArgumentException[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(5000);
            js.ExecuteScript("ArgumentException[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));

            ClearForm(emailInput);
            ClearForm(passwordInput);


        }

        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"jin@xyz.com","1111"},
                new object[] {"suga@xyz.com","2222"},
            };
        }


    }
}
