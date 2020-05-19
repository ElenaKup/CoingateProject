using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace CoingateProject.Pages
{
    class PosPage : BasePage

    {
        public PosPage(IWebDriver driver) : base(driver) { }
        private IWebElement NumberOneButton => Driver.FindElement(By.XPath("//div[3]/div/div"));
        private IWebElement NumberFiveButton => Driver.FindElement(By.XPath("//div[2]/div[2]"));
        private IWebElement DoubleZeroButton => Driver.FindElement(By.XPath("//div[4]/div"));
        private IWebElement OkButton => Driver.FindElement(By.CssSelector(".new-order-button"));
        private IWebElement EnteredOrderPrice => Driver.FindElement(By.ClassName("new-order-price"));
        private IWebElement ErrorMessagePopUp => Driver.FindElement(By.CssSelector(".ant-message-custom-content >span"));
        private By ErrorMessagePopUWait => By.CssSelector(".ant-message-custom-content >span");


        public PosPage EnterNumber1ToPos()
        {
            NumberOneButton.Click();
            return this;
        }
        
        public void AssertEnteredSumIsCorrectForInvalidBTCAmountTest()
        {
            Assert.AreEqual("0.00000001 BTC", EnteredOrderPrice.Text);
        }

        public void AssertErrorMessageIsVisible()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(ErrorMessagePopUWait));
            Assert.AreEqual("Price amount must be greater or equal to 0.0001 BTC", ErrorMessagePopUp.Text);
        }

        public PosPage EnterValidSumToPos()
        {
            NumberFiveButton.Click();
            DoubleZeroButton.Click();
            DoubleZeroButton.Click();
            return this;
        }
        public void AssertEnteredSumIsCorrectForHappyPathTest()
        {
            Assert.AreEqual("0.00050000 BTC", EnteredOrderPrice.Text);
        }

        public SelectCurrencyPage ConfirmEnteredAmount()
        {
            OkButton.Click();
            return new SelectCurrencyPage (Driver);
        }
    }
}
