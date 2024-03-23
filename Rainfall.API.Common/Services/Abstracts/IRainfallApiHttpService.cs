using Rainfall.API.Common.HttpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Services.Abstracts
{
    public interface IRainfallApiHttpService
    {
        public Task<RainfallHttpResponse> GetRainfall(string stationId, int count = 10);
    }
}
