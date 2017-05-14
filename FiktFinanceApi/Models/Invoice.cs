using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiktFinanceApi.Models
{
    public class Invoice : BaseResponse
    {
        public int Id { get; set; }

        public int InvoiceNumber { get; set; }

        public int InvoiceYear { get; set; }

        public int IdCustomer { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int IdDocument { get; set; }

        public string ExternalInvoiceNumber { get; set; }

        public DateTime ExternallInvoiceDate { get; set; }

        public int IdUser { get; set; }

        public string Description { get; set; }

        public int IdPayMethod { get; set; }

        public DateTime DueDate { get; set; }

        public bool Paid { get; set; }

        public DateTime PaidDate { get; set; }
    }
}