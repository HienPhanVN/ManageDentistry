using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class company
    {
        private int id_company;
        private string name_company;
        private string address_company;
        private string phone_company;
        private string email_company;

        public int Id_company { get => id_company; set => id_company = value; }
        public string Name_company { get => name_company; set => name_company = value; }
        public string Address_company { get => address_company; set => address_company = value; }
        public string Phone_company { get => phone_company; set => phone_company = value; }
        public string Email_company { get => email_company; set => email_company = value; }

        public bool Create(string name_company, string address_company, string phone_company, string email_company)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO `managerdentist`.`company`(name_company, address_company, phone_company, email_company) VALUES(?name_company, ?address_company, ?phone_company, ?email_company)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_company", MySqlDbType.VarChar).Value = name_company;
                cmd.Parameters.Add("?address_company", MySqlDbType.VarChar).Value = address_company;
                cmd.Parameters.Add("?phone_company", MySqlDbType.VarChar).Value = phone_company;
                cmd.Parameters.Add("?email_company", MySqlDbType.VarChar).Value = email_company;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_company)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM `managerdentist`.`company` WHERE (`id_company` = @id_company)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_company", MySqlDbType.Int32).Value = id_company;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<company> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<company> list = new List<company>();
            try
            {
                conn.Open();
                String sql = "SELECT id_company, name_company, address_company, phone_company, email_company FROM `managerdentist`.`company`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            company company_temp = new company();
                            company_temp.Id_company = reader.GetInt32(0);
                            company_temp.Name_company = reader.GetString(1);
                            company_temp.Address_company = reader.GetString(2);
                            company_temp.Phone_company = reader.GetString(3);
                            company_temp.Email_company = reader.GetString(4);
                            list.Add(company_temp);
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
                conn.Close();
                conn.Dispose();
            }
            return list;
        }


        public bool Update(int id_company, string name_company, string address_company, string phone_company, string email_company)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            //Date 20/10 include DBUtils
            conn.Open();
            String sql = "UPDATE account SET name_company = ?name_company, address_company = ?address_company, phone_company = ?phone_company, email_company = ?email_company WHERE id_company = ?id_company";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_company", MySqlDbType.VarChar).Value = name_company;
                cmd.Parameters.Add("?address_company", MySqlDbType.VarChar).Value = address_company;
                cmd.Parameters.Add("?phone_company", MySqlDbType.VarChar).Value = phone_company;
                cmd.Parameters.Add("?email_company", MySqlDbType.VarChar).Value = email_company;
                cmd.Parameters.Add("?id_company", MySqlDbType.Int32).Value = id_company;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

    }
}