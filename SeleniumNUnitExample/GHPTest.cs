/*using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    [TestFixture] // act as an independent test
    internal class GHPTest : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            Thread.Sleep(2000);
            // string title = driver.Title;
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");

        }
        [Ignore("other")]

        [Test]
        [Order(20)]
        public void GSTest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));  //Name("btnK"));
            gsbutton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine("GS Test-Pass");

        }
        [Ignore("other")]

        *//*  [Test]
          public void AllLinkStatusTest()
          {
              List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();

              foreach(var link in allLinks) 
              {
                  string url = link.GetAttribute("href");
                  if (url == null)
                  {
                      Console.WriteLine("URL is null");
                      continue;
                  }
                  else
                  {
                      bool isworking=true;      CheckLinkStatus(url);
                      if (isworking)
                          Console.WriteLine(url + "is working");
                      else
                          Console.WriteLine(url + "not working");


                     }
}              }
        */
    
    
