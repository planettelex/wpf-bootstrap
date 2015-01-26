using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using SampleApplication.Modules.Sidebar.Views;

namespace SampleApplication.Modules.Sidebar
{
    public class SidebarModule : IModule
    {
        public SidebarModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        private readonly IRegionManager _regionManager;

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("SidebarRegion", typeof(SidebarView));
        }
    }
}
