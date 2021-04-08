using RedBadgeMVC.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.ClothingModels
{
    public class ClothingListItem
    {
        public int ClothingId { get; set; }
        [Display(Name = "Clothing")]
        public string ClothingName { get; set; }
       // public virtual List<ItemList> Items { get; set; } = new List<ItemList>();
    }
}
