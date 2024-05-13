namespace Hackaton_DW_2024.Infrastructure.Repositories.Api;

public class OcrConfiguration
{
    public OcrConfiguration(OcrEnvironment env)
    {
        Engine = int.Parse(Environment.GetEnvironmentVariable(env.EngineVar) ??
                           throw new Exception("No env variable provided"));
        Scale = bool.Parse(Environment.GetEnvironmentVariable(env.ScaleVar) ??
                           throw new Exception("No env variable provided"));
        ApiKey = Environment.GetEnvironmentVariable(env.ApiKeyVar) ?? throw new Exception("No env variable provided");
        Url = Environment.GetEnvironmentVariable(env.ApiUrlVar) ?? throw new Exception("No env variable provided");
    }

    public int Engine { get; set; }
    public bool Scale { get; set; }
    public string ApiKey { get; set; }
    public string Url { get; set; }
}

public class OcrEnvironment
{
    public string ApiKeyVar => "APP_OCR_API_KEY";
    public string ScaleVar => "APP_OCR_SCALE";
    public string EngineVar => "APP_OCR_ENGINE";
    public string ApiUrlVar => "APP_OCR_URL";
}