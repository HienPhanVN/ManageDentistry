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

        //public ActionResult getAllAccount()
        //{
        //    account patient = new account();
        //    return this.Json(patient.Read(), JsonRequestBehavior.AllowGet);
        //}

        //create
        public bool createUser(string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            user patient = new user();
            bool result = patient.Create(name_user, phone_user, address_user, email_user, id_tier);
            return result;
        }

        public bool createAccount(string username_account, string password_account, int id_user)
        {
            account Account = new account();
            bool result = Account.Create(username_account, password_account, id_user);
            return result;
        }

        public bool createIll(string name_ill, string status_ill, int id_user)
        {
            ill Ill = new ill();
            bool result = Ill.Create(name_ill, status_ill, id_user);
            return result;
        }

        //read
        public ActionResult pageUser(int? page)
        {

            user tempUser = new user();

            var allUser = tempUser.Read();

            var pageNumber = page ?? 1;

            var onePageOfUsers = allUser.ToPagedList(pageNumber, 5);

            ViewBag.OnePageOfUsers = onePageOfUsers;

            return View();
        }


        public ActionResult pageAccount(int? page)
        {

            account accountTemp = new account();

            var allAccount = accountTemp.Read();

            var pageNumber = page ?? 1;

            var onePageOfAccounts = allAccount.ToPagedList(pageNumber, 5);

            ViewBag.OnePageOfAccounts = onePageOfAccounts;

            return View();

        }

        public ActionResult pageIll(int? page)
        {

            ill tempIll = new ill();

            var allIll = tempIll.Read();

            var pageNumber = page ?? 1;

            var onePageOfIlls = allIll.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfIlls = onePageOfIlls;

            return View();
        }

        //update
        public bool updateUser(int id_user, string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            user patient = new user();
            bool result = patient.Update(id_user, name_user, phone_user, address_user, email_user, id_tier);
            return result;
        }
        public bool updateAccount(int id_account, string username_account, string password_account, int id_user)
        {
            account Account = new account();
            bool result = Account.Update(id_account, username_account, password_account, id_user);
            return result;
        }

        public bool updateIll(int id_ill, string name_ill, string status_ill)
        {
            ill Ill = new ill();
            bool result = Ill.Update(id_ill, name_ill, status_ill);
            return result;
        }

        //delete
        public bool deleteUser(int id_user)
        {
            user patient = new user();
            bool result = patient.Delete(id_user);
            return result;
        }

        public bool deleteAccount(int id_account)
        {
            account Account = new account();
            bool result = Account.Delete(id_account);
            return result;
        }

        public bool deleteIll(int id_ill)
        {
            ill Ill = new ill();
            bool result = Ill.Delete(id_ill);
            return result;
        }

    }   //end class
}       //end namespace

