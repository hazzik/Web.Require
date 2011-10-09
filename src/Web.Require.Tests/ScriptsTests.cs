namespace Brandy.Web.Require.Tests
{
    using Xunit;

    public class ScriptsTests
    {
        [Fact]
        public void ToStringShouldOutputScriptTag()
        {
            var script = new Scripts();
            script.Add("jquery.js");
            Assert.Equal(@"<script src=""jquery.js"" type=""text/javascript""></script>", script.ToString());
        }

        [Fact]
        public void ToStringShouldReturnsEmptyIfScriptsIsEmpty()
        {
            var script = new Scripts();
            Assert.Empty(script.ToString());
        }
    }
}