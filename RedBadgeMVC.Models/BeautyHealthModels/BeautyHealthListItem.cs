using RedBadgeMVC.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.BeautyHealthModels
{
    public class BeautyHealthListItem
    {
        public int BeautyhealthId { get; set; }

        [Display(Name = "Beauty & Health")]
        public string BeautyHealthName { get; set; }

        public virtual List<ItemList> Items { get; set; } = new List<ItemList>();
    }
}
