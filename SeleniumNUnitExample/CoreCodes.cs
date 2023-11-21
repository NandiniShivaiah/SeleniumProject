using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    internal class CoreCodes
    {

        Dictionary<string, string>? properties;

        public IWebDriver driver;
        public void ReadConfigsetting()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string fileName = currDir + "/Configsetting/Config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("=")) ;
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }



        [OneTimeSetUp] //annotation
        public void InitializeBrowser()
        {
            ReadConfigsetting();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();

            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }

            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();


        }
        [Test]
        public void TakeScreenShot()
        {
            ITakesScreenshot iss = (ITakesScreenshot)driver;
            Screenshot ss = iss.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/Screenshot/ss_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ss.SaveAsFile(filepath);

            Console.WriteLine("ss");
        }


        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();

        }
    }
}

