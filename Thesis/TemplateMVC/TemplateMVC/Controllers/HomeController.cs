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
            user test = new user();
            ViewBag.totalDoctor = test.queryDoctor();
            ViewBag.totalPatient = test.queryPatient();
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

        //create
        public int createUser(string name_user, string phone_user, string address_user, string email_user, int id_tier)
        {
            user patient = new user();
            object result = patient.Create(name_user, phone_user, address_user, email_user, id_tier);
            int result2 = Convert.ToInt32(result);
            if (result2 > 0)
            {
                ill ill = new ill();
                bool resultOfIll = ill.Create("Unknow", "Unknow", result2, 6);
            }
            return result2;
        }

        public ActionResult getUserById(int id_user_patient)
        {
            ill tempIll = new ill();
            ill result = tempIll.getIllOfUserById(id_user_patient);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool createAccount(string username_account, string password_account, int id_user)
        {
            account Account = new account();
            bool result = Account.Create(username_account, password_account, id_user);
            return result;
        }

        public bool createIll(string name_ill, string status_ill, int id_user_patient, int id_user_doctor)
        {
            ill Ill = new ill();
            bool result = Ill.Create(name_ill, status_ill, id_user_patient, id_user_doctor);
            return result;
        }

        public bool createCompany(string name_company, string address_company, string phone_company, string email_company)
        {
            company Company = new company();
            bool result = Company.Create(name_company, address_company, phone_company, email_company);
            return result;
        }

        public bool createHistoryIll(DateTime dayUpdate_historyIll, int id_ill)
        {
            historyIll HistoryIll = new historyIll();
            bool result = HistoryIll.Create(dayUpdate_historyIll, id_ill);
            return result;
        }

        public bool createCategory(int id_category, string name_category)
        {
            category Category = new category();
            bool result = Category.Create(id_category, name_category);
            return result;
        }

        public bool createBill(string status_bill, DateTime dayCreate_bill, string note_bill, float price_bill, float debt_bill)
        {
            bill Bill = new bill();
            bool result = Bill.Create(status_bill, dayCreate_bill, note_bill, price_bill, debt_bill);
            return result;
        }

        //read
        public ActionResult pageUser(int? page, int? typeUserInput)
        {
            int typeUser;

            if (string.IsNullOrEmpty(Request["typeUser"])){
                typeUser = 0;
            }else {
                typeUser = Int32.Parse(Request["typeUser"]);
            }
            user tempUser = new user();
            List<user> allUser;
            string typeNameUser;
            if(typeUser == 2)
            {

                allUser = tempUser.queryDoctor();

                typeNameUser = "Doctor";

            }else if (typeUser == 4) {

                allUser = tempUser.queryPatient();

                typeNameUser = "Patient";

            }
            else if (typeUser == 3) {

                allUser = tempUser.querySecretary();

                typeNameUser = "Secretary";

            }
            else {

                allUser = tempUser.Read();

                typeNameUser = "All";

            }


            var pageNumber = page ?? 1;


            var onePageOfUsers = allUser.ToPagedList(pageNumber, 5);

            ViewBag.typeNameUser = typeNameUser;

            ViewBag.typeUser = typeUser;

            ViewBag.currnetPage = pageNumber;

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

        public ActionResult pagePatient(int? page) {
            user tempPatient = new user();

            var pageNumber = page ?? 1;

            var allPatient = tempPatient.queryPatient();

            var onePageOfPatients = allPatient.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfPatients = onePageOfPatients;

            return View();
        }
        public ActionResult pageIll(int? page)
        {
            user test = new user();

            string id_user = Request["id_user_patient"];

            ill tempIll = new ill();

            var allIll = tempIll.Read();

            var pageNumber = page ?? 1;

            var onePageOfIlls = allIll.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfIlls = onePageOfIlls;

            ViewBag.id_user_patient = id_user;

            ViewBag.totalDoctor = test.queryDoctor();

            List<string> allTooth = new List<string>();
            for (int n = 1; n <= 4; n++) {
                for (int i = 1; i <= 8; i++)
                {
                    allTooth.Add("R"+n+i);
                }
            }

            ViewBag.totalTooth = allTooth;

            return View();
        }

        public ActionResult pageCompany(int? page)
        {

            company tempCompany = new company();

            var allCompany = tempCompany.Read();

            var pageNumber = page ?? 1;

            var onePageOfCompanys = allCompany.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfCompanys = onePageOfCompanys;

            return View();
        }

        public ActionResult pageHistoryIll(int? page)
        {

            historyIll tempHistoryIll = new historyIll();

            var allHistoryIll = tempHistoryIll.Read();

            var pageNumber = page ?? 1;

            var onePageOfHistoryIlls = allHistoryIll.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfHistoryIlls = onePageOfHistoryIlls;

            return View();
        }

        public ActionResult pageCategory(int? page)
        {

            category tempCategory = new category();

            var allCategory = tempCategory.Read();

            var pageNumber = page ?? 1;

            var onePageOfCategorys = allCategory.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfCategorys = onePageOfCategorys;

            return View();
        }

        public ActionResult pageProduct(int? page)
        {

            product tempProduct = new product();

            var allProduct = tempProduct.Read();

            var pageNumber = page ?? 1;

            var onePageOfProducts = allProduct.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfProducts = onePageOfProducts;

            return View();
        }

        public ActionResult pageHistoryProduct(int? page)
        {

            historyproduct tempHistoryproduct = new historyproduct();

            var allHistoryproduct = tempHistoryproduct.Read();

            var pageNumber = page ?? 1;

            var onePageOfHistoryproducts = allHistoryproduct.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfHistoryproducts = onePageOfHistoryproducts;

            return View();
        }

        public ActionResult pageBill(int? page)
        {

            bill tempBill = new bill();

            var allBill = tempBill.Read();

            var pageNumber = page ?? 1;

            var onePageOfallBills = allBill.ToPagedList(pageNumber, 5);

            ViewBag.onePageOfallBills = onePageOfallBills;

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

        public bool updateCompany(int id_company, string name_company, string address_company, string phone_company, string email_company)
        {
            company Company = new company();
            bool result = Company.Update(id_company, name_company, address_company, phone_company, email_company);
            return result;
        }

        [Obsolete]
        public bool updateHistoryIll(int id_historyIll, DateTime dayUpdate_historyIll)
        {
            historyIll HistoryIll = new historyIll();
            bool result = HistoryIll.Update(id_historyIll, dayUpdate_historyIll);
            return result;
        }

        public bool updateProduct(int id_product, string name_product, float price_product, string note_product)
        {
            product Product = new product();
            bool result = Product.Update(id_product, name_product, price_product, note_product);
            return result;
        }

        public bool updateBill(int id_bill, string status_bill, DateTime dayCreate_bill, string note_bill, float price_bill, float debt_bill)
        {
            bill Bill = new bill();
            bool result = Bill.Update(id_bill, status_bill, dayCreate_bill, note_bill, price_bill, debt_bill);
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

        public bool deleteCompany(int id_company)
        {
            company Company = new company();
            bool result = Company.Delete(id_company);
            return result;
        }

        public bool deleteHistoryIll(int id_historyIll)
        {
            historyIll Company = new historyIll();
            bool result = Company.Delete(id_historyIll);
            return result;
        }

        public bool deleteProduct(int id_product)
        {
            product Product = new product();
            bool result = Product.Delete(id_product);
            return result;
        }

        public bool deleteBill(int id_bill)
        {
            bill Bill = new bill();
            bool result = Bill.Delete(id_bill);
            return result;
        }

        //Find user
        public ActionResult findUser(string nameInput) {
            user User = new user();
            List<user> result = new List<user>();
            result = User.findUser(nameInput);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }   //end class
}       //end namespace

