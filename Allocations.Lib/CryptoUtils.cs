using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Allocations.Lib
{
    public static class CryptoUtils
    {
        public static string ComputeHash(string input, string alg)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create(alg);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
