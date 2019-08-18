// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Common;

namespace Ruler
{
    internal class RulerLocalization : Localization
    {
        internal String RulerVersion;
        internal String MaskName;
        internal String Angle;
        internal String AngleValue;
        internal String BlackHole;
        internal String BlackHoleRadius;
        internal String Portal;
        internal String PortalRadius;
        internal String Power;
        internal String PowerValue;
        internal String Sight;
        internal String SightRadius;
        internal String Wind;
        internal String WindValue;
        internal String Meters;

        internal RulerLocalization UpdateLocalization(String cultureInfo = null)
        {
            LocalCulture = cultureInfo ?? GetCurrentCulture();

            RulerVersion = LocalizedString(new CultureStrings(
                $"Ruler version {Settings.Version}",
                $"Линейка версии {Settings.Version}"));

            MaskName = LocalizedString(new CultureStrings(
                "Notepad",
                "Блокнот"));
            
            Angle = LocalizedString(new CultureStrings(
                "Angle",
                "Угол"));

            AngleValue = LocalizedString(new CultureStrings(
                "Angle value",
                "Параметр угла"));

            BlackHole = LocalizedString(new CultureStrings(
                "Black Hole",
                "Черная дыра"));

            BlackHoleRadius = LocalizedString(new CultureStrings(
                "Radius of black hole",
                "Параметр радиуса черной дыры"));

            Portal = LocalizedString(new CultureStrings(
                "Portal",
                "Портал"));

            PortalRadius = LocalizedString(new CultureStrings(
                "Radius of portals",
                "Параметр радиуса портала"));

            Power = LocalizedString(new CultureStrings(
                "Power",
                "Сила"));

            PowerValue = LocalizedString(new CultureStrings(
                "Power value",
                "Параметр силы"));

            Sight = LocalizedString(new CultureStrings(
                "Sight",
                "Прицел"));

            SightRadius = LocalizedString(new CultureStrings(
                "Radius of sight",
                "Радиус прицела"));

            Wind = LocalizedString(new CultureStrings(
                "Wind",
                "Ветер"));

            WindValue = LocalizedString(new CultureStrings(
                "Wind speed",
                "Скорость ветра"));

            Meters = LocalizedString(new CultureStrings(
                "m",
                "м"));

            return this;
        }
        internal RulerLocalization(String cultureInfo = null)
        {
            UpdateLocalization(cultureInfo);
        }
    }
}
