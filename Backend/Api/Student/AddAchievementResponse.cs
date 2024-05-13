using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Hackaton_DW_2024.Api.Student;

public class AddAchievementResponse
{
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("date")]
    public string Date { get; set;}
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("result")]
    public string Result { get; set; }
}