using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiktFinanceApi.Models
{
    public class Item : BaseResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdItemCategory { get; set; }

        public int IdMetric { get; set; }

        public decimal NetAmount { get; set; }

        public int IdCurrency { get; set; }

        public int TaxRate { get; set; }
    }

}