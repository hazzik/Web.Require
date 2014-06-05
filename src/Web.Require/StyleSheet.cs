using System;
using System.Web.Mvc;

namespace Brandy.Web.Require
{
    internal class StyleSheet : IAsset, IEquatable<StyleSheet>
    {
        public StyleSheet(string link)
        {
            Link = link;
        }

        public string Link { get; private set; }

        public string Render()
        {
            var tag = new TagBuilder("link");
            tag.Attributes["rel"] = "stylesheet";
            tag.Attributes["type"] = "text/css";
            tag.Attributes["href"] = Link;
            return tag.ToString(TagRenderMode.SelfClosing);
        }

        public bool Equals(StyleSheet other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;
            return other.Link == Link;
        }
    }
}