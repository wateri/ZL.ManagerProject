using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLib;
namespace DAL
{
    public class GalleryDAL
    {
        IDataAccessLib data = null;
        public GalleryDAL(IDataAccessLib _data)
        {
            data = _data;
        }


        public int Save(DataTable dt)
        {
            try
            {
                SqlStruct sqlStruct = new SqlStruct();
                sqlStruct.SqlString = @"INSERT INTO dbo.G_GALLERY (ID, PICTURENAME, PATH, UPLOADDATE, UPLOADUSER)
VALUES (@ID, @PICTURENAME, @PATH, @UPLOADDATE, @UPLOADUSER) ";
                foreach (DataRow item in dt.Rows)
                {

                    ParamField[] para = new ParamField[5];
                    para[0] = new ParamField("@DISCARDNO", "ID");
                    para[1] = new ParamField("@PICTURENAME", "FILENAME");
                    para[2] = new ParamField("@PATH", "PATH");
                    para[3] = new ParamField("@UPLOADDATE", "DATE");
                    para[4] = new ParamField("@UPLOADUSER", "USERNAME");

                    sqlStruct.ParamFields = para;
                    return data.ExecuteNonQuery(item, sqlStruct);
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetData()
        {
            try
            {
                string sql = @"SELECT * FROM G_GALLERY";
                QueryParameterList para = new QueryParameterList();
              
                return data.ExecuteDataSet(sql, para);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
