using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SimpleSeleniumTest.Page
{
    public class LoginPage : BasePage
    {
        private By xpathInputUsername = By.XPath("//input[contains(@name, 'username')]");
        private By xpathInputPassword = By.XPath("//input[@name='password'] | //input[@id = 'ipassword']");
        private By xpathButtonLogin = By.XPath("//button[contains(., 'Login')]");
        private By xpathErrorMessage = By.XPath("//p[text() = 'Invalid credentials']  | //div[contains(@class, 'toast-message')]");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void InputUsername(string username)
        {
            driver.FindElement(xpathInputUsername).SendKeys(username);
        }

        public void InputPassword(string password)
        {
            driver.FindElement(xpathInputPassword).SendKeys(password);
        }

        public void ClickLogin()
        {
            driver.FindElement(xpathButtonLogin).Click();
        }

        public void LoginWithUsernameAndPassword(string username, string password)
        {
            InputUsername(username);
            InputPassword(password);
            ClickLogin();
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(xpathErrorMessage).Text;
        }
    }
}
