using TestFrameworkCore.Helper.Report;

[assembly: Parallelize(Workers = 3, Scope = ExecutionScope.MethodLevel)]
namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class AssemblyTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            // Set up report
            BaseTest.ReportHelper = new ReportHelper();

            BaseTest.ReportHelper.InitRePort();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Export report
            if (BaseTest.ReportHelper != null)
            {
                BaseTest.ReportHelper.ExportReport();
            }
        }
    }
}
