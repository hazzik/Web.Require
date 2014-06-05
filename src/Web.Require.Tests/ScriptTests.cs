using Xunit;

namespace Brandy.Web.Require.Tests
{
    public class ScriptTests
    {
        [Fact]
        public void CanRenderScript()
        {
            var script = new Script("/test.js") { Type = "text/javascript" };
            var render = script.Render();
            Assert.Equal("<script src=\"/test.js\" type=\"text/javascript\"></script>", render);
        }

        [Fact]
        public void CanRenderAsyncScript()
        {
            var script = new Script("/test.js") { Async = true, Type = "text/javascript" };
            var render = script.Render();
            Assert.Equal("<script async=\"async\" src=\"/test.js\" type=\"text/javascript\"></script>", render);
        }

        [Fact]
        public void CanRenderDeferScript()
        {
            var script = new Script("/test.js") { Defererd = true, Type = "text/javascript" };
            var render = script.Render();
            Assert.Equal("<script defer=\"defer\" src=\"/test.js\" type=\"text/javascript\"></script>", render);
        }
    }
}
