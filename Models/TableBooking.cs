using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Models
{
    public class TableBooking
    {
        [Key]
        public int BookingId { get; set; }
        public string Restaurant { get; set; }
        public int NoOfTables { get; set; }
        public DateTime BookingDate { get; set; }
    }
}