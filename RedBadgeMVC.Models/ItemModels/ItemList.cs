using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.ItemModels
{
    public class ItemList
    {
        [Display(Name = "Item ID")]
        public int ItemId { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Item Price")]
        public double ItemPrice { get; set; }
        public int HomeId { get; set; }
        public string HomeName { get; set; }
    }
}
