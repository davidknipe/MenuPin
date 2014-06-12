using MenuPin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MenuPin.Impl
{
    public class MenuPinnedSelector : IMenuPinnedSelector
    {
        private HttpContextBase _httpContext;

        public MenuPinnedSelector(HttpContextBase context)
        {
            this._httpContext = context;
        }

        public bool IsMenuPinned(string associatedUIUrl)
        {
            var urlWithOutSlash = associatedUIUrl.TrimStart("~".ToCharArray()).TrimEnd("/".ToCharArray()).ToLower();
            var urlWithSlash = urlWithOutSlash + "/";
            var rawUrl = _httpContext.Request.RawUrl.ToLower();

            //Only show as selected if we are looking at a URL that supports the pull down menu
            if (rawUrl.Equals(urlWithOutSlash) || rawUrl.Equals(urlWithSlash))
            {
                return this.IsMenuPinned();
            }
            else
            {
                return false;
            }
        }
        private bool IsMenuPinned()
        {
            return _httpContext.Request.Cookies["menupin"] != null && _httpContext.Request.Cookies["menupin"].Value == "true";
        }
    }
}
