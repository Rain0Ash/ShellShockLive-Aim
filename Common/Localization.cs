// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Ruler.Properties;
using Image = System.Drawing.Image;

namespace Common
{
    internal abstract class Localization
    {
        internal const String DefaultCulture = @"en";
        protected String LocalCulture;

        internal struct Culture
        {
            internal String CultureCode;
            internal String CultureName;
            internal Image CultureImage;

            private void SetDefaultCulture()
            {
                CultureCode = DefaultCulture;
                CountryData.EnglishNameByIso2.TryGetValue(CultureCode, out String cultureName);
                CultureName = cultureName ?? "English";
                CultureImage = (Image)LanguageFlags.GetFlag(CultureCode);
            }

            internal Culture(String cultureCode = null, String cultureName = null, Image cultureImage = null)
            {
                cultureCode = cultureCode?.ToLower();

                CultureCode = cultureCode;
                CultureName = cultureName;
                CultureImage = cultureImage;

                if ((cultureCode == null || cultureCode.Length != 2) && cultureName == null)
                {
                    SetDefaultCulture();
                }
                else if (cultureCode == null || cultureCode.Length != 2)
                {
                    String cultureKey = CountryData.EnglishNameByIso2.FirstOrDefault(x => x.Value == cultureName).Key;
                    
                    if (cultureKey != null)
                    {
                        cultureCode = cultureKey.ToLower();
                        CultureCode = cultureCode;
                        CultureName = cultureName;
                        SetImage(cultureCode);
                    }
                    else
                    {
                        SetDefaultCulture();
                    }
                }
                else if (cultureName == null)
                {
                    CountryData.EnglishNameByIso2.TryGetValue(cultureCode.ToUpper(), out String value);
                    CultureName = value ?? "null";
                    SetImage(cultureCode);
                }

                if (cultureImage == null)
                {
                    SetImage(CultureCode);
                }
            }

            private void SetImage(String cultureCode)
            {
                CultureImage = (Image)Resources.ResourceManager.GetObject(cultureCode) ?? (Image)Resources.ResourceManager.GetObject(@"null");
            }
        }

        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        internal struct CultureStrings
        {
            private String en, ru;
            
            internal CultureStrings(String english, String russian = null)
            {
                en = english ?? "String is missing!";
                ru = russian;
            }
        }

        internal static String GetCurrentCulture()
        {
            return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }

        protected String LocalizedString(CultureStrings strings)
        {
            Dictionary<String, String> localString = new Dictionary<String, String>();
            Array.ForEach(typeof(CultureStrings).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                field => localString.Add(field.Name, field.GetValue(strings)?.ToString()));

            return LocalCulture != null && localString.ContainsKey(LocalCulture) && localString[LocalCulture] != null ? localString[LocalCulture] : localString[DefaultCulture];
        }

        internal static IEnumerable<Culture> GetCultures()
        {
            OrderedSet<Culture> cultures = new OrderedSet<Culture>();
            Array.ForEach(typeof(CultureStrings).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                field => cultures.Add(new Culture(field.Name)));

            return cultures;
        }

        internal String GetLocalCultureCode()
        {
            return LocalCulture;
        }
    }
}
