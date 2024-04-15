using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace TestAutomationFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var options = new EdgeOptions();
                options.AddArgument("--safebrowsing-disable-download-protection");
                IWebDriver driver = new EdgeDriver(options);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://selectorshub.com/xpath-practice-page/");
                driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(100);

                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                driver.FindElement(By.Name("email")).SendKeys("testuser@select.com");
                driver.FindElement(By.Id("pass")).SendKeys("passcode");

                Console.WriteLine("action success");
                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception - " + ex.Message);
            }
            



        }
    }
}
