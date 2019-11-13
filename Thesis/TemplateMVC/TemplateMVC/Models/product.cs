using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class product
    {
        private int id_product;
        private string name_product;
        private float price_product;
        private string note_product;
        private string name_company;
        private string name_category;
        public int id_company;
        public int id_category;
        public int id_bill;

        public int Id_product { get => id_product; set => id_product = value; }
        public string Name_product { get => name_product; set => name_product = value; }
        public float Price_product { get => price_product; set => price_product = value; }
        public string Note_product { get => note_product; set => note_product = value; }
        public int Id_company { get => id_company; set => id_company = value; }
        public int Id_category { get => id_category; set => id_category = value; }
        public int Id_bill { get => id_bill; set => id_bill = value; }
        public string Name_company { get => name_company; set => name_company = value; }
        public string Name_category { get => name_category; set => name_category = value; }

        public bool Create(int id_category, string name_category)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO `managerdentist`.`product`(name_product, price_product, note_product, id_company, id_category, id_bill) VALUES(?name_product, ?price_product, ?note_product, ?id_company, ?id_category, ?id_bill)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_product", MySqlDbType.VarChar).Value = name_product;
                cmd.Parameters.Add("?price_product", MySqlDbType.Float).Value = price_product;
                cmd.Parameters.Add("?note_product", MySqlDbType.VarChar).Value = note_product;
                cmd.Parameters.Add("?id_company", MySqlDbType.Int32).Value = id_company;
                cmd.Parameters.Add("?id_category", MySqlDbType.Int32).Value = id_category;
                cmd.Parameters.Add("?id_bill", MySqlDbType.Int32).Value = id_bill;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_product)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM `managerdentist`.`product` WHERE (`id_product` = @id_product)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_product", MySqlDbType.Int32).Value = id_product;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<product> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<product> list = new List<product>();
            try
            {
                conn.Open();
                String sql = "SELECT id_product, name_product, price_product, note_product, product.id_company, product.id_category, product.id_bill, name_company, name_category FROM(((product INNER JOIN category ON product.id_category = category.id_category) INNER JOIN company ON product.id_company = company.id_company) INNER JOIN bill ON product.id_bill = bill.id_bill)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            product product_temp = new product();
                            product_temp.Id_product = reader.GetInt32(0);
                            product_temp.Name_product = reader.GetString(1);
                            product_temp.Price_product = reader.GetFloat(2);
                            product_temp.Note_product = reader.GetString(3);
                            product_temp.Id_company = reader.GetInt32(4);
                            product_temp.Id_category = reader.GetInt32(5);
                            product_temp.Id_bill = reader.GetInt32(6);
                            product_temp.Name_company = reader.GetString(7);
                            product_temp.Name_category = reader.GetString(8);
                            list.Add(product_temp);
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


        public bool Update(int id_product,string name_product,float price_product,string note_product)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "UPDATE account SET name_product = ?name_product, price_product = ?price_product, note_product = ?note_product WHERE id_product = ?id_product";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_product", MySqlDbType.VarChar).Value = name_product;
                cmd.Parameters.Add("?price_product", MySqlDbType.Float).Value = price_product;
                cmd.Parameters.Add("?note_product", MySqlDbType.Float).Value = note_product;
                cmd.Parameters.Add("?id_product", MySqlDbType.Int32).Value = id_product;
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