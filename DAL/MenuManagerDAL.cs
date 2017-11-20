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


        public DataSet GetData(string userid)
        {
            try
            {
                string sql = "SELECT USERID, MENUID FROM dbo.T_MENUATTACH WHERE USERID=@USERID";
                QueryParameterList para = new QueryParameterList();
                para.Add("@USERID", userid);
                return data.ExecuteDataSet(sql, para);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
