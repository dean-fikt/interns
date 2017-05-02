using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiktFinanceApi.Models;

namespace FiktFinanceApi.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public TestResponse GetData(int parametarId)
        {
            var conn = ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;
            var response = new TestResponse
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("ime na procedurata", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("ime na oarametarot", parametarId);
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var test = new TestResponse
                        {
                            Id = Convert.ToInt32(reader["ime na parametarot"]),
                            Name = reader["ime na prametarot"].ToString(),
                        };
                        response.Id = test.Id;
                        response.Name = test.Name;
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
    }
}
