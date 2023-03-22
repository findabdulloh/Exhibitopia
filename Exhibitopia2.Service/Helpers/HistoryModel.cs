using Newtonsoft.Json;

namespace Exhibitopia2.Service.Helpers;

public class HistoryModel
{
    [JsonProperty("year")]
    public string Year { get; set; }
    [JsonProperty("month")]
    public string Month { get; set; }
    [JsonProperty("day")]
    public string Day { get; set; }
    [JsonProperty("event")]
    public string Event { get; set; }
}
