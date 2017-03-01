using System.Collections.Generic;
using EPiServer.Shell.Navigation;

namespace MenuPin.MenuProvider
{
    [MenuProvider]
    public class AddFindPinToMenu : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var pinMenuItemCommerce = new UrlMenuItem(
                            "<span class=\"epi-iconPin menuPinButton\"></span>",
                            "/global/find/Manage",
                            "javascript: return;"
                            );
            pinMenuItemCommerce.Alignment = MenuItemAlignment.Right;

            return new List<MenuItem>() { pinMenuItemCommerce };
        }
    }
}
