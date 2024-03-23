using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Models
{
    public class ErrorDetail
    {
        public string? PropertyName { get; set; }
        public string? Message { get; set; }
    }
}
