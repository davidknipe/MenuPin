using EPiServer.ServiceLocation;
using EPiServer.Shell.Navigation;
using System.Collections.Generic;

namespace MenuPin.MenuProvider
{
    [MenuProvider]
    public class AddPinToMenu : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var pinMenuItemCms = new UrlMenuItem(
                            "<span class=\"epi-iconPin menuPinButton\"></span>", 
                            "/global/cms/edit",
                            "javascript: return;"
                            );
            pinMenuItemCms.Alignment = MenuItemAlignment.Right;

            return new List<MenuItem>() { pinMenuItemCms };
        }
    }
}
