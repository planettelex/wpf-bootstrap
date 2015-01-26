using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Modules.ModuleB.Services
{
    public interface IModuleBService
    {
        void NewModuleBTab();

        void DuplicateModuleBTab(Guid tabId);
    }
}
