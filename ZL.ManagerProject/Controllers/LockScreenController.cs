using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace ZL.ManagerProject.Controllers
{
    public class LockScreenController : Controller
    {
        //
        // GET: /LockScreen/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string password)
        {

            return View();
        }
        
    }
}
