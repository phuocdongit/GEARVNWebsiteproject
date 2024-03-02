using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WEB_Project.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}