using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public Guid OwnerID { get; set; }

        [Display(Name = "Category Type")]
        [MaxLength(100, ErrorMessage = "Too long characters")]

        public string CategoryName { get; set; }

        [Display(Name = "Category Image")]
        public string CategoryImage { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();

        

    }
}
