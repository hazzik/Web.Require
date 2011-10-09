namespace Brandy.Web.Require.Tests
{
    using Xunit;

    public class StyleSheetsTests
    {
        [Fact]
        public void ToStringShouldOutputLinkTag()
        {
            var script = new StyleSheets();
            script.Add("jquery.js");
            Assert.Equal(@"<link href=""jquery.js"" rel=""stylesheet"" type=""text/css"" />", script.ToString());
        }

        [Fact]
        public void ToStringShouldReturnsEmptyIfStyleSheetsIsEmpty()
        {
            var script = new StyleSheets();
            Assert.Empty(script.ToString());
        }
    }
}