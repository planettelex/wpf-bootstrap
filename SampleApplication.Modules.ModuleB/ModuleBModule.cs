using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using SampleApplication.Modules.ModuleB.Services;

namespace SampleApplication.Modules.ModuleB
{
    [Module(ModuleName = "ModuleBModule")]
    public class ModuleBModule : IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ModuleBModule(IUnityContainer container)
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
            _container.RegisterType<IModuleBService, ModuleBService>(new ContainerControlledLifetimeManager());
            _container.Resolve(typeof(IModuleBService));
        }
    }
}
