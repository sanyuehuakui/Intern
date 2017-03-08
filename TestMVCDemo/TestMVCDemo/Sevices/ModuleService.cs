using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestMVCDemo.Models.EntityData;

namespace TestMVCDemo.Sevices
{
    public class ModuleService : IModuleService
    {
        private CSADemoDBEntities db = new CSADemoDBEntities();

        public List<Module> GetAllModules()
        {
            return db.Modules.ToList();
        }
        public Module GetModuleById(int? id)
        {

            return db.Modules.Find(id);

        }
        public void CreateModule(Module module)
        {
            module.CreateDate = DateTime.Today;
            module.CreateBy = "Admin";
            db.Modules.Add(module);
            db.SaveChanges();

        }
        public void UpdateModule(Module module)
        {
            module.ModifiedDate = DateTime.Today;
            module.ModifiedBy = "Admin2";
            db.Entry(module).State = EntityState.Modified;
            db.SaveChanges();
        }



    }
}