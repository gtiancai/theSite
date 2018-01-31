using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using theSite.Models;
using theSite.ViewModels;

namespace theSite.Controllers
{
    public class NewsController : Controller
    {
        private theSiteDBEF db = new theSiteDBEF();

        // GET: News
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.User);
            return View(news.ToList());
        }

        public ActionResult List()
        {
            var news = db.News.Include(n => n.User);
            return View(news.ToList());
            /*
            var news = new News() { ID = 2, CreatedBy = 1, CreatedDateTime = System.DateTime.Now, Detail = "hehe", ModifiedDateTime = DateTime.Now, Summary = "hello", Title = "abc", User = null };
            IList<News> newsList = new List<News>();

            newsList.Add(news);

            return View(newsList);
            */
        }

        // GET: News/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);

            if (news == null)
            {
                return HttpNotFound();
            }
            HtmlDecode(news);

            NewsViewModel newsVM = CreateNewsVMFromNews(news);

            return View(newsVM);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            // ViewBag.CreatedBy = new SelectList(db.Users, "ID", "Name");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        // public ActionResult Create([Bind(Include = "ID,Title,Summary,Detail,CreatedBy,CreatedDateTime,ModifiedDateTime")] News news)
        public ActionResult Create([Bind(Include = "Title, Summary, Detail")] NewsViewModel newsVM)
        {
            if (ModelState.IsValid)
            {
                /*
                News n = CreateCopy2Save(news);
                */

                News news = CreateNewsFromNewsVM(newsVM);
                news.CreatedDateTime = DateTime.UtcNow;

                HtmlEncode(news);

                db.News.Add(news);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // ViewBag.CreatedBy = new SelectList(db.Users, "ID", "Name", news.CreatedBy);
            return View(newsVM);
        }

        // GET: News/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = db.News.Find(id);

            if (news == null)
            {
                return HttpNotFound();
            }

            HtmlDecode(news);


            NewsViewModel newsVM = CreateNewsVMFromNews(news);

            // ViewBag.CreatedBy = new SelectList(db.Users, "ID", "Name", news.CreatedBy);
            return View(newsVM);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        // public ActionResult Edit([Bind(Include = "ID,Title,Summary,Detail,CreatedBy,CreatedDateTime,ModifiedDateTime")] News news)
        public ActionResult Edit([Bind(Include = "ID, Title, Summary, Detail")] NewsViewModel newsVM)
        {
            if (ModelState.IsValid)
            {
                // News n = CreateCopy2Save(news);
                // News news = CreateNewsFromNewsVM(newsVM);
                News news = db.News.Find(newsVM.ID);

                news.Title = newsVM.Title;
                news.Summary = newsVM.Summary;
                news.Detail = newsVM.Detail;
                news.ModifiedDateTime = DateTime.UtcNow;

                HtmlEncode(news);

                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // ViewBag.CreatedBy = new SelectList(db.Users, "ID", "Name", news.CreatedBy);
            return View(newsVM);
        }

        // GET: News/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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

        private News CreateCopy2Save(News news)
        {
            News n = new News()
            {
                ID = news.ID,
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow
            };

            string userName = System.Web.HttpContext.Current.User.Identity.Name;

            User user = db.Users.Where(u => u.Name.Equals(userName)).FirstOrDefault();
            n.CreatedBy = user != null ? user.ID : 0;

            HtmlEncode(n);

            return n;
        }

        private void HtmlEncode(News news)
        {
            news.Title = HttpUtility.HtmlEncode(news.Title);
            news.Summary = HttpUtility.HtmlEncode(news.Summary);
            news.Detail = HttpUtility.HtmlEncode(news.Detail);
        }

        private void HtmlDecode(News news)
        {
            news.Title = HttpUtility.HtmlDecode(news.Title);
            news.Summary = HttpUtility.HtmlDecode(news.Summary);
            news.Detail = HttpUtility.HtmlDecode(news.Detail);
        }

        private NewsViewModel CreateNewsVMFromNews(News news)
        {
            NewsViewModel newsVM = new NewsViewModel()
            {
                ID = news.ID,
                Title = news.Title,
                Summary = news.Summary,
                Detail = news.Detail
            };

            return newsVM;
        }

        private News CreateNewsFromNewsVM(NewsViewModel newsVM)
        {
            News news = new News()
            {
                Title = newsVM.Title,
                Summary = newsVM.Summary,
                Detail = newsVM.Detail,
                // CreatedDateTime = ; // Not change it if do update.
                ModifiedDateTime = DateTime.UtcNow

                , CreatedBy = 1 // remove?
            };

            return news;
        }
    }
}
