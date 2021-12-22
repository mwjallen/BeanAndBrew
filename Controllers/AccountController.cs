using BeanAndBrew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeanAndBrew.Models
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ProcessLogin(AccountModel accountModel)
        {
            AccountDAO accountDAO = new AccountDAO();
            string email = accountModel.Email;
            string password = accountModel.Password;

            int role = accountDAO.ValidateLogin(email, password);

            switch (role)
            {
                case 0:
                    return View("UserView");

                case 1:
                    return View("AdminView");

                default:
                    return View();
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ProcessRegistration(AccountModel accountModel)
        {
            AccountDAO accountDAO = new AccountDAO();
            bool success = accountDAO.RegisterAccount(accountModel);
            if (success)
            {
                return View("Login");
            }
            else
            {
                return View("Error");
            }
        }
    }
}