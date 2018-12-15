using System.Collections.Generic;

namespace InvoicingAppl.Models
{
    internal interface IInvoiceStorage
    {
        int InvoiceCounter { get; set; }
        IEnumerable<Invoice> ReceivableInvoiceList { get; set; }

        void AddInvoice(Invoice invoice);
        Invoice FindInvoiceById(int invoiceId);
        bool HasInvoice(int invoiceId);
    }
}