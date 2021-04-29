using RedBadgeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RedBadgeMVC.Models.ItemModels
{
    public class ProductList
    {
         public List<Product>products { get; set; }
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Item Image")]
        public string ProductImage { get; set; }

        //[Display(Name = "Store Name")]
        //public string StoreName { get; set; }

        public List<Product> findAll()
        {
            return products;
        }

        public Product find(int id)
        {
            return products.Single(p => p.ProductId.Equals(id));
        }
    }
}
