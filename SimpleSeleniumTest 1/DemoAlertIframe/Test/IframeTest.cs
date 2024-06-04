using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoAlertIframe.Test
{
    [TestClass]
    public class IframeTest
    {
        private BrowserHelper browserHelper;

        private By xpathInput = By.XPath("//div[@class = 'row']/div/input[@type = 'text']");
        private By xpathIframeSingle = By.XPath("//iframe[@id = 'singleframe']");
        private By xpathButtonMultipleFrame = By.XPath("//a[text() = 'Iframe with in an Iframe']");

        [TestInitialize]
        public void TestInitialize()
        {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://demo.automationtesting.in/Frames.html");
        }

        [TestMethod]
        public void VerifyFrame()
        {
            var frame = browserHelper.Driver.FindElement(xpathIframeSingle);

            browserHelper.Driver.SwitchTo().Frame(frame);
            browserHelper.Driver.FindElement(xpathInput).SendKeys("Thai");

            browserHelper.Driver.SwitchTo().DefaultContent();
            browserHelper.Driver.FindElement(xpathButtonMultipleFrame).Click();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            browserHelper.Driver.Quit();
        }
    }
}
