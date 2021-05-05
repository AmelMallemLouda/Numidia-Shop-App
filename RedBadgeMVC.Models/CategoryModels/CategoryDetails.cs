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
       
       
        public int CategoryId { get; set; }


        [Display(Name = "Category Type")]
        public string CategoryName { get; set; }
        [Display(Name = "Category Image")]
        public string CategoryImage { get; set; }
        public virtual List<ProductShortList> Items { get; set; } = new List<ProductShortList>();

        public string ItemImage { get; set; }

    }
}
