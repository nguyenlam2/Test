using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestFrameworkCore.Helper.Report
{
    public class ReportHelper
    {
        private ExtentReports extent;

        public void InitRePort()
        {
            extent = new ExtentReports();
            // Create random name to avoid override
            var reportName = $"Report_{DateTime.Now.ToFileTimeUtc()}.html";

            // Create a folder to save all reports
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", reportName);
            var spark = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(spark);
        }

        public void ExportReport()
        {
            extent.Flush();
        }

        public ExtentTest CreateTest(string testName, string description)
        {
            return extent.CreateTest(testName, description);
        }

        public void LogMessage(ExtentTest test, string message)
        {
            test.Log(Status.Info, message);
        }

        /// <summary>
        /// Passed/Failed
        /// </summary>
        /// <param name="test"></param>
        /// <param name="result"></param>
        public void AddResult(ExtentTest test, string result)
        {
            if (result.Equals("Passed"))
            {
                test.Pass("Test case is passed");
            }
            else
            {
                test.Fail("Test case is failed");
            }
        }
    }
}
