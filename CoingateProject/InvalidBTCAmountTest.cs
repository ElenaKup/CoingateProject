using NUnit.Framework;
using CoingateProject.Pages;


namespace CoingateProject
{
    class InvalidBTCAmountTest : BaseTest
    {
        public void BeforeTest()
        {
            posPage = new PosPage(Driver);
        }

        [Test]
        public void InvalidBTCTest()
        {
            posPage.EnterNumber1ToPos();
            posPage.AssertEnteredSumIsCorrectForInvalidBTCAmountTest();
            posPage.ConfirmEnteredAmount();
            posPage.AssertErrorMessageIsVisible();
        }

        [TearDown]
        public void ChnageOrderOfFoldersBackAndLogOut()
        {
            DoScreenshot();
        }
    }


}
