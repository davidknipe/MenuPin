using EPiServer.Shell.Web;
using EPiServer.Shell.Web.Mvc;
using MenuPin.Interface;
using System.Web.Mvc;

namespace MenuPin
{
    public class CustomBootStrapper : EPiServer.Shell.UI.Bootstrapper, EPiServer.Shell.Web.Mvc.IBootstrapper
    {
        private IMenuPinnedSelector _menuPinnedSelector;
        public CustomBootStrapper(IMenuPinnedSelector MenuPinnedSelector) 
        {
            _menuPinnedSelector = MenuPinnedSelector;
        }

        string EPiServer.Shell.Web.Mvc.IBootstrapper.BootstrapperViewName
        {
            get { return base.BootstrapperViewName; }
        }

        BootstrapperViewModel EPiServer.Shell.Web.Mvc.IBootstrapper.CreateViewModel(string viewName, ControllerContext context, string moduleName)
        {
            BootstrapperViewModel model = base.CreateViewModel(viewName, context, moduleName);
            if (_menuPinnedSelector.IsMenuPinned(context.RequestContext.HttpContext.Request.RawUrl))
            {
                model.GlobalNavigationMenuType = GlobalNavigationMenuType.Static;
            }
            return model;
        }
    }
}
