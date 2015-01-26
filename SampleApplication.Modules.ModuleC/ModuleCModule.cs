using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using SampleApplication.Modules.ModuleC.Services;

namespace SampleApplication.Modules.ModuleC
{
    [Module(ModuleName = "ModuleCModule")]
    public class ModuleCModule : IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleCModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ModuleCModule(IUnityContainer container)
        {
            _container = container;
        }
        private readonly IUnityContainer _container;

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            // Register services this module provides
            _container.RegisterType<IModuleCService, ModuleCService>(new ContainerControlledLifetimeManager());
            _container.Resolve(typeof(IModuleCService));
        }
    }
}
