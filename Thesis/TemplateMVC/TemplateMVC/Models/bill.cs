using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class bill
    {
        private int id_bill;
        private string status_bill;
        private DateTime dayCreate_bill;
        private string note_bill;
        private float price_bill;
        private float debt_bill;

        public int Id_bill { get => id_bill; set => id_bill = value; }
        public string Status_bill { get => status_bill; set => status_bill = value; }
        public DateTime DayCreate_bill { get => dayCreate_bill; set => dayCreate_bill = value; }
        public string Note_bill { get => note_bill; set => note_bill = value; }
        public float Price_bill { get => price_bill; set => price_bill = value; }
        public float Debt_bill { get => debt_bill; set => debt_bill = value; }

        public bool Create(string status_bill, DateTime dayCreate_bill, string note_bill, float price_bill, float debt_bill)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO `managerdentist`.`bill`(status_bill, dayCreate_bill, note_bill, price_bill, debt_bill) VALUES(?status_bill, ?dayCreate_bill, ?note_bill, ?price_bill, ?debt_bill)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?status_bill", MySqlDbType.VarChar).Value = status_bill;
                cmd.Parameters.Add("?dayCreate_bill", MySqlDbType.DateTime).Value = dayCreate_bill;
                cmd.Parameters.Add("?note_bill", MySqlDbType.VarChar).Value = note_bill;
                cmd.Parameters.Add("?price_bill", MySqlDbType.Float).Value = price_bill;
                cmd.Parameters.Add("?debt_bill", MySqlDbType.Float).Value = debt_bill;


                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_bill)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM `managerdentist`.`bill` WHERE (`id_bill` = @id_bill)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_bill", MySqlDbType.Int32).Value = id_bill;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<bill> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<bill> list = new List<bill>();
            try
            {
                conn.Open();
                String sql = "SELECT id_bill, status_bill, dayCreate_bill, note_bill, price_bill, debt_bill FROM `managerdentist`.`bill`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            bill historyproduct_temp = new bill();
                            historyproduct_temp.Id_bill = reader.GetInt32(0);
                            historyproduct_temp.Status_bill= reader.GetString(1);
                            historyproduct_temp.DayCreate_bill = reader.GetDateTime(2);
                            historyproduct_temp.Note_bill = reader.GetString(3);
                            historyproduct_temp.Price_bill = reader.GetFloat(4);
                            historyproduct_temp.Debt_bill = reader.GetFloat(5);
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


        public bool Update(int id_bill, string status_bill, DateTime dayCreate_bill, string note_bill, float price_bill, float debt_bill)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "UPDATE bill SET status_bill = ?status_bill, dayCreate_bill = ?dayCreate_bill, note_bill = ?note_bill, price_bill = ?price_bill, debt_bill = ?debt_bill WHERE id_bill = ?id_bill";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?status_bill", MySqlDbType.VarChar).Value = status_bill;
                cmd.Parameters.Add("?dayCreate_bill", MySqlDbType.DateTime).Value = dayCreate_bill;
                cmd.Parameters.Add("?note_bill", MySqlDbType.VarChar).Value = note_bill;
                cmd.Parameters.Add("?price_bill", MySqlDbType.Float).Value = price_bill;
                cmd.Parameters.Add("?debt_bill", MySqlDbType.Float).Value = debt_bill;
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