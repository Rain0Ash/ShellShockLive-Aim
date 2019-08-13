using System;
using System.Collections.Generic;
using System.Drawing;
using Common;
using Common_Localization = Common.Localization;

namespace Ruler.Weapons.Common
{
    public static class Weapons
    {
        //private static Dictionary<String, Weapon> _weaponsDict = GetWeapons();
        private static readonly WeaponsLocalization Localization = new WeaponsLocalization(Ruler.GetLocalCultureCode());
        public static readonly List<Weapon> WeaponList = new List<Weapon>
        {
            //-
            new Weapon(Localization.Shot, new WeaponSpecifications(1, 0, 0), Guidance.Parabola, Color.Gray, WeaponsImg.Shot),
            new Weapon(Localization.BigShot, new WeaponSpecifications(1, 0, 1), Guidance.Parabola, Color.Gray, WeaponsImg.Big_Shot),
            new Weapon(Localization.HeavyShot, new WeaponSpecifications(1, 0, 2), Guidance.Parabola, Color.Gray, WeaponsImg.Heavy_Shot),
            new Weapon(Localization.MassiveShot, new WeaponSpecifications(1, 0, 3), Guidance.Parabola, Color.Gray, WeaponsImg.Massive_Shot),
            //-
            new Weapon("Three-Ball", new WeaponSpecifications(1, 1, 0), Guidance.Parabola, Color.Gray, WeaponsImg.Three_Ball),
            new Weapon("Five-Ball", new WeaponSpecifications(1, 1, 1), Guidance.Parabola, Color.Gray, WeaponsImg.Five_Ball),
            new Weapon("Eleven-Ball", new WeaponSpecifications(1, 1, 2), Guidance.Parabola, Color.Gray, WeaponsImg.Eleven_Ball),
            new Weapon("TwentyFive-Ball", new WeaponSpecifications(1, 1, 3), Guidance.Parabola, Color.Gray, WeaponsImg.TwentyFive_Ball),
            //-
            new Weapon("One-Bounce", new WeaponSpecifications(1, 2, 0), Guidance.Parabola, Color.Purple, WeaponsImg.One_Bounce),
            new Weapon("Three-Bounce", new WeaponSpecifications(1, 2, 1), Guidance.Parabola, Color.Purple, WeaponsImg.Three_Bounce),
            new Weapon("Five-Bounce", new WeaponSpecifications(1, 2, 2), Guidance.Parabola, Color.Purple, WeaponsImg.Five_Bounce),
            new Weapon("Seven-Bounce", new WeaponSpecifications(1, 2, 3), Guidance.Parabola, Color.Purple, WeaponsImg.Seven_Bounce),
            //-
            new Weapon("Digger", new WeaponSpecifications(1, 3, 0), Guidance.Parabola, Color.Brown, WeaponsImg.Digger),
            new Weapon("Mega-Digger", new WeaponSpecifications(1, 3, 1), Guidance.Parabola, Color.Brown, WeaponsImg.Mega_Digger),
            new Weapon("Excavation", new WeaponSpecifications(1, 3, 2), Guidance.Parabola, Color.Brown, WeaponsImg.Excavation),
            //-
            new Weapon("Grenade", new WeaponSpecifications(1, 4, 0), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Grenade),
            new Weapon("Tri-Nade", new WeaponSpecifications(1, 4, 1), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Tri_Nade),
            new Weapon("Multi-Nade", new WeaponSpecifications(1, 4, 2), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Multi_Nade),
            new Weapon("Grenade Storm", new WeaponSpecifications(1, 4, 3), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Grenade_Storm),
            //-
            new Weapon("Stream", new WeaponSpecifications(1, 5, 0), Guidance.Parabola, Color.Blue, WeaponsImg.Stream),
            new Weapon("Creek", new WeaponSpecifications(1, 5, 1), Guidance.Parabola, Color.Blue, WeaponsImg.Creek),
            new Weapon("River", new WeaponSpecifications(1, 5, 2), Guidance.Parabola, Color.Blue, WeaponsImg.River),
            new Weapon("Tsunami", new WeaponSpecifications(1, 5, 3), Guidance.Parabola, Color.Blue, WeaponsImg.Tsunami),
            //-
            new Weapon("Flame", new WeaponSpecifications(1, 6, 0), Guidance.Parabola, Color.Orange, WeaponsImg.Flame),
            new Weapon("Blaze", new WeaponSpecifications(1, 6, 1), Guidance.Parabola, Color.Orange, WeaponsImg.Blaze),
            new Weapon("Inferno", new WeaponSpecifications(1, 6, 2), Guidance.Parabola, Color.Orange, WeaponsImg.Inferno),
            //-
            new Weapon("Roller", new WeaponSpecifications(1, 7, 0), Guidance.Parabola, Color.Red, WeaponsImg.Roller),
            new Weapon("Heavy Roller", new WeaponSpecifications(1, 7, 1), Guidance.Parabola, Color.Red, WeaponsImg.Heavy_Roller),
            new Weapon("Groller", new WeaponSpecifications(1, 7, 2), Guidance.Parabola, Color.Red, WeaponsImg.Groller),
            //-
            new Weapon("Back-Roller", new WeaponSpecifications(1, 8, 0), Guidance.Parabola, Color.Chocolate, WeaponsImg.Back_Roller),
            new Weapon("Heavy Back-Roller", new WeaponSpecifications(1, 8, 1), Guidance.Parabola, Color.Chocolate, WeaponsImg.Heavy_Back_Roller),
            new Weapon("Back-Groller", new WeaponSpecifications(1, 8, 2), Guidance.Parabola, Color.Chocolate, WeaponsImg.Back_Groller),
            //-
            new Weapon("Splitter", new WeaponSpecifications(1, 9, 0), Guidance.Parabola, Color.Goldenrod, WeaponsImg.Splitter),
            new Weapon("Double-Splitter", new WeaponSpecifications(1, 9, 1), Guidance.Parabola, Color.Goldenrod, WeaponsImg.Double_Splitter),
            new Weapon("Super-Splitter", new WeaponSpecifications(1, 9, 2), Guidance.Parabola, Color.Goldenrod, WeaponsImg.Super_Splitter),
            new Weapon("SplitterChain", new WeaponSpecifications(1, 9, 3), Guidance.Parabola, Color.Goldenrod, WeaponsImg.SplitterChain),
            //-
            new Weapon("Breaker", new WeaponSpecifications(1, 10, 0), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Breaker),
            new Weapon("Double-Breaker", new WeaponSpecifications(1, 10, 1), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Double_Breaker),
            new Weapon("Super-Breaker", new WeaponSpecifications(1, 10, 2), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Super_Breaker),
            new Weapon("BreakerChain", new WeaponSpecifications(1, 10, 3), Guidance.Parabola, Color.LimeGreen, WeaponsImg.BreakerChain),
            //-
            new Weapon("Twinkler", new WeaponSpecifications(1, 11, 0), Guidance.Parabola, Color.Goldenrod, WeaponsImg.Twinkler),
            new Weapon("Sparkler", new WeaponSpecifications(1, 11, 1), Guidance.Parabola, Color.Goldenrod, WeaponsImg.Sparkler),
            new Weapon("Crackler", new WeaponSpecifications(1, 11, 2), Guidance.Parabola, Color.Goldenrod, WeaponsImg.Crackler),
            //-
            new Weapon("Sniper", new WeaponSpecifications(1, 12, 0), Guidance.Parabola, Color.Red, WeaponsImg.Sniper),
            new Weapon("Sub-Sniper", new WeaponSpecifications(1, 12, 1), Guidance.Parabola, Color.Red, WeaponsImg.Sub_Sniper),
            new Weapon("Smart Snipe", new WeaponSpecifications(1, 12, 2), Guidance.Parabola, Color.Red, WeaponsImg.SmartSnipe),
            //-
            new Weapon("Cactus", new WeaponSpecifications(1, 13, 0), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Cactus),
            new Weapon("Cactus Strike", new WeaponSpecifications(1, 13, 1), Guidance.Parabola, Color.LimeGreen, WeaponsImg.Cactus_Strike),
            //-
            new Weapon("Bulger", new WeaponSpecifications(1, 14, 0), Guidance.Parabola, Color.Blue, WeaponsImg.Bulger),
            new Weapon("Big Bulger", new WeaponSpecifications(1, 14, 1), Guidance.Parabola, Color.Blue, WeaponsImg.Big_Bulger),
            //-
            new Weapon("Sinkhole", new WeaponSpecifications(1, 15, 0), Guidance.Parabola, Color.Red, WeaponsImg.Sinkhole),
            new Weapon("Area Strike", new WeaponSpecifications(1, 15, 1), Guidance.Parabola, Color.Red, WeaponsImg.Area_Strike),
            new Weapon("Area Attack", new WeaponSpecifications(1, 15, 2), Guidance.Parabola, Color.Red, WeaponsImg.Area_Attack),
            //-
            new Weapon("RapidFire", new WeaponSpecifications(1, 16, 0), Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.RapidFire),
            new Weapon("Shotgun", new WeaponSpecifications(1, 16, 1), Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Shotgun),
            new Weapon("Burst-Fire", new WeaponSpecifications(1, 16, 2), Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Burst_Fire),
            new Weapon("Gatling Gun", new WeaponSpecifications(1, 16, 3), Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Gatling_Gun),
            //-
            new Weapon("Tunneler", new WeaponSpecifications(1, 17, 0), Guidance.Parabola, Color.Blue, WeaponsImg.Tunneler),
            new Weapon("Torpedoes", new WeaponSpecifications(1, 17, 1), Guidance.Parabola, Color.Blue, WeaponsImg.Torpedoes),
            new Weapon("Tunnel Strike", new WeaponSpecifications(1, 17, 2), Guidance.Parabola, Color.Blue, WeaponsImg.Tunnel_Strike),
            new Weapon("MegaTunneler", new WeaponSpecifications(1, 17, 3), Guidance.Parabola, Color.Blue, WeaponsImg.MegaTunneler),
            //-
            new Weapon("Horizon", new WeaponSpecifications(1, 18, 0), Guidance.Parabola, Color.Gray, WeaponsImg.Horizon),
            new Weapon("Sweeper", new WeaponSpecifications(1, 18, 1), Guidance.Parabola, Color.Gray, WeaponsImg.Sweeper),
            //-
            new Weapon("Air Strike", new WeaponSpecifications(1, 19, 0), Guidance.Parabola, Color.Red, WeaponsImg.Air_Strike),
            new Weapon("Helicopter Strike", new WeaponSpecifications(1, 19, 1), Guidance.Parabola, Color.Red, WeaponsImg.Helicopter_Strike),
            new Weapon("AC-130", new WeaponSpecifications(1, 19, 2), Guidance.Parabola, Color.Red, WeaponsImg.AC_130),
            new Weapon("Artillery", new WeaponSpecifications(1, 19, 3), Guidance.Parabola, Color.Red, WeaponsImg.Artillery),
            //-
            //-
            //-
            //-
            //-
            //-
            //-
        };
        
        private static Dictionary<String, Weapon> GetWeapons()
        {
            Dictionary<String, Weapon> dict;
            dict = new Dictionary<String, Weapon>();
            WeaponList.ForEach(weapon => dict.Add(weapon.Name, weapon));
            return dict;
        }

        //public static Weapon GetWeapon(String weaponName)
        //{
        //    _weaponsDict.TryGetValue(weaponName, out Weapon value);
        //    return value;
        //}
        
    }
}