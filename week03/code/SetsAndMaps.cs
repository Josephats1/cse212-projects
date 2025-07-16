using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();
        
        foreach (var word in words)
        {
            // Skip words with identical characters
            if (word[0] == word[1]) continue;
            
            string reversed = $"{word[1]}{word[0]}";
            
            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            
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
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }
        
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string normalized1 = word1.Replace(" ", "").ToLower();
        string normalized2 = word2.Replace(" ", "").ToLower();
        
        if (normalized1.Length != normalized2.Length)
        {
            return false;
        }
        
        var charCounts = new Dictionary<char, int>();
        
        foreach (char c in normalized1)
        {
            if (charCounts.ContainsKey(c))
            {
                charCounts[c]++;
            }
            else
            {
                charCounts[c] = 1;
            }
        }
        
        foreach (char c in normalized2)
        {
            if (!charCounts.ContainsKey(c))
            {
                return false;
            }
            
            charCounts[c]--;
            
            if (charCounts[c] < 0)
            {
                return false;
            }
        }
        
        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = new List<string>();
        
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Properties != null)
                {
                    string place = feature.Properties.Place;
                    double? mag = feature.Properties.Mag;
                    
                    if (!string.IsNullOrEmpty(place) && mag.HasValue)
                    {
                        summaries.Add($"{place} - Mag {mag.Value.ToString("0.00")}");
                    }
                }
            }
        }
        
        return summaries.ToArray();
    }
}

public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}