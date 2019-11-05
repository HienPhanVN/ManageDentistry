﻿using System;
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

    }   //end class
}       //end namespace

