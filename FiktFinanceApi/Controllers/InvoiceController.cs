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
    }
}
