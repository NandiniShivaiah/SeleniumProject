﻿// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();
driver.Url = "https://www.google.com";
Thread.Sleep(10000);
string title = driver.Title;
try
{
    Assert.AreEqual("Google", title);
    Console.WriteLine("Pass");

}
catch(AssertionException)
{
    Console.WriteLine("Fail");
}

driver.Close();

