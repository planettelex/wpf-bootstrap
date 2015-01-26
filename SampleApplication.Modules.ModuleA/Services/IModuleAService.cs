using System;

namespace SampleApplication.Modules.ModuleA.Services
{
    public interface IModuleAService
    {
        void NewModuleATab();

        void DuplicateModuleATab(Guid tabId);
    }
}
