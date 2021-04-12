using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data
{
    public class BeautyHealth
    {
        [Key]
        public int BeautyhealthId { get; set; }

        [Display(Name = "Beauty & Health")]
        public string BeautyHealthName { get; set; }

        public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
