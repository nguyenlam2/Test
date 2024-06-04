using FluentAssertions;
using SimpleSeleniumTest.Model;
using SimpleSeleniumTest.Page;

namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class DashboardTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        public override void SetUpPage()
        {
            loginPage = new LoginPage(browser.Driver);
            dashboardPage = new DashboardPage(browser.Driver);
        }

        [TestMethod("TC01: Verify all widget titles are displayed")]
        public void VerifyWidgetTitles()
        {
            loginPage.LoginWithUsernameAndPassword("Admin", "admin123");
            dashboardPage.IsTimeAtWorkDisplayed().Should().BeTrue();
            dashboardPage.IsMyActionsDisplayed().Should().BeTrue();
        }
    }
}
