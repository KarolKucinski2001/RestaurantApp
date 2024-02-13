using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        [Display(Name ="Name")]
        public string MenuItemName { get; set; }
        public int Calories { get; set; }
        public int Price { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public List<OrderMenuItem> OrderMenuItems { get; set; }
        public MenuItem()
        {
            
        }
        public virtual Menu Menu { get; set; }

    }
}