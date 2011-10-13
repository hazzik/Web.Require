namespace Brandy.Web.Require
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public static class RequireHtmlHelperExtensions
    {
        public static string RequireScript(this HtmlHelper html, string path)
        {
            AsyncScripts asyncScripts = AsyncScripts(html);
            Scripts scripts = Scripts(html);
            if (asyncScripts.Contains(path) == false)
                scripts.Add(path);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, string path1, string path2)
        {
            AsyncScripts asyncScripts = AsyncScripts(html);
            Scripts scripts = Scripts(html);
            if (asyncScripts.Contains(path1) == false)
                scripts.Add(path1);
            if (asyncScripts.Contains(path2) == false)
                scripts.Add(path2);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, string path1, string path2, string path3)
        {
            AsyncScripts asyncScripts = AsyncScripts(html);
            Scripts scripts = Scripts(html);
            if (asyncScripts.Contains(path1) == false)
                scripts.Add(path1);
            if (asyncScripts.Contains(path2) == false)
                scripts.Add(path2);
            if (asyncScripts.Contains(path3) == false)
                scripts.Add(path3);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, params string[] paths)
        {
            Scripts scripts = Scripts(html);
            AsyncScripts asyncScripts = AsyncScripts(html);
            foreach (string path in paths.Where(path => asyncScripts.Contains(path) == false))
                scripts.Add(path);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, string path)
        {
            Scripts scripts = Scripts(html);
            AsyncScripts asyncScripts = AsyncScripts(html);
            if (scripts.Contains(path) == false)
                asyncScripts.Add(path);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, string path1, string path2)
        {
            Scripts scripts = Scripts(html);
            AsyncScripts asyncScripts = AsyncScripts(html);
            if (scripts.Contains(path1) == false)
                asyncScripts.Add(path1);
            if (scripts.Contains(path2) == false)
                asyncScripts.Add(path2);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, string path1, string path2, string path3)
        {
            Scripts scripts = Scripts(html);
            AsyncScripts asyncScripts = AsyncScripts(html);
            if (scripts.Contains(path1) == false)
                asyncScripts.Add(path1);
            if (scripts.Contains(path2) == false)
                asyncScripts.Add(path2);
            if (scripts.Contains(path3) == false)
                asyncScripts.Add(path3);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, params string[] paths)
        {
            Scripts scripts = Scripts(html);
            AsyncScripts asyncScripts = AsyncScripts(html);
            foreach (string path in paths.Where(path => scripts.Contains(path) == false))
                asyncScripts.Add(path);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path)
        {
            StyleSheets(html).Add(path);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path1, string path2)
        {
            StyleSheets styleSheets = StyleSheets(html);
            styleSheets.Add(path1);
            styleSheets.Add(path2);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, string path1, string path2, string path3)
        {
            StyleSheets styleSheets = StyleSheets(html);
            styleSheets.Add(path1);
            styleSheets.Add(path2);
            styleSheets.Add(path3);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, params string[] paths)
        {
            StyleSheets styleSheets = StyleSheets(html);
            foreach (string path in paths)
                styleSheets.Add(path);
            return string.Empty;
        }

        public static IHtmlString OutputRequiredScripts(this HtmlHelper html)
        {
            MvcHtmlString requiredScripts = MvcHtmlString.Create(string.Format("{0}{1}", Scripts(html), AsyncScripts(html).ToString(html)));
            RemoveContainer<Scripts>(html);
            RemoveContainer<AsyncScripts>(html);
            return requiredScripts;
        }

        public static IHtmlString OutputRequiredStyleSheets(this HtmlHelper html)
        {
            MvcHtmlString requiredStyleSheets = MvcHtmlString.Create(StyleSheets(html).ToString());
            RemoveContainer<StyleSheets>(html);
            return requiredStyleSheets;
        }

        private static Scripts Scripts(HtmlHelper html)
        {
            return GetOrCreateContainer<Scripts>(html);
        }

        private static AsyncScripts AsyncScripts(HtmlHelper html)
        {
            return GetOrCreateContainer<AsyncScripts>(html);
        }

        private static StyleSheets StyleSheets(HtmlHelper html)
        {
            return GetOrCreateContainer<StyleSheets>(html);
        }

        private static T GetOrCreateContainer<T>(HtmlHelper html)
            where T : class, IAssetsContainer, new()
        {
            HttpContextBase httpContext = html.ViewContext.HttpContext;
            T container = (T) httpContext.Items[typeof (T)] ?? new T();
            httpContext.Items[typeof (T)] = container;
            return container;
        }

        private static T RemoveContainer<T>(HtmlHelper html)
            where T : class, IAssetsContainer, new()
        {
            HttpContextBase httpContext = html.ViewContext.HttpContext;
            httpContext.Items[typeof (T)] = null;
            return null;
        }
    }
}