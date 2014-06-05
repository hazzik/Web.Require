using System;

namespace Brandy.Web.Require
{
    internal class InlineContent : IEquatable<InlineContent>, IAsset
    {
        public InlineContent(string content)
        {
            Content = content;
        }

        public string Render()
        {
            return Content;
        }

        public string Content { get; private set; }

        public bool Equals(InlineContent obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.Content == Content;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as InlineContent);
        }

        public override int GetHashCode()
        {
            return Content.GetHashCode();
        }
    }
}
