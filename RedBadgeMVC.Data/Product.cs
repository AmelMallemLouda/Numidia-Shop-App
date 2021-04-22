using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RedBadgeMVC.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
       
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be greater than 50 characters")]
        [MinLength(3, ErrorMessage = "Name cannot be less than 3 characters")]
        public string ProductName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description cannot be less than 10")]
        public string ProductDescription { get; set; }

        [Required]
        public double ProductPrice { get; set; }
        public Guid OwnerID { get; set; }
        [Required]
        public string ItemCondition { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
       
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(Store))]
        [Required]
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public virtual List<Review> Reviews { get; set; } = new List<Review>();



    }
}
