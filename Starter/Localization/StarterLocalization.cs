﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Common;

namespace Ruler.Starter
{
    internal class StarterLocalization : Localization
    {
        public String StarterTitle;
        public String LanguageLabel;
        public String IDLabel;
        public String KeyLabel;
        public String NotDisplayAnymoreCheckBox;
        public String DisguiseCheckBox;
        public String StartButton;

        public String InvalidKeyID;

        public StarterLocalization UpdateLocalization(String cultureInfo = null)
        {
            culture = cultureInfo ?? CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            StarterTitle = LocalizedString(new CultureStrings(
                $"Ruler version {Common.Settings.Version}",
                $"Версия линейки {Common.Settings.Version}"));

            LanguageLabel = LocalizedString(new CultureStrings(
                "Language",
                "Язык"));

            IDLabel = LocalizedString(new CultureStrings(
                "Enter licence ID",
                "Введите ID"));

            KeyLabel = LocalizedString(new CultureStrings(
                "Enter licence key",
                "Введите ключ"));

            NotDisplayAnymoreCheckBox = LocalizedString(new CultureStrings(
                "Don't display anymore",
                "Далее не отображать"));

            DisguiseCheckBox = LocalizedString(new CultureStrings(
                "Disguise ruler",
                "Прятать линейку"));

            StartButton = LocalizedString(new CultureStrings(
                "Start",
                "Запустить"));

            InvalidKeyID = LocalizedString(new CultureStrings(
                "Invalid KeyID combination!",
                "Неверная комбинация ID и ключа"));

            return this;
        }
        public StarterLocalization(String cultureInfo = null)
        {
            UpdateLocalization(cultureInfo);
        }
    }
}