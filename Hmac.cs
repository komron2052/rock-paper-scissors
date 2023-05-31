using System.Security.Cryptography;
using System.Text;

namespace Task3;

public static class Hmac
{

    public static byte[] GenerateRandomKey()
    {
        byte[] key = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
        }
        return key;
    }
    
    public static byte[] ComputeHMAC(string message, byte[] key)
    {
        
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        using(var hmac = new HMACSHA256(key))
        {
            return hmac.ComputeHash(messageBytes);
        }
    }

    public static string ByteArrayToString(byte[] bytes)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }

}

