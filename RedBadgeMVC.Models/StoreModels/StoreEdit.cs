using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.StoreModels
{
    public class StoreEdit
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
    }
}
