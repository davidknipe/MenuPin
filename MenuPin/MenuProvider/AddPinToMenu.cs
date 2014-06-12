using EPiServer.Configuration;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Navigation;
using MenuPin.Impl;
using MenuPin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Shell.Web.UI;

namespace MenuPin.MenuProvider
{
    [MenuProvider]
    public class AddPinToMenu : IMenuProvider
    {
        private IServiceLocator _serviceLocator;
        public AddPinToMenu(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            var uiUrl = EPiServer.Configuration.Settings.Instance.UIUrl.OriginalString.TrimStart("~".ToCharArray()).TrimEnd("/".ToCharArray());

            var pinMenuItemCMS = new PinMenuItem(
                            "<span class=\"epi-iconPin\"></span>", 
                            "/global/cms/edit",
                            "javascript: if (dojo.cookie('menupin') == 'true') { dojo.cookie('menupin', 'false', { path: '/' }); } else { dojo.cookie('menupin', 'true', { expires: 365, path: '/' }); } ; document.location.reload(true);",
                            uiUrl
                            );
            pinMenuItemCMS.Alignment = MenuItemAlignment.Right;

            return new List<MenuItem>() { pinMenuItemCMS };
        }
    }
}
