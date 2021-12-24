using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Models
{
    public class ShopModel
    {
        [Key]
        [Required]
        public int ShopId { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string ShopName { get; set; }
        [Required]
        [Display(Name = "No of Tables")]
        public int NoOfTables { get; set; }

        public ShopModel()
        {
            ShopId = -1;
            ShopName = "Unknown";
            NoOfTables = 0;
        }

        public ShopModel(int id, string restaurantName, int noOfTables)
        {
            ShopId = id;
            ShopName = restaurantName;
            NoOfTables = noOfTables;
        }
    }

    
}