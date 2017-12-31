using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using theWebApp.Modes;

namespace theWebApp.Controllers
{
    public class ATestEntitiesController : Controller
    {
        private ATestEntityDBContext db = new ATestEntityDBContext();

        // GET: ATestEntities
        public ActionResult Index()
        {
            return View(db.entities.ToList());
        }

        // GET: ATestEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATestEntity aTestEntity = db.entities.Find(id);
            if (aTestEntity == null)
            {
                return HttpNotFound();
            }
            return View(aTestEntity);
        }

        // GET: ATestEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ATestEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DateTime")] ATestEntity aTestEntity)
        {
            if (ModelState.IsValid)
            {
                db.entities.Add(aTestEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aTestEntity);
        }

        // GET: ATestEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATestEntity aTestEntity = db.entities.Find(id);
            if (aTestEntity == null)
            {
                return HttpNotFound();
            }
            return View(aTestEntity);
        }

        // POST: ATestEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DateTime")] ATestEntity aTestEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTestEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aTestEntity);
        }

        // GET: ATestEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATestEntity aTestEntity = db.entities.Find(id);
            if (aTestEntity == null)
            {
                return HttpNotFound();
            }
            return View(aTestEntity);
        }

        // POST: ATestEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATestEntity aTestEntity = db.entities.Find(id);
            db.entities.Remove(aTestEntity);
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
