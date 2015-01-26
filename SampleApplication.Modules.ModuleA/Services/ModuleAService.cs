using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.PubSubEvents;
using SampleApplication.Controls;
using SampleApplication.Modules.ModuleA.ViewModels;
using SampleApplication.Modules.ModuleA.Views;
using SampleApplication.PubSubEvents;

namespace SampleApplication.Modules.ModuleA.Services
{
    public class ModuleAService : IModuleAService
    {
        public ModuleAService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _tabs = new List<Tab>();

            // Subscribe to events
            _eventAggregator.GetEvent<NewModuleATabEvent>().Subscribe(NewModuleATab);
            _eventAggregator.GetEvent<DuplicateTabEvent>().Subscribe(DuplicateModuleATab);
        }
        private readonly IEventAggregator _eventAggregator;
        private readonly List<Tab> _tabs;

        public void NewModuleATab(object nothing)
        {
            NewModuleATab();
        }

        public void NewModuleATab()
        {
            var moduleAViewModel = new ModuleAViewModel();
            var moduleAView = new ModuleAView(moduleAViewModel);
            var moduleATab = new Tab
            {
                Header = "Module A",
                Content = moduleAView
            };

            _tabs.Add(moduleATab);
            _eventAggregator.GetEvent<AddTabEvent>().Publish(moduleATab);
        }

        public void DuplicateModuleATab(Guid tabId)
        {
            var existingTab = _tabs.FirstOrDefault(tab => tab.Id == tabId);
            if (existingTab == null)
                return;

            var moduleAViewModel = new ModuleAViewModel();
            var moduleAView = new ModuleAView(moduleAViewModel);
            var moduleATab = new Tab
            {
                Header = "Module A Copy",
                Content = moduleAView
            };

            _tabs.Add(moduleATab);
            _eventAggregator.GetEvent<AddTabEvent>().Publish(moduleATab);
        }
    }
}
