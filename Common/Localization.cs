// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Image = System.Drawing.Image;

namespace Common
{
    internal abstract class Localization
    {
        public static Int32 LettersInCultureCode = 2;
        protected String culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        public struct Culture
        {
            public String cultureCode;
            public String cultureName;
            public Image cultureImage;

            private void SetDefaultCulture()
            {
                this.cultureCode = "en";
                CountryData.EnglishNameByIso2.TryGetValue(cultureCode, out String value);
                this.cultureName = value ?? "English";
                this.cultureImage = (Image)new LanguageFlags().GetFlag(cultureCode);
            }

            public Culture(String cultureCode = null, String cultureName = null, Image cultureImage = null)
            {
                cultureCode = cultureCode?.ToLower();

                this.cultureCode = cultureCode;
                this.cultureName = cultureName;
                this.cultureImage = cultureImage;

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
                        this.cultureCode = cultureCode;
                        this.cultureName = cultureName;
                        this.cultureImage = (Image)new LanguageFlags().GetFlag(cultureCode);
                    }
                    else
                    {
                        SetDefaultCulture();
                    }
                }
                else if (cultureName == null)
                {
                    CountryData.EnglishNameByIso2.TryGetValue(cultureCode.ToUpper(), out String value);
                    this.cultureName = value ?? "null";
                    this.cultureImage = (Image)new LanguageFlags().GetFlag(cultureCode);
                }

                if (cultureImage == null)
                {
                    this.cultureImage = (Image)new LanguageFlags().GetFlag(this.cultureCode);
                }
                
            }
        }

        public struct CultureStrings
        {
            public String en, ru;

            public CultureStrings(String english, String russian = null, String deutch = null)
            {
                this.en = english ?? "String is missing!";
                this.ru = russian;
            }
        }


        protected String LocalizedString(CultureStrings strings)
        {
            Dictionary<String, String> localString = new Dictionary<String, String>();
            Array.ForEach(typeof(CultureStrings).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                field => localString.Add(field.Name, field.GetValue(strings)?.ToString()));

            return localString.ContainsKey(culture) && localString[culture] != null ? localString[culture] : localString["en"];
        }

        public SortedSet<String> GetCultures()
        {
            SortedSet<String> cultures = new SortedSet<String>();
            Array.ForEach(typeof(CultureStrings).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                field => cultures.Add(field.Name));

            return cultures;
        }
    }
}
