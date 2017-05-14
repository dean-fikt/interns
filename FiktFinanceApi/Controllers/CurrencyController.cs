using System;
using System.Collections.Generic;
using System.Web.Http;
using FiktFinanceApi.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FiktFinanceApi.Controllers
{
    public class CurrencyController : BaseController
    {
        [HttpGet]
        public List<Currency> GetData()
        {
            var conn = ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;
            var currencyList = new List<Currency>();
            var response = new Currency
            {
                Status = ResponseStatus.Success,
            };
            
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_Currency_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var currency = new Currency
                        {
                            Id = Convert.ToInt32(reader["IDCurrency"]),
                            CurrencyName = reader["Currency"].ToString(),
                            CurrencyValue = Convert.ToDecimal(reader["CurrencyValue"])
                        };
                        response.Id = currency.Id;
                        response.CurrencyName = currency.CurrencyName;
                        response.CurrencyValue = currency.CurrencyValue;
                        currencyList.Add(response);
                    }
                    con.Close();
                }
                return currencyList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                currencyList.Add(response);
                return currencyList;
            }
        }
    }
}
