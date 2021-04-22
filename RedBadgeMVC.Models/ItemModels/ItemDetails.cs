using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.ItemModels
{
    public class ProductDetails
    {
        [Display(Name = "Item Id")]
        public int ProductId { get; set; }
       
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }

        
        [Display(Name = "Product Condition")]

        public string ProductCondition { get; set; }


        [Display(Name = "Product Quantity")]
        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [Display(Name = "Store ID")]
        public int StoreId { get; set; }
        [Display(Name = "Image")]
        public string ItemImage { get; set; }
        public virtual List<ReviewListItem> Reviews { get; set; } = new List<ReviewListItem>();

    }
}   
