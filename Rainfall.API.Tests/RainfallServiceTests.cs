using Moq;
using Newtonsoft.Json;
using Rainfall.API.Common.CustomExceptions;
using Rainfall.API.Common.HttpModels;
using Rainfall.API.Common.Services;
using Rainfall.API.Common.Services.Abstracts;
using System.Text.Json.Nodes;

namespace Rainfall.API.Tests
{
    public class RainfallServiceTests
    {
        public Mock<IRainfallApiHttpService> _mockRainfallService;
        public RainfallService _rainfallService;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CanReturnValueFromHttpService()
        {
            _mockRainfallService = new Mock<IRainfallApiHttpService>();
            _mockRainfallService.Setup(x => x.GetRainfall("3680", It.IsAny<int?>())).ReturnsAsync(this.response);
            _rainfallService = new RainfallService(_mockRainfallService.Object);
            var response = await _rainfallService.GetRainfall("3680", 1);
            var itemsToTest = response.RainfallReadings.Select(e => e.AmountMeasured).ToList();
            Assert.NotNull(itemsToTest);
            Assert.Contains(5.0, itemsToTest);

        }


        [Test]
        public async Task CanReturnNoValueFromHttpService()
        {
            Assert.ThrowsAsync<NullValueException>(async () =>
            {
                _mockRainfallService = new Mock<IRainfallApiHttpService>();
                _mockRainfallService.Setup(x => x.GetRainfall("3680", It.IsAny<int?>()));
                _rainfallService = new RainfallService(_mockRainfallService.Object);
                var response = await _rainfallService.GetRainfall("3680", 1);
            });
        }

        [Test]
        public async Task InvalidRequestFromHttpService()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                _mockRainfallService = new Mock<IRainfallApiHttpService>();
                _mockRainfallService.Setup(x => x.GetRainfall("3680", 1000));
                _rainfallService = new RainfallService(_mockRainfallService.Object);
                var response = await _rainfallService.GetRainfall("3680", 1000);
            });
        }



        public RainfallHttpResponse response = JsonConvert.DeserializeObject<RainfallHttpResponse>(@"{ 
  ""@context"" : ""http://environment.data.gov.uk/flood-monitoring/meta/context.jsonld"" ,
  ""meta"" : { 
    ""publisher"" : ""Environment Agency"" ,
    ""licence"" : ""http://www.nationalarchives.gov.uk/doc/open-government-licence/version/3/"" ,
    ""documentation"" : ""http://environment.data.gov.uk/flood-monitoring/doc/reference"" ,
    ""version"" : ""0.9"" ,
    ""comment"" : ""Status: Beta service"" ,
    ""hasFormat"" : [ ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/readings.csv?_sorted&_limit=100"", ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/readings.rdf?_sorted&_limit=100"", ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/readings.ttl?_sorted&_limit=100"", ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/readings.html?_sorted&_limit=100"" ] ,
    ""limit"" : 100
  }
   ,
  ""items"" : [ { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T02-30-00Z"" ,
    ""dateTime"" : ""2024-03-23T02:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T02-15-00Z"" ,
    ""dateTime"" : ""2024-03-23T02:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 5.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T02-00-00Z"" ,
    ""dateTime"" : ""2024-03-23T02:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T01-45-00Z"" ,
    ""dateTime"" : ""2024-03-23T01:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T01-30-00Z"" ,
    ""dateTime"" : ""2024-03-23T01:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T01-15-00Z"" ,
    ""dateTime"" : ""2024-03-23T01:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T01-00-00Z"" ,
    ""dateTime"" : ""2024-03-23T01:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T00-45-00Z"" ,
    ""dateTime"" : ""2024-03-23T00:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T00-30-00Z"" ,
    ""dateTime"" : ""2024-03-23T00:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T00-15-00Z"" ,
    ""dateTime"" : ""2024-03-23T00:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-23T00-00-00Z"" ,
    ""dateTime"" : ""2024-03-23T00:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T23-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T23:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T23-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T23:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T23-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T23:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T23-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T23:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T22-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T22:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T22-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T22:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T22-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T22:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T22-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T22:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T21-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T21:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T21-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T21:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T21-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T21:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T21-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T21:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T20-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T20:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T20-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T20:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T20-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T20:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T20-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T20:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T19-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T19:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T19-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T19:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T19-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T19:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T19-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T19:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T18-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T18:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T18-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T18:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T18-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T18:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T18-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T18:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T17-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T17:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T17-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T17:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T17-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T17:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T17-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T17:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T16-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T16:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T16-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T16:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T16-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T16:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T16-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T16:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T15-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T15:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T15-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T15:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T15-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T15:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T15-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T15:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T14-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T14:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T14-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T14:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T14-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T14:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T14-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T14:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T13-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T13:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T13-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T13:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T13-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T13:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T13-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T13:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T12-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T12:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T12-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T12:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T12-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T12:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T12-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T12:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T11-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T11:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T11-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T11:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T11-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T11:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T11-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T11:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T10-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T10:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T10-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T10:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T10-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T10:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T10-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T10:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T09-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T09:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T09-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T09:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T09-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T09:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T09-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T09:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T08-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T08:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T08-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T08:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.2
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T08-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T08:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T08-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T08:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T07-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T07:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T07-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T07:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T07-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T07:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T07-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T07:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T06-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T06:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T06-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T06:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T06-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T06:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T06-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T06:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T05-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T05:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T05-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T05:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T05-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T05:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T05-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T05:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T04-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T04:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T04-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T04:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T04-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T04:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T04-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T04:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T03-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T03:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.4
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T03-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T03:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T03-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T03:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T03-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T03:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T02-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T02:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T02-30-00Z"" ,
    ""dateTime"" : ""2024-03-22T02:30:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T02-15-00Z"" ,
    ""dateTime"" : ""2024-03-22T02:15:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T02-00-00Z"" ,
    ""dateTime"" : ""2024-03-22T02:00:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
  , { 
    ""@id"" : ""http://environment.data.gov.uk/flood-monitoring/data/readings/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-22T01-45-00Z"" ,
    ""dateTime"" : ""2024-03-22T01:45:00Z"" ,
    ""measure"" : ""http://environment.data.gov.uk/flood-monitoring/id/measures/3680-rainfall-tipping_bucket_raingauge-t-15_min-mm"" ,
    ""value"" : 0.0
  }
   ]
}

");

    }
}