using FluentAssertions;
using RazorEngine.Compilation.ImpromptuInterface;
using SimpleSeleniumTest.Page;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;

namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        public override void SetUpPage()
        {
            loginPage = new LoginPage(browser.Driver);
            dashboardPage = new DashboardPage(browser.Driver);
        }

        [TestMethod("TC01: Verify login with valid username and password")]
        public void VerifyValidUser()
        {
            // Login with valid username and password
            var username = ConfigurationHelper.GetConfig<string>("username");
            extentTest.LogMessage($"Read configuraion - username: {username}");

            var password = ConfigurationHelper.GetConfig<string>("password");
            extentTest.LogMessage($"Read configuraion - password: {password}");

            extentTest.LogMessage($"Login with valid username and password");
            loginPage.LoginWithUsernameAndPassword(username, password);

            // Verify that the Dashboard label is displayed
            dashboardPage.IsLabelDashboardDisplayed(10).Should().BeTrue();
        }

        [TestMethod("TC02: Verify login with invalid username or password")]
        public void VerifyInvalidUser()
        {
            // Login with valid username and password
            var username = ConfigurationHelper.GetConfig<string>("username");
            loginPage.LoginWithUsernameAndPassword(username, "admin124");

            // Verify that error message is displayed
            loginPage.GetErrorMessage().Should().Contain("Invalid");
            

            // Verify that the Dashboard label is NOT displayed
            dashboardPage.IsLabelDashboardDisplayed(10).Should().BeFalse();
        }

        [TestMethod("TC03: Dynamic data - login test")]
        [DynamicData(nameof(DataLoginUser))]
        public void VerifyLoginUser(string username, string password, string isLabelDashboardDisplayed)
        {
            loginPage.LoginWithUsernameAndPassword(username, password);
            dashboardPage.IsLabelDashboardDisplayed().Should().Be(bool.Parse(isLabelDashboardDisplayed));
        }

        public static IEnumerable<object[]> DataLoginUser
        {
            get
            {
                return new ExcelHelper(Path.Combine("Resources", "VerifyLoginUser.xlsx")).GetLoginUserData();
            }
        }
    }
}
