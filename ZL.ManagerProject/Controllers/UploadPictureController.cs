using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL;
using Common;
using ZL.ManagerProject.Common;

namespace ZL.ManagerProject.Controllers
{
    public class UploadPictureController : Controller
    {
        //
        // GET: /UploadPicture/

        public ActionResult UploadPicture()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadPicture(string id)
        {
            string[] filename = id.Split('=');
            if (filename.Length > 0)
            {
                DataTable dtFile = new DataTable();
                DataColumn col = new DataColumn();
                col.ColumnName = "FILENAME";
                col.DataType = typeof(string);
                dtFile.Columns.Add(col);
                col = new DataColumn();
                col.ColumnName = "ID";
                col.DataType = typeof(string);
                dtFile.Columns.Add(col);
                col = new DataColumn();
                col.ColumnName = "USERNAME";
                col.DataType = typeof(string);
                dtFile.Columns.Add(col);
                col = new DataColumn();
                col.ColumnName = "DATE";
                col.DataType = typeof(DateTime);
                dtFile.Columns.Add(col);
                col = new DataColumn();
                col.ColumnName = "PATH";
                col.DataType = typeof(string);
                dtFile.Columns.Add(col);
                DataRow row = dtFile.NewRow();
                foreach (string item in filename)
                {
                    row["FILENAME"] = item;
                    row["ID"] = GuidTool.GuidTo16String();
                    row["USERNAME"] = CommonInfo.UserName;
                    row["DATE"] = DateTime.Now;
                    row["PATH"] = "~/Content/assets/img";
                }
                GalleryBLL bll = new GalleryBLL();
                int i = bll.Save(dtFile);
                if (i > 0)
                {
                    Response.Write("上传成功！");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
