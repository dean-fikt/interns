using System;
using System.Collections.Generic;
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
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
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
                        var invoiceItems = new InvoiceItems
                        {
                            Status = ResponseStatus.Success,
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
                        response.IdInvoiceItems = invoiceItems.IdInvoiceItems;
                        response.IdInvoice = invoiceItems.IdInvoice;
                        response.IdItem = invoiceItems.IdItem;
                        response.InQuantity = invoiceItems.InQuantity;
                        response.OutQuantity = invoiceItems.OutQuantity;
                        response.NetAmount = invoiceItems.NetAmount;
                        response.IdCurrency = invoiceItems.IdCurrency;
                        response.CurrencyValue = invoiceItems.CurrencyValue;
                        response.TaxRate = invoiceItems.TaxRate;
                        response.Discount = invoiceItems.Discount;

                        invoiceItemsList.Add(invoiceItems);
                       
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

        [HttpGet]
        public InvoiceItems GetData(int id)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            var response = new InvoiceItems
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_InvoiceItems_SelectID", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var invoiceItems = new InvoiceItems
                        {
                            Status = ResponseStatus.Success,
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
                        response.IdInvoiceItems = invoiceItems.IdInvoiceItems;
                        response.IdInvoice = invoiceItems.IdInvoice;
                        response.IdItem = invoiceItems.IdItem;
                        response.InQuantity = invoiceItems.InQuantity;
                        response.OutQuantity = invoiceItems.OutQuantity;
                        response.NetAmount = invoiceItems.NetAmount;
                        response.IdCurrency = invoiceItems.IdCurrency;
                        response.CurrencyValue = invoiceItems.CurrencyValue;
                        response.TaxRate = invoiceItems.TaxRate;
                        response.Discount = invoiceItems.Discount;
                    }
                    con.Close();
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                return response;
            }
        }

        [HttpPost]
        public InvoiceItems AddInvoiceItems(InvoiceItems response)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_InvoiceItems_Insert", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@IDInvoice", response.IdInvoice);
                    command.Parameters.AddWithValue("@IDItem", response.IdItem);
                    command.Parameters.AddWithValue("@INQuantity", response.InQuantity);
                    command.Parameters.AddWithValue("@OUTQuantity", response.OutQuantity);
                    command.Parameters.AddWithValue("@NetAmount", response.NetAmount);
                    command.Parameters.AddWithValue("@IDCurrency", response.IdCurrency);
                    command.Parameters.AddWithValue("@CurrencyValue", response.CurrencyValue);
                    command.Parameters.AddWithValue("@TaxRate", response.TaxRate);
                    command.Parameters.AddWithValue("@Discount", response.Discount);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                return response;
            }
        }

        [HttpPut]
        public InvoiceItems UpdateInvoiceItems(InvoiceItems response)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_InvoiceItems_Update", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@IDInvoiceItems", response.IdItem);
                    command.Parameters.AddWithValue("@IDInvoice", response.IdInvoice);
                    command.Parameters.AddWithValue("@IDItem", response.IdItem);
                    command.Parameters.AddWithValue("@INQuantity", response.InQuantity);
                    command.Parameters.AddWithValue("@OUTQuantity", response.OutQuantity);
                    command.Parameters.AddWithValue("@NetAmount", response.NetAmount);
                    command.Parameters.AddWithValue("@IDCurrency", response.IdCurrency);
                    command.Parameters.AddWithValue("@CurrencyValue", response.CurrencyValue);
                    command.Parameters.AddWithValue("@TaxRate", response.TaxRate);
                    command.Parameters.AddWithValue("@Discount", response.Discount);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                return response;
            }
        }



        [HttpDelete]
        public void DeleteInvoice(int id)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_InvoiceItems_Delete", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@IDInvoiceItems", id);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    //return "Deleted";
                }
            }
            catch (Exception ex)
            {
                //return "Request Failed";
            }
        }

    }
}
