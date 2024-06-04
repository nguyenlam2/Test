using SimpleSeleniumTest.Helper;
using TestFrameworkCore.Helper;

namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class KeywordDrivenTest
    {
        [TestMethod("TC04: Verify login by using keyword driven")]
        public void VerifyLogin()
        {
            // Read keywords
            var excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriven.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            // Execute keywords
            var keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywords();
        }

        [TestMethod("TC05: Verify login by using keyword driven with model")]
        public void VerifyLoginWithModel()
        {
            // Read keywords
            var excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriven2.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            // Execute keywords
            var keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywords();
        }
    }
}
