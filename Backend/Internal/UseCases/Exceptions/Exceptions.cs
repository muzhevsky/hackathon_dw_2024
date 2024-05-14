namespace Hackaton_DW_2024.Internal.UseCases.Exceptions;

public class AuthException: Exception
{
    public AuthException(string? message) : base(message)
    {
    }
}

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string? message) : base(message)
    {
    }
}

public class DuplicateEntityException : Exception
{
    public DuplicateEntityException(string? message) : base(message)
    {
    }
}