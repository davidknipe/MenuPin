using System;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using MenuPin.Attributes;

namespace MenuPin.Init
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class MenuPinFilterConfigInit : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (IsFindInstalled())
            {
                GlobalFilters.Filters.Add(ServiceLocator.Current.GetInstance<InsertMenuPinForFindActionFilterAttribute>());
            }
        }

        public void Uninitialize(InitializationEngine context) { }

        private bool IsFindInstalled()
        {
            // Work out if Find is installed 
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var assembly = (from a in assemblies
                            where a.FullName.StartsWith("EPiServer.Find")
                            select a).FirstOrDefault();

            return assembly != null;
        }
    }
}