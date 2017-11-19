using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLib;
using DAL;
using System.Data;
namespace BLL
{
    public class LoginBLL 
    {
        public DataSet Login(string username, string pwd)
        {
            IDataAccessLib data = MultiDataAccess.CreateDataAccess();
            data.Open();
            try
            {
                LoginDAL dal = new LoginDAL(data);
                return dal.Login(username, pwd);
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

        public int UserRegister(string id, string username, string pwd)
        {
            IDataAccessLib data = MultiDataAccess.CreateDataAccess();
            data.Open();
            try
            {
                LoginDAL dal = new LoginDAL(data);
                return dal.UserRegister(id, username, pwd);
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


        public DataSet GetData(string id, string username, string pwd)
        {
            IDataAccessLib data = MultiDataAccess.CreateDataAccess();
            data.Open();
            try
            {
                LoginDAL dal = new LoginDAL(data);
                return dal.GetData(id, username, pwd);
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

        public int Delete(string userid)
        {
            IDataAccessLib data = MultiDataAccess.CreateDataAccess();
            data.Open();
            try
            {
                LoginDAL dal = new LoginDAL(data);
                return dal.Delete(userid);
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

        public int Save(string userid, string username, string pwd, string pri)
        {
            IDataAccessLib data = MultiDataAccess.CreateDataAccess();
            data.Open();

            try
            {
                LoginDAL dal = new LoginDAL(data);
                return dal.Save(userid, username, pwd, pri);
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
