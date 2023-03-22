using Exhibitopia2.Service.Helpers;
using Newtonsoft.Json;

namespace Exhibitopia2.Service.Services;

public class InformationService
{
    public async Task<Response<InformationModel>> GetInformationAboutAsync(string topic)
    {
        topic = topic.Replace(" ", "%20");

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://wiki-briefs.p.rapidapi.com/search?q={topic}&topk=3"),
            Headers =
            {
                { "X-RapidAPI-Key", "2273fc4a48mshba57abdb08c4833p11b560jsnb83916b46d6c" },
                { "X-RapidAPI-Host", "wiki-briefs.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<InformationModel>(body);

            return new Response<InformationModel>
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }
    }
    public async Task<Response<List<HistoryModel>>> GetHistoryAboutAsync(string topic)
    {
        topic = topic.Replace(" ", "%20");
        
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri
            ("https://historical-events-by-api-ninjas.p.rapidapi.com/v1/historicalevents?text=" + topic),
            Headers =
            {
                { "X-RapidAPI-Key", "2273fc4a48mshba57abdb08c4833p11b560jsnb83916b46d6c" },
                { "X-RapidAPI-Host", "historical-events-by-api-ninjas.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var models = JsonConvert.DeserializeObject<List<HistoryModel>>(body);

            return new Response<List<HistoryModel>>
            {
                StatusCode = 200,
                Message = "Success",
                Value = models
            };
        }
    }
}
