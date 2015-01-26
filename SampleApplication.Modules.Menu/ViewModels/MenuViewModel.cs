using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using SampleApplication.Common;
using SampleApplication.Common.Services;
using SampleApplication.PubSubEvents;

namespace SampleApplication.Modules.Menu.ViewModels
{
    /// <summary>
    /// View model for MenuView.xaml.
    /// </summary>
    public class MenuViewModel
    {
        public MenuViewModel(IRegionManager regionManager, ISkinningService skinningService, IEventAggregator eventAggregator)
        {
            State = (State) regionManager.Regions["MenuRegion"].Context;
            _skinningService = skinningService;
            _eventAggregator = eventAggregator;

            ExitApplicationCommand = new DelegateCommand<object>(ExitApplication, CanExitApplication);
            SetSkinCommand = new DelegateCommand<string>(SetSkin, CanSetSkin);
            DuplicateTabCommand = new DelegateCommand<object>(DuplicateTab, CanDuplicateTab);
            CloseOtherTabsCommand = new DelegateCommand<object>(CloseOtherTabs, CanCloseOtherTabs);
            CloseAllTabsCommand = new DelegateCommand<object>(CloseAllTabs, CanCloseAllTabs);
        }
        private readonly ISkinningService _skinningService;
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Gets the application state.
        /// </summary>
        public State State { get; private set; }

        #region File Menu

        /// <summary>
        /// Gets or sets the exit application command.
        /// </summary>
        public ICommand ExitApplicationCommand { get; set; }

        private bool CanExitApplication(object nothing)
        {
            return true;
        }

        private void ExitApplication(object nothing)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region View Menu

        /// <summary>
        /// Gets or sets the set skin command.
        /// </summary>
        public ICommand SetSkinCommand { get; set; }

        private bool CanSetSkin(string skinName)
        {
            return true;
        }

        private void SetSkin(string skinName)
        {
            if (State.SkinName == skinName)
                return;

            State.SkinName = skinName;
            _skinningService.SetSkin(skinName);
        }

        #endregion

        #region Browser Menu

        /// <summary>
        /// Gets or sets the duplicate tab command.
        /// </summary>
        public ICommand DuplicateTabCommand { get; set; }

        private bool CanDuplicateTab(object nothing)
        {
            return true;
        }

        private void DuplicateTab(object nothing)
        {
            _eventAggregator.GetEvent<DuplicateTabEvent>().Publish(State.SelectedTabId);
        }

        /// <summary>
        /// Gets or sets the close other tabs command.
        /// </summary>
        public ICommand CloseOtherTabsCommand { get; set; }

        private bool CanCloseOtherTabs(object nothing)
        {
            return true;
        }

        private void CloseOtherTabs(object nothing)
        {
            _eventAggregator.GetEvent<CloseOtherTabsEvent>().Publish(null);
        }

        /// <summary>
        /// Gets or sets the close all tabs command.
        /// </summary>
        public ICommand CloseAllTabsCommand { get; set; }

        private bool CanCloseAllTabs(object nothing)
        {
            return true;
        }

        private void CloseAllTabs(object nothing)
        {
            _eventAggregator.GetEvent<CloseAllTabsEvent>().Publish(null);
        }

        #endregion
    }
}
