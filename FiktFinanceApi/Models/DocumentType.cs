using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiktFinanceApi.Models
{
    public class DocumentType : BaseResponse
    {
        public int Id { get; set; }

        public string Flag { get; set; }
    }
}