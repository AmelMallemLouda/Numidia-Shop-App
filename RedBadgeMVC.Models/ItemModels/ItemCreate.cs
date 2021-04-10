using RedBadgeMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.ItemModels
{
   public  class ItemCreate
    {
        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        public double ItemPrice { get; set; }

        [Required]
        [Display(Name = "Item Condition")]
        public string ItemCondition { get; set; }


        [Display(Name = "Clothing Category ")]
        public int ClothingId { get; set; }

        
        public int categoryId { get; set; }
        
        public virtual Category category { get; set; }

        public int HomeId { get; set; }
        public int BautyId { get; set; }
        

    }
}
