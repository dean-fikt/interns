using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using FiktFinanceApi.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FiktFinanceApi.Controllers
{
    public class PaymentMethodController : BaseController
    {
        [HttpGet]
        public List<PaymentMethodFlag> GetData()
        {
            List<PaymentMethodFlag> payMethodList = new List<PaymentMethodFlag>();
            var conn = ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;
            var response = new PaymentMethodFlag
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_PaymentMethod_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var payMethod = new PaymentMethodFlag
                        {
                            Id = Convert.ToInt32(reader["IDPayMethod"]),
                            Flag = reader["FLag"].ToString()
                        };
                        response.Id = payMethod.Id;
                        response.Flag = payMethod.Flag;
                        payMethodList.Add(response);
                    }
                    con.Close();
                }
                return payMethodList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                payMethodList.Add(response);
                return payMethodList;
            }
        }

    }
}
