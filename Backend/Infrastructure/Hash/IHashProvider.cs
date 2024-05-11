namespace Hackaton_DW_2024.Infrastructure.Hash;

public interface IHashProvider
{
    string Hash(string stringToHash);
}