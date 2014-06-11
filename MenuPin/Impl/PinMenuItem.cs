using EPiServer.ServiceLocation;
using EPiServer.Shell.Navigation;
using MenuPin.Interface;

namespace MenuPin.Impl
{
    public class PinMenuItem : UrlMenuItem
    {
        private string _associatedUIUrl;
        public PinMenuItem(string text, string path, string url, string associatedUIUrl)
            : base(text, path, url)
        {
            _associatedUIUrl = associatedUIUrl;
        }

        public override bool IsSelected(System.Web.Routing.RequestContext requestContext)
        {
            return ServiceLocator.Current.GetInstance<IMenuPinnedSelector>().IsMenuPinned(_associatedUIUrl);
        }
    }
}
