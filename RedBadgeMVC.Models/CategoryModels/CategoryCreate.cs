using RedBadgeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.CategoryModels
{
    public class CategoryCreate
    {

        public string CategoryName { get; set; }
        [Required]
        public int ClothingId { get; set; }
        public virtual Clothing Clothes { get; set; }

        [Required]
        public int HomeId { get; set; }
        public virtual HomeKitchen HomeKitchen { get; set; }

        [Required]
        public int BeautyId { get; set; }
        public virtual BeautyHealth BeautyHealth { get; set; }


    }
}
