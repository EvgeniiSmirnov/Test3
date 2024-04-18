using System.Text.Json.Serialization;

namespace Test3.Models;

public class Case
{
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("id")] public int Id { get; set; }
}