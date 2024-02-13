using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    public class Waiter
    {
        [Key]
        public int WaiterId { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name ="Last name")]
        public string LastName { get; set; }
        [Display(Name ="Phone number")]
        public int PhoneNumber { get; set; }
        [Display(Name ="Salary [zł]")]
        public float Salary { get; set; }
        public virtual List<Order> Orders { get; set; }
        public Waiter()
        {

        }

        public Waiter(string firstName, string lastName, int phoneNumber, float salary)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Salary = salary;
        }
    }
}