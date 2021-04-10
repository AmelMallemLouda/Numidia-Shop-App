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


        [Display(Name = "Clothing Category ")]
        public int ClothingId { get; set; }

        [ForeignKey("ClothingId")]
        public virtual Clothing Clothing { get; set; }


        [Display(Name = "Home & Kitchen Category ")]
        public int HomeId { get; set; }

        [ForeignKey("HomeId")]
        public virtual HomeKitchen Home { get; set; }


        [Display(Name = "Beauty & Health Category ")]
        public int BeautyHealthId { get; set; }

        [ForeignKey("BeautyHealthId")]
        public virtual BeautyHealth BeautyHealth { get; set; }

       //public virtual List<Item> Items { get; set; } = new List<Item>();





    }
}
