﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Common;

namespace Starter.Localization
{
    internal class StarterLocalization : global::Common.Localization
    {
        public String StarterTitle;
        public String LanguageLabel;
        public String ScreenLabel;
        public String IDLabel;
        public String KeyLabel;
        public String DisguiseCheckBox;
        public String NotSaveSettings;
        public String NotDisplayAnymoreCheckBox;
        public String StartButton;
        public String InvalidKeyID;
        public String OccurredError;

        public StarterLocalization UpdateLocalization(String cultureInfo = null)
        {
            LocalCulture = cultureInfo ?? GetCurrentCulture();

            StarterTitle = LocalizedString(new CultureStrings(
                $"Ruler version {Settings.Version}",
                $"Версия линейки {Settings.Version}"));

            LanguageLabel = LocalizedString(new CultureStrings(
                "Language",
                "Язык"));            
            
            ScreenLabel = LocalizedString(new CultureStrings(
                "Screen",
                "Экран"));

            IDLabel = LocalizedString(new CultureStrings(
                "Enter licence ID",
                "Введите ID"));

            KeyLabel = LocalizedString(new CultureStrings(
                "Enter licence key",
                "Введите ключ"));

            DisguiseCheckBox = LocalizedString(new CultureStrings(
                "Disguise ruler",
                "Прятать линейку"));

            NotSaveSettings = LocalizedString(new CultureStrings(
                "Don't save settings",
                "Не сохранять настройки"));

            NotDisplayAnymoreCheckBox = LocalizedString(new CultureStrings(
                "Don't display anymore",
                "Далее не отображать"));
            
            StartButton = LocalizedString(new CultureStrings(
                "Start",
                "Запустить"));

            InvalidKeyID = LocalizedString(new CultureStrings(
                "Invalid KeyID combination!",
                "Неверная комбинация ID и ключа"));

            OccurredError = LocalizedString(new CultureStrings(
                "An error has occurred!",
                "Произошла ошибка!"));
            
            return this;
        }
        public StarterLocalization(String cultureInfo = null)
        {
            UpdateLocalization(cultureInfo);
        }
    }
}
