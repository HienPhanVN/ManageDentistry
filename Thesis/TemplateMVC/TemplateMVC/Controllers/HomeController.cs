using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using TemplateMVC.Models;
using PagedList;
using System.Diagnostics;

namespace TemplateMVC.Controllers
{
    public class HomeController : Controller
    {

        public object pageUser(int? page) {
            

            user tempUser = new user();

            var allUser = tempUser.Read();

            //foreach (user temp in allUser) {
            //    Debug.WriteLine(temp.id_tier);
            //}

            var pageNumber = page ?? 1;

            var onePageOfUsers = allUser.ToPagedList(pageNumber, 5);

            ViewBag.OnePageOfUsers = onePageOfUsers;

            return View();
        }
        
        public ActionResult managepatient() 
        {
            return View();

        }

        public ActionResult managedoctor()
        {
            return View();
        }

        public ActionResult manageproduct()
        {
            return View();
        }

        public ActionResult managebill()
        {
            return View();
        }

        public ActionResult managecategory()
        {
            return View();
        }

        public ActionResult manageill()
        {
            return View();
        }


    

        /*public ActionResult getAllUser()
        {
            user patient = new user();                        
            return this.Json(patient.Read(), JsonRequestBehavior.AllowGet);
        }*/

        public bool updateUser(int id_user, string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            user patient = new user();
            bool result = patient.Update(id_user, name_user, phone_user, address_user, email_user, id_tier);
            return result;
        }

        public bool deleteUser(int id_user)
        {
            user patient = new user();
            bool result = patient.Delete(id_user);
            return result;
        }


        public bool createUser(string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            user patient = new user();
            bool result = patient.Create(name_user, phone_user, address_user, email_user, id_tier);
            return result;
        }        
    
    }   //end class
}       //end namespace

