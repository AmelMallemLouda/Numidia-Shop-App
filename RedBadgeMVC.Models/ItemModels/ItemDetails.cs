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
        [Required]
        [Display(Name = "Item Id")]
        public int ItemId { get; set; }
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

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }    }   
