namespace Brandy.Web.Require
{
    using System.Collections.Generic;
    using System.Text;

    internal class AssetBase
    {
        private readonly ISet<string> assets = new HashSet<string>();
        private readonly string format;

        public AssetBase(string format)
        {
            this.format = format;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string asset in assets)
                sb.AppendFormat(format, asset);
            return sb.ToString();
        }

        public void Add(string asset)
        {
            assets.Add(asset);
        }
    }
}