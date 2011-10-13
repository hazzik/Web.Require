namespace Brandy.Web.Require.Tests
{
    using System.Collections;
    using System.Web.Mvc;
    using Moq;
    using Xunit;

    public class RequireHtmlHelperExtensionsTests
    {
        private readonly HtmlHelper html = CreateHtmlHelper();

        [Fact]
        public void OutputRequiredStyleSheetsShouldNotWriteValueNotCreated()
        {
            Assert.DoesNotContain("Value is not created.", html.OutputRequiredStyleSheets().ToHtmlString());
        }

        [Fact]
        public void OutputRequiredScriptsShouldNotWriteValueNotCreated()
        {
            Assert.DoesNotContain("Value is not created.", html.OutputRequiredScripts().ToHtmlString());
        }

        private static HtmlHelper CreateHtmlHelper()
        {
            var viewContextMock = new Mock<ViewContext>();
            var viewDataContainerMock = new Mock<IViewDataContainer>();
            viewContextMock.Setup(x => x.HttpContext.Items).Returns(new Hashtable());
            return new HtmlHelper(viewContextMock.Object, viewDataContainerMock.Object);
        }
    }
}