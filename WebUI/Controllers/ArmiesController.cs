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
    public class ArmiesController : Controller
    {
        private ArmyContext db = new ArmyContext();

        // GET: Armies
        public ActionResult Index()
        {
            return View(db.Armys.ToList());
        }

        // GET: Armies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Army army = db.Armys.Find(id);
            if (army == null)
            {
                return HttpNotFound();
            }
            return View(army);
        }

        // GET: Armies/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Army army)
        {
            if (ModelState.IsValid)
            {
                db.Armys.Add(army);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(army);
        }

        // GET: Armies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Army army = db.Armys.Find(id);
            if (army == null)
            {
                return HttpNotFound();
            }
            return View(army);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Army army)
        {
            if (ModelState.IsValid)
            {
                db.Entry(army).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(army);
        }

        // GET: Armies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Army army = db.Armys.Find(id);
            if (army == null)
            {
                return HttpNotFound();
            }
            return View(army);
        }

        // POST: Armies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Army army = db.Armys.Find(id);
            db.Armys.Remove(army);
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
