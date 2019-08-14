// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
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
            new Weapon(Localization.Shot, 1, 0, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Shot),
            new Weapon(Localization.BigShot, 1, 0, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Big_Shot),
            new Weapon(Localization.HeavyShot, 1, 0, 2, Guidance.Parabola, Color.Gray, WeaponsImg.Heavy_Shot),
            new Weapon(Localization.MassiveShot, 1, 0, 3, Guidance.Parabola, Color.Gray, WeaponsImg.Massive_Shot),
            //-
            new Weapon("Three-Ball", 1, 1, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Three_Ball),
            new Weapon("Five-Ball", 1, 1, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Five_Ball),
            new Weapon("Eleven-Ball", 1, 1, 2, Guidance.Parabola, Color.Gray, WeaponsImg.Eleven_Ball),
            new Weapon("TwentyFive-Ball", 1, 1, 3, Guidance.Parabola, Color.Gray, WeaponsImg.TwentyFive_Ball),
            //-
            new Weapon("One-Bounce", 1, 2, 0, Guidance.Parabola, Color.Purple, WeaponsImg.One_Bounce),
            new Weapon("Three-Bounce", 1, 2, 1, Guidance.Parabola, Color.Purple, WeaponsImg.Three_Bounce),
            new Weapon("Five-Bounce", 1, 2, 2, Guidance.Parabola, Color.Purple, WeaponsImg.Five_Bounce),
            new Weapon("Seven-Bounce", 1, 2, 3, Guidance.Parabola, Color.Purple, WeaponsImg.Seven_Bounce),
            //-
            new Weapon("Digger", 1, 3, 0, Guidance.Parabola, Color.Brown, WeaponsImg.Digger),
            new Weapon("Mega-Digger", 1, 3, 1, Guidance.Parabola, Color.Brown, WeaponsImg.Mega_Digger),
            new Weapon("Excavation", 1, 3, 2, Guidance.Parabola, Color.Brown, WeaponsImg.Excavation),
            //-
            new Weapon("Grenade", 1, 4, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Grenade),
            new Weapon("Tri-Nade", 1, 4, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Tri_Nade),
            new Weapon("Multi-Nade", 1, 4, 2, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Multi_Nade),
            new Weapon("Grenade Storm", 1, 4, 3, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Grenade_Storm),
            //-
            new Weapon("Stream", 1, 5, 0, Guidance.Parabola, Color.Blue, WeaponsImg.Stream),
            new Weapon("Creek", 1, 5, 1, Guidance.Parabola, Color.Blue, WeaponsImg.Creek),
            new Weapon("River", 1, 5, 2, Guidance.Parabola, Color.Blue, WeaponsImg.River),
            new Weapon("Tsunami", 1, 5, 3, Guidance.Parabola, Color.Blue, WeaponsImg.Tsunami),
            //-
            new Weapon("Flame", 1, 6, 0, Guidance.Parabola, Color.Orange, WeaponsImg.Flame),
            new Weapon("Blaze", 1, 6, 1, Guidance.Parabola, Color.Orange, WeaponsImg.Blaze),
            new Weapon("Inferno", 1, 6, 2, Guidance.Parabola, Color.Orange, WeaponsImg.Inferno),
            //-
            new Weapon("Roller", 1, 7, 0, Guidance.Parabola, Color.Red, WeaponsImg.Roller),
            new Weapon("Heavy Roller", 1, 7, 1, Guidance.Parabola, Color.Red, WeaponsImg.Heavy_Roller),
            new Weapon("Groller", 1, 7, 2, Guidance.Parabola, Color.Red, WeaponsImg.Groller),
            //-
            new Weapon("Back-Roller", 1, 8, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Back_Roller),
            new Weapon("Heavy Back-Roller", 1, 8, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Heavy_Back_Roller),
            new Weapon("Back-Groller", 1, 8, 2, Guidance.Parabola, Color.Chocolate, WeaponsImg.Back_Groller),
            //-
            new Weapon("Splitter", 1, 9, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Splitter),
            new Weapon("Double-Splitter", 1, 9, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Double_Splitter),
            new Weapon("Super-Splitter", 1, 9, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Super_Splitter),
            new Weapon("SplitterChain", 1, 9, 3, Guidance.Parabola, Color.Goldenrod, WeaponsImg.SplitterChain),
            //-
            new Weapon("Breaker", 1, 10, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Breaker),
            new Weapon("Double-Breaker", 1, 10, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Double_Breaker),
            new Weapon("Super-Breaker", 1, 10, 2, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Super_Breaker),
            new Weapon("BreakerChain", 1, 10, 3, Guidance.Parabola, Color.LimeGreen, WeaponsImg.BreakerChain),
            //-
            new Weapon("Twinkler", 1, 11, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Twinkler),
            new Weapon("Sparkler", 1, 11, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Sparkler),
            new Weapon("Crackler", 1, 11, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Crackler),
            //-
            new Weapon("Sniper", 1, 12, 0, Guidance.Parabola, Color.Red, WeaponsImg.Sniper),
            new Weapon("Sub-Sniper", 1, 12, 1, Guidance.Parabola, Color.Red, WeaponsImg.Sub_Sniper),
            new Weapon("Smart Snipe", 1, 12, 2, Guidance.Parabola, Color.Red, WeaponsImg.SmartSnipe),
            //-
            new Weapon("Cactus", 1, 13, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Cactus),
            new Weapon("Cactus Strike", 1, 13, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Cactus_Strike),
            //-
            new Weapon("Bulger", 1, 14, 0, Guidance.Parabola, Color.Blue, WeaponsImg.Bulger),
            new Weapon("Big Bulger", 1, 14, 1, Guidance.Parabola, Color.Blue, WeaponsImg.Big_Bulger),
            //-
            new Weapon("Sinkhole", 1, 15, 0, Guidance.Parabola, Color.Red, WeaponsImg.Sinkhole),
            new Weapon("Area Strike", 1, 15, 1, Guidance.Parabola, Color.Red, WeaponsImg.Area_Strike),
            new Weapon("Area Attack", 1, 15, 2, Guidance.Parabola, Color.Red, WeaponsImg.Area_Attack),
            //-
            new Weapon("RapidFire", 1, 16, 0, Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.RapidFire),
            new Weapon("Shotgun", 1, 16, 1, Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Shotgun),
            new Weapon("Burst-Fire", 1, 16, 2, Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Burst_Fire),
            new Weapon("Gatling Gun", 1, 16, 3, Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Gatling_Gun),
            //-
            new Weapon("Tunneler", 1, 17, 0, Guidance.Parabola, Color.Blue, WeaponsImg.Tunneler),
            new Weapon("Torpedoes", 1, 17, 1, Guidance.Parabola, Color.Blue, WeaponsImg.Torpedoes),
            new Weapon("Tunnel Strike", 1, 17, 2, Guidance.Parabola, Color.Blue, WeaponsImg.Tunnel_Strike),
            new Weapon("MegaTunneler", 1, 17, 3, Guidance.Parabola, Color.Blue, WeaponsImg.MegaTunneler),
            //-
            new Weapon("Horizon", 1, 18, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Horizon),
            new Weapon("Sweeper", 1, 18, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Sweeper),
            //-
            new Weapon("Air Strike", 1, 19, 0, Guidance.Parabola, Color.Red, WeaponsImg.Air_Strike),
            new Weapon("Helicopter Strike", 1, 19, 1, Guidance.Parabola, Color.Red, WeaponsImg.Helicopter_Strike),
            new Weapon("AC-130", 1, 19, 2, Guidance.Parabola, Color.Red, WeaponsImg.AC_130),
            new Weapon("Artillery", 1, 19, 3, Guidance.Parabola, Color.Red, WeaponsImg.Artillery),
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