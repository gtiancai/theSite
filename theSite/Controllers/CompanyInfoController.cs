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
    public class CompanyInfoController : Controller
    {
        private theSiteDBEF db = new theSiteDBEF();

        // GET: CompanyInfo
        public ActionResult Index()
        {
            return View(db.CompanyInfoes.ToList());
        }

        // GET: CompanyInfo/Details/5
        public ActionResult Details()
        {
            CompanyInfo companyInfo = db.CompanyInfoes.FirstOrDefault();

            if (companyInfo == null)
            {
                return HttpNotFound();
            }

            return View(companyInfo);
        }

        // GET: CompanyInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Logo,Vision,Email,Phone,Address,CompanyCultureDesc,ID")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                db.CompanyInfoes.Add(companyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyInfo);
        }

        // GET: CompanyInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = db.CompanyInfoes.Find(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Logo,Vision,Email,Phone,Address,CompanyCultureDesc,ID")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyInfo);
        }

        // GET: CompanyInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = db.CompanyInfoes.Find(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyInfo companyInfo = db.CompanyInfoes.Find(id);
            db.CompanyInfoes.Remove(companyInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// just render as a partial code for main layout
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult RenderLogoBar()
        {
            // var companyInfo = db.CompanyInfoes.FirstOrDefault();
            var companyInfo = new CompanyInfo
            {
                Name = "Site01",
                Address = "site address",
                CompanyCultureDesc = "Company culture descripion",
                Email = "gtianshu@163.com",
                ID = 1,
                Logo = @"Resources\img\logo.png",
                Phone = "12345679",
                Vision = "Vision is xxxxx"
            };

            if (companyInfo == null)
            {
                throw new HttpException(404, "Site not found");
            }

            // Have to give it full name with extension .cshtml!!
            return PartialView("~/Views/CompanyInfo/LogoBar.cshtml", companyInfo);
            // return PartialView("~/Views/CompanyInfo/RenderLogoBar.cshtml", companyInfo);
        }

        /*
         * use such a ActionResult method will lead to stack overflow to recurely call this method and render view!!!
        [ChildActionOnly]
        public ActionResult RenderLogoBar()
        {
            var companyInfo = db.CompanyInfoes.FirstOrDefault();
            return View(companyInfo);
        }
        */

        [ChildActionOnly]
        public PartialViewResult RenderSiteName()
        {
            // var companyInfo = db.CompanyInfoes.FirstOrDefault();
            var companyInfo = new CompanyInfo {
                Name = "Site01"
                , Address = "site address"
                , CompanyCultureDesc = "Company culture descripion"
                , Email = "gtianshu@163.com"
                , ID = 1
                , Logo = @"Resources\img\logo.png"
                , Phone = "12345679"
                , Vision = "Vision is xxxxx"
            };

            if (companyInfo == null)
            {
                throw new HttpException(404, "Site not found");
            }

            return PartialView("~/Views/CompanyInfo/SiteName.cshtml", companyInfo);
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
