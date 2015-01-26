using System;

namespace SampleApplication.Modules.ModuleC.Services
{
    public interface IModuleCService
    {
        void NewModuleCTab();

        void DuplicateModuleCTab(Guid tabId);
    }
}
