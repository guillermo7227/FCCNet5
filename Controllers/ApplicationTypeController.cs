using System.Collections.Generic;
using FCCNet5.Data;
using FCCNet5.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCCNet5.Controllers
{
    public class ApplicationTypeController : BaseControllerClass
    {
        public ApplicationTypeController(ApplicationDbContext db) : base(db)
        {}

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationTypes;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(ApplicationType obj)
        {
            if (ModelState.IsValid) 
            {
                _db.ApplicationTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", obj);
        }

        public IActionResult Edit(int? id)
        {
            var obj = _db.ApplicationTypes.Find(id);
            if(obj==null) return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if(ModelState.IsValid) {
                _db.ApplicationTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.ApplicationTypes.Find(id);
            if(obj==null) return NotFound();

            _db.ApplicationTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}