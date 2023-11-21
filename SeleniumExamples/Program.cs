// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExamples;



List<string> drivers=new List<string>();
drivers.Add("Chrome");
AmazonPageTest am = new AmazonPageTest();
foreach (var driver in drivers)
{


    switch (driver)
    {
        case "Edge":
            am.InitializeEdgeDriver(); break;
        case "Chrome":
            am.InitializeChromeDriver(); break;


    }
    try
    {
       /* am.TitleTest();

        am.LogoClickTest();
        Thread.Sleep(10000);
        am.SearchProductTest();
        Thread.Sleep(10000);

        am.ReloadHomePage();
       
        am.TodaysDealTest();
        am.SignInAccListTest();
        am.SearchandFilterOhoneByBrandTest();*/
       am.SearchandFilterOhoneByBrandTest(); 
    }
    catch (AssertionException e)
    {
        Console.WriteLine("Fail");
    }
    catch (NoSuchElementException nse)
    {
        Console.WriteLine("nse");
    }
    am.Destruct();

}



/*IWebDriver driver = new ChromeDriver(); //opens browser
driver.Url = "https://www.google.com/";

Thread.Sleep(1000); //should never use thread.sleep in code

string title = driver.Title;*/




/*Console.WriteLine("1. Edge 2. Chrome");
int ch = Convert.ToInt32(Console.ReadLine());
switch(ch)
{
    case 1:
        gHPTest.InitializeEdgeDriver(); break;
    case 2:
        gHPTest.InitializeChromeDriver(); break;

}*/

/*GHPTest gHPTest = new();
List<string> drivers = new List<string>();
drivers.Add("Edge");
drivers.Add("Chrome");


foreach (var driver in drivers)
{
    switch (driver)
    {
        case "Edge":
            gHPTest.InitializeEdgeDriver(); break;
        case "Chrome":
            gHPTest.InitializeChromeDriver(); break;

    }




    try
    {
        gHPTest.TitleTest();
        gHPTest.PageSourceURLTest();
        gHPTest.GSTest();
        gHPTest.GmailLinkTest();
        gHPTest.ImagesLinkTest();
        gHPTest.LocalizationTest();
        gHPTest.GAppYoutubeTest();

    }
    catch (AssertionException e)
    {
        Console.WriteLine("URL test-Fail");
    }

    gHPTest.Destruct();
}*/