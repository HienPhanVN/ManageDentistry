using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class category
    {

        private int id_category;
        private string name_category;

        public int Id_category { get => id_category; set => id_category = value; }
        public string Name_category { get => name_category; set => name_category = value; }

        public bool Create(int id_category,string name_category)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO `managerdentist`.`category`(id_category, name_category) VALUES(?id_category, ?name_category)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_category", MySqlDbType.VarChar).Value = id_category;
                cmd.Parameters.Add("?name_category", MySqlDbType.VarChar).Value = name_category;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_category)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM `managerdentist`.`category` WHERE (`id_category` = @id_category)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_category", MySqlDbType.Int32).Value = id_category;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<category> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<category> list = new List<category>();
            try
            {
                conn.Open();
                String sql = "SELECT id_category, name_category FROM `managerdentist`.`category`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            category category_temp = new category();
                            category_temp.Id_category = reader.GetInt32(0);
                            category_temp.Name_category = reader.GetString(1);
                            list.Add(category_temp);
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


        public bool Update(int id_category, string name_category)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            //Date 20/10 include DBUtils
            conn.Open();
            String sql = "UPDATE account SET name_category = ?name_category WHERE id_category = ?id_category";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_category", MySqlDbType.VarChar).Value = name_category;
                cmd.Parameters.Add("?id_category", MySqlDbType.Int32).Value = id_category;
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