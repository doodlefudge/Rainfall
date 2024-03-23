using Rainfall.API.Common.HttpModels;
using Rainfall.API.Common.Models;
using Rainfall.API.Common.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.Services
{
    public class RainfallService : IRainfallService
    {
        private IRainfallApiHttpService _service;
        public RainfallService(
            IRainfallApiHttpService service)
        {
            _service = service;
        }
        public async Task<RainfallReadingResponse> GetRainfall(string stationId, int? count)
        {
            var response = await _service.GetRainfall(stationId, count);
            var rainfallReadings = new List<RainfallReading>();

            if (response == null)
            {
                throw new 
            }
            var items = response.Items.ToList();

            rainfallReadings.AddRange(items.Select(item => new RainfallReading()
            {
                AmountMeasured = item.Value,
                DateMeasured = item.DateTime.ToString()
            }));
            return new RainfallReadingResponse
            {
                RainfallReadings = rainfallReadings
            };
        }
    }
}
