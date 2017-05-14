using System;
using System.Web.Http;
using FiktFinanceApi.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace FiktFinanceApi.Controllers
{
    public class DocumentTypeController : BaseController
    {
        [HttpGet]
        public List<DocumentType> GetData()
        {
            var conn = ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;
            var documentTypeList = new List<DocumentType>();
            var response = new DocumentType
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
                        var customer = new DocumentType
                        {
                            Id = Convert.ToInt32(reader["IDCustumerDocumentType"]),
                            Flag = reader["Flag"].ToString(),
                        };
                        response.Id = customer.Id;
                        response.Flag = customer.Flag;
                        documentTypeList.Add(response);
                    }
                    con.Close();
                }
                return documentTypeList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                documentTypeList.Add(response);
                return documentTypeList;
            }
        }
    }
}
