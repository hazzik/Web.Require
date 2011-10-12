namespace Brandy.Web.Require
{
    using System.Linq;
    using System.Web.Mvc;

    internal class AsyncScripts : AssetsContainerBase
    {
        public AsyncScripts()
            : base("'{0}', ")
        {
        }

        public string ToString(HtmlHelper html)
        {
            if (Assets.Count == 0)
                return string.Empty;

            var url = new UrlHelper(html.ViewContext.RequestContext);
            
            var scripts = string.Join(", ", Assets.Select(x => string.Format("'{0}'", x)));

            return string.Format(@"<script src=""{0}"" type=""text/javascript""></script>
<script type=""text/javascript"">(function (){{ 
    var hr = (jQuery || {{}}).holdReady || function (b){{}}; 
    hr(true); 
    head.js({1}, function (){{ 
        hr(false); 
    }})
}})();
</script>", url.Content("~/Scripts/head.load.min.js"), scripts);
        }
    }
}