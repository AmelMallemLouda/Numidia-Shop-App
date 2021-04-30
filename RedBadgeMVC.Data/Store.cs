using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual List<Review> Reviews { get; set; } = new List<Review>();

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
