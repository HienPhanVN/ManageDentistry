    using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplateMVC.Models;
using TemplateMVC.Controllers;
using System.Web.Mvc;
using System.Data.Common;
using System.Data.SqlClient;

namespace TemplateMVC.Models
{
    public class user
    {

        public int id_user;
        public string name_user;
        public string phone_user;
        public string address_user;
        public string email_user;
        public int id_tier;

        public bool Create(string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            //Date 20/10 include DBUtils
            conn.Open();
            String sql = "INSERT INTO user(name_user, phone_user, address_user, email_user, id_tier) VALUES(?name_user, ?phone_user, ?address_user, ?email_user, ?id_tier)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_user", MySqlDbType.VarChar).Value = name_user;
                cmd.Parameters.Add("?phone_user", MySqlDbType.VarChar).Value = phone_user;
                cmd.Parameters.Add("?address_user", MySqlDbType.VarChar).Value = address_user;
                cmd.Parameters.Add("?email_user", MySqlDbType.VarChar).Value = email_user;
                cmd.Parameters.Add("?id_tier", MySqlDbType.Int32).Value = id_tier;                
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_user)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM managerdentist.user WHERE id_user=@id";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = id_user;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<user> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<user> list = new List<user>();
            try
            {
                conn.Open();
                String sql = "SELECT id_user, name_user, phone_user, address_user, email_user, id_tier FROM managerdentist.user;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);                
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user user_temp = new user();
                            user_temp.id_user = reader.GetInt32(0);
                            user_temp.name_user = reader.GetString(1);
                            user_temp.phone_user = reader.GetString(2);
                            user_temp.address_user = reader.GetString(3);
                            user_temp.email_user = reader.GetString(4);
                            user_temp.id_user = reader.GetInt32(5);
                            list.Add(user_temp);                            
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
                conn.Close();             
                conn.Dispose();
            }

            //foreach (user item in list)
            //{                
            //    System.Diagnostics.Debug.WriteLine(item.name_user);
            //}
            return list;
        }


        public bool Update(int id_user, string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            //Date 20/10 include DBUtils
            conn.Open();
            String sql = "UPDATE user SET name_user = ?name_user , phone_user = ?phone_user, address_user = ?address_user, email_user = ?email_user, id_tier = ?id_tier WHERE id_user = ?id_user";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_user", MySqlDbType.VarChar).Value = name_user;
                cmd.Parameters.Add("?phone_user", MySqlDbType.VarChar).Value = phone_user;
                cmd.Parameters.Add("?address_user", MySqlDbType.VarChar).Value = address_user;
                cmd.Parameters.Add("?email_user", MySqlDbType.VarChar).Value = email_user;
                cmd.Parameters.Add("?id_tier", MySqlDbType.Int32).Value = id_tier;
                cmd.Parameters.Add("?id_user", MySqlDbType.Int32).Value = id_user;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

    }
}