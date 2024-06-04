using AventStack.ExtentReports;
using System.Reflection;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;
using WebDriverHelper.Helper;

namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class BaseTest
    {
        protected BrowserHelper browser;
        public static ReportHelper ReportHelper;
        public TestContext TestContext {  get; set; }
        protected ExtentTest extentTest;

        public virtual void SetUpPage()
        {
        }

        [TestInitialize]
        public void InitBrowser()
        {
            // Init browser
            browser = new BrowserHelper();
            browser.OpenBrowser(ConfigurationHelper.GetConfig<string>("url"));

            // Call the SetUpPage() in derived classes
            SetUpPage();

            // Create a test
            // REFLECTION
            MethodInfo testMethod = GetType().GetMethod(TestContext.TestName);
            TestMethodAttribute displayNameAttribute = testMethod.GetCustomAttribute<TestMethodAttribute>();
            string displayName = displayNameAttribute != null ? displayNameAttribute.DisplayName : TestContext.TestName;

            extentTest = ReportHelper.CreateTest(TestContext.TestName, displayName);
        }

        [TestCleanup]
        public void QuitBrowser()
        {
            // Add result
            if (extentTest != null)
            {
                if (TestContext.CurrentTestOutcome ==  UnitTestOutcome.Failed)
                {
                    extentTest.AddImageBase64(browser.TakeScreenShotAsBase64());
                }

                extentTest.AddResult(TestContext.CurrentTestOutcome.ToString());
            }

            browser.Driver.Quit();
        }

    }
}
