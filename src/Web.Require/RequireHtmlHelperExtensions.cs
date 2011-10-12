namespace Brandy.Web.Require
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    public static class RequireHtmlHelperExtensions
    {
        private static Lazy<Scripts> scripts = new Lazy<Scripts>();
        private static Lazy<AsyncScripts> asyncScripts = new Lazy<AsyncScripts>();
        private static Lazy<StyleSheets> styleSheets = new Lazy<StyleSheets>();

        public static string RequireScript(this HtmlHelper html, string path)
        {
            if (asyncScripts.Value.Contains(path) == false)
                scripts.Value.Add(path);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, string path1, string path2)
        {
            RequireScript(html, path1);
            RequireScript(html, path2);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, string path1, string path2, string path3)
        {
            RequireScript(html, path1);
            RequireScript(html, path2);
            RequireScript(html, path3);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, params string[] paths)
        {
            Scripts requiredScripts = scripts.Value;
            foreach (string path in paths)
                requiredScripts.Add(path);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, string path)
        {
            if (scripts.Value.Contains(path) == false)
                asyncScripts.Value.Add(path);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, string path1, string path2)
        {
            RequireScriptAsync(html, path1);
            RequireScriptAsync(html, path2);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, string path1, string path2, string path3)
        {
            RequireScriptAsync(html, path1);
            RequireScriptAsync(html, path2);
            RequireScriptAsync(html, path3);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, params string[] paths)
        {
            foreach (string path in paths)
                RequireScriptAsync(html, path);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path)
        {
            styleSheets.Value.Add(path);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path1, string path2)
        {
            StyleSheets requiredStyleSheets = styleSheets.Value;
            requiredStyleSheets.Add(path1);
            requiredStyleSheets.Add(path2);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path1, string path2, string path3)
        {
            StyleSheets requiredStyleSheets = styleSheets.Value;
            requiredStyleSheets.Add(path1);
            requiredStyleSheets.Add(path2);
            requiredStyleSheets.Add(path3);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, params string[] paths)
        {
            StyleSheets requiredStyleSheets = styleSheets.Value;
            foreach (string path in paths)
                requiredStyleSheets.Add(path);
            return string.Empty;
        }

        public static IHtmlString OutputRequiredScripts(this HtmlHelper html)
        {
            MvcHtmlString requiredScripts = MvcHtmlString.Create(string.Format("{0}{1}", scripts, asyncScripts.Value.ToString(html)));
            scripts = new Lazy<Scripts>();
            asyncScripts = new Lazy<AsyncScripts>();
            return requiredScripts;
        }

        public static IHtmlString OutputRequiredStyleSheets(this HtmlHelper html)
        {
            MvcHtmlString requiredStyleSheets = MvcHtmlString.Create(styleSheets.ToString());
            styleSheets = new Lazy<StyleSheets>();
            return requiredStyleSheets;
        }
    }
}