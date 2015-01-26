using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using SampleApplication.PubSubEvents;

namespace SampleApplication.Modules.Sidebar.ViewModels
{
    public class SidebarViewModel
    {
        public SidebarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            AddModuleATabCommand = new DelegateCommand<object>(AddModuleATab, CanAddModuleATab);
            AddModuleBTabCommand = new DelegateCommand<object>(AddModuleBTab, CanAddModuleBTab);
            AddModuleCTabCommand = new DelegateCommand<object>(AddModuleCTab, CanAddModuleCTab);
        }
        private readonly IEventAggregator _eventAggregator;

        public ICommand AddModuleATabCommand { get; set; }

        private bool CanAddModuleATab(object nothing)
        {
            return true;
        }

        private void AddModuleATab(object nothing)
        {
            _eventAggregator.GetEvent<NewModuleATabEvent>().Publish(null);
        }

        public ICommand AddModuleBTabCommand { get; set; }

        private bool CanAddModuleBTab(object nothing)
        {
            return true;
        }

        private void AddModuleBTab(object nothing)
        {
            _eventAggregator.GetEvent<NewModuleBTabEvent>().Publish(null);
        }

        public ICommand AddModuleCTabCommand { get; set; }

        private bool CanAddModuleCTab(object nothing)
        {
            return true;
        }

        private void AddModuleCTab(object nothing)
        {
            _eventAggregator.GetEvent<NewModuleCTabEvent>().Publish(null);
        }
    }
}
