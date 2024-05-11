namespace Hackaton_DW_2024.Infrastructure.Auth;

public interface ITokenProvider
{
    string ProvideToken(Dictionary<string, string> claims);
}