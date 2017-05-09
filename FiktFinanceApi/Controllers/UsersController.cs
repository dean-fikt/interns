using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using FiktFinanceApi.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FiktFinanceApi.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public List<User> GetData()
        {
            List<User> userList = new List<User>();
            var conn = ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;
            var response = new User
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_User_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            FirstName = reader["UserName"].ToString(),
                            LastName = reader["UserSurname"].ToString(),
                            Email = reader["UserEmail"].ToString()
                        };
                        response.FirstName = user.FirstName;
                        response.LastName = user.LastName;
                        response.Email = user.Email;

                        userList.Add(response);

                    }
                    con.Close();
                }
                return userList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                userList.Add(response);
                return userList;
            }
        }

    }
}
