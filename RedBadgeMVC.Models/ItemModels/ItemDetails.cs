using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.ItemModels
{
    public class ItemDetails
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


        [Display(Name = "Item Quantity")]
        public int Quantity { get; set; }


       
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }  
}   
