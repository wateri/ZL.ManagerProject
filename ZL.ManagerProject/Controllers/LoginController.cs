﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Data;
namespace ZL.ManagerProject.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string username, string pwd)
        {
            LoginBLL bll = new LoginBLL();
            DataSet dsUser = bll.Login(username, pwd);
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                return Redirect("/Index/Index/" + username + "");
            }
            else
            {
                ViewData["loginfail"] = "用户名或密码错误";
                return View();
            }
        }
    }
}