// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using Assignment;



/*AmazonTest amazonTest = new();


amazonTest.ChromeDriver();

try
{
    
    amazonTest.TitleTest();
   amazonTest.AmazonLinkTest();

}
catch (AssertionException e)
{
    Console.WriteLine("URL test-Fail");
}
amazonTest.Destruct();*/

YahooTest yahoo = new YahooTest();
yahoo.ChromeDriver();
try
{
    yahoo.NavigateTest();
}
catch(AssertionException e)
{
    Console.WriteLine("Failed\n"+e.Message);
}
yahoo.Destruct();

