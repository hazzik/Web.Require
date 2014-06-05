using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Brandy.Web.Require
{
    internal class Scripts
    {
        private readonly ISet<Script> loadedScripts = new HashSet<Script>();
        private readonly ICollection<Script> scripts = new HashSet<Script>();
        private readonly ICollection<InlineContent> inlineScripts = new HashSet<InlineContent>();

        public void AddAsyncScript(string asset)
        {
            var script = new Script(asset);
            if (!scripts.Contains(script))
                loadedScripts.Add(script);
        }

        public void AddScript(string source)
        {
            var script = new Script(source) { Type = "text/javascript" };
            if (!loadedScripts.Contains(script))
                scripts.Add(script);
        }

        public void AddInlineScript(string script)
        {
            inlineScripts.Add(new InlineContent(script));
        }

        public string Render(HtmlHelper html)
        {
            var sb = new StringBuilder();
            foreach (var script in scripts)
                sb.Append(script.Render());
            foreach (var script in inlineScripts)
                sb.Append(script.Render());

            if (loadedScripts.Count > 0)
            {
                var url = new UrlHelper(html.ViewContext.RequestContext);

                var @join = string.Join(", ", loadedScripts.Select(x => string.Format("'{0}'", x.Source)));

                sb.AppendFormat(@"<script src=""{0}"" type=""text/javascript""></script>
<script type=""text/javascript"">(function (){{ 
    var hr = (jQuery || {{}}).holdReady || function (b){{}}; 
    hr(true); 
    head.js({1}, function (){{ 
        hr(false); 
    }})
}})();
</script>", url.Content("~/Scripts/head.load.min.js"), @join);
            }

            return sb.ToString();
        }
    }
}
