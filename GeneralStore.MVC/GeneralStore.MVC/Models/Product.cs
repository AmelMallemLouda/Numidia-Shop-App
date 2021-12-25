using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name =("Inventory Count"))]
        public int InventoryCount { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [Display(Name = ("It is Food"))]
        public bool IsFood { get; set; }
    }
}