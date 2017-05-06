using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiktFinanceApi.Models
{
    public class InvoiceItems : BaseResponse
    {
        public int IdInvoiceItems { get; set; }

        public int IdItem { get; set; }

        public decimal InQuantity { get; set; }

        public decimal OutQuantity { get; set; }

        public decimal NetAmount { get; set; }

        public int IdCurrency { get; set; }

        public decimal CurrencyValue { get; set; }

        public int TaxRate { get; set; }

        public int Discount { get; set; }
    }
}