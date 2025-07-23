using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EarthquakeData
{
    /// <summary>
    /// Simplified version containing only what's needed for the assignment
    /// </summary>
    public class FeatureCollection
    {
        [JsonPropertyName("features")]
        public List<EarthquakeFeature> Features { get; set; }
    }

    public class EarthquakeFeature
    {
        [JsonPropertyName("properties")]
        public EarthquakeProperties Properties { get; set; }
    }

    public class EarthquakeProperties
    {
        [JsonPropertyName("place")]
        public string Place { get; set; }
        
        [JsonPropertyName("mag")]
        public double? Magnitude { get; set; }
    }
}