// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Ruler.Common
{
    internal abstract class Localization
    {
        protected String culture = CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;

        public struct CultureStrings
        {
            public String rus, eng;

            public CultureStrings(String english, String russian = null)
            {
                english = english ?? ConsoleColor.Red + "String is missing!" + ConsoleColor.White;
                this.rus = russian;
                this.eng = english;
            }
        }


        protected String LocalizedString(CultureStrings strings)
        {
            Dictionary<String, String> localString = new Dictionary<String, String>();
            Array.ForEach(typeof(CultureStrings).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                field => localString.Add(field.Name, field.GetValue(strings).ToString()));

            return localString.ContainsKey(culture) && localString[culture] != null ? localString[culture] : localString["eng"];
        }

        public HashSet<String> GetCultures()
        {
            HashSet<String> cultures = new HashSet<String>();
            Array.ForEach(typeof(CultureStrings).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                field => cultures.Add(field.Name));

            return cultures;
        }
    }
}
