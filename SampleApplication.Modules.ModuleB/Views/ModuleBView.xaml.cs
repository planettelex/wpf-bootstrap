using SampleApplication.Modules.ModuleB.ViewModels;

namespace SampleApplication.Modules.ModuleB.Views
{
    /// <summary>
    /// Interaction logic for ModuleBView.xaml
    /// </summary>
    public partial class ModuleBView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ModuleBView(ModuleBViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
