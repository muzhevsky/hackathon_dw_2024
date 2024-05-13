using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Hackaton_DW_2024.Internal.Repositories.Api;

public class GigaChatRepository
{
    string _token;
    GigaChatApiConfiguration _config;

    public GigaChatRepository(GigaChatApiConfiguration config)
    {
        _config = config;
    }

    public async Task Authorize()
    {
        var authorizationHeader = $"Basic {_config.AuthKey}";
        var clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
        using (var httpClient = new HttpClient(clientHandler))
        {
            httpClient.Timeout = new TimeSpan(0, 0, _config.TimeOut);
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("scope", "GIGACHAT_API_PERS")
            });

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_config.AuthUrl),
                Headers =
                {
                    { "RqUID", $"{new Guid().ToString()}" },
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { HttpRequestHeader.Authorization.ToString(), $"{authorizationHeader}" }
                },
                Content = content
            };

            try
            {
                var response = await httpClient.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var authData = JsonConvert.DeserializeObject<GigaChatAuthResponse>(result);
                    _token = authData.access_token;
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public async Task<string> SendMessage(string message)
    {
        var result = "";
        var url = "https://gigachat.devices.sberbank.ru/api/v1/chat/completions";
        var authorizationHeader = $"Bearer {_token}";

        var clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
        {
            return true;
        };

        using (var httpClient = new HttpClient(clientHandler))
        {
            httpClient.Timeout = new TimeSpan(0, 0, _config.TimeOut);
            var payload = new
            {
                model = _config.ModelName,
                messages = new[] { new { role = "user", content = message } }
            };
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8);
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_config.MessageRequestUrl),
                Headers =
                {
                    { "RqUID", $"{new Guid().ToString()}" },
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { HttpRequestHeader.Authorization.ToString(), $"{authorizationHeader}" }
                },
                Content = content
            };

            var response = await httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }

        return result;
    }
}

public class GigaChatAuthResponse
{
    public string access_token { get; set; }
    public long expires_at { get; set; }
}