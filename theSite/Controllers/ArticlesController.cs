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
    public class ArticlesController : Controller
    {
        IList<Article> articles = new List<Article>()
        {
            new Article()
            {
                ArticleID = 1,
                AuthorName = "TC",
                CategoryID = 2,
                Content = "abcdefg",
                PostTime = DateTime.UtcNow,
                Title = "article"
            }
        };

        // GET: Articles
        public ActionResult Index()
        {
            return View(articles);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = articles.FirstOrDefault();
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ArticleID,CategoryID,Title,Content,AuthorName,PostTime")] Article article)
        {
            if (ModelState.IsValid)
            {
                Article a = articles.FirstOrDefault();
                a.Content = article.Content;
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = articles.FirstOrDefault();
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ArticleID,CategoryID,Title,Content,AuthorName,PostTime")] Article article)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(article).State = EntityState.Modified;
                // db.SaveChanges();
                Article a = articles.FirstOrDefault();
                a.Content = article.Content;

                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = articles.FirstOrDefault();
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            */
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
