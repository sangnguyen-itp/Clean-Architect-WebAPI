using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Common
{
    public interface IEncryptionService
    {
        public string HashMD5(string input);
        public bool CompareMD5(string input, string hashed);
    }
}
