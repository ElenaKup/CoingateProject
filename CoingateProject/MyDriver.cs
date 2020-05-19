using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;


namespace CoingateProject
{
    public class MyDriver
    {
        public static IWebDriver InitDriver(Browser browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver(GetChromeOptions());
                    break;
                case Browser.Firefox:
                    return new FirefoxDriver();
                    break;
                default:
                    NUnit.Framework.Assert.Fail("Not supporting browser");
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            return options;
        }
    }
    public enum Browser
    {
        Firefox,
        Chrome
    }
}


