﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"\d{6,10}",ErrorMessage ="Account number must between 6 to 10 numbers")]
        [Column(TypeName ="varchar")]
        [Display(Name="Account #")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Name {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<TransactionModel> Transactions { get; set; }

    }
}