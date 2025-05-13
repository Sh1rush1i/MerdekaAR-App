using System.Security.Cryptography;
using System.Text;

public static class PasswordHasher
{
    public static string Hash(string input)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha.ComputeHash(inputBytes);
            return System.BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
