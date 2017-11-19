
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Data;
namespace ZL.ManagerProject.Controllers
{
    public class UserEditController : Controller
    {
        //
        // GET: /UserEdit/

        public ActionResult UserEdit(string id)
        {
            LoginBLL bll = new LoginBLL();
            DataSet dsUser = bll.GetData(id, "", "");

            return View(dsUser.Tables[0]);
        }

        public ActionResult Save(string id, FormCollection form)
        {
            string username = form["USERNAME"].ToString();
            string pwd = form["pwd"].ToString();
            string pri = form["pri"].ToString();
            LoginBLL bll = new LoginBLL();
            int i = bll.Save(id, username, pwd, pri);
            if (i == 1)
            {
                return Redirect("/UserManager/UserManager");
            }
            else
            {
                return null;
            }
        }
    }
}
