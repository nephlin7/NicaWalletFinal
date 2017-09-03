using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NicaWallet.Models
{
    [Table("Category")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> ParentId { get; set; }
        public bool? IsParent { get; set; }
        public string CategoryIcon { get; set; }
    }
}