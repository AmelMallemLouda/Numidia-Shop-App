using RedBadgeMVC.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.HomeKitchenModels
{
   public class HomeKitchenListItem
    {
        [Key]
        public int HomeKitchenId { get; set; }

      [Display (Name= "Home & Kitchen")]
        public string HomeKitchenName { get; set; }

        //public virtual List<ItemList> Items { get; set; } = new List<ItemList>();
    }
}
