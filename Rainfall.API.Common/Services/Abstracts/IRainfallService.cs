using Rainfall.API.Common.HttpModels;
using Rainfall.API.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Services.Abstracts
{
    public interface IRainfallService
    {
        public Task<RainfallReadingResponse> GetRainfall(string stationId, int? count);
    }
}
