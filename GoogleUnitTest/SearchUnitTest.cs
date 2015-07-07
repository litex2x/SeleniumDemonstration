using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CodePound.SeleniumDemonstration.GoogleUnitTest
{
    [TestClass]
    public class SearchUnitTest
    {
        [TestMethod]
        public void SearchMethod()
        {
            //  Make sure chromedriver.exe is in your bin folder
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            try
            {
                driver.Navigate().GoToUrl("https://www.google.com");

                var searchBox = driver.FindElement(By.CssSelector("input[type='text'][title='Search']"));
                searchBox.SendKeys("selenium hq");

                var searchButton = driver.FindElement(By.CssSelector("button[value='Search']"));
                searchButton.Click();

                //  Need to wait for element to appear
                wait.Until(x =>
                    {
                        return x.FindElement(By.LinkText("Selenium - Web Browser Automation"));
                    });

                var seleniumLink = driver.FindElement(By.LinkText("Selenium - Web Browser Automation"));
                seleniumLink.Click();
            }
            finally
            {
                //  Clean up driver resources
                driver.Quit();
            }

            //  Helpful Links:
            //  Nuget - http://www.nuget.org
            //  Selenium Downloads - http://www.seleniumhq.org/download/
            //  Selenium WebDriver Tutorial - http://www.seleniumhq.org/docs/03_webdriver.jsp
            //  CSS Selectors Reference - http://www.w3schools.com/css/css_selectors.asp
        }
    }
}
