using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data
{
    public class Clothing
    {
        [Key]
        public int ClothingId { get; set; }

        [Display(Name = "Clothing")]
        public string ClothingName { get; set; }
      // public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
