using SampleApplication.Modules.ModuleA.ViewModels;

namespace SampleApplication.Modules.ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ModuleAView.xaml
    /// </summary>
    public partial class ModuleAView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleAView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ModuleAView(ModuleAViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
