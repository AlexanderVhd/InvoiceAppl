using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingAppl.Models
{
    public enum InvoiceFormType
    {
        Add,
        Edit
    }

    /// <summary>
    /// Represents the view model for the invoice (the view files deal with this model directly)
    /// </summary>
    public class InvoicingViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public InvoicingViewModel()
        {

        }

        /// <summary>
        /// Constructor that initializes an invoice view model from an actual view domain object
        /// </summary>
        /// <param name="invoice"></param>
        public InvoicingViewModel(Invoice _invoice)
        {
            this.Id = _invoice.Id;
            this.ClientName = _invoice.ClientName;
            this.ClientAddress = _invoice.ClientAddress;
            this.ProductName = _invoice.ProductName;
            this.ProdQuantity = _invoice.ProdQuantity;
            this.UnitPrice = _invoice.UnitPrice;
            this.ShipDate = _invoice.ShipDate.ToString("yyyy-MM-dd");
            this.PaymentDueDate = _invoice.PaymentDueDate.ToString("yyyy-MM-dd");
            this.Currency = _invoice.Currency;
            this.SubTotal = _invoice.SubTotal;
            this.Tax = _invoice.Tax;
            this.Total = _invoice.Total;
        }

        /// <summary>
        /// get set property of the Id
        /// </summary>
        [HiddenInput]
        public int Id { get; set; }

        /// <summary>
        /// get set property of the clientName
        /// </summary>
        [Required(ErrorMessage = "Please provide client name")]
        public string ClientName { get; set; }

        /// <summary>
        /// get set property of the clientAddress
        /// </summary>
        [Required(ErrorMessage = "Please provide client address")]
        public string ClientAddress { get; set; }

        /// <summary>
        /// get set property of the productName
        /// </summary>
        [Required(ErrorMessage = "Please provide product name")]
        public string ProductName { get; set; }

        /// <summary>
        /// get set property of the productQuantity
        /// </summary>
        [Required(ErrorMessage = "Please specify product quantity")]
        public int? ProdQuantity { get; set; }

        /// <summary>
        /// get set property of the unitPrice
        /// </summary>
        [Required(ErrorMessage = "Please specify the unit price for the product")]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// get set property of the ShipDate
        /// </summary>
        [Required(ErrorMessage = "Please specify a valid shipment date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string ShipDate { get; set; }

        /// <summary>
        /// get set property of the paymentDueDate
        /// </summary>
        [Required(ErrorMessage = "Please specify a valid payment date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string PaymentDueDate { get; set; }

        /// <summary>
        /// get set property of the currency
        /// </summary>
        [Required(ErrorMessage = "Please select a currency")]
        [DataType(DataType.Currency)]
        public Currency? Currency { get; set; }

        /// <summary>
        /// get properties of the calculation parameters
        /// </summary>
        public decimal SubTotal { get; }
        public decimal Tax { get; }
        public decimal Total { get; }

        public Invoice Invoice
        {
            get
            {
                //create invoice using model info
                Invoice invoice = new Invoice(this.Id);
                UpdateInvoice(invoice);
                return invoice;
            }
        }

        public void UpdateInvoice(Invoice invToUpdate)
        {
            //create an invoice using model info
            invToUpdate.ClientName = this.ClientName;
            invToUpdate.ClientAddress = this.ClientAddress;
            invToUpdate.ProductName = this.ProductName;
            invToUpdate.ProdQuantity = this.ProdQuantity.Value;
            invToUpdate.UnitPrice = this.UnitPrice.Value;
            invToUpdate.ShipDate = DateTime.Parse(this.ShipDate);
            invToUpdate.PaymentDueDate = DateTime.Parse(this.PaymentDueDate);
            invToUpdate.Currency = this.Currency.Value;
        }
    
    }
}