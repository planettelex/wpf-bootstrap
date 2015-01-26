using SampleApplication.Modules.Sidebar.ViewModels;

namespace SampleApplication.Modules.Sidebar.Views
{
    /// <summary>
    /// Interaction logic for SidebarView.xaml
    /// </summary>
    public partial class SidebarView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SidebarView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public SidebarView(SidebarViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
