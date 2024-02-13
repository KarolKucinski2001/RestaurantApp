using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public virtual List<Order> Orders { get; set; }
        public Customer()
        {

        }
    }
}