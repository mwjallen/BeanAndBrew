using BeanAndBrew.Data;
using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeanAndBrew.Controllers
{
    public class CoffeeController : Controller
    {
        // GET: Coffee
        public ActionResult Index()
        {
            List<CoffeeViewModel> coffees = new List<CoffeeViewModel>();
            CoffeeDAO coffeeDAO = new CoffeeDAO();
            coffees = coffeeDAO.FetchAll();
            return View("Index", coffees);
        }

        public ActionResult Details(int id)
        {
            CoffeeViewModel coffee = new CoffeeViewModel();
            CoffeeDAO coffeeDAO = new CoffeeDAO();
            coffee = coffeeDAO.FetchOne(id);
            return View("Details", coffee);
        }
        [HttpGet]
        public ActionResult Order(int id)
        {
            ViewBag.id = id;
            ViewData["CoffeeId"] = id;
           return View("Order");
        }

        
    }
}