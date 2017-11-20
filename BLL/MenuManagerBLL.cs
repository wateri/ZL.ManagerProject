using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLib;
using DAL;
using System.Data;
namespace BLL
{
    public class MenuManagerBLL
    {
        public DataSet GetData(string userid)
        {
            IDataAccessLib data = MultiDataAccess.CreateDataAccess();
            data.Open();
            try
            {
                MenuManagerDAL dal = new MenuManagerDAL(data);
                return dal.GetData(userid);
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
