using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLib;
using System.Data;
namespace DAL
{
    public class MenuManagerDAL
    {
        IDataAccessLib data = null;
        public MenuManagerDAL(IDataAccessLib _data)
        {
            data = _data;
        }


//        public DataSet Login(string username, string pwd)
//        {
//            try
//            {
//                string sql = "SELECT USERID, USERNAME, PASSWORDS, PRIVILEGE" +
//"FROM T_USERS WHERE USERNAME=@USERNAME AND PASSWORDS=@PWD";
//                QueryParameterList para = new QueryParameterList();
//                para.Add("@USERNAME", username);
//                para.Add("@PWD", pwd);
//                return data.ExecuteDataSet(sql, para);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//        }

    }
}
