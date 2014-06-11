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
        public bool IsMenuPinned(string associatedUIUrl)
        {
            //Only show as selected if we are looking at a URL that supports the pull down menu
            if (HttpContext.Current.Request.RawUrl.ToLower().Equals(associatedUIUrl.ToLower()))
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
            return HttpContext.Current.Request.Cookies["menupin"] != null && HttpContext.Current.Request.Cookies["menupin"].Value == "true";
        }
    }
}
