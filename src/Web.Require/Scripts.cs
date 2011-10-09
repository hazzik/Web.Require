namespace Brandy.Web.Require
{
    internal class Scripts : AssetBase
    {
        public Scripts()
            : base(@"<script src=""{0}"" type=""text/javascript""></script>")
        {
        }
    }
}