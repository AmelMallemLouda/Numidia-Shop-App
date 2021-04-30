using RedBadgeMVC.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.StoreModels
{
    public class StoreListItem
    {
        public int StoreId { get; set; }

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public virtual List<ProductShortList> Items { get; set; } = new List<ProductShortList>();
    }
}
