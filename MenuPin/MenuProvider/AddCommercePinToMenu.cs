using EPiServer.ServiceLocation;
using EPiServer.Shell.Navigation;
using System.Collections.Generic;

namespace MenuPin.MenuProvider
{
    [MenuProvider]
    public class AddCommercePinToMenu : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var pinMenuItemCommerce = new UrlMenuItem(
                            "<span class=\"epi-iconPin menuPinButton\"></span>", 
                            "/global/commerce/catalog",
                            "javascript: return;"
                            );
            pinMenuItemCommerce.Alignment = MenuItemAlignment.Right;

            return new List<MenuItem>() { pinMenuItemCommerce }; 
        }
    }
}
