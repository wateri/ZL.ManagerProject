using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLib;
using System.Data;


namespace DAL
{
    public class LoginDAL
    {
        IDataAccessLib data = null;
        public LoginDAL(IDataAccessLib _data)
        {
            data = _data;
        }

        public DataSet Login(string username, string pwd)
        {
            try
            {
                string sql = @"SELECT USERID, USERNAME, PASSWORDS, PRIVILEGE 
FROM T_USERS WHERE USERNAME=@USERNAME AND PASSWORDS=@PWD";
                QueryParameterList para = new QueryParameterList();
                para.Add("@USERNAME", username);
                para.Add("@PWD", pwd);
                return data.ExecuteDataSet(sql, para);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int UserRegister(string id, string username, string pwd)
        {
            try
            {
                string sql = @"INSERT INTO dbo.T_USERS (USERID, USERNAME, PASSWORDS, PRIVILEGE)
VALUES (@USERID, @USERNAME, @PWD, @PRIVILEGE)";
                QueryParameterList para = new QueryParameterList();
                para.Add("@USERID", id);
                para.Add("@USERNAME", username);
                para.Add("@PWD", pwd);
                para.Add("@PRIVILEGE", "1");
                return data.ExecuteNonQuery(sql, para);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetData(string id, string username, string pwd)
        {
            try
            {
                string sql = @"SELECT * FROM T_USERS";
                QueryParameterList para = new QueryParameterList();
                if (id != "")
                {
                    sql += " WHERE USERID=@USERID ";
                    para.Add("@USERID", id);
                }
                if (username != "")
                {
                    sql += " WHERE USERNAME=@USERNAME ";
                    para.Add("@USERNAME", username);
                }
                //para.Add("@PWD", pwd);
                //para.Add("@PRIVILEGE", "1");
                return data.ExecuteDataSet(sql, para);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(string id)
        {
            try
            {
                string sql = @"DELETE FROM T_USERS WHERE USERID=@USERID";
                QueryParameterList para = new QueryParameterList();
                para.Add("@USERID", id);
                //para.Add("@USERNAME", username);
                //para.Add("@PWD", pwd);
                //para.Add("@PRIVILEGE", "1");
                return data.ExecuteNonQuery(sql, para);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save(string userid, string username, string pwd, string pri)
        {
            try
            {
                string sql = @"UPDATE dbo.T_USERS
                                    SET  USERNAME = @USERNAME,
	                                    PASSWORDS = @PASSWORDS,
	                                    PRIVILEGE = @PRIVILEGE
                                        WHERE USERID = @USERID ";
                QueryParameterList para = new QueryParameterList();
                para.Add("@USERID", userid);
                para.Add("@USERNAME", username);
                para.Add("@PASSWORDS", pwd);
                para.Add("@PRIVILEGE", pri == "超级管理员" ? 1 : 2);
                return data.ExecuteNonQuery(sql, para);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
