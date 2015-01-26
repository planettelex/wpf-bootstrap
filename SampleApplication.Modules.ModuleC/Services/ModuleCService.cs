using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.PubSubEvents;
using SampleApplication.Controls;
using SampleApplication.Modules.ModuleC.ViewModels;
using SampleApplication.Modules.ModuleC.Views;
using SampleApplication.PubSubEvents;

namespace SampleApplication.Modules.ModuleC.Services
{
    public class ModuleCService : IModuleCService
    {
        public ModuleCService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _tabs = new List<Tab>();

            // Subscribe to events
            _eventAggregator.GetEvent<NewModuleCTabEvent>().Subscribe(NewModuleCTab);
            _eventAggregator.GetEvent<DuplicateTabEvent>().Subscribe(DuplicateModuleCTab);
        }
        private readonly IEventAggregator _eventAggregator;
        private readonly List<Tab> _tabs;

        public void NewModuleCTab(object nothing)
        {
            NewModuleCTab();
        }

        public void NewModuleCTab()
        {
            var moduleCViewModel = new ModuleCViewModel();
            var moduleCView = new ModuleCView(moduleCViewModel);
            var moduleCTab = new Tab
            {
                Header = "Module C",
                Content = moduleCView
            };

            _tabs.Add(moduleCTab);
            _eventAggregator.GetEvent<AddTabEvent>().Publish(moduleCTab);
        }

        public void DuplicateModuleCTab(Guid tabId)
        {
            var existingTab = _tabs.FirstOrDefault(tab => tab.Id == tabId);
            if (existingTab == null)
                return;

            var moduleCViewModel = new ModuleCViewModel();
            var moduleCView = new ModuleCView(moduleCViewModel);
            var moduleCTab = new Tab
            {
                Header = "Module C Copy",
                Content = moduleCView
            };

            _tabs.Add(moduleCTab);
            _eventAggregator.GetEvent<AddTabEvent>().Publish(moduleCTab);
        }
    }
}
