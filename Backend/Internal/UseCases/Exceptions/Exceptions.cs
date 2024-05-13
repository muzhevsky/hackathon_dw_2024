namespace Hackaton_DW_2024.Internal.UseCases.Exceptions;

public class AuthException: Exception
{
    public AuthException(string? message) : base(message)
    {
    }
}