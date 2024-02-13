using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    public class OrderMenuItem
    {
        
        [Key]
        public int OrderMenuItemId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
        public OrderMenuItem()
        {
            Orders = new List<Order>();
            MenuItems = new List<MenuItem>();
        }
        public OrderMenuItem(int quantity, float unitPrice)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            Orders = new List<Order>();
            MenuItems = new List<MenuItem>();
        }


    }
}