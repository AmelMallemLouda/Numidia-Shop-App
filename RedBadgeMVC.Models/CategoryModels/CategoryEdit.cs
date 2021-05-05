using RedBadgeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.CategoryModels
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
      
    }
}
