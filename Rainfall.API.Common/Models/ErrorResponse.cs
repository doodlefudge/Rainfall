using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Models
{
    public class ErrorResponse
    {
        public string? Message { get; set; }
        public IEnumerable<ErrorDetail>? Detail { get; set; }
    }
}
