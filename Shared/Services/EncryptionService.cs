using Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructures.Shared.Services
{
    public class EncryptionService : IEncryptionService
    {
        public EncryptionService() { }

        public bool CompareMD5(string input, string hashed)
        {
            hashed = hashed.ToLower();
            string hashedInput = HashMD5(input).ToLower();

            if (hashed.Length == hashedInput.Length)
            {
                int i = 0;
                while ((i < hashedInput.Length) && (hashedInput[i] == hashed[i]))
                {
                    i += 1;
                }
                return i == hashed.Length;
            }
            return false;
        }

        public string HashMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
