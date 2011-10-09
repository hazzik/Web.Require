namespace Brandy.Web.Require
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    public static class RequireHtmlHelperExtensions
    {
        private static Lazy<Scripts> scripts = new Lazy<Scripts>();
        private static Lazy<StyleSheets> styleSheets = new Lazy<StyleSheets>();

        public static string RequireScript(this HtmlHelper html, string path)
        {
            scripts.Value.Add(path);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, string path1, string path2)
        {
            var requiredScripts = scripts.Value;
            requiredScripts.Add(path1);
            requiredScripts.Add(path2);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, string path1, string path2, string path3)
        {
            var requiredScripts = scripts.Value;
            requiredScripts.Add(path1);
            requiredScripts.Add(path2);
            requiredScripts.Add(path3);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, params string[] paths)
        {
            var requiredScripts = scripts.Value;
            foreach (string path in paths)
                requiredScripts.Add(path);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path)
        {
            styleSheets.Value.Add(path);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path1, string path2)
        {
            var requiredStyleSheets = styleSheets.Value;
            requiredStyleSheets.Add(path1);
            requiredStyleSheets.Add(path2);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path1, string path2, string path3)
        {
            var requiredStyleSheets = styleSheets.Value;
            requiredStyleSheets.Add(path1);
            requiredStyleSheets.Add(path2);
            requiredStyleSheets.Add(path3);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, params string[] paths)
        {
            var requiredStyleSheets = styleSheets.Value;
            foreach (string path in paths)
                requiredStyleSheets.Add(path);
            return string.Empty;
        }

        public static IHtmlString OutputRequiredScripts(this HtmlHelper html)
        {
            var requiredScripts = MvcHtmlString.Create(scripts.ToString());
            scripts = new Lazy<Scripts>();
            return requiredScripts;
        }

        public static IHtmlString OutputRequiredStyleSheets(this HtmlHelper html)
        {
            var requiredStyleSheets = MvcHtmlString.Create(styleSheets.ToString());
            styleSheets = new Lazy<StyleSheets>();
            return requiredStyleSheets;
        }
    }
}