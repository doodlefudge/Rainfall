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
        public Uri? Context { get; set; }

        [JsonProperty("meta")]
        public Meta? Meta { get; set; }

        [JsonProperty("items")]
        public Items? Items { get; set; }
    }
    public partial class Items
    {
        [JsonProperty("@id")]
        public Uri? Id { get; set; }

        [JsonProperty("eaRegionName")]
        public string? EaRegionName { get; set; }

        [JsonProperty("easting")]
        public long Easting { get; set; }

        [JsonProperty("gridReference")]
        public string? GridReference { get; set; }

        [JsonProperty("label")]
        public string? Label { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("long")]
        public double Long { get; set; }

        [JsonProperty("measures")]
        public Measure[]? Measures { get; set; }

        [JsonProperty("northing")]
        public long Northing { get; set; }

        [JsonProperty("notation")]
        public long Notation { get; set; }

        [JsonProperty("stationReference")]
        public long StationReference { get; set; }

        [JsonProperty("type")]
        public Uri? Type { get; set; }
    }

    public partial class Measure
    {
        [JsonProperty("@id")]
        public Uri? Id { get; set; }

        [JsonProperty("label")]
        public string? Label { get; set; }

        [JsonProperty("latestReading")]
        public LatestReading? LatestReading { get; set; }

        [JsonProperty("notation")]
        public string? Notation { get; set; }

        [JsonProperty("parameter")]
        public string? Parameter { get; set; }

        [JsonProperty("parameterName")]
        public string? ParameterName { get; set; }

        [JsonProperty("period")]
        public long? Period { get; set; }

        [JsonProperty("qualifier")]
        public string? Qualifier { get; set; }

        [JsonProperty("station")]
        public Uri? Station { get; set; }

        [JsonProperty("stationReference")]
        public long? StationReference { get; set; }

        [JsonProperty("type")]
        public Uri?[]? Type { get; set; }

        [JsonProperty("unit")]
        public Uri? Unit { get; set; }

        [JsonProperty("unitName")]
        public string? UnitName { get; set; }

        [JsonProperty("valueType")]
        public string? ValueType { get; set; }
    }

    public partial class LatestReading
    {
        [JsonProperty("@id")]
        public Uri? Id { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("dateTime")]
        public DateTimeOffset DateTime { get; set; }

        [JsonProperty("measure")]
        public Uri? Measure { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("publisher")]
        public string? Publisher { get; set; }

        [JsonProperty("licence")]
        public Uri? Licence { get; set; }

        [JsonProperty("documentation")]
        public Uri? Documentation { get; set; }

        [JsonProperty("version")]
        public string? Version { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; }

        [JsonProperty("hasFormat")]
        public Uri[]? HasFormat { get; set; }
    }

}
