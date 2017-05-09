using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using FiktFinanceApi.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FiktFinanceApi.Controllers
{
    public class ItemCategoryController : BaseController
    {
        [HttpGet]
        public List<ItemCategory> GetData()
        {
            List<ItemCategory> itemCategoryList = new List<ItemCategory>();
            var conn = ConfigurationManager.ConnectionStrings[GetConnectionStringName()].ConnectionString;
            var response = new ItemCategory
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_ItemCategory_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var itemCategory = new ItemCategory
                        {
                            IdItemCategory = Convert.ToInt32(reader["IDItemCategory"]),
                            ItemCategoryName = reader["ItemCategory"].ToString()
                        };
                        response.IdItemCategory = itemCategory.IdItemCategory;
                        response.ItemCategoryName = itemCategory.ItemCategoryName;
                        itemCategoryList.Add(response);

                    }
                    con.Close();
                }
                return itemCategoryList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                itemCategoryList.Add(response);
                return itemCategoryList;
            }
        }
    }
}
