using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class historyIll
    {
        private int id_historyIll;
        private DateTime dayUpdate_historyIll;
        public int id_ill;
        private string name_ill;

        public int Id_historyIll { get => id_historyIll; set => id_historyIll = value; }
        public DateTime DayUpdate_historyIll { get => dayUpdate_historyIll; set => dayUpdate_historyIll = value; }
        public int Id_ill { get => id_ill; set => id_ill = value; }
        public string Name_ill { get => name_ill; set => name_ill = value; }

        public bool Create(DateTime dayUpdate_historyIll, int id_ill)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO `managerdentist`.`historyill`(dayUpdate_historyIll, id_ill) VALUES(?dayUpdate_historyIll, ?id_ill)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?dayUpdate_historyIll", MySqlDbType.DateTime).Value = dayUpdate_historyIll;
                cmd.Parameters.Add("?id_ill", MySqlDbType.Int32).Value = id_ill;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_historyIll)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM `managerdentist`.`historyill` WHERE (`id_historyIll` = @id_historyIll)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_historyIll", MySqlDbType.Int32).Value = id_historyIll;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<historyIll> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<historyIll> list = new List<historyIll>();
            try
            {
                conn.Open();
                String sql = "SELECT id_historyIll, dayUpdate_historyIll, ill.id_ill, name_ill FROM `managerdentist`.`ill`, `managerdentist`.`historyill` WHERE ill.id_ill = historyill.id_ill;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            historyIll historyIll_temp = new historyIll();
                            historyIll_temp.Id_historyIll = reader.GetInt32(0);
                            historyIll_temp.DayUpdate_historyIll = reader.GetDateTime(1);
                            historyIll_temp.Id_ill = reader.GetInt32(2);
                            historyIll_temp.Name_ill = reader.GetString(3);
                            list.Add(historyIll_temp);
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

        [Obsolete]
        public bool Update(int id_historyIll, DateTime dayUpdate_historyIll)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            //Date 20/10 include DBUtils
            conn.Open();
            String sql = "UPDATE `historyill` SET dayUpdate_historyIll = ?dayUpdate_historyIll WHERE id_historyIll = ?id_historyIll";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?dayUpdate_historyIll", MySqlDbType.Datetime).Value = dayUpdate_historyIll;
                cmd.Parameters.Add("?id_historyIll", MySqlDbType.Int32).Value = id_historyIll;
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