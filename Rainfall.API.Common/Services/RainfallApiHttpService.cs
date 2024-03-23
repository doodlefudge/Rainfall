using Newtonsoft.Json;
using Rainfall.API.Common.CustomExceptions;
using Rainfall.API.Common.HttpModels;
using Rainfall.API.Common.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<RainfallHttpResponse> GetRainfall(string stationId, int? count)
        {
            string url = $"{stationId}-rainfall-tipping_bucket_raingauge-t-15_min-mm/readings?_sorted";
            if(count != null)
            {
                url += $"&_limit={count}";
            }
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<RainfallHttpResponse>(responseString);

            if (responseObject == null)
            {
                throw new NullValueException();
            }
            return responseObject;
        }
    }
}
