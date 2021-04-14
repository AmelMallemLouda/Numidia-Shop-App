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
   public class CategoryListItem
    {
     
        public int CategoryId { get; set; }

        [Display(Name = "Category Type")]
        public string CategoryName { get; set; }

        //public virtual List<ItemShortList> Items { get; set; } = new List<ItemShortList>();

    }
}
