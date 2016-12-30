using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var db = new ApplicationDbContext();

                // TODO: Add insert logic here
                var transaction = new TransactionModel();
                transaction.Amount = Convert.ToDecimal(collection["Amount"]);
                transaction.userId = User.Identity.GetUserId();

                CheckingAccount ca = db.CheckingAccounts.First(cd => cd.ApplicationUserId == transaction.userId);

                transaction.CheckingAccountId = ca.Id;

                //saving to db
                db.TransactionModels.Add(transaction);
                db.SaveChanges();
                 return RedirectToAction("Index");
                //return RedirectToAction("Index", "Home");
            }
            //catch
            //{
            //    //return View();
            //}
            catch(Exception ex)
            {
                // Add useful information to the exception
                throw new ApplicationException("Something wrong happened in the transaction:", ex);
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
