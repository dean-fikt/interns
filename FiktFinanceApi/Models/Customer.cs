using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiktFinanceApi.Models
{
    public class Customer : BaseResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}