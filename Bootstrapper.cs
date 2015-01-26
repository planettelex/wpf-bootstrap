using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using SampleApplication.Common.Services;
using SampleApplication.Modules.Menu;
using SampleApplication.Modules.ModuleA;
using SampleApplication.Modules.ModuleB;
using SampleApplication.Modules.ModuleC;
using SampleApplication.Modules.Sidebar;

namespace SampleApplication
{
    /// <summary>
    /// The bootstrapper initializes the application and resolves dependencies.
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        /// <remarks>
        /// If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        /// <see cref="T:Microsoft.Practices.Prism.Bootstrapper" /> will attach the default <see cref="T:Microsoft.Practices.Prism.Regions.IRegionManager" /> of
        /// the application in its <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty" /> attached property
        /// in order to be able to add regions by using the <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionNameProperty" />
        /// attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            InjectServices();
            return Container.Resolve<Shell>();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof (MenuModule));
            moduleCatalog.AddModule(typeof (SidebarModule));
            moduleCatalog.AddModule(typeof (ModuleAModule));
            moduleCatalog.AddModule(typeof (ModuleBModule));
            moduleCatalog.AddModule(typeof (ModuleCModule));
        }

        /// <summary>
        /// Injects the services into the DI container.
        /// </summary>
        protected void InjectServices()
        {
            Container.RegisterType<ISkinningService, SkinningService>(new ContainerControlledLifetimeManager());
            Container.Resolve<ISkinningService>();
        }
    }
}
