using InvoicingAppl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingAppl.Controllers
{
    public class UserAccountsController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User _user, string roleType)
        {
            return View();
        }
    }
}