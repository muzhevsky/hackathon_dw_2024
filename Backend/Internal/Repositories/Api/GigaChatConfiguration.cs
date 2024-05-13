namespace Hackaton_DW_2024.Internal.Repositories.Api;

public class GigaChatApiConfiguration
{
    public GigaChatApiConfiguration(GigaChatEnvironment env)
    {
        TimeOut = int.Parse(Environment.GetEnvironmentVariable(env.TimeoutVar) ?? throw new Exception("No env variable provided"));
        ModelName = Environment.GetEnvironmentVariable(env.ModelNameVar) ?? throw new Exception("No env variable provided");
        AuthKey = Environment.GetEnvironmentVariable(env.ApiKeyVar) ?? throw new Exception("No env variable provided");
        AuthUrl = Environment.GetEnvironmentVariable(env.AuthUrlVar) ?? throw new Exception("No env variable provided");
        MessageRequestUrl = Environment.GetEnvironmentVariable(env.MessageUrlVar) ?? throw new Exception("No env variable provided");
    }
    public int TimeOut { get; set; }
    public string ModelName { get; set; }
    public string AuthKey { get; set; }
    public string AuthUrl { get; set; }
    public string MessageRequestUrl { get; set; }
}

public class GigaChatEnvironment
{
    public string TimeoutVar => "APP_GIGACHAT_TIMEOUT";
    public string ModelNameVar => "APP_GIGACHAT_MODEL_NAME";
    public string AuthUrlVar => "APP_GIGACHAT_AUTH_URL";
    public string MessageUrlVar => "APP_GIGACHAT_MESSAGE_REQUEST_URL";
    public string ApiKeyVar => "APP_GIGACHAT_API_KEY";
}