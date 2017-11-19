using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BLL;
using System.Data;
namespace ZL.ManagerProject.Controllers
{
    public class GalleryController : Controller
    {
        //
        // GET: /Gallery/

        public ActionResult Gallery()
        {

            GalleryBLL bll = new GalleryBLL();
            DataSet ds = bll.GetData();

            DataTable dtPicture = new DataTable("Picture");
            dtPicture.Columns.Add("PICTURENAME1", typeof(string));
            dtPicture.Columns.Add("PICTURENAME2", typeof(string));
            dtPicture.Columns.Add("PICTURENAME3", typeof(string));
            DataRow newRow = null;
            int count = ds.Tables[0].Rows.Count;

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int index = ds.Tables[0].Rows.IndexOf(item);
                if (index % 3 == 0)
                {
                    newRow = dtPicture.NewRow();
                    newRow["PICTURENAME1"] = item["PICTURENAME"].ToString();
                    if (count % 3 == 1)
                    {
                        dtPicture.Rows.Add(newRow);
                    }
                }
                if (index % 3 == 1)
                {
                    newRow["PICTURENAME2"] = item["PICTURENAME"].ToString();
                    if (count % 3 == 2)
                    {
                        dtPicture.Rows.Add(newRow);
                    }
                }
                if (index % 3 == 2)
                {
                    newRow["PICTURENAME3"] = item["PICTURENAME"].ToString();
                    if (count % 3 == 0)
                    {
                        dtPicture.Rows.Add(newRow);
                    }
                }
            }
            return View(dtPicture);
        }

    }
}
