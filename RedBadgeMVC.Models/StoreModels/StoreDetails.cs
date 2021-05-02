using RedBadgeMVC.Data;
using RedBadgeMVC.Models.ItemModels;
using RedBadgeMVC.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.StoreModels
{
    public class StoreDetails
    {
        public int StoreId { get; set; }
       
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
       
        [Display(Name = "Store Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }
        [Required]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }

      
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string ItemImage { get; set; }
        public virtual List<ProductShortList> Items { get; set; } = new List<ProductShortList>();

        public virtual List<ReviewListItem> Reviews { get; set; } = new List<ReviewListItem>();
    }
}
