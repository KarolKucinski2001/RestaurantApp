using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models.DbModels
{
    
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        [Display(Name ="Menu description")]
        public string MenuDescription { get; set; }
        [Display(Name ="Menu items")]
        public virtual List<MenuItem> MenuItems { get; set; }
        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }

        public Menu(string menuDescription)
        {
            MenuDescription = menuDescription;
            
        }
    }
}