using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    public enum PaymentType { card,cash,blik}
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public PaymentType Payment { get; set; }
        public bool Paid { get; set; }
        public string Comments { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Waiter")]
        public int WaiterId { get; set; }
        public virtual Waiter Waiter {get;set;}
        [ForeignKey("TableSeating")]
        public int TableSeatingId { get; set; }
        public virtual TableSeating TableSeating { get; set; }
        
        public List<OrderMenuItem> OrderMenuItems { get; set; }
        public Order()
        {

        }

        public Order(PaymentType payment, bool paid, string comments)
        {
            Payment = payment;
            Paid = paid;
            Comments = comments;
        }
    }
}