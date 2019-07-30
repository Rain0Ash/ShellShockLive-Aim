// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Ruler.Common;

namespace Ruler
{
    internal class RulerLocalization : Localization
    {
        public String Angle;
        public String AngleValue;
        public String BlackHole;
        public String BlackHoleRadius;
        public String Portal;
        public String PortalRadius;
        public String Power;
        public String PowerValue;
        public String Sight;
        public String SightRadius;
        public String Wind;
        public String WindValue;

        public RulerLocalization UpdateLocalization(String cultureInfo = null)
        {
            culture = cultureInfo ?? CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;

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

            return this;
        }
        public RulerLocalization(String cultureInfo = null)
        {
            UpdateLocalization(cultureInfo);
        }
    }
}
