using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.ItemModels
{
   public class ItemShortList
    {
        [Display(Name = "Note Id")]
        public int ItemId { get; set; }
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Display(Name = "Item Price")]
        public double Price { get; set; }
    }
}
