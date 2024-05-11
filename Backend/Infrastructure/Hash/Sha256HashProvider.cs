using System.Security.Cryptography;
using System.Text;

namespace Hackaton_DW_2024.Infrastructure.Hash;

public class Sha256HashProvider: IHashProvider
{
    public string Hash(string stringToHash)
    {
        var inputBytes = Encoding.UTF8.GetBytes(stringToHash);
        var inputHash = SHA256.HashData(inputBytes);
        return Convert.ToHexString(inputHash);
    }
}