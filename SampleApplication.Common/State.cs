using System;
using Microsoft.Practices.Prism.Mvvm;

namespace SampleApplication.Common
{
    /// <summary>
    /// Encapsulates the state of the application.
    /// </summary>
    public class State : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State()
        {
            _selectedTabId = Properties.Settings.Default.SelectedTabId;
            _skinName = Properties.Settings.Default.SkinName;

            HasTabs = true;
        }

        /// <summary>
        /// Gets or sets the selected tab identifier.
        /// </summary>
        public Guid SelectedTabId
        {
            get { return _selectedTabId; }
            set
            {
                _selectedTabId = value;
                Properties.Settings.Default.SelectedTabId = _selectedTabId;
                HasTabs = _selectedTabId != Guid.Empty;
            }
        }
        private Guid _selectedTabId;

        /// <summary>
        /// Gets or sets the skin name.
        /// </summary>
        public string SkinName
        {
            get { return _skinName; }
            set
            {
                _skinName = value;
                Properties.Settings.Default.SkinName = _skinName;
            }
        }
        private string _skinName;

        /// <summary>
        /// Gets or sets a value indicating whether the applications has tabs.
        /// </summary>
        public bool HasTabs
        {
            get { return _hasTabs; }
            set { SetProperty(ref _hasTabs, value); }
        }
        private bool _hasTabs;

        /// <summary>
        /// Saves the state to the default user settings.
        /// </summary>
        public void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
