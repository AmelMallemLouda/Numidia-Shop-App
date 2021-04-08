using RedBadgeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.ItemModels
{
    public class ItemEdit
    {
        [Display(Name = "Item Id")]
        public int ItemId { get; set; }


        [Display(Name = "Item Name")]
        public string ItemName { get; set; }


        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }


        [Display(Name = "Item Price")]
        public double ItemPrice { get; set; }


        [Display(Name = "Item Condition")]
        public string ItemCondition { get; set; }

        public int CategoryId { get; set; }

    } 
}
