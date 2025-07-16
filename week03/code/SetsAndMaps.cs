using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();
        
        foreach (var word in words)
        {
            if (word[0] == word[1]) continue;
            
            string reversed = $"{word[1]}{word[0]}";
            
            if (seen.Contains(reversed))
                result.Add($"{word} & {reversed}");
            
            seen.Add(word);
        }
        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length < 4) continue;
            
            string degree = fields[3].Trim();
            if (string.IsNullOrEmpty(degree)) continue;
            
            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        var clean1 = word1.Replace(" ", "").ToLower();
        var clean2 = word2.Replace(" ", "").ToLower();
        
        if (clean1.Length != clean2.Length) return false;
        
        var count1 = new Dictionary<char, int>();
        var count2 = new Dictionary<char, int>();
        
        foreach (char c in clean1)
        {
            if (count1.ContainsKey(c))
                count1[c]++;
            else
                count1[c] = 1;
        }
        
        foreach (char c in clean2)
        {
            if (count2.ContainsKey(c))
                count2[c]++;
            else
                count2[c] = 1;
        }
        
        return count1.OrderBy(kvp => kvp.Key)
                   .SequenceEqual(count2.OrderBy(kvp => kvp.Key));
    }

    public static string[] EarthquakeDailySummary()
    {
        try
        {
            const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
            using var client = new HttpClient();
            var json = client.GetStringAsync(uri).Result;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var data = JsonSerializer.Deserialize<EarthquakeData.FeatureCollection>(json, options);
            
            return data?.Features?
                .Where(f => f?.Properties != null)
                .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag:0.00}")
                .ToArray() ?? Array.Empty<string>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching earthquake data: {ex.Message}");
            return Array.Empty<string>();
        }
    }
}

namespace EarthquakeData
{
    public class FeatureCollection
    {
        [JsonPropertyName("features")]
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("place")]
        public string Place { get; set; }
        
        [JsonPropertyName("mag")]
        public double Mag { get; set; }
    }
}