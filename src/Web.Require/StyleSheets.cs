namespace Brandy.Web.Require
{
    internal class StyleSheets : AssetsContainerBase
    {
        public StyleSheets()
            : base(@"<link href=""{0}"" rel=""stylesheet"" type=""text/css"" />")
        {
        }
    }
}