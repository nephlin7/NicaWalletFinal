using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NicaWallet.Models
{
    [Table("Account")]
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string AccountName { get; set; }
        [Required]
        public double? Amount { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Color { get; set; }
        public string AccountIcon { get; set; }


        #region FOREINGKEYS        
        public int? CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        [Display(Name = "Account Type")]
        public int? AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }


        //public virtual ApplicationUser User { get; set; }

        #endregion
    }
}