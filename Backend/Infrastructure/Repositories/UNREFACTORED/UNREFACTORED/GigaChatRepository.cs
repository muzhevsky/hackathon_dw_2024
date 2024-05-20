using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Hackaton_DW_2024.Infrastructure.Repositories.UNREFACTORED;

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
                Console.WriteLine(authorizationHeader);
                var response = await httpClient.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var authData = JsonConvert.DeserializeObject<GigaChatAuthResponse>(result);
                    _token = authData.AccessToken;
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
                var json = JsonConvert.DeserializeObject<GigaChatMessageResponse>(result);
                result = json.Choices[0].Message.Content;
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
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
    [JsonProperty("expires_at")]
    public long ExpiresAt { get; set; }
}

public class GigaChatMessageResponse
{
    [JsonProperty("choices")]
    public GigaChatChoice[] Choices { get; set; }
    [JsonProperty("created")]
    public long Created { get; set; }
    [JsonProperty("model")]
    public string Model { get; set; }
    [JsonProperty("object")]
    public string Object { get; set; }
    [JsonProperty("usage")]
    public GigaChatMessageUsage Usage { get; set; }
}

public class GigaChatChoice
{
    [JsonProperty("message")]
    public GigaChatMessage Message { get; set; }
    [JsonProperty("index")]
    public int Index { get; set; }
    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; }
}

public class GigaChatMessage
{
    [JsonProperty("content")]
    public string Content { get; set; }
    [JsonProperty("role")]
    public string Role { get; set; }
}

public class GigaChatMessageUsage
{
    [JsonProperty("prompt_tokens")]
    public int PromptTokens { get; set; }
    [JsonProperty("completion_tokens")]
    public int CompletionTokens { get; set; }
    [JsonProperty("total_tokens")]
    public int TotalTokens { get; set; }
}