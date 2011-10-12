namespace Brandy.Web.Require
{
    internal interface IAssetsContainer
    {
        void Add(string asset);
        bool Contains(string asset);
    }
}