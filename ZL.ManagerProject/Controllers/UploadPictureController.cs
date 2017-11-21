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
            HttpFileCollectionBase files = Request.Files;
            int j = 0;
            if (files != null && files.Count > 0)
            {
                DataTable dtFile = SetTable();
                DataRow row = null;
                GalleryBLL bll = new GalleryBLL();

                #region 图片上传
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    file.SaveAs(Server.MapPath("../Content/assets/img/portfolio/" + file.FileName));
                    row = dtFile.NewRow();
                    row["FILENAME"] = file.FileName;
                    row["ID"] = GuidTool.GuidTo16String();
                    row["USERNAME"] = CommonInfo.UserName;
                    row["DATE"] = DateTime.Now;
                    row["PATH"] = "~/Content/assets/img/portfolio/";
                    dtFile.Rows.Add(row);
                    j = bll.Save(dtFile);
                }
                #endregion
            }
            if (j > 0)
            {
                return Json("上传成功");
            }
            else
            {
                return Json("上传失败");
            }
        }

        private static DataTable SetTable()
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
            return dtFile;
        }

    }
}
