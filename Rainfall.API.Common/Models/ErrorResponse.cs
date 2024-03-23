using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Models
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Detail = new List<ErrorDetail>();
        }
        public string? Message { get; set; }
        public List<ErrorDetail>? Detail { get; set; }
    }
}
