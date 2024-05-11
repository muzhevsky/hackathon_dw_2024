namespace Hackaton_DW_2024.Internal.Data.Config;

public class DatabaseConnectionConfig
{
    public DatabaseConnectionConfig(DatabaseEnvironment environment)
    {
        Host = Environment.GetEnvironmentVariable(environment.HostVarName) ?? throw new Exception("Necessary environment variable is not set");
        Port = Environment.GetEnvironmentVariable(environment.PortVarName) ?? throw new Exception("Necessary environment variable is not set");
        Database = Environment.GetEnvironmentVariable(environment.DatabaseVarName) ?? throw new Exception("Necessary environment variable is not set");
        Username = Environment.GetEnvironmentVariable(environment.UsernameVarName) ?? throw new Exception("Necessary environment variable is not set");
        Password = Environment.GetEnvironmentVariable(environment.PasswordVarName) ?? throw new Exception("Necessary environment variable is not set");
    }

    public string Host { get; }
    public string Port { get; }
    public string Database { get; }
    public string Username { get; }
    public string Password { get; }
}

public abstract class DatabaseEnvironment
{
    public virtual string HostVarName { get; }
    public virtual string PortVarName { get; }
    public virtual string DatabaseVarName { get; }
    public virtual string UsernameVarName { get; }
    public virtual string PasswordVarName { get; }
}

public class PostgresDatabaseEnvironment: DatabaseEnvironment
{
    public override string HostVarName { get => "POSTGRES_HOST"; }
    public override string PortVarName { get => "POSTGRES_PORT"; }
    public override string DatabaseVarName { get => "POSTGRES_NAME"; }
    public override string UsernameVarName { get => "POSTGRES_USER"; }
    public override string PasswordVarName { get => "POSTGRES_PASSWORD"; }
}