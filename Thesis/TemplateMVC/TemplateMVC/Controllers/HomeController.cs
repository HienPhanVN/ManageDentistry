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
using System.Data;
using TemplateMVC.Models;

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
                Console.WriteLine(e.ToString());
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

        public ActionResult managepatient() 
        {
            return View();
        }
        

        public ActionResult getAllPatient()
        {
            user patient = new user();                        
            return this.Json(patient.Read(), JsonRequestBehavior.AllowGet);
        }


        public bool Create(string qrCode, string name, int age, string sex, string address, string phone, string insuranceCode)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO patient(qrCode,name,age,sex,address,phone,insuranceCode) VALUES(?qrCode,?name,?age,?sex,?address,?phone,?insuranceCode)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?qrCode", MySqlDbType.VarChar).Value = qrCode;
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("?age", MySqlDbType.Int32).Value = age;
                cmd.Parameters.Add("?sex", MySqlDbType.VarChar).Value = sex;
                cmd.Parameters.Add("?address", MySqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("?phone", MySqlDbType.VarChar).Value = phone;
                cmd.Parameters.Add("?insuranceCode", MySqlDbType.VarChar).Value = insuranceCode;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM patient WHERE idPatient=@id";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }
    
    }   //end class
}       //end namespace

