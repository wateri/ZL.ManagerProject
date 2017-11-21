using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Data;
using ZL.ManagerProject.Common;
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
                Create(username, pwd);
                MenuManagerBLL mbll = new MenuManagerBLL();
                DataSet dsMenu = mbll.GetData(dsUser.Tables[0].Rows[0]["USERID"].ToString());
                UserMenu.MenuTab = new List<string>();
                foreach (DataRow item in dsMenu.Tables[0].Rows)
                {
                    UserMenu.MenuTab.Add(item["MENUID"].ToString());
                }
             
                return Redirect("/Index/Index/" + username + "");
            }
            else
            {
                ViewData["loginfail"] = "用户名或密码错误";
                return View();
            }
        }

        public void Create(string username, string pwd)
        {
            HttpCookie cookie = new HttpCookie("zl_cookie");
            cookie.Values.Add("zl_username", username);
            cookie.Values.Add("zl_pwd", pwd);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
        }
    }
}
