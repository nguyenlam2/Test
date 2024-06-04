using OpenQA.Selenium;
using TestFrameworkCore.Helper;

namespace WebDriverHelper.Helper
{
    public class BrowserHelper
    {
        public IWebDriver Driver;

        /// <summary>
        /// Init browser/ open browser and navigate to url
        /// </summary>
        /// <param name="url"></param>
        public void OpenBrowser(string url = null, string browserType = null)
        {
            // If do not pass browserType then read from config
            // Else use the argument that we pass

            if (string.IsNullOrEmpty(browserType))
            {
                browserType = ConfigurationHelper.GetConfig<string>("browser");
            }

            Driver = DriverFactoryHelper.InitDriver(browserType);

            // Setting implicit wait
            int timeout = ConfigurationHelper.GetConfig<int>("timeout");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);

            Driver.Manage().Window.Maximize();

            if (!string.IsNullOrEmpty(url))
            {
                GoToURL(url);
            }
        }

        /// <summary>
        /// Quit and dispose all resources
        /// </summary>
        public void QuitBrowser()
        {
            if (Driver is null)
            {
                return;
            }

            Driver.Quit();
        }

        public void GoToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string TakeScreenShotAsBase64()
        {
            // Chụp màn hình
            ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            // Chuyển đổi thành dạng base64
            byte[] screenshotAsByteArray = screenshot.AsByteArray;
            string screenshotAsBase64 = Convert.ToBase64String(screenshotAsByteArray);

            return screenshotAsBase64;
        }

    }
}
