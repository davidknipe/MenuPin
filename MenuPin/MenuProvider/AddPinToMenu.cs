using EPiServer.ServiceLocation;
using EPiServer.Shell.Navigation;
using System.Collections.Generic;

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

            var pinMenuItemCMS = new UrlMenuItem(
                            "<span class=\"epi-iconPin\" id=\"menuPin\"></span>", 
                            "/global/cms/edit",
                            "javascript: return;"
                            );
            pinMenuItemCMS.Alignment = MenuItemAlignment.Right;

            return new List<MenuItem>() { pinMenuItemCMS };
        }
    }
}
