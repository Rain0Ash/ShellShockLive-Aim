// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    internal class Licence
    {
        internal static Int32 MaxIDLength = 12;

        private readonly String licence;

        private static readonly HashSet<String> ValidHash= new HashSet<String>
        {
            "e783af48571881f3d38883ffb57227b62308656d6e66b5c20ae451295bd6ef1b",
            "1bd65a8da051182d293dcc018634066cdbcf21b139ee14ce00baf56f46b3e164"
        };

        private static String Sha256(String hashString)
        {
            StringBuilder hash = new StringBuilder();
            new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(hashString)).ToList()
                .ForEach(theByte => hash.Append(theByte.ToString("x2")));
            return hash.ToString();
        }

        private static String GetHashedKeyID(String id, String key)
        {
            return Sha256($"{id}@{key}");
        }

        internal static Boolean IsValidKeyID(String hash)
        {
            return ValidHash.Contains(hash);
        }
        internal static Boolean IsValidKeyID(String id, String key)
        {
            return IsValidKeyID(GetHashedKeyID(id, key));
        }

        internal Licence(String id, String key)
        {
            licence = GetHashedKeyID(id, key);
        }

        internal Boolean IsValid()
        {
            return licence != null && IsValidKeyID(licence);
        }
    }
}
