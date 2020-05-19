using NUnit.Framework;
using OpenQA.Selenium;


namespace CoingateProject.Pages
{
    class InvoicePage : BasePage

    {
        public InvoicePage (IWebDriver driver) : base(driver) { }
        private IWebElement SendAmountTitle => Driver.FindElement(By.CssSelector("#payment-address > div.send-amount > div"));
        private IWebElement InvoiceAmountInputField => Driver.FindElement(By.Id("invoice-amount-input"));
        private IWebElement MarkAsPaidButton => Driver.FindElement(By.XPath("//button[contains(.,'Mark as Paid')]"));


        public void AssertSelectInvoicePageIsVisible()
        {
            Assert.AreEqual("Send the indicated amount to the address below", SendAmountTitle.Text);
        }

        public void AssertLiteCoinValueIsCorrect()
        {
            Assert.AreEqual("0.1072", InvoiceAmountInputField.GetAttribute("value"));
        }

        public ConfirmationPage MarkOrderAsPaid()
        {
            MarkAsPaidButton.Click();
            return new ConfirmationPage(Driver)
;       }
    }
}
