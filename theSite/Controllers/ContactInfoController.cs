using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using theSite.Models;

namespace theSite.Controllers
{
    public class ContactInfoController : Controller
    {
        private theSiteDBEF db = new theSiteDBEF();

        // GET: ContactInfo
        public ActionResult Index()
        {
            return View(db.ContactInfoes.ToList());
        }

        // GET: ContactInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        [ChildActionOnly]
        public PartialViewResult RenderContactInfo()
        {

            ContactInfo contactInfo = db.ContactInfoes.Where(c => c.IsActive == true).FirstOrDefault();
            if (contactInfo == null)
            {
                throw new HttpException(404, "Contact is not found");
            }
            return PartialView("~/Views/ContactInfo/ContactInfo.cshtml", contactInfo);
        }


        // GET: ContactInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Telephone,Email,Wechat,QQ,Site,Fax,ZipCode,Address,IsActive")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                db.ContactInfoes.Add(contactInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactInfo);
        }

        // GET: ContactInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        // POST: ContactInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Telephone,Email,Wechat,QQ,Site,Fax,ZipCode,Address,IsActive")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactInfo);
        }

        // GET: ContactInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        // POST: ContactInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            db.ContactInfoes.Remove(contactInfo);
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
