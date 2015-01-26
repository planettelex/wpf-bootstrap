using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using SampleApplication.Modules.ModuleA.Services;
using SampleApplication.PubSubEvents;

namespace SampleApplication.Modules.ModuleA
{
    [Module(ModuleName = "ModuleAModule")]
    public class ModuleAModule : IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleAModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ModuleAModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
        }
        private readonly IUnityContainer _container;
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            // Register services this module provides
            _container.RegisterType<IModuleAService, ModuleAService>(new ContainerControlledLifetimeManager());
            _container.Resolve(typeof(IModuleAService));

            // Create an initial module A tab
            _eventAggregator.GetEvent<NewModuleATabEvent>().Publish(null);
        }
    }
}
