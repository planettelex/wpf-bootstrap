using System;
using System.Windows.Controls;

namespace SampleApplication.Controls
{
    /// <summary>
    /// A shell docking control tab.
    /// </summary>
    public class Tab
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tab"/> class.
        /// </summary>
        public Tab()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets or sets the tab header.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the tab content.
        /// </summary>
        public UserControl Content { get; set; }
    }
}
