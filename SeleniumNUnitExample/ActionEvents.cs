using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    internal class ActionEvents:CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homelink=driver.FindElement(By.LinkText("Home"));
            IWebElement tdHomelink = driver.FindElement(By.XPath("/html/body/div/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr"));
            Actions actions = new Actions(driver);
          Action mouseOverAction= () => actions.MoveToElement(homelink).Build().Perform();
            Console.WriteLine("Before:" + tdHomelink.GetCssValue("background-color"));
            mouseOverAction.Invoke();
            Console.WriteLine("After:" + tdHomelink.GetCssValue("background-color"));



        }
        [Test]
        public void MultipleActionsTest() 
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(150);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not found";
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));

            Actions actions = new Actions(driver);
            Action upperCaseInput = () => actions.KeyDown(Keys.Shift).SendKeys(emailInput,"hello").KeyUp(Keys.Shift).Build().Perform();
            upperCaseInput.Invoke();
            Console.WriteLine("Text is:"+emailInput.GetAttribute("value"));
            Thread.Sleep(3000);

        }
    }
}
