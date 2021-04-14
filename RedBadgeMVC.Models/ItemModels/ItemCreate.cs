﻿using RedBadgeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.ItemModels
{
   public  class ItemCreate
    {
        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        public double ItemPrice { get; set; }

        [Required]
        [Display(Name = "Item Condition")]
        public string ItemCondition { get; set; }
        public int Quantity { get; set; }



        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

       

    }
}
