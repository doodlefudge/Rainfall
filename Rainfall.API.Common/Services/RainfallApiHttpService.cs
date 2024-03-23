using Rainfall.API.Common.HttpModels;
using Rainfall.API.Common.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Services
{
    public class RainfallApiHttpService : IRainfallApiHttpService
    {
        private readonly HttpClient _httpClient;

        public RainfallApiHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<RainfallHttpResponse> GetRainfall(string stationId, int count = 10)
        {
            throw new NotImplementedException();
        }
    }
}
