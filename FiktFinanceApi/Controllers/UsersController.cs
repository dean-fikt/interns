using System;
using System.Collections.Generic;
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
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
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
                            Status = ResponseStatus.Success,
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["email"].ToString()
                        };
                        response.FirstName = user.FirstName;
                        response.LastName = user.LastName;
                        response.Email = user.Email;
                        userList.Add(user);
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

        [HttpPost]
        public User AddUser(User response)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_User_Insert", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@UserName", response.FirstName);
                    command.Parameters.AddWithValue("@UserSurname", response.LastName);
                    command.Parameters.AddWithValue("@UserEmail", response.Email);
                    command.Parameters.AddWithValue("@UserPassword", response.Password);
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
        public User UpdateUser(User response)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_UserName_Update", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@UserEmail", response.Email);
                    command.Parameters.AddWithValue("@UserPassword", response.Password);
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
        public string DeleteUser(string userEmail)
        {
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_User_Delete", con) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
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
