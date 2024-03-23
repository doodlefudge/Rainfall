using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Models
{
    public class RainfallReading
    {
        public string? DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }
}
