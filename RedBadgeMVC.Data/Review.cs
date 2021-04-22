using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeMVC.Data
{
     public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string Reviews { get; set; }
        [Required]
        public Guid OwnerID { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [ForeignKey(nameof(Product))]
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
