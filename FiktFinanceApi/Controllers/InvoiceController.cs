using System;
using System.Web.Http;
using FiktFinanceApi.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace FiktFinanceApi.Controllers
{
    public class InvoiceController : BaseController
    {
        [HttpGet]
        public List<Invoice> GetData()
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            var invoiceList = new List<Invoice>();
            var response = new Invoice
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_DocumentType_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var invoice = new Invoice
                        {
                            Status = ResponseStatus.Success,
                            Id = Convert.ToInt32(reader["IDInvoice"]),
                            InvoiceNumber = Convert.ToInt32(reader["InvoiceNumber"]),
                            InvoiceYear = Convert.ToInt32(reader["InvoiceDate"]),
                            IdCustomer = Convert.ToInt32(reader["IDCustumer"]),
                            InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                            IdDocument = Convert.ToInt32(reader["IDDocument"]),
                            ExternalInvoiceNumber = reader["ExternalInvoiceNumber"].ToString(),
                            ExternallInvoiceDate = Convert.ToDateTime(reader["ExternalInvoiceDate"]),
                            IdUser = Convert.ToInt32(reader["IDUser"]),
                            Description = reader["Description"].ToString(),
                            IdPayMethod = Convert.ToInt32(reader["IDPayMethod"]),
                            DueDate = Convert.ToDateTime(reader["DueDate"]),
                            Paid = Convert.ToBoolean(reader["Paid"]),
                            PaidDate = Convert.ToDateTime(reader["PaidDate"])
                        };
                        response.Id = invoice.Id;
                        response.InvoiceNumber = invoice.InvoiceNumber;
                        response.InvoiceYear = invoice.InvoiceYear;
                        response.IdCustomer = invoice.IdCustomer;
                        response.InvoiceDate = invoice.InvoiceDate;
                        response.IdDocument = invoice.IdDocument;
                        response.ExternalInvoiceNumber = invoice.ExternalInvoiceNumber;
                        response.ExternallInvoiceDate = invoice.ExternallInvoiceDate;
                        response.IdUser = invoice.IdUser;
                        response.Description = invoice.Description;
                        response.IdPayMethod = invoice.IdPayMethod;
                        response.DueDate = invoice.DueDate;
                        response.Paid = invoice.Paid;
                        response.PaidDate = invoice.PaidDate;
                        invoiceList.Add(invoice);
                    }
                    con.Close();
                }
                return invoiceList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                invoiceList.Add(response);
                return invoiceList;
            }
        }

        [HttpGet]
        public Invoice GetData(int id)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            var response = new Invoice
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_DocumentType_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var invoice = new Invoice
                        {
                            Status = ResponseStatus.Success,
                            Id = Convert.ToInt32(reader["IDInvoice"]),
                            InvoiceNumber = Convert.ToInt32(reader["InvoiceNumber"]),
                            InvoiceYear = Convert.ToInt32(reader["InvoiceDate"]),
                            IdCustomer = Convert.ToInt32(reader["IDCustumer"]),
                            InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                            IdDocument = Convert.ToInt32(reader["IDDocument"]),
                            ExternalInvoiceNumber = reader["ExternalInvoiceNumber"].ToString(),
                            ExternallInvoiceDate = Convert.ToDateTime(reader["ExternalInvoiceDate"]),
                            IdUser = Convert.ToInt32(reader["IDUser"]),
                            Description = reader["Description"].ToString(),
                            IdPayMethod = Convert.ToInt32(reader["IDPayMethod"]),
                            DueDate = Convert.ToDateTime(reader["DueDate"]),
                            Paid = Convert.ToBoolean(reader["Paid"]),
                            PaidDate = Convert.ToDateTime(reader["PaidDate"])
                        };
                        response.Id = invoice.Id;
                        response.InvoiceNumber = invoice.InvoiceNumber;
                        response.InvoiceYear = invoice.InvoiceYear;
                        response.IdCustomer = invoice.IdCustomer;
                        response.InvoiceDate = invoice.InvoiceDate;
                        response.IdDocument = invoice.IdDocument;
                        response.ExternalInvoiceNumber = invoice.ExternalInvoiceNumber;
                        response.ExternallInvoiceDate = invoice.ExternallInvoiceDate;
                        response.IdUser = invoice.IdUser;
                        response.Description = invoice.Description;
                        response.IdPayMethod = invoice.IdPayMethod;
                        response.DueDate = invoice.DueDate;
                        response.Paid = invoice.Paid;
                        response.PaidDate = invoice.PaidDate;
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
        public Invoice AddInvoice(Invoice response)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_Invoice_Insert", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@InvoiceNumber", response.InvoiceNumber);
                    command.Parameters.AddWithValue("@InvoiceYear", response.InvoiceYear);
                    command.Parameters.AddWithValue("@IDCustumer", response.IdCustomer);
                    command.Parameters.AddWithValue("@InvoiceDate", response.InvoiceDate);
                    command.Parameters.AddWithValue("@IDDocument", response.IdDocument);
                    command.Parameters.AddWithValue("@ExternalInvoiceNumber", response.ExternalInvoiceNumber);
                    command.Parameters.AddWithValue("@ExternalInvoiceDate", response.ExternallInvoiceDate);
                    command.Parameters.AddWithValue("@IDUser", response.IdUser);
                    command.Parameters.AddWithValue("@Description", response.Description);
                    command.Parameters.AddWithValue("@IDPayMethod", response.IdPayMethod);
                    command.Parameters.AddWithValue("@DueDate", response.DueDate);
                    command.Parameters.AddWithValue("@Paid", response.Paid);
                    command.Parameters.AddWithValue("@PaidDate", response.PaidDate);
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
        public Invoice UpdateInvoice(Invoice response)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_Invoice_Update", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@IDInvoice", response.Id);
                    command.Parameters.AddWithValue("@InvoiceNumber", response.InvoiceNumber);
                    command.Parameters.AddWithValue("@InvoiceYear", response.InvoiceYear);
                    command.Parameters.AddWithValue("@IDCustumer", response.IdCustomer);
                    command.Parameters.AddWithValue("@InvoiceDate", response.InvoiceDate);
                    command.Parameters.AddWithValue("@IDDocument", response.IdDocument);
                    command.Parameters.AddWithValue("@ExternalInvoiceNumber", response.ExternalInvoiceNumber);
                    command.Parameters.AddWithValue("@ExternalInvoiceDate", response.ExternallInvoiceDate);
                    command.Parameters.AddWithValue("@IDUser", response.IdUser);
                    command.Parameters.AddWithValue("@Description", response.Description);
                    command.Parameters.AddWithValue("@IDPayMethod", response.IdPayMethod);
                    command.Parameters.AddWithValue("@DueDate", response.DueDate);
                    command.Parameters.AddWithValue("@Paid", response.Paid);
                    command.Parameters.AddWithValue("@PaidDate", response.PaidDate);
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
        public string DeleteInvoice(int ID)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_Invoice_Delete", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@IDInvoice", ID);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    return "Deleted";
                }
            }
            catch (Exception ex)
            {
                return "Request Failed";
            }
        }
    }
}
