namespace Brandy.Web.Require.Tests
{
    using Xunit;

    public class ScriptsTests
    {
        [Fact]
        public void ToStringShouldOutputScriptTag()
        {
            var scripts = new Scripts();
            scripts.AddScript("jquery.js");
            Assert.Equal(@"<script src=""jquery.js"" type=""text/javascript""></script>", scripts.Render(null));
        }

        [Fact]
        public void ToStringShouldReturnsEmptyIfScriptsIsEmpty()
        {
            var scripts = new Scripts();
            Assert.Empty(scripts.Render(null));
        }
    }
}