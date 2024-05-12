namespace Hackaton_DW_2024.Infrastructure.Auth;

public class DefaultSaltProvider: ISaltProvider
{
    Random _rand = new();
    const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    const int DefaultSize = 8;
    public string GetSalt(int size)
    {
        if (size == 0) size = DefaultSize;
        return new string(Enumerable.Repeat(Chars, size)
            .Select(s => s[_rand.Next(s.Length)]).ToArray());
    }
}