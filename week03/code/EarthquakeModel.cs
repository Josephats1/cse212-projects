using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EarthquakeData
{
    public class EarthquakeDataCollection
    {
        [JsonPropertyName("features")]
        public List<EarthquakeEvent> Features { get; set; }
    }

    public class EarthquakeEvent
    {
        [JsonPropertyName("properties")]
        public EarthquakeDetails Properties { get; set; }
    }

    public class EarthquakeDetails
    {
        [JsonPropertyName("place")]
        public string Location { get; set; }
        
        [JsonPropertyName("mag")]
        public double Magnitude { get; set; }
    }
}