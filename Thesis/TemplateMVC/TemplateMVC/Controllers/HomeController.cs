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
        

        public ActionResult getAllUser()
        {
            user patient = new user();                        
            return this.Json(patient.Read(), JsonRequestBehavior.AllowGet);
        }

        public bool updateUser(int id_user, string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            user patient = new user();
            bool result = patient.Update(id_user, name_user, phone_user, address_user, email_user, id_tier);
            return result;
        }

        public bool deleteUser(int id_user)
        {
            user patient = new user();
            bool result = patient.Delete(id_user);
            return result;
        }


        public bool createUser(string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            user patient = new user();
            bool result = patient.Create(name_user, phone_user, address_user, email_user, id_tier);
            return result;
        }

        
    
    }   //end class
}       //end namespace

