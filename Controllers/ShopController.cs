using BeanAndBrew.Data;
using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeanAndBrew.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            List<ShopModel> shops = new List<ShopModel>();
            ShopDAO shopDAO = new ShopDAO();
            shops = shopDAO.FetchAll();
            return View("Index", shops);
        }


        public ActionResult Details(int id)
        {
            ShopModel shop = new ShopModel();
            ShopDAO shopDAO = new ShopDAO();
            shop = shopDAO.FetchOne(id);
            return View("Details", shop);
        }
    }
}