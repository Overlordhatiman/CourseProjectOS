using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebUI.DBEntities;

namespace WebUI.Controllers
{
    [Authorize]
    public class TypesController : Controller
    {
        private ArmyContext db = new ArmyContext();

        // GET: Types
        public ActionResult Index()
        {
            var types = db.Types.Include(t => t.Army);
            return View(types.ToList());
        }

        // GET: Types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUI.DBEntities.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // GET: Types/Create
        public ActionResult Create()
        {
            ViewBag.ArmyId = new SelectList(db.Armys, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Count,ArmyId")] WebUI.DBEntities.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArmyId = new SelectList(db.Armys, "Id", "Name", type.ArmyId);
            return View(type);
        }

        // GET: Types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUI.DBEntities.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArmyId = new SelectList(db.Armys, "Id", "Name", type.ArmyId);
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Count,ArmyId")]  WebUI.DBEntities.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArmyId = new SelectList(db.Armys, "Id", "Name", type.ArmyId);
            return View(type);
        }

        // GET: Types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUI.DBEntities.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebUI.DBEntities.Type type = db.Types.Find(id);
            db.Types.Remove(type);
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
