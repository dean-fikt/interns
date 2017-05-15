using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FiktFinanceApi.Controllers
{
    public class BaseController : ApiController
    {
        public string ConnectionStringName()
        {
            return System.Configuration.ConfigurationManager.AppSettings["connectionString"];

         }
    }
}