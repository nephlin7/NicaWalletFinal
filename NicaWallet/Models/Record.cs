using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NicaWallet.Models
{
    [Table("Record")]
    public class Record
    {
        public int RecordId { get; set; }
        [Display(Name = "Monto")]
        public double? Amount { get; set; }
        [Display(Name = "Notas")]
        public string Note { get; set; }
        [Display(Name = "Es un ingreso?")]
        public bool PaymentType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RecordDate { get; set; }

        #region FOREINGKEYS
        [Display(Name = "Tipo de cuenta")]
        public int? AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Display(Name = "Currency")]
        public int? CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        #endregion
    }
}