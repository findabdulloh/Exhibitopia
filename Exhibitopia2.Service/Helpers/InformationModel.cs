using Newtonsoft.Json;

namespace Exhibitopia2.Service.Helpers;

public class InformationModel
{
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("summary")]
    public List<string> Summary { get; set; }
}
