using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingAppl.Models
{
    public class InvoiceTether
    {
        //stores and maintains the invoice data
        private IInvoiceStorage _invoiceStorage;

        //represents the unique Id that the invoice number will acquire
        private static int nextId;

        /// <summary>
        /// Static constructor needed to initialize the static field variables. Alternatively the variable 
        /// can be initialized inline when declared.
        /// </summary>
        static InvoiceTether()
        {

        }

        public void AddInvoice(Invoice invoice)
        {
            //assign the next available ID to the invoice
            invoice.Id = nextId++;

            //add the invoice to the store
            _invoiceStorage.AddInvoice(invoice);
        }

        /// <summary>
        /// Returns invoice with the given Id from the invoice tetherer
        /// </summary>
        /// <returns>the invoice object (if invoice found is not null)</returns>
        public Invoice GetInvoiceById(int invoiceId)
        {
            Invoice _invoice = _invoiceStorage.FindInvoiceById(invoiceId);

            if (_invoice == null)
            {
                return null;
            }
            return _invoice;
        }

        /// <summary>
        /// get enumerator of invoices that are unpaid for the user
        /// </summary>
        public IEnumerable<Invoice> ReceivableInvoiceList
        {
            get
            {
                return _invoiceStorage.ReceivableInvoiceList.Where(invoice => (invoice.HasPaid == false));
            }
        }

        /// <summary>
        /// Checks if a specific invoice exists in the invoice tetherer
        /// </summary>
        public bool ContainsInvoice(int invoiceId)
        {
            return _invoiceStorage.HasInvoice(invoiceId);
        }
    }
}
