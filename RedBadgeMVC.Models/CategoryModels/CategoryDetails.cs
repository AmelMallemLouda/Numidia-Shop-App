using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.CategoryModels
{
    public class CategoryDetails
    {
       
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        
      
        public int ClothingId { get; set; }
        public virtual Clothing Clothes { get; set; }


        public int HomeId { get; set; }
        public virtual HomeKitchen HomeKitchen { get; set; }


        public int BeautyID { get; set; }
        public virtual BeautyHealth BeautyHealth { get; set; }


    }
}
