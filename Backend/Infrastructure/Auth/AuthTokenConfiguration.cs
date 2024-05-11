namespace Hackaton_DW_2024.Infrastructure.Auth;

public class AuthTokenConfiguration
{
    public AuthTokenConfiguration(AuthTokenEnvironment environment)
    {
        var durationString = Environment.GetEnvironmentVariable(environment.DurationVarName) ?? throw new Exception("Necessary environment variable is not set");
        SigningKey = Environment.GetEnvironmentVariable(environment.SigningKeyVarName) ?? throw new Exception("Necessary environment variable is not set");

        DurationInMinutes = int.Parse(durationString);
    }

    public int DurationInMinutes { get; }
    public string SigningKey { get; }
}

public class AuthTokenEnvironment
{
    public virtual string DurationVarName { get => "APP_JWT_MINUTES_DURATION"; }
    public virtual string SigningKeyVarName { get => "APP_JWT_SIGNING_KEY"; }
}
