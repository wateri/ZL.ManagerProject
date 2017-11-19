using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Data;
namespace ZL.ManagerProject.Controllers
{
    public class UserManagerController : Controller
    {
        //
        // GET: /UserManager/

        public ActionResult UserManager()
        {
            LoginBLL bll = new LoginBLL();
            DataSet dsUsers = bll.GetData("", "", "");
            if (!dsUsers.Tables[0].Columns.Contains("LEVEL"))
            {
                dsUsers.Tables[0].Columns.Add("LEVEL", typeof(string));
            }
            foreach (DataRow item in dsUsers.Tables[0].Rows)
            {
                if (item["PRIVILEGE"].ToString() == "1")
                {
                    item["LEVEL"] = "超级管理员";
                }
                else
                {
                    item["LEVEL"] = "一般用户";
                }
            }
            return View(dsUsers.Tables[0]);
        }

        public ActionResult Delete(string id)
        {
            LoginBLL bll = new LoginBLL();
            int i = bll.Delete(id);
            if (i == 1)
            {
                return Redirect("/UserManager/UserManager");
            }
            else
            {
                Response.Write("删除失败！");
                return View();
            }
        }
    }
}
