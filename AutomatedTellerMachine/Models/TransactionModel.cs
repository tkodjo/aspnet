using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^-?\+?\d+(\.\d+)?$", ErrorMessage = "Amount must be a natural number")]
        public Decimal Amount { get; set; }

        public string userId { get; set; }

        //settin foreign key for checking accounts
        public int CheckingAccountId { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }



    }
}