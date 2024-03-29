﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TemplateMVC.Controllers;

namespace TemplateMVC.Models
{
    public class ill
    {
        private int id_ill;
        private string name_ill;
        private string status_ill;
        private int id_user;
        private string name_user_patient;
        private string name_user_doctor;
        public int Id_ill { get => id_ill; set => id_ill = value; }
        public string Name_ill { get => name_ill; set => name_ill = value; }
        public string Status_ill { get => status_ill; set => status_ill = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public string Name_user_patient { get => name_user_patient; set => name_user_patient = value; }
        public string Name_user_doctor { get => name_user_doctor; set => name_user_doctor = value; }

        public bool Create(string name_ill, string status_ill, int id_user_patient, int id_user_doctor)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO `managerdentist`.`ill`(name_ill, status_ill, id_user_patient, id_user_doctor) VALUES(?name_ill, ?status_ill, ?id_user_patient, ?id_user_doctor)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_ill", MySqlDbType.VarChar).Value = name_ill;
                cmd.Parameters.Add("?status_ill", MySqlDbType.VarChar).Value = status_ill;
                cmd.Parameters.Add("?id_user_patient", MySqlDbType.Int32).Value = id_user_patient;
                cmd.Parameters.Add("?id_user_doctor", MySqlDbType.Int32).Value = id_user_doctor;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id_ill)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            String sql = "DELETE FROM `managerdentist`.`ill` WHERE (`id_ill` = @id_ill)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?id_ill", MySqlDbType.Int32).Value = id_ill;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public List<ill> Read()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            List<ill> list = new List<ill>();
            try
            {
                conn.Open();
                String sql = "SELECT id_ill, name_ill, status_ill, s.name_user, h.name_user FROM user s INNER JOIN ill hp on s.id_user = hp.id_user_patient INNER JOIN user h on hp.id_user_doctor = h.id_user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ill ill_temp = new ill();
                            ill_temp.Id_ill = reader.GetInt32(0);
                            ill_temp.Name_ill = reader.GetString(1);
                            ill_temp.Status_ill = reader.GetString(2);
                            ill_temp.Name_user_patient = reader.GetString(3);
                            ill_temp.Name_user_doctor = reader.GetString(4);
                            list.Add(ill_temp);
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


        public bool Update(int id_ill, string name_ill, string status_ill)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            //Date 20/10 include DBUtils
            conn.Open();
            String sql = "UPDATE account SET name_ill = ?name_ill, status_ill = ?status_ill WHERE id_ill = ?id_ill";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.Parameters.Add("?name_ill", MySqlDbType.VarChar).Value = name_ill;
                cmd.Parameters.Add("?status_ill", MySqlDbType.VarChar).Value = status_ill;
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

        public ill getIllOfUserById(int id_user_patient)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            ill ill_of_user_temp = new ill();
            try
            {
                conn.Open();
                String sql = "SELECT id_ill, name_ill, status_ill, s.name_user, h.name_user FROM user s INNER JOIN ill hp on s.id_user = hp.id_user_patient INNER JOIN user h on hp.id_user_doctor = h.id_user WHERE hp.id_user_patient = ?id_user_patient";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("?id_user_patient", MySqlDbType.Int32).Value = id_user_patient;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ill_of_user_temp.Id_ill = reader.GetInt32(0);
                            ill_of_user_temp.Name_ill = reader.GetString(1);
                            ill_of_user_temp.Status_ill = reader.GetString(2);
                            ill_of_user_temp.Name_user_patient = reader.GetString(3);
                            ill_of_user_temp.Name_user_doctor = reader.GetString(4);
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
            return ill_of_user_temp;
        }

    }
}