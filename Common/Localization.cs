// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Image = System.Drawing.Image;

namespace Common
{
    internal abstract class Localization
    {
        public struct LettersInCultureCode
        {
            public const Int32 ThreeLetterWindowsLanguageName = 1;
            public const Int32 TwoLetterISOLanguageName = 2;
            public const Int32 ThreeLetterISOLanguageName = 3;
        }
        public static Int32 LettersInCultureCodeUsing = 2;
        protected String culture;

        public struct Culture
        {
            public String CultureCode;
            public String CultureName;
            public Image CultureImage;

            private void SetDefaultCulture()
            {
                this.CultureCode = "en";
                CountryData.EnglishNameByIso2.TryGetValue(CultureCode, out String cultureName);
                this.CultureName = cultureName ?? "English";
                this.CultureImage = (Image)new LanguageFlags().GetFlag(CultureCode);
            }

            public Culture(String cultureCode = null, String cultureName = null, Image cultureImage = null)
            {
                cultureCode = cultureCode?.ToLower();

                this.CultureCode = cultureCode;
                this.CultureName = cultureName;
                this.CultureImage = cultureImage;

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
                        this.CultureCode = cultureCode;
                        this.CultureName = cultureName;
                        this.CultureImage = (Image)new LanguageFlags().GetFlag(cultureCode);
                    }
                    else
                    {
                        SetDefaultCulture();
                    }
                }
                else if (cultureName == null)
                {
                    CountryData.EnglishNameByIso2.TryGetValue(cultureCode.ToUpper(), out String value);
                    this.CultureName = value ?? "null";
                    this.CultureImage = (Image)new LanguageFlags().GetFlag(cultureCode);
                }

                if (cultureImage == null)
                {
                    this.CultureImage = (Image)new LanguageFlags().GetFlag(this.CultureCode);
                }
                
            }
        }

        public struct CultureStrings
        {
            public String en, ru;

            public CultureStrings(String english, String russian = null)
            {
                this.en = english ?? "String is missing!";
                this.ru = russian;

            }
        }

        internal String GetCurrentCulture(Int32? lettersInCultureCode = null)
        {
            LettersInCultureCodeUsing = lettersInCultureCode ?? 2;
            return LettersInCultureCodeUsing == LettersInCultureCode.TwoLetterISOLanguageName ? CultureInfo.CurrentCulture.TwoLetterISOLanguageName :
                LettersInCultureCodeUsing == LettersInCultureCode.ThreeLetterISOLanguageName ? CultureInfo.CurrentCulture.ThreeLetterISOLanguageName :
                    CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName;
        }

        protected String LocalizedString(CultureStrings strings)
        {
            Dictionary<String, String> localString = new Dictionary<String, String>();
            Array.ForEach(typeof(CultureStrings).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                field => localString.Add(field.Name, field.GetValue(strings)?.ToString()));

            return culture != null && localString.ContainsKey(culture) && localString[culture] != null ? localString[culture] : localString["en"];
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
