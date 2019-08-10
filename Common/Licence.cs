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
        internal const Int32 MaxIDLength = 12;
        internal const Int32 MaxKeyCells = 5;
        internal const Int32 MaxKeyCharInCell = 4;
        internal const Int32 MaxKeyLength = MaxKeyCells*MaxKeyCharInCell + MaxKeyCells - 1;

        internal const String FreeID = @"FREE";
        internal const String FreeKey = @"FREE-FREE-FREE-FREE-FREE";

        private readonly String licence;

        private static readonly HashSet<String> ValidHash= new HashSet<String>
        {
            GetHashedKeyID(FreeID, FreeKey),
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
