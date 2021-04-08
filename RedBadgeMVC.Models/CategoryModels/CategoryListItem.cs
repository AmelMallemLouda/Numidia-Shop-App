using RedBadgeMVC.Data;
using RedBadgeMVC.Models.BeautyHealthModels;
using RedBadgeMVC.Models.ClothingModels;
using RedBadgeMVC.Models.HomeKitchenModels;
using RedBadgeMVC.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.CategoryModels
{
   public class CategoryListItem
    {
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }

        //public string Name { get; set; }


        [Display(Name = "Clothing Category ")]
        public int ClothingId { get; set; }
        public virtual List<ClothingListItem> Clothes { get; set; }


        [Display(Name = "Home & Kitchen Category ")]
        public int HomeId { get; set; }
        public virtual HomeKitchen HomeKitchen { get; set; }


        [Display(Name = "Beauty & Health Category ")]
        public int BeautyId { get; set; }
        public virtual BeautyHealth BeautyHealth { get; set; }

    }
}
