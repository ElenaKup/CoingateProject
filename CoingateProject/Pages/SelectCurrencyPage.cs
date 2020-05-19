using NUnit.Framework;
using OpenQA.Selenium;


namespace CoingateProject.Pages
{
    class SelectCurrencyPage : BasePage

    {
        public SelectCurrencyPage (IWebDriver driver) : base(driver) { }
        private IWebElement CurrencyPageHeader => Driver.FindElement(By.CssSelector("#payment-new .text-center"));
        private IWebElement LitecoinOption => Driver.FindElement(By.CssSelector(".currency-card:nth-child(2) .currency-card-currency-title"));
        private IWebElement InvoiceEmailInputField => Driver.FindElement(By.Id("invoice-email"));
        private IWebElement InvoiceCheckoutButton => Driver.FindElement(By.Id("invoice-checkout-button"));

        public void AssertSelectCurrencyPageIsVisible()
        {
            Assert.AreEqual("Select payment currency", CurrencyPageHeader.Text);
        }

        public SelectCurrencyPage SelectLitecoin()
        {
            LitecoinOption.Click();
            return this;
        }

        public SelectCurrencyPage EnterInvoiceEmail(string email)
        {
            InvoiceEmailInputField.Click();
            InvoiceEmailInputField.SendKeys(email);
            return this;
        }

        public InvoicePage ClickInvoiceCheckoutButton()
        {
            InvoiceCheckoutButton.Click();
            return new InvoicePage(Driver);
        }
          
    }
}
