using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Web.Mvc;
using MenuPin.Impl;
using MenuPin.Interface;
using System.Web.Mvc;

namespace MenuPin.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    [ModuleDependency(typeof(EPiServer.Shell.ShellInitialization))]
    public class MenuPinInit : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(x => { x.For<EPiServer.Shell.Web.Mvc.IBootstrapper>().Use<CustomBootStrapper>(); });
            context.Container.Configure(x => { x.For<IMenuPinnedSelector>().Use<MenuPinnedSelector>(); });
        }

        public void Initialize(InitializationEngine context) { }

        public void Uninitialize(InitializationEngine context) { }

        public void Preload(string[] parameters) { }
    }
}