using System;
using Common;

namespace Ruler.Weapons.Common
{
    internal class WeaponsLocalization : Localization
    {
        public String Shot, BigShot, HeavyShot, MassiveShot;

        public WeaponsLocalization UpdateLocalization(String cultureInfo = null)
        {
            LocalCulture = cultureInfo ?? GetCurrentCulture();

            Shot = LocalizedString(new CultureStrings(
                "Shot",
                "Выстрел"));
            BigShot = LocalizedString(new CultureStrings(
                "Big Shot",
                "Средний выстрел"));            
            HeavyShot = LocalizedString(new CultureStrings(
                "Heavy Shot",
                "Мощный выстрел"));            
            MassiveShot = LocalizedString(new CultureStrings(
                "Massive Shot",
                "Массивный выстрел"));

            return this;
        }

        public WeaponsLocalization(String cultureInfo = null)
        {
            UpdateLocalization(cultureInfo);
        }
    }
}