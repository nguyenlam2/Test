using OpenQA.Selenium;

namespace SimpleSeleniumTest.Page
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
