using NUnit.Framework;
using CoingateProject.Pages;


namespace CoingateProject
{
    class HappyPathTest : BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            posPage = new PosPage(Driver);
            selectCurrencyPage = new SelectCurrencyPage(Driver);
            invoicePage = new InvoicePage(Driver);
            confirmationPage = new ConfirmationPage(Driver);
        }

        [Test]
        public void HappyPathBTCTest()
        {
            posPage.EnterValidSumToPos();
            posPage.AssertEnteredSumIsCorrectForHappyPathTest();
            posPage.ConfirmEnteredAmount();
            selectCurrencyPage.AssertSelectCurrencyPageIsVisible();
            selectCurrencyPage.SelectLitecoin();
            selectCurrencyPage.EnterInvoiceEmail(TestData.Data.Email);
            selectCurrencyPage.ClickInvoiceCheckoutButton();
            invoicePage.AssertSelectInvoicePageIsVisible();
            invoicePage.MarkOrderAsPaid();
            confirmationPage.AssertOrderIsPaidAndConfirmed();
            confirmationPage.OpenInvoiceFile();
            confirmationPage.CheckIfInvoiceFileIsOpened();
        }

        [TearDown]
        public void ChnageOrderOfFoldersBackAndLogOut()
        {
            DoScreenshot();
        }
    }


}
