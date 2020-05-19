using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace CoingateProject.Pages
{
    class ConfirmationPage : BasePage

    {
        public ConfirmationPage (IWebDriver driver) : base(driver) { }
        private IWebElement OrderStatusTitle => Driver.FindElement(By.CssSelector(".payment-info > h2"));
        private IWebElement ViewReceiptButton => Driver.FindElement(By.XPath("//button[contains(.,' View Receipt')]"));


        public void AssertOrderIsPaidAndConfirmed()
        {
            Assert.AreEqual("Paid and Confirmed", OrderStatusTitle.Text);
        }

        public ConfirmationPage OpenInvoiceFile()
        {
            ViewReceiptButton.Click();
            return this;
        }

        public ConfirmationPage CheckIfInvoiceFileIsOpened()
        {
            var browserTabs = Driver.WindowHandles;
            Driver.SwitchTo().Window(browserTabs[1]);

            String URL = Driver.Url;
            Assert.IsTrue(URL.Contains(".pdf"));

            Driver.Close();
            Driver.SwitchTo().Window(browserTabs[0]);
            return this;
        }
    }
}
