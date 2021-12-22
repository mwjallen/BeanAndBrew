using BeanAndBrew.Data;
using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeanAndBrew.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ProcessOrder(OrderModel orderModel)
        {
            OrderDAO order = new OrderDAO();

            bool success = order.OrderCoffee(orderModel);

            if (success)
            {
                return View("Confirmation");
            }
            else
            {
                return View("Error");
            }
        }
    }
}