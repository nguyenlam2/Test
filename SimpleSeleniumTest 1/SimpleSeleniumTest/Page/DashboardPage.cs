using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V123.Browser;

namespace SimpleSeleniumTest.Page
{
    public class DashboardPage : BasePage
    {
        private By xpathLabelDashboard = By.XPath("//h6[text() = 'Dashboard'] | //p[text() = '@jhon.doe']");
        private By xpathTitleTimeAtWork = By.XPath("//p[contains(., 'Time at Work')]");
        private By xpathTitleMyActions = By.XPath("//p[contains(., 'My Actions')]");
        private By xpathTitleQuickLaunch = By.XPath("//p[contains(., 'Quick Launch')]");
        private By xpathTitleBuzzLatestPosts = By.XPath("//p[contains(., 'Buzz Latest')]");
        private By xpathEmployeesOnLeaveToday = By.XPath("//p[contains(., 'Employees on Leave Today')]");
        private By xpathDistributionBySubUnit = By.XPath("//p[contains(., 'Sub Unit')]");
        private By xpathDistributionByLocation = By.XPath("//p[contains(., 'Location')]");

        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLabelDashboardDisplayed(int timeout = 1)
        {
            // Save the implicit wait to a variable
            var defaultTimeout = driver.Manage().Timeouts().ImplicitWait;

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                return driver.FindElement(xpathLabelDashboard).Displayed;
            }
            catch
            {
                return false;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            }
        }

        public bool IsTimeAtWorkDisplayed()
        {
            return driver.FindElement(xpathTitleTimeAtWork).Displayed;
        }

        public bool IsMyActionsDisplayed()
        {
            return driver.FindElement(xpathTitleMyActions).Displayed;
        }
    }
}
