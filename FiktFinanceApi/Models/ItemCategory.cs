using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiktFinanceApi.Models
{
    public class ItemCategory : BaseResponse
    {
        public int IdItemCategory { get; set; }

        public string ItemCategoryName { get; set; }
    }
}