using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using FiktFinanceApi.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FiktFinanceApi.Controllers
{
    public class ItemsController : BaseController
    {
        [HttpGet]
        public List<Item> GetData()
        {
            List<Item> itemsList = new List<Item>();
            var conn = ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;
            var response = new Item
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_Items_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new Item
                        {
                            Id = Convert.ToInt32(reader["IDItem"]),
                            Name = reader["ItemName"].ToString(),
                            IdItemCategory = Convert.ToInt32(reader["IDItemCategory"]),
                            IdMetric = Convert.ToInt32(reader["IDMetric"]),
                            NetAmount = Convert.ToDecimal(reader["NetAmount"]),
                            IdCurrency = Convert.ToInt32(reader["IDCurrency"]),
                            TaxRate = Convert.ToInt16(reader["TaxRate"])
                        };
                        response.Id = item.Id;
                        response.Name = item.Name;
                        response.IdItemCategory = item.IdItemCategory;
                        response.IdMetric = item.IdMetric;
                        response.NetAmount = item.NetAmount;
                        response.IdCurrency = item.IdCurrency;
                        response.TaxRate = item.TaxRate;

                        itemsList.Add(response);

                    }
                    con.Close();
                }
                return itemsList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                itemsList.Add(response);
                return itemsList;
            }
        }
    }
}
