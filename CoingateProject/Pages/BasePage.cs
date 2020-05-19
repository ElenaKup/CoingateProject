using OpenQA.Selenium;

namespace CoingateProject.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        { 
            Driver = driver;
        }
    }
}
