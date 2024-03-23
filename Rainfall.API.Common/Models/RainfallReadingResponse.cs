using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Models
{
    public class RainfallReadingResponse
    {
        public IEnumerable<RainfallReading>? RainfallReadings { get; set; }
    }
}
