namespace Hackaton_DW_2024.Infrastructure.Auth;

public interface ISaltProvider
{
    string GetSalt(int size);
}