using BeanAndBrew.Data;
using BeanAndBrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeanAndBrew.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            List<CourseModel> courses = new List<CourseModel>();
            CourseDAO courseDAO = new CourseDAO();
            courses = courseDAO.FetchAll();
            return View("Index", courses);
        }


        public ActionResult Details(int id)
        {
            CourseModel course = new CourseModel();
            CourseDAO courseDAO = new CourseDAO();
            course = courseDAO.FetchOne(id);
            return View("Details", course);
        }
    }
}