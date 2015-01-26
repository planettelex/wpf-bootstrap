using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.PubSubEvents;
using SampleApplication.Controls;
using SampleApplication.Modules.ModuleB.ViewModels;
using SampleApplication.Modules.ModuleB.Views;
using SampleApplication.PubSubEvents;

namespace SampleApplication.Modules.ModuleB.Services
{
    public class ModuleBService : IModuleBService
    {
        public ModuleBService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _tabs = new List<Tab>();

            // Subscribe to events
            _eventAggregator.GetEvent<NewModuleBTabEvent>().Subscribe(NewModuleBTab);
            _eventAggregator.GetEvent<DuplicateTabEvent>().Subscribe(DuplicateModuleBTab);
        }
        private readonly IEventAggregator _eventAggregator;
        private readonly List<Tab> _tabs;

        public void NewModuleBTab(object nothing)
        {
            NewModuleBTab();
        }

        public void NewModuleBTab()
        {
            var moduleBViewModel = new ModuleBViewModel();
            var moduleBView = new ModuleBView(moduleBViewModel);
            var moduleBTab = new Tab
            {
                Header = "Module B",
                Content = moduleBView
            };

            _tabs.Add(moduleBTab);
            _eventAggregator.GetEvent<AddTabEvent>().Publish(moduleBTab);
        }

        public void DuplicateModuleBTab(Guid tabId)
        {
            var existingTab = _tabs.FirstOrDefault(tab => tab.Id == tabId);
            if (existingTab == null)
                return;

            var moduleBViewModel = new ModuleBViewModel();
            var moduleBView = new ModuleBView(moduleBViewModel);
            var moduleBTab = new Tab
            {
                Header = "Module B Copy",
                Content = moduleBView
            };

            _tabs.Add(moduleBTab);
            _eventAggregator.GetEvent<AddTabEvent>().Publish(moduleBTab);
        }
    }
}
