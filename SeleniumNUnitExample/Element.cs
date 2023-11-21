using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    [TestFixture]
    internal class Element:CoreCodes
    {
        [Ignore("other")]
        [Test]
        public void TestCheckBox()
        {
            Thread.Sleep(3000);
            /*IWebElement elements = driver.FindElement(By.XPath("//h5[textT()='Elements;]//parent::div"));
            elements.Click();*/
            IWebElement cbnemu = driver.FindElement(By.XPath("<span[text()=Check Box]"));
            cbnemu.Click();

            List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse-rct-collapse-btn")).ToList();
            foreach(var item in expandcollapse)
            {
                item.Click();
            }
            Thread.Sleep(3000);
           /* IWebElement commandcheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandcheckbox.Click();*/
            driver.FindElement(By.XPath("\"//span[text()='Commands']")).Click();
            Assert.True(driver.FindElement(By.Id("'tree-node-commands")).Selected);
            Console.WriteLine("CheckBoxTest-Passed");
           
              


        }


        [Test]
        public void TestFormElements()
        {
            Thread.Sleep(3000);
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("John");
            Thread.Sleep(3000);
            IWebElement  lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Doe");
            Thread.Sleep(3000);

            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("myid@gmail.com");
            Thread.Sleep(3000);

            IWebElement genderRadio= driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            genderRadio.Click();
            Thread.Sleep(3000);

           IWebElement mobilenum = driver.FindElement(By.XPath("//input[@id='userNumber']"));
            mobilenum.SendKeys("123445678");
            Thread.Sleep(3000);

            IWebElement dateofbirthField = driver.FindElement(By.Id("//input[@id='dateofBirthInput']"));
            dateofbirthField.Click();
            Thread.Sleep(3000);

            IWebElement dobMonth = driver.FindElement(By.XPath("//select[@class=react-datepicker__month-select"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByIndex(5);
            Thread.Sleep(3000);

            IWebElement dobYear = driver.FindElement(By.XPath("//select[@class=react-datepicker__year-select"));
            SelectElement selecTYear = new SelectElement(dobMonth);
            selecTYear.SelectByText("1999");
            Thread.Sleep(3000);



            IWebElement dobDay = driver.FindElement(By.XPath("//select[@class=react-datepicker__day react-datepicker__day--017"));
           // SelectElement selectDay = new SelectElement(dobDay);
            dobDay.Click();
            Thread.Sleep(3000);

            IWebElement subjectField = driver.FindElement(By.Id("subjectsInput"));
            subjectField.SendKeys("maths");
            subjectField.SendKeys(Keys.Enter);
            subjectField.SendKeys("chemistry");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            IWebElement uploadPicture = driver.FindElement(By.Id("uploadPicture"));
            uploadPicture.SendKeys("C:\\Users\\Administrator\\Pictures\\Saved Pictures");
            Thread.Sleep(3000);

            IWebElement address = driver.FindElement(By.Id("currentAddress"));
            uploadPicture.SendKeys("123 street,city,country");
            Thread.Sleep(3000);

            IWebElement submitButton= driver.FindElement(By.Id("submit"));
            submitButton.Click();








        }
        [Test]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle - > " + parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for(var i=0;i<3;i++)
            {
                clickElement.Click();
                Thread.Sleep(3000);

            }
            List<string> lastwindow = driver.WindowHandles.ToList();
            String lastWindowHandle = "";
            foreach(var handle in lastwindow)
            {
                Console.WriteLine("Switching to window - >" + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
                Console.WriteLine("Navigating to google.com");
                driver.Navigate().GoToUrl("https://www.google.com");
                Thread.Sleep(2000);

                lastWindowHandle = handle;


            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();


        }

        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
                IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text isn" + simpleAlert.Text);
            simpleAlert.Accept();
            Thread.Sleep(5000);


           

            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(5000);
            element.Click();
            IAlert confirmationAlert=driver.SwitchTo().Alert();
            string alertText=confirmationAlert.Text;
            Console.WriteLine("alert text is" + alertText);
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(5000);
           
            IAlert promtAlert = driver.SwitchTo().Alert();
                alertText = promtAlert.Text;
            Console.WriteLine("alert text is" + alertText);
            promtAlert.SendKeys("Accepting the alert");
            Thread.Sleep(5000);
            promtAlert.Accept();
         


        }
    }
}
