using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        [Display(Name="Coffee Id")]
        [Required]
        public int CoffeeId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Name { get; set; }
    }
}