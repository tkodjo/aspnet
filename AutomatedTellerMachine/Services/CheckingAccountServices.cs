using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Services
{
    public class CheckingAccountServices
    {
      private ApplicationDbContext db;

        public CheckingAccountServices(ApplicationDbContext dbcontext)
        {
            db = dbcontext;

        }

        public void CreateCheckingAccount(string FirstName, string LastName, decimal Balance, string ApplicationUserId)
        {
            // var db = new ApplicationDbContext();
            string AccountNumber = (123456 + db.CheckingAccounts.Count()).ToString().PadLeft(10, '0');

            var checkingAccount = new CheckingAccount { FirstName = FirstName, LastName = LastName, Balance = Balance, AccountNumber = AccountNumber, ApplicationUserId = ApplicationUserId };

            db.CheckingAccounts.Add(checkingAccount);
            db.SaveChanges();
            //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        }

    }
}