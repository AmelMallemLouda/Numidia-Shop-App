using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int CustomerId { get; set; }

        //to bring Customer object
        public Customer customer { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }

        [Required]
        public double Price { get; set; }
        public DateTimeOffset DateOfTransaction { get; set; }


}   }