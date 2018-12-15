using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvoicingAppl.Models;

namespace InvoicingAppl.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// test method regarding the actual calculation of the invoice total
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            //arrange, act, and assert testing functionality for invoice total calculations
            Invoice inv = new Invoice();

            inv.ProdQuantity = 5;
            inv.UnitPrice = 10;

            Assert.AreEqual(50 * Invoice.TAX, inv.Tax, $"Tax calculation is incorrect.");
            Assert.AreEqual(50, inv.SubTotal, "Subtotal calculation is incorrect.");
            Assert.AreEqual(50 + 50 * Invoice.TAX, inv.Total, "Total calculation is incorrect.");
        }
    }
}
