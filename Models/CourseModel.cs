using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeanAndBrew.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public CourseModel()
        {
            CourseId = -1;
            Title = "A course";
            Description = "With or without baking";
            Date = DateTime.Now;
            Price = 0;
        }

        public CourseModel(int id, string name, string description, DateTime date, decimal price)
        {
            CourseId = id;
            Title = name;
            Description = description;
            Date = date;
            Price = price;
        }

    }
}