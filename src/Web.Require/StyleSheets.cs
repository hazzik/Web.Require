using System.Collections.Generic;
using System.Text;

namespace Brandy.Web.Require
{
    internal class StyleSheets
    {
        private readonly ISet<StyleSheet> styleSheets = new HashSet<StyleSheet>();
        private readonly ISet<InlineContent> inline = new HashSet<InlineContent>();

        public void AddStyleSheet(string styleshit)
        {
            styleSheets.Add(new StyleSheet(styleshit));
        }

        public void AddInlineStyleSheet(string styleshit)
        {
            styleSheets.Add(new StyleSheet(styleshit));
        }

        public string Render()
        {
            var sb = new StringBuilder();
            foreach (var sheet in styleSheets)
                sb.Append(sheet.Render());
            foreach (var content in inline)
                sb.Append(content.Render());
            return sb.ToString();
        }
    }
}
