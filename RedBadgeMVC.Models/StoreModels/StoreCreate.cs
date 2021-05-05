using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Models.StoreModels
{
   public  class StoreCreate
    {
        [Key]
        public int StoreId { get; set; }
        [Required]
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        [Required]
        [Display(Name = "Store Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }
        [Required]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }

       
        public int StoreImage { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }

    }
}
