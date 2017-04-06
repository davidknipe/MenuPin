using System.Web.Mvc;
using EPiServer.Framework.Modules;
using EPiServer.ServiceLocation;

namespace MenuPin.Attributes
{
    public class InsertMenuPinForFindActionFilterAttribute : OutputProcessorActionFilterAttribute
    {
        protected override string Process(string data)
        {
            var moduleResourceResolver = ServiceLocator.Current.GetInstance<IModuleResourceResolver>();
            var menuPinUrl = moduleResourceResolver.ResolveClientPath("MenuPin", "Scripts/MenuPin/MenuPinForFind.js");

            return data
                .Replace("\"dojo/parser\"", "\"dojo/parser\" ,\"" + menuPinUrl + "\"")
                .Replace("parser.parse();", "parser.parse(); var menuPinInit = new MenuPin(); menuPinInit.initialize();")
                .Replace("parser)", "parser, MenuPin)");
        }

        protected override bool ShouldProcess(ResultExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResultBase;
            if (result != null && result.ViewName.Equals("FindBootstrapper"))
            {
                return true;
            }
            return false;
        }
    }
}