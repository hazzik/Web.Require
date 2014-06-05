using System;
using System.Web.Mvc;

namespace Brandy.Web.Require
{
    internal class Script : IEquatable<Script>, IAsset
    {
        public Script(string source)
        {
            Source = source;
        }

        public string Source { get; private set; }
        public bool Async { get; set; }
        public bool Defererd { get; set; }
        public string Type { get; set; }

        public string Render()
        {
            var tag = new TagBuilder("script");
            tag.Attributes["src"] = Source;
            if (!string.IsNullOrEmpty(Type))
                tag.Attributes["type"] = Type;
            if (Async)
                tag.Attributes["async"] = "async";
            if (Defererd)
                tag.Attributes["defer"] = "defer";
            return tag.ToString();
        }

        public bool Equals(Script script)
        {
            if (ReferenceEquals(null, script)) return false;
            if (ReferenceEquals(this, script)) return true;
            return script.Source == Source;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Script);
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode();
        }
    }
}
