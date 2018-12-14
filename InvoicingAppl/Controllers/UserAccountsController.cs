using InvoicingAppl.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingAppl.Controllers
{
    public class UserAccountsController : Controller
    {
        /// <summary>
        /// get and post methods that display the login view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User _user, string roleType)
        {
            //check if model is valid
            if (ModelState.IsValid)
            {
                //validate user password
                if (_user.Check() == false)
                {
                    //the password is incorrect, add an error to the model and return
                    ModelState.AddModelError("Password", "Invalid password.");

                    return View(_user);
                }

                //the user role
                UserRole role;

                //determine the user role
                if(roleType == "Manager Login" ) { role = UserRole.Manager; }
                else { role = UserRole.User; }

                //check the role that was requested. Only two manager users exist per requirements: Amanda and Ray
                if (CheckRole(_user, role))
                {
                    //assign role to the user
                    _user.Role = role;
                }
                else
                {
                    //return to the login form if the user is not authorized for this role
                    return RedirectToAction("Login");
                }

                //save the user in the session data
                Session["saved_user"] = _user;

                //check role and display the appropriate view      
                switch (_user.Role)
                {
                    case UserRole.User:
                        return RedirectToAction("AddInvoice", "Invoice");   //display view for normal user role

                    case UserRole.Manager:
                        return RedirectToAction("ReviewReceivables", "Invoice");    //display view for manager role

                    default:
                        //revert to the view for user if role is unknown
                        return RedirectToAction("AddInvoice", "Invoicing");
                }
            }
            else
            {
                //return to the login to ask user to enter correct information 
                return View(_user);
            }
        }

        /// <summary>
        /// validates whether the user is has the correct role 
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool CheckRole(User _user, UserRole role)
        {
            switch (role)
            {
                case UserRole.User:
                    return true;

                case UserRole.Manager:
                    return _user.UserName == "Amanda" || _user.UserName == "Ray";

                default:
                    return false;
            }
        }
    }
}