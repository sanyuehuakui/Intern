using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCDemo.Models.EntityData;

namespace TestMVCDemo.Sevices
{
    interface IModuleService
    {
        List<Module> GetAllModules();
        void CreateModule(Module module);
        Module GetModuleById(int? id);
        void UpdateModule(Module module);
        void DeleteModule(int? id);
    }
}
