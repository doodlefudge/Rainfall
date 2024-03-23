using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.HttpModels
{
    public class RainfallHttpResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
    public class Item
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("dateTime")]
        public DateTimeOffset DateTime { get; set; }

        [JsonProperty("measure")]
        public Uri Measure { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }

    public class Meta
    {
        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("licence")]
        public Uri Licence { get; set; }

        [JsonProperty("documentation")]
        public Uri Documentation { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("hasFormat")]
        public List<Uri> HasFormat { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }
    }

}
