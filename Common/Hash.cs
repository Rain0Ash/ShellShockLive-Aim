// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Hash
    {
        public static String Sha256(String hashString)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            Byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(hashString));
            foreach (Byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            crypt.Dispose();
            return hash.ToString();
        }
    }
}
