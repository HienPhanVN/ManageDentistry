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

    }
}