using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace TemplateMVC.Controllers
{
    public class HomeController : Controller
    {
        

        // GET: Home
        public ActionResult Index()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                String sql = "SELECT * FROM sakila.actor;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            // Chỉ số (index) của cột Emp_ID trong câu lệnh SQL.
                            int empIdIndex = reader.GetOrdinal("actor_id"); // 0


                            long empId = Convert.ToInt64(reader.GetValue(0));

                            // Cột Emp_No có index = 1.
                            string empNo = reader.GetString(1);
                            int empNameIndex = reader.GetOrdinal("last_name");// 2
                            string empName = reader.GetString(empNameIndex);

                            // Chỉ số (index) của cột Mng_Id trong câu lệnh SQL.
                            int mngIdIndex = reader.GetOrdinal("actor_id");

                            long? mngId = null;

                            // Kiểm tra giá trị của cột này có thể null hay không.
                            if (!reader.IsDBNull(mngIdIndex))
                            {
                                mngId = Convert.ToInt64(reader.GetValue(mngIdIndex));
                            }
                            string[] proinfo = new string[] { "a", "b" };
                            ViewBag.ProInfo = proinfo;
                            ViewBag.TotalStudents = empName;
                        }
                    }
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Đóng kết nối.
                conn.Close();
                // Tiêu hủy đối tượng, giải phóng tài nguyên.
                conn.Dispose();
            }   
            return View();
        }

        public string ChaoMung()
        {
            return "Đây là phương thức ChaoMung nằm trong Controller Dammio!";
        } 

        public String Create()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();

            conn.Open();
            String sql = "INSERT INTO patient(qrCode,name,age,sex,address,phone) VALUES(?qrCode,?name,?age,?sex,?address,?phone)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?qrCode", MySqlDbType.VarChar).Value = "myQrcode";
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = "myName";
                cmd.Parameters.Add("?age", MySqlDbType.Int16).Value = 99;
                cmd.Parameters.Add("?sex", MySqlDbType.VarChar).Value = "male";
                cmd.Parameters.Add("?address", MySqlDbType.VarChar).Value = "myaddress";
                cmd.Parameters.Add("?phone", MySqlDbType.VarChar).Value = "12355";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                return e.ToString();
            }

            return "okie";
        }
        
    
    }   //end class
}       //end namespace