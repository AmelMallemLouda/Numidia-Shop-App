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
    public class ProductEdit
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }


        [Display(Name = "Product Name")]
        public string ProductName { get; set; }


        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }


        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }


        [Display(Name = "Product Condition")]
        public string ProductCondition { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Display(Name = "Store ID")]
        public int StoreId { get; set; }
        public string ProductImage { get; set; }

    }
}
