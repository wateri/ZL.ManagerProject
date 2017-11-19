using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using DataAccessLib;
using System.Configuration;
namespace ZL.ManagerProject
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ServerDataInfo.SqlDataAddress = "Server=localhost;Database=BadmintonManager;User=sa;Pwd=water";
            string dataBaseType = "DataBaseType.MSSQLSERVER";
            switch (dataBaseType)
            {
                case "DataBaseType.MSSQLSERVER":
                    ServerDataInfo.DataBaseTypeInfo = DataBaseType.MSSQLSERVER;
                    break;
                case "DataBaseType.SQLite":
                    ServerDataInfo.DataBaseTypeInfo = DataBaseType.SQLite;
                    break;
            }
        }
    }
}