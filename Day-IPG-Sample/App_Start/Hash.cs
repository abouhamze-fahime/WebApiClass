using System.Security.Cryptography;
using System.Text;

namespace Day_IPG_Sample.App_Start
{
    public class Hash
    {
        public static string GetHash(string input)
        {
            using (var sha = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                var sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }
    }
}