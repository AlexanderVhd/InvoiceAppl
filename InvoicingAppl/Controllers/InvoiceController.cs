using InvoicingAppl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingAppl.Controllers
{
    public class InvoiceController : Controller
    {
        public string InvoiceTether { get; private set; }

        /// <summary>
        /// get method for adding an invoice (displays empty invoice)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddInvoice()
        {
            ViewBag.InvoiceFormScope = InvoiceFormType.Add;

            //empty invoice model object is passed
            return View("InvoicePage", new InvoicingViewModel());
        }

        [HttpPost]
        public ActionResult AddInvoice(InvoicingViewModel invoiceView)
        {
            if (ModelState.IsValid)
            {
                //allow the user to add the next invoice
                return RedirectToAction("AddInvoice");
            }
            else
            {
                //display the invoice form since 
                ViewBag.InvoiceFormScope = InvoiceFormType.Add;
                return View("InvoicePage", invoiceView);
            }
        }

        /// <summary>
        /// action method that allows managers to view list of recievables
        /// </summary>
        /// <returns></returns>
        public ActionResult ReviewReceivables()
        {
            User user = Session["Session_User"] as User;

            //check whether the current user is eligible for this operation. If not send the user to the login page
            if (user.Role != UserRole.Manager)
            {
                return RedirectToAction("Login", "UserAccounts");
            }

            return View("ReceivablesPage", this.InvoiceTether);
        }

        [HttpGet]
        public ActionResult EditInvoice(int _invoiceId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditInvoice()
        {
            return View();
        }
    }
}