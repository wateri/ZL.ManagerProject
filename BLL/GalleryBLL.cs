using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using DataAccessLib;

namespace BLL
{
    public class GalleryBLL
    {
        public int Save(DataTable dt)
        {
            IDataAccessLib data = MultiDataAccess.CreateDataAccess();
            data.Open();

            try
            {
                GalleryDAL dal = new GalleryDAL(data);
                return dal.Save(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }


        public DataSet GetData()
        {
            IDataAccessLib data = MultiDataAccess.CreateDataAccess();
            data.Open();
            try
            {
                GalleryDAL dal = new GalleryDAL(data);
                return dal.GetData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }


    }
}
