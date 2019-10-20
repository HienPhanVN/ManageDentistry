using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using TemplateMVC.Controllers;
using System.Data;
using System.Diagnostics;
using Newtonsoft.Json;

namespace TemplateMVC.Models
{
    public class Patient
    {
        public class PageRowDTO
        {
            public int idPatient;
            public string qrCode;
            public string name;
            public int age;
            public string sex;
            public string address;
            public string phone;
            public string insuranceCode;

        }
        public int idPatient { get; set; }
        public string qrCode { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public bool createPatient(string qrCode, string name, int age, string sex, string address, string phone)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO patient(qrCode,name,age,sex,address,phone) VALUES(?qrCode,?name,?age,?sex,?address,?phone)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?qrCode", MySqlDbType.VarChar).Value = qrCode;
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("?age", MySqlDbType.Int32).Value = age;
                cmd.Parameters.Add("?sex", MySqlDbType.VarChar).Value = sex;
                cmd.Parameters.Add("?address", MySqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("?phone", MySqlDbType.VarChar).Value = phone;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }       

        public bool updatePatient(int idPatient, string qrCode, string name, int age, string sex, string address, string phone)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "UPDATE patient SET qrCode = ?qrCode, name = ?name, age = ?age, sex = ?sex, address = ?address, phone = ?phone WHERE idPatient = ?idPatient";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?qrCode", MySqlDbType.VarChar).Value = qrCode;
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("?age", MySqlDbType.Int32).Value = age;
                cmd.Parameters.Add("?sex", MySqlDbType.VarChar).Value = sex;
                cmd.Parameters.Add("?address", MySqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("?phone", MySqlDbType.VarChar).Value = phone;
                cmd.Parameters.Add("?idPatient", MySqlDbType.Int32).Value = idPatient;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public string getAll()
        {
            DataTable ques = new DataTable();
            MySqlConnection conn = DBUtils.GetDBConnection();
            string[] str = new string[] { };
            try
            {
                conn.Open();
                String sql = "SELECT idPatient, qrCode, name, age, sex, address, phone, insuranceCode FROM patient;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            int i = 0;
                            str[i] = reader[2].ToString(); 
                            //pr[i][2] = reader[2].ToString();
                            //pr[i][3] = reader[3].ToString();
                            //pr[i][4] = reader[4].ToString();
                            //pr[i][5] = reader[5].ToString();
                            //pr[i][6] = reader[6].ToString();
                            //pr[i][7] = reader[7].ToString();
                            i++;
                            // loop on columns   
                                                      
                        }

                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());

            }
            finally
            {
                // Đóng kết nối.
                conn.Close();
                // Tiêu hủy đối tượng, giải phóng tài nguyên.
                conn.Dispose();
            }
            return JsonConvert.SerializeObject(str);
        }

    }
}