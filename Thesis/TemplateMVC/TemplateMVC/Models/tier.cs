using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class tier
    {

        public int id_tier;
        private string name_tier;

        public tier()
        {
        }

        public tier(int id_tier, string name_tier)
        {
            this.id_tier = id_tier;
            this.name_tier = name_tier;
        }

        public int Id_tier { get => id_tier; set => id_tier = value; }
        public string Name_tier { get => name_tier; set => name_tier = value; }

        public List<tier> Read(int? id_tier) {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<tier> list = new List<tier>();
            try
            {
                conn.Open();
                Debug.WriteLine(id_tier);
                //if()
                String sql = "SELECT id_tier, name_tier FROM managerdentist.tier;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tier tierTemp = new tier();
                            tierTemp.Id_tier = reader.GetInt32(0);
                            tierTemp.Name_tier = reader.GetString(1);
                            list.Add(tierTemp);
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



    }
}