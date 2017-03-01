using System.Web.Mvc;
using EPiServer.Configuration;

namespace MenuPin.Attributes
{
    public class InsertMenuPinForFindActionFilterAttribute : OutputProcessorActionFilterAttribute
    {
        protected override string Process(string data)
        {
            string epiUrlSegment;
            if (Settings.Instance.UIUrl.IsAbsoluteUri)
            {
                epiUrlSegment = Settings.Instance.UIUrl.Segments[1].TrimEnd("/".ToCharArray());
            }
            else
            {
                epiUrlSegment = Settings.Instance.UIUrl.OriginalString.TrimStart("~/".ToCharArray()).TrimEnd("/CMS".ToCharArray());
            }

            var menuPinUrl = "/" + epiUrlSegment + "/MenuPin/ClientResources/Scripts/MenuPin/MenuPinForFind.js";

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