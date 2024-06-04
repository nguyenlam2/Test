using FluentAssertions;
using Newtonsoft.Json;
using SimpleSeleniumTest.Model;
using SimpleSeleniumTest.Page;
using TestFrameworkCore.Model;
using WebDriverHelper.Helper;

namespace SimpleSeleniumTest.Helper
{
    public class KeywordHelper
    {
        private List<KeywordData> keywords;
        private BrowserHelper browserHelper;

        public KeywordHelper(List<KeywordData> keywords)
        {
            this.keywords = keywords;
        }

        /// <summary>
        /// Execute keywords in the list
        /// </summary>
        public void ExecuteKeywords()
        {
            foreach (var keyword in keywords)
            {
                ExecuteKeyword(keyword);
            }
        }

        public void ExecuteKeyword(KeywordData keyword)
        {
            switch (keyword.Keyword)
            {
                case "Open Browser":
                    browserHelper = new BrowserHelper();
                    browserHelper.OpenBrowser(browserType: keyword.Data);
                    break;

                case "Go to URL":
                    browserHelper.GoToURL(keyword.Data);
                    break;

                case "Enter username":
                    EnterUsername(keyword.Data);
                    break;

                case "Enter password":
                    EnterPassword(keyword.Data);
                    break;

                case "Click login button":
                    ClickLoginButton();
                    break;

                case "Verify dashboard display":
                    var verifyDashboardModel = JsonConvert.DeserializeObject<VerifyDashboardModel>(keyword.Data);
                    VerifyDashboardDisplay(verifyDashboardModel);
                    break;

                case "Enter username and password":
                    var userModel = JsonConvert.DeserializeObject<UserModel>(keyword.Data);
                    EnterUsernameAndPassword(userModel);
                    break;

                case "Close Browser":
                    browserHelper.QuitBrowser();
                    break;

                default:
                    throw new Exception("Not support this keyword");
            }
        }

        private void EnterUsername(string username)
        {
            var loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputUsername(username);
        }

        private void EnterPassword(string password)
        {
            var loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputPassword(password);
        }

        public void EnterUsernameAndPassword(UserModel model)
        {
            var loginPage = new LoginPage(browserHelper.Driver);
            loginPage.InputUsername(model.Username);
            loginPage.InputPassword(model.Password);
        }

        private void ClickLoginButton()
        {
            var loginPage = new LoginPage(browserHelper.Driver);
            loginPage.ClickLogin();
        }

        private void VerifyDashboardDisplay(VerifyDashboardModel model)
        {
            var dashboardPage = new DashboardPage(browserHelper.Driver);
            dashboardPage.IsLabelDashboardDisplayed(model.Timeout).Should().Be(model.Expected);
        }
    }
}
