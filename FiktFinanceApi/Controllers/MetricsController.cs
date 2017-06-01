using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FiktFinanceApi.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FiktFinanceApi.Controllers
{
    public class MetricsController : BaseController
    {
        [HttpGet]
        public List<Metric> GetData()
        {
            List<Metric> metricList = new List<Metric>();
            var conn = ConfigurationManager.ConnectionStrings[ConnectionStringName()].ConnectionString;
            var response = new Metric
            {
                Status = ResponseStatus.Success,
            };
            try
            {
                using (var con = new SqlConnection(conn))
                {
                    var command = new SqlCommand("USP_Metrics_Select", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var metric = new Metric
                        {
                            Status = ResponseStatus.Success,
                            Id = Convert.ToInt32(reader["IDMetric"]),
                            MetricName = reader["Metric"].ToString()
                        };
                        response.Id = metric.Id;
                        response.MetricName = metric.MetricName;
                        metricList.Add(response);
                    }
                    con.Close();
                }
                return metricList;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Message = "RequestFailed";
                metricList.Add(response);
                return metricList;
            }
        }

    }
}
