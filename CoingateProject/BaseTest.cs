using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using CoingateProject.Pages;
using System;
using System.IO;


namespace CoingateProject
{
    class BaseTest
    {
        protected IWebDriver Driver;
        protected PosPage posPage;
        protected SelectCurrencyPage selectCurrencyPage;
        protected InvoicePage invoicePage;
        protected ConfirmationPage confirmationPage;
       

        [SetUp]
        public void InitDriver()
        {
            Driver = MyDriver.InitDriver(Browser.Chrome);
            Driver.Url = "https://pay-sandbox.coingate.com/pay/TestPOS1";
            Driver.Manage().Window.Maximize();
            InitPages();
        }

        private void InitPages()
        {
            posPage = new PosPage(Driver);
        }

        [TearDown]
        public void QuitDriver()
        {
            Driver.Close();
        }

        protected byte[] DoScreenshot()
        {
            Screenshot screenshot = Driver.TakeScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            return screenshot.AsByteArray;
        }
    }
}

