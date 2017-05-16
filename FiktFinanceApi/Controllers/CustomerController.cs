using System;
using System.Web.Http;
using FiktFinanceApi.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace FiktFinanceApi.Controllers
{
    public class CustomerController : BaseController
    {
        [HttpGet]
        public List<Customer> GetData()
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            var customerList = new List<Customer>();
            var response = new Customer
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_Custumer_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var customer = new Customer
                        {
                            Status = ResponseStatus.Success,
                            Id = Convert.ToInt32(reader["IDCustumer"]),
                            Name = reader["Name"].ToString(),
                        };
                        response.Id = customer.Id;
                        response.Name = customer.Name;
                        customerList.Add(customer);
                    }
                    con.Close();
                }
                return customerList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                customerList.Add(response);
                return customerList;
            }
        }
    }
}
