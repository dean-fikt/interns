using System;
using System.Web.Http;
using FiktFinanceApi.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace FiktFinanceApi.Controllers
{
    public class DocumentController : BaseController
    {
        [HttpGet]
        public List<Document> GetData()
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            var documentList = new List<Document>();
            var response = new Document
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_Document_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var document = new Document
                        {
                            Id = Convert.ToInt32(reader["IDDocument"]),
                            Name = reader["DocumentName"].ToString(),
                            IdDocumentType = Convert.ToInt32(reader["IDDocumentType"])
                        };
                        response.Id = document.Id;
                        response.Name = document.Name;
                        response.IdDocumentType = document.IdDocumentType;
                        documentList.Add(response);
                    }
                    con.Close();
                }
                return documentList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                documentList.Add(response);
                return documentList;
            }
        }
    }
}

