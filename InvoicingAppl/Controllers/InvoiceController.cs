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
        /// <summary>
        /// get method for adding an invoice (displays empty invoice)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddInvoice()
        {
            ViewBag.InvoiceFormScope = InvoiceFormType.Add;

            //empty invoice model object is passed
            return View("InvoiceForm", new InvoicingViewModel());
        }

        [HttpPost]
        public ActionResult AddInvoice(InvoicingViewModel invoiceView)
        {
            return View();
        }

        public ActionResult ReviewReceivables()
        {
            return View();
        }
    }
}