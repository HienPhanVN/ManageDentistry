using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class historyproduct
    {
        private int id_historyProduct;
        private DateTime dayUpdate_historyProduct;
        public int id_product;
        private string name_product;

        public int Id_historyProduct { get => id_historyProduct; set => id_historyProduct = value; }
        public DateTime DayUpdate_historyProduct { get => dayUpdate_historyProduct; set => dayUpdate_historyProduct = value; }
        public int Id_product { get => id_product; set => id_product = value; }
        public string Name_product { get => name_product; set => name_product = value; }

        [Obsolete]
        public bool Create(int id_category, string name_category)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO `managerdentist`.`historyproduct`(dayUpdate_historyProduct) VALUES(?dayUpdate_historyProduct)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?dayUpdate_historyProduct", MySqlDbType.Datetime).Value = dayUpdate_historyProduct;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_historyProduct)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM `managerdentist`.`historyproduct` WHERE (`id_historyProduct` = @id_historyProduct)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_historyProduct", MySqlDbType.Int32).Value = id_historyProduct;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<historyproduct> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<historyproduct> list = new List<historyproduct>();
            try
            {
                conn.Open();
                String sql = "SELECT id_historyProduct, dayUpdate_historyProduct, historyproduct.id_product, name_product FROM managerdentist.historyproduct, managerdentist.product WHERE managerdentist.product.id_product = managerdentist.historyproduct.id_product ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            historyproduct historyproduct_temp = new historyproduct();
                            historyproduct_temp.Id_historyProduct = reader.GetInt32(0);
                            historyproduct_temp.DayUpdate_historyProduct = reader.GetDateTime(1);
                            historyproduct_temp.Id_product = reader.GetInt32(2);
                            historyproduct_temp.Name_product = reader.GetString(3);
                            list.Add(historyproduct_temp);
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


        public bool Update(int id_historyProduct, DateTime dayUpdate_historyProduct)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "UPDATE historyproduct SET dayUpdate_historyProduct = ?dayUpdate_historyProduct WHERE id_historyProduct = ?id_historyProduct";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?dayUpdate_historyProduct", MySqlDbType.DateTime).Value = dayUpdate_historyProduct;
                cmd.Parameters.Add("?id_historyProduct", MySqlDbType.Int32).Value = id_historyProduct;
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