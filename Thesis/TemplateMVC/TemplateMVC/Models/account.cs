using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class account
    {
        private int id_account;
        private string username_account;
        private string password_account;
        private int id_user;

        public int Id_account { get => this.id_account; set => id_account = value; }
        public string Username_account { get => this.username_account; set => username_account = value; }
        public string Password_account { get => this.password_account; set => password_account = value; }
        public int Id_user { get => this.id_user; set => id_user = value; }

        public bool Create(string username_account, string password_account, int id_user)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO `managerdentist`.`account`(username_account, password_account, id_user) VALUES(?username_account, ?password_account, ?id_user)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?username_account", MySqlDbType.VarChar).Value = username_account;
                cmd.Parameters.Add("?password_account", MySqlDbType.VarChar).Value = password_account;
                cmd.Parameters.Add("?id_user", MySqlDbType.Int32).Value = id_user;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_account)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM `managerdentist`.`account` WHERE (`id_account` = @id_account)";           
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_account", MySqlDbType.Int32).Value = id_account;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<account> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<account> list = new List<account>();
            try
            {
                conn.Open();
                String sql = "SELECT id_account, username_account, password_account, id_user FROM `managerdentist`.`account`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            account account_temp = new account();
                            account_temp.Id_account = reader.GetInt32(0);
                            account_temp.Username_account = reader.GetString(1);
                            account_temp.Password_account = reader.GetString(2);
                            account_temp.Id_user = reader.GetInt32(3);
                            list.Add(account_temp);
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


        public bool Update(int id_account, string username_account, string password_account, int id_user)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            //Date 20/10 include DBUtils
            conn.Open();
            String sql = "UPDATE account SET username_account = ?username_account, password_account = ?password_account, id_user = ?id_user WHERE id_account = ?id_account";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?username_account", MySqlDbType.VarChar).Value = username_account;
                cmd.Parameters.Add("?password_account", MySqlDbType.VarChar).Value = password_account;
                cmd.Parameters.Add("?id_user", MySqlDbType.Int32).Value = id_user;
                cmd.Parameters.Add("?id_account", MySqlDbType.Int32).Value = id_account;
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