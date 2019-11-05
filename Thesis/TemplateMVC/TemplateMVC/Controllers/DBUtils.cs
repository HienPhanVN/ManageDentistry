using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace TemplateMVC.Controllers
{
    public class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            
            string host = "35.185.191.138";
            //string host = "127.0.0.1";
            int port = 3306;
            string database = "managerdentist";
            string username = "admin";
            string password = "admin";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}