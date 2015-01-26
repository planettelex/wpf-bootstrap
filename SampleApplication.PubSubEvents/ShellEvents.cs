using System;
using Microsoft.Practices.Prism.PubSubEvents;
using SampleApplication.Controls;

namespace SampleApplication.PubSubEvents
{
    /// <summary>
    /// Add the passed user control to the shell as a new tab.
    /// </summary>
    public class AddTabEvent : PubSubEvent<Tab> { }

    /// <summary>
    /// Create a new module A control and pass it to the <see cref="AddTabEvent"/>.
    /// </summary>
    public class NewModuleATabEvent : PubSubEvent<object> { }

    /// <summary>
    /// Create a new module B control and pass it to the <see cref="AddTabEvent"/>.
    /// </summary>
    public class NewModuleBTabEvent : PubSubEvent<object> { }

    /// <summary>
    /// Create a new module C control and pass it to the <see cref="AddTabEvent"/>.
    /// </summary>
    public class NewModuleCTabEvent : PubSubEvent<object> { }

    /// <summary>
    /// Duplicates the currently active tab.
    /// </summary>
    public class DuplicateTabEvent : PubSubEvent<Guid> { }

    /// <summary>
    /// Closes all tabs.
    /// </summary>
    public class CloseAllTabsEvent : PubSubEvent<object> { }

    /// <summary>
    /// Close all tabs except the currently active tab.
    /// </summary>
    public class CloseOtherTabsEvent : PubSubEvent<object> { }
    
}
