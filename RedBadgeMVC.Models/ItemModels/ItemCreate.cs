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
   public  class ProductCreate
    {
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }

        [Required]
        [Display(Name = "Product Condition")]
        public string ProductCondition { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [Display(Name = "Store ID")]
        public int StoreId { get; set; }



    }
}
