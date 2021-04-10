using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data
{
    public class HomeKitchen
    {
        [Key]
        public int HomeKitchenId { get; set; }

        [Display(Name = "Home & Kitchen")]
        public string HomeKitchenName { get; set; }
        //public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
