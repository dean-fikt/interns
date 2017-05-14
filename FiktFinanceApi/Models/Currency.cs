using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiktFinanceApi.Models
{
    public class Currency : BaseResponse
    {
        public int Id { get; set; }

        public string CurrencyName { get; set; }

        public decimal CurrencyValue { get; set;}
    }
}