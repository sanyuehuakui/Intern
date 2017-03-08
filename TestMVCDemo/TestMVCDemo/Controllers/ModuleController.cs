using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestMVCDemo.Models.EntityData;
using TestMVCDemo.Sevices;

namespace TestMVCDemo.Controllers
{
    public class ModuleController : Controller
    {
        private IModuleService modulesvc; 
        
        public ModuleController()
        {
            modulesvc = new ModuleService();
        }
        // GET: Module
        public ActionResult Index()
        {
            return View(modulesvc .GetAllModules ());
        }


        // GET: Module/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Module/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleId,ModuleCode,ModuleName,Status")] Module module)
        {
            if (ModelState.IsValid)
            {
                modulesvc.CreateModule(module);
                return RedirectToAction("Index");
            }

            return View(module);
        }

        // GET: Module/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = modulesvc.GetModuleById(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Module/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleId,ModuleCode,ModuleName,Status,CreateDate,CreateBy")] Module module)
        {
            if (ModelState.IsValid)
            {
                modulesvc.UpdateModule(module);
                return RedirectToAction("Index");
            }
            return View(module);
        }

        // GET: Module/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
