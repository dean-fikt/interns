using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiktFinanceApi.Models
{
    /// <summary>
    /// Base response class
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Base message returned to client
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Response status
        /// </summary>
        public ResponseStatus Status { get; set; }
    }
    public enum ResponseStatus
    {
        Error = 0,
        Success = 1
    }
}