using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace theWebApp.Controllers
{
    [Route("TestName")]
    public class ATestController : Controller
    {
        // GET: ATest
        public string Index()
        {
            // return View();
            return "This is my <b>default</b> action...";

            /* souce code on page: just one line (no header/body...)
             
              This is my <b>default</b> action...
             */
        }

        public string Welcome(string name)
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Hello, Welcome {0}!", name);
        }

        // To bind an action to a view
        //    1. Add a folder under Views named with controler name (without controller)
        //    2. Add a .cshtml file named with the action name (exact same with action name)
        public ActionResult ATestView()
        {
            ViewBag.Title = "Hello, TestViewBag";

            ViewBag.xxxx = "Hello, viewBag.xxxx!";

            ViewBag.Title += ViewBag.TTCC;

            return View("abc"); // without respective view page, this call will get exception that explains view is not found.
        }
        /*
         * The parameters dictionary contains a null entry for parameter 'count' of non-nullable type 'System.Int32' for method 'System.Web.Mvc.ActionResult TestVC(System.String, Int32)' in 'theWebApp.Controllers.ATestController'. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters
         */
        public ActionResult TestVC(string msg, int count = 0)
        {
            this.ViewBag.Message = msg;
            this.ViewBag.Number = count;

            return this.View();
        }
    }
}