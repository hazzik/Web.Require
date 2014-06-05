using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace Brandy.Web.Require
{
    public static class RequireHtmlHelperExtensions
    {
        public static string RequireScript(this HtmlHelper html, [NotNull, PathReference] string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            var scripts = Scripts(html);
            scripts.AddScript(path);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, [NotNull, PathReference] string path1, [NotNull, PathReference] string path2)
        {
            if (path1 == null) throw new ArgumentNullException("path1");
            if (path2 == null) throw new ArgumentNullException("path2");
            var scripts = Scripts(html);
            scripts.AddScript(path1);
            scripts.AddScript(path2);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, [NotNull, PathReference] string path1, [NotNull, PathReference] string path2, [NotNull, PathReference] string path3)
        {
            if (path1 == null) throw new ArgumentNullException("path1");
            if (path2 == null) throw new ArgumentNullException("path2");
            if (path3 == null) throw new ArgumentNullException("path3");
            var scripts = Scripts(html);
            scripts.AddScript(path1);
            scripts.AddScript(path2);
            scripts.AddScript(path3);
            return string.Empty;
        }

        public static string RequireScript(this HtmlHelper html, params string[] paths)
        {
            var scripts = Scripts(html);
            foreach (var path in paths)
                scripts.AddScript(path);
            return string.Empty;
        }

        public static string RequireInlineScript(this HtmlHelper html, string script)
        {
            var scripts = Scripts(html);
            scripts.AddInlineScript(script);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, [NotNull, PathReference] string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            var scripts = Scripts(html);
            scripts.AddAsyncScript(path);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, [NotNull, PathReference] string path1, [NotNull, PathReference] string path2)
        {
            if (path1 == null) throw new ArgumentNullException("path1");
            if (path2 == null) throw new ArgumentNullException("path2");
            var scripts = Scripts(html);
            scripts.AddAsyncScript(path1);
            scripts.AddAsyncScript(path2);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, [NotNull, PathReference] string path1, [NotNull, PathReference] string path2, [NotNull, PathReference] string path3)
        {
            if (path1 == null) throw new ArgumentNullException("path1");
            if (path2 == null) throw new ArgumentNullException("path2");
            if (path3 == null) throw new ArgumentNullException("path3");
            var scripts = Scripts(html);
            scripts.AddAsyncScript(path1);
            scripts.AddAsyncScript(path2);
            scripts.AddAsyncScript(path3);
            return string.Empty;
        }

        public static string RequireScriptAsync(this HtmlHelper html, params string[] paths)
        {
            var scripts = Scripts(html);
            foreach (var path in paths)
                scripts.AddAsyncScript(path);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, [NotNull, PathReference] string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            StyleSheets(html).AddStyleSheet(path);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, [NotNull, PathReference] string path1, [NotNull, PathReference] string path2)
        {
            if (path1 == null) throw new ArgumentNullException("path1");
            if (path2 == null) throw new ArgumentNullException("path2");
            var styleSheets = StyleSheets(html);
            styleSheets.AddStyleSheet(path1);
            styleSheets.AddStyleSheet(path2);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, [NotNull, PathReference] string path1, [NotNull, PathReference] string path2, [NotNull, PathReference] string path3)
        {
            if (path1 == null) throw new ArgumentNullException("path1");
            if (path2 == null) throw new ArgumentNullException("path2");
            if (path3 == null) throw new ArgumentNullException("path3");
            var styleSheets = StyleSheets(html);
            styleSheets.AddStyleSheet(path1);
            styleSheets.AddStyleSheet(path2);
            styleSheets.AddStyleSheet(path3);
            return string.Empty;
        }

        public static string RequireStyleSheet(this HtmlHelper html, params string[] paths)
        {
            var styleSheets = StyleSheets(html);
            foreach (var path in paths)
                styleSheets.AddStyleSheet(path);
            return string.Empty;
        }

        public static IHtmlString OutputRequiredScripts(this HtmlHelper html)
        {
            var scripts = Scripts(html);
            var requiredScripts = MvcHtmlString.Create(scripts.Render(html));
            RemoveContainer<Scripts>(html);
            return requiredScripts;
        }

        public static IHtmlString OutputRequiredStyleSheets(this HtmlHelper html)
        {
            var styleSheets = StyleSheets(html);
            var requiredStyleSheets = MvcHtmlString.Create(styleSheets.Render());
            RemoveContainer<StyleSheets>(html);
            return requiredStyleSheets;
        }

        private static Scripts Scripts(HtmlHelper html)
        {
            return GetOrCreateContainer<Scripts>(html);
        }

        private static StyleSheets StyleSheets(HtmlHelper html)
        {
            return GetOrCreateContainer<StyleSheets>(html);
        }

        private static T GetOrCreateContainer<T>(HtmlHelper html)
            where T : class, new()
        {
            var httpContext = html.ViewContext.HttpContext;
            var container = (T) httpContext.Items[typeof (T)] ?? new T();
            httpContext.Items[typeof (T)] = container;
            return container;
        }

        private static T RemoveContainer<T>(HtmlHelper html)
            where T : class, new()
        {
            var httpContext = html.ViewContext.HttpContext;
            httpContext.Items.Remove(typeof (T));
            return null;
        }
    }
}
