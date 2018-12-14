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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
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