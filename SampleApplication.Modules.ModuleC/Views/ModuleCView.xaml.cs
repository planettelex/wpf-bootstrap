using SampleApplication.Modules.ModuleC.ViewModels;

namespace SampleApplication.Modules.ModuleC.Views
{
    /// <summary>
    /// Interaction logic for ModuleCView.xaml
    /// </summary>
    public partial class ModuleCView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleCView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ModuleCView(ModuleCViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
