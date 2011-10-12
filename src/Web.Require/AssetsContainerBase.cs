namespace Brandy.Web.Require
{
    using System.Collections.Generic;
    using System.Text;

    internal abstract class AssetsContainerBase : IAssetsContainer
    {
        protected readonly ISet<string> Assets = new HashSet<string>();
        private readonly string format;

        protected AssetsContainerBase(string format)
        {
            this.format = format;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string asset in Assets)
                sb.AppendFormat(format, asset);
            return sb.ToString();
        }

        public void Add(string asset)
        {
            Assets.Add(asset);
        }

        public bool Contains(string asset)
        {
            return Assets.Contains(asset);
        }
    }
}