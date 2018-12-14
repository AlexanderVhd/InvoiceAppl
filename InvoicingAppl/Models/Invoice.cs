using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingAppl.Models
{
    /// <summary>
    /// type of currency for an invoice
    /// </summary>
    public enum Currency
    {
        CAD = 1,
        US = 2,
        EUR = 3
    }

    public class Invoice
    {
        //Id of the invoice
        private int _id;

        //attributes of the invoice
        private string clientName;
        private string clientAddress;

        private string productName;
        private int productQuantity;
        private decimal unitPrice;

        private DateTime? shipDate;
        private DateTime? paymentDueDate;
        private Currency? currency;

        //10% tax rate for the invoice
        public const decimal TAX = 0.1m;

        /// <summary>
        /// Invoice constructor 
        /// </summary>
        /// <param name="id"></param>
        public Invoice(int id)
        {
            //initialize the ID of invoice
            _id = id;

            //initialize invoice information
            clientName = string.Empty;
            clientAddress = string.Empty;
            productName = string.Empty;
            productQuantity = 0;
            unitPrice = 0;
            shipDate = null;
            paymentDueDate = null;
            currency = null;
        }

        /// <summary>
        /// get set property of Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// get set property of clientName
        /// </summary>
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        /// <summary>
        /// get set property of clientAddress 
        /// </summary>
        public string ClientAddress
        {
            get { return clientAddress; }
            set { clientAddress = value; }
        }

        /// <summary>
        /// get set property of ProductName
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        /// <summary>
        /// get set property of ProdQuantity
        /// </summary>
        public int ProdQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }

        /// <summary>
        /// Provides read-write access to the product unit price. This property is required. 
        /// </summary>
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        /// <summary>
        /// get set property of ShipDate
        /// </summary>
        public DateTime ShipDate
        {
            get { return shipDate.Value; }
            set { shipDate = value; }
        }

        /// <summary>
        /// get set property of PaymentDueDate
        /// </summary>
        public DateTime PaymentDueDate
        {
            get { return paymentDueDate.Value; }
            set { paymentDueDate = value; }
        }

        /// <summary>
        /// get set property of Currency
        /// </summary>
        public Currency Currency
        {
            get { return currency.Value; }
            set { currency = value; }
        }

        /// <summary>
        /// property that calculates the subtotal. 
        /// </summary>
        public decimal SubTotal
        {
            get { return unitPrice * productQuantity; }
        }

        /// <summary>
        /// property that calculates the taxes 
        /// </summary>
        public decimal Tax
        {
            get { return SubTotal * TAX; }
        }

        /// <summary>
        /// property that calculates the total amount of the invoice
        /// </summary>
        public decimal Total
        {
            get { return SubTotal + Tax; }
        }

        /// <summary>
        /// Update current invoice with the values of the given invoice 
        /// </summary>
        /// <param name="invoice"></param>
        public void Update(Invoice invoice)
        {
            _id = invoice.Id;

            clientName = invoice.ClientName;
            clientAddress = invoice.ClientAddress;

            productName = invoice.ProductName;
            productQuantity = invoice.ProdQuantity;

            shipDate = invoice.ShipDate;
            paymentDueDate = invoice.PaymentDueDate;
            unitPrice = invoice.UnitPrice;
            currency = invoice.Currency;
        }
    }
}