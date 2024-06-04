using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoAlertIframe.Test
{
    [TestClass]
    public class AlertTest
    {
        private By xpathButton(string text) => By.XPath($"//button[text() = '{text}']");
        private By xpathTextResult = By.XPath("//p[@id = 'result']");

        private BrowserHelper browserHelper;

        [TestInitialize]
        public void TestInitialize()
        {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://the-internet.herokuapp.com/javascript_alerts");
        }

        [TestMethod]
        public void VerifyAlert()
        {
            // Click on the button
            browserHelper.Driver.FindElement(xpathButton("Click for JS Alert")).Click();

            // Switch to alert box and click OK
            browserHelper.Driver.SwitchTo().Alert().Accept();

            // Verify that the text is displayed after click OK
            Assert.AreEqual(browserHelper.Driver.FindElement(xpathTextResult).Text, "You successfully clicked an alert");
        }

        [TestMethod]
        public void VerifyConfirm()
        {
            // Click on the button
            browserHelper.Driver.FindElement(xpathButton("Click for JS Confirm")).Click();

            // Switch to alert box and click OK
            browserHelper.Driver.SwitchTo().Alert().Dismiss();

            // Verify that the text is displayed after click OK
            //browserHelper.Driver.FindElement(xpathTextResult).Text, "You clicked: Cancel");
        }

        [TestMethod]
        public void VerifyPrompt()
        {
            // Click on the button
            browserHelper.Driver.FindElement(xpathButton("Click for JS Prompt")).Click();

            // Input random value
            var inputValue = "Thai" + DateTime.Now.ToFileTimeUtc();
            browserHelper.Driver.SwitchTo().Alert().SendKeys(inputValue);
            browserHelper.Driver.SwitchTo().Alert().Accept();

            // Verify that the text is displayed after click OK
            //List<string> splitString = actualValue.Split().ToList();
            //string
            //var actualResult = browserHelper.Driver.FindElement(xpathTextResult).Text;
            //actualResult.Should().Be($"You entered: {inputValue}");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            browserHelper.Driver.Quit();
        }
    }
}
