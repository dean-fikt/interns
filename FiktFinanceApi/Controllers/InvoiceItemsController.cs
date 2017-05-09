using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using FiktFinanceApi.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FiktFinanceApi.Controllers
{
    public class InvoiceItemsController : BaseController
    {
        [HttpGet]
        public List<InvoiceItems> GetData()
        {
            List<InvoiceItems> invoiceItemsList = new List<InvoiceItems>();
            var conn = ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;
            var response = new InvoiceItems
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_InvoiceItems_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var invoice = new InvoiceItems
                        {
                            IdInvoiceItems = Convert.ToInt32(reader["IDInvoiceItems"]),
                            IdInvoice = Convert.ToInt32(reader["IDInvoice"]),
                            IdItem = Convert.ToInt32(reader["IDItem"]),
                            InQuantity = Convert.ToDecimal(reader["INQuantity"]),
                            OutQuantity = Convert.ToDecimal(reader["OUTQuantity"]),
                            NetAmount = Convert.ToDecimal(reader["NetAmount"]),
                            IdCurrency = Convert.ToInt32(reader["IDCurrency"]),
                            CurrencyValue = Convert.ToDecimal(reader["CurrencyValue"]),
                            TaxRate = Convert.ToInt16(reader["TaxRate"]),
                            Discount = Convert.ToInt16(reader["Discount"])
                        };
                        response.IdInvoiceItems = invoice.IdInvoiceItems;
                        response.IdInvoice = invoice.IdInvoice;
                        response.IdItem = invoice.IdItem;
                        response.InQuantity = invoice.InQuantity;
                        response.OutQuantity = invoice.OutQuantity;
                        response.NetAmount = invoice.NetAmount;
                        response.IdCurrency = invoice.IdCurrency;
                        response.CurrencyValue = invoice.CurrencyValue;
                        response.TaxRate = invoice.TaxRate;
                        response.Discount = invoice.Discount;

                        invoiceItemsList.Add(response);
                       
                    }
                    con.Close();
                }
                return invoiceItemsList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                invoiceItemsList.Add(response);
                return invoiceItemsList;
            }
        }
    }
}
