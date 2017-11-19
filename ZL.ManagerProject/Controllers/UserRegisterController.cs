using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using BLL;
namespace ZL.ManagerProject.Controllers
{
    public class UserRegisterController : Controller
    {
        //
        // GET: /UserRegister/

        public ActionResult UserRegister()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserRegister(string username, string pwd, string repwd)
        {
            if (pwd != repwd)
            {
                ViewData["registerFail"] = "两次输入的密码不一致！";
                ViewData["username"] = username;
                return View();
            }
            string id = GuidTool.GuidTo16String();
            LoginBLL bll = new LoginBLL();
            int i = bll.UserRegister(id, username, pwd);
            if (i == 1)
            {
                return Redirect("/Login/Login");
            }
            else
            {
                ViewData["registerFail"] = "注册失败！";
                return View();
            }
        }
    }
}
