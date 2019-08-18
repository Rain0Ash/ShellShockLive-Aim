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
        private static readonly WeaponsLocalization Localization = new WeaponsLocalization(MainForm.GetLocalCultureCode());
        public static readonly List<Weapon> WeaponList = new List<Weapon>
        {
            //-
            new Weapon(Localization.Shot, 1, 0, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Shot),
            new Weapon(Localization.BigShot, 1, 0, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Big_Shot),
            new Weapon(Localization.HeavyShot, 1, 0, 2, Guidance.Parabola, Color.Gray, WeaponsImg.Heavy_Shot),
            new Weapon(Localization.MassiveShot, 1, 0, 3, Guidance.Parabola, Color.Gray, WeaponsImg.Massive_Shot),
            //-
            new Weapon(Localization.ThreeBall, 1, 1, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Three_Ball),
            new Weapon(Localization.FiveBall, 1, 1, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Five_Ball),
            new Weapon(Localization.ElevenBall, 1, 1, 2, Guidance.Parabola, Color.Gray, WeaponsImg.Eleven_Ball),
            new Weapon(Localization.TwentyFiveBall, 1, 1, 3, Guidance.Parabola, Color.Gray, WeaponsImg.TwentyFive_Ball),
            //-
            new Weapon(Localization.OneBounce, 1, 2, 0, Guidance.Parabola, Color.Purple, WeaponsImg.One_Bounce),
            new Weapon(Localization.ThreeBounce, 1, 2, 1, Guidance.Parabola, Color.Purple, WeaponsImg.Three_Bounce),
            new Weapon(Localization.FiveBounce, 1, 2, 2, Guidance.Parabola, Color.Purple, WeaponsImg.Five_Bounce),
            new Weapon(Localization.SevenBounce, 1, 2, 3, Guidance.Parabola, Color.Purple, WeaponsImg.Seven_Bounce),
            //-
            new Weapon(Localization.Digger, 1, 3, 0, Guidance.Parabola, Color.Brown, WeaponsImg.Digger),
            new Weapon(Localization.MegaDigger, 1, 3, 1, Guidance.Parabola, Color.Brown, WeaponsImg.Mega_Digger),
            new Weapon(Localization.Excavation, 1, 3, 2, Guidance.Parabola, Color.Brown, WeaponsImg.Excavation),
            //-
            new Weapon(Localization.Grenade, 1, 4, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Grenade),
            new Weapon(Localization.TriNade, 1, 4, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Tri_Nade),
            new Weapon(Localization.MultiNade, 1, 4, 2, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Multi_Nade),
            new Weapon(Localization.GrenadeStorm, 1, 4, 3, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Grenade_Storm),
            //-
            new Weapon(Localization.Stream, 1, 5, 0, Guidance.Parabola, Color.Blue, WeaponsImg.Stream),
            new Weapon(Localization.Creek, 1, 5, 1, Guidance.Parabola, Color.Blue, WeaponsImg.Creek),
            new Weapon(Localization.River, 1, 5, 2, Guidance.Parabola, Color.Blue, WeaponsImg.River),
            new Weapon(Localization.Tsunami, 1, 5, 3, Guidance.Parabola, Color.Blue, WeaponsImg.Tsunami),
            //-
            new Weapon(Localization.Flame, 1, 6, 0, Guidance.Parabola, Color.Orange, WeaponsImg.Flame),
            new Weapon(Localization.Blaze, 1, 6, 1, Guidance.Parabola, Color.Orange, WeaponsImg.Blaze),
            new Weapon(Localization.Inferno, 1, 6, 2, Guidance.Parabola, Color.Orange, WeaponsImg.Inferno),
            //-
            new Weapon(Localization.Roller, 1, 7, 0, Guidance.Parabola, Color.Red, WeaponsImg.Roller),
            new Weapon(Localization.HeavyRoller, 1, 7, 1, Guidance.Parabola, Color.Red, WeaponsImg.Heavy_Roller),
            new Weapon(Localization.Groller, 1, 7, 2, Guidance.Parabola, Color.Red, WeaponsImg.Groller),
            //-
            new Weapon(Localization.BackRoller, 1, 8, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Back_Roller),
            new Weapon(Localization.HeavyBackRoller, 1, 8, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Heavy_Back_Roller),
            new Weapon(Localization.BackGroller, 1, 8, 2, Guidance.Parabola, Color.Chocolate, WeaponsImg.Back_Groller),
            //-
            new Weapon(Localization.Splitter, 1, 9, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Splitter),
            new Weapon(Localization.DoubleSplitter, 1, 9, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Double_Splitter),
            new Weapon(Localization.SuperSplitter, 1, 9, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Super_Splitter),
            new Weapon(Localization.SplitterChain, 1, 9, 3, Guidance.Parabola, Color.Goldenrod, WeaponsImg.SplitterChain),
            //-
            new Weapon(Localization.Breaker, 1, 10, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Breaker),
            new Weapon(Localization.DoubleBreaker, 1, 10, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Double_Breaker),
            new Weapon(Localization.SuperBreaker, 1, 10, 2, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Super_Breaker),
            new Weapon(Localization.BreakerChain, 1, 10, 3, Guidance.Parabola, Color.LimeGreen, WeaponsImg.BreakerChain),
            //-
            new Weapon(Localization.Twinkler, 1, 11, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Twinkler),
            new Weapon(Localization.Sparkler, 1, 11, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Sparkler),
            new Weapon(Localization.Crackler, 1, 11, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Crackler),
            //-
            new Weapon(Localization.Sniper, 1, 12, 0, Guidance.Parabola, Color.Red, WeaponsImg.Sniper),
            new Weapon(Localization.SubSniper, 1, 12, 1, Guidance.Parabola, Color.Red, WeaponsImg.Sub_Sniper),
            new Weapon(Localization.SmartSnipe, 1, 12, 2, Guidance.Parabola, Color.Red, WeaponsImg.SmartSnipe),
            //-
            new Weapon(Localization.Cactus, 1, 13, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Cactus),
            new Weapon(Localization.CactusStrike, 1, 13, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Cactus_Strike),
            //-
            new Weapon(Localization.Bulger, 1, 14, 0, Guidance.Parabola, Color.Blue, WeaponsImg.Bulger),
            new Weapon(Localization.BigBulger, 1, 14, 1, Guidance.Parabola, Color.Blue, WeaponsImg.Big_Bulger),
            //-
            new Weapon(Localization.Sinkhole, 1, 15, 0, Guidance.Parabola, Color.Red, WeaponsImg.Sinkhole),
            new Weapon(Localization.AreaStrike, 1, 15, 1, Guidance.Parabola, Color.Red, WeaponsImg.Area_Strike),
            new Weapon(Localization.AreaAttack, 1, 15, 2, Guidance.Parabola, Color.Red, WeaponsImg.Area_Attack),
            //-
            new Weapon(Localization.RapidFire, 1, 16, 0, Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.RapidFire),
            new Weapon(Localization.Shotgun, 1, 16, 1, Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Shotgun),
            new Weapon(Localization.BurstFire, 1, 16, 2, Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Burst_Fire),
            new Weapon(Localization.GatlingGun, 1, 16, 3, Guidance.Parabola, Color.CornflowerBlue, WeaponsImg.Gatling_Gun),
            //-
            new Weapon(Localization.Tunneler, 1, 17, 0, Guidance.Parabola, Color.Blue, WeaponsImg.Tunneler),
            new Weapon(Localization.Torpedoes, 1, 17, 1, Guidance.Parabola, Color.Blue, WeaponsImg.Torpedoes),
            new Weapon(Localization.TunnelStrike, 1, 17, 2, Guidance.Parabola, Color.Blue, WeaponsImg.Tunnel_Strike),
            new Weapon(Localization.MegaTunneler, 1, 17, 3, Guidance.Parabola, Color.Blue, WeaponsImg.MegaTunneler),
            //-
            new Weapon(Localization.Horizon, 1, 18, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Horizon),
            new Weapon(Localization.Sweeper, 1, 18, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Sweeper),
            //-
            new Weapon(Localization.AirStrike, 1, 19, 0, Guidance.Parabola, Color.Red, WeaponsImg.Air_Strike),
            new Weapon(Localization.HelicopterStrike, 1, 19, 1, Guidance.Parabola, Color.Red, WeaponsImg.Helicopter_Strike),
            new Weapon(Localization.AC130, 1, 19, 2, Guidance.Parabola, Color.Red, WeaponsImg.AC_130),
            new Weapon(Localization.Artillery, 1, 19, 3, Guidance.Parabola, Color.Red, WeaponsImg.Artillery),
            //-
                        new Weapon(Localization.Flower, 2, 40, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Flower),
            new Weapon(Localization.Bouquet, 2, 40, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Bouquet),
            //-
            new Weapon(Localization.Guppies, 3, 41, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Guppies),
            new Weapon(Localization.Minnows, 3, 41, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Minnows),
            new Weapon(Localization.Goldfish, 3, 41, 2, Guidance.Parabola, Color.Chocolate, WeaponsImg.Goldfish),
            //-
            new Weapon(Localization.Earthquake, 4, 42, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Earthquake),
            new Weapon(Localization.MegaQuake, 4, 42, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Mega_Quake),
            //-
            new Weapon(Localization.Banana, 5, 43, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Banana),
            new Weapon(Localization.BananaSplit, 5, 43, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Banana_Split),
            new Weapon(Localization.BananaBunch, 5, 43, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Banana_Bunch),
            //-
            new Weapon(Localization.Snake, 6, 44, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Snake),
            new Weapon(Localization.Python, 6, 44, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Python),
            new Weapon(Localization.Cobra, 6, 44, 2, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Cobra),
            //-
            new Weapon(Localization.Zipper, 7, 45, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Zipper),
            new Weapon(Localization.DoubleZipper, 7, 45, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Double_Zipper),
            new Weapon(Localization.ZipperQuad, 7, 45, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Zipper_Quad),
            //-
            new Weapon(Localization.Bounsplode, 8, 46, 0, Guidance.Parabola, Color.Purple, WeaponsImg.Bounsplode),
            new Weapon(Localization.DoubleBounsplode, 8, 46, 1, Guidance.Parabola, Color.Purple, WeaponsImg.Double_Bounsplode),
            new Weapon(Localization.TripleBounsplode, 8, 46, 2, Guidance.Parabola, Color.Purple, WeaponsImg.Triple_Bounsplode),
            //-
            new Weapon(Localization.Glock, 9, 47, 0, Guidance.Parabola, Color.SlateGray, WeaponsImg.Glock),
            new Weapon(Localization.M9, 9, 47, 1, Guidance.Parabola, Color.SlateGray, WeaponsImg.M9),
            new Weapon(Localization.DesertEagle, 9, 47, 2, Guidance.Parabola, Color.SlateGray, WeaponsImg.Desert_Eagle),
            //-
            new Weapon(Localization.DeadWeight, 10, 48, 0, Guidance.Parabola, Color.DarkBlue, WeaponsImg.Dead_Weight),
            new Weapon(Localization.DeadRiser, 10, 48, 1, Guidance.Parabola, Color.DarkBlue, WeaponsImg.Dead_Riser),
            //-
            new Weapon(Localization.Pixel, 11, 49, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Pixel),
            new Weapon(Localization.MegaPixel, 11, 49, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Mega_Pixel),
            new Weapon(Localization.SuperPixel, 11, 49, 2, Guidance.Parabola, Color.Gray, WeaponsImg.Super_Pixel),
            new Weapon(Localization.UltraPixel, 11, 49, 3, Guidance.Parabola, Color.Gray, WeaponsImg.Ultra_Pixel),
            //-
            new Weapon(Localization.Builder, 12, 50, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Builder),
            new Weapon(Localization.MegaBuilder, 12, 50, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.MegaBuilder),
            //-
            new Weapon(Localization.Static, 13, 51, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Static),
            new Weapon(Localization.StaticLink, 13, 51, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Static_Link),
            new Weapon(Localization.StaticChain, 13, 51, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Static_Chain),
            //-
            new Weapon(Localization.Molehill, 14, 52, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Molehill),
            new Weapon(Localization.Moles, 14, 52, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Moles),
            //-
            new Weapon(Localization.Counter3000, 15, 53, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Counter_3000),
            new Weapon(Localization.Counter4000, 15, 53, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Counter_4000),
            new Weapon(Localization.Counter5000, 15, 53, 2, Guidance.Parabola, Color.Gray, WeaponsImg.Counter_5000),
            new Weapon(Localization.Counter6000, 15, 53, 3, Guidance.Parabola, Color.Gray, WeaponsImg.Counter_6000),
            //-
            new Weapon(Localization.HoverBall, 16, 54, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Hover_Ball),
            new Weapon(Localization.HeavyHoverBall, 16, 54, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Heavy_Hover_Ball),
            //-
            new Weapon(Localization.Ringer, 17, 55, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Ringer),
            new Weapon(Localization.HeavyRinger, 17, 55, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Heavy_Ringer),
            new Weapon(Localization.OlympicRinger, 17, 55, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Olympic_Ringer),
            //-
            new Weapon(Localization.Rainbow, 18, 56, 0, Guidance.Parabola, Color.Red, WeaponsImg.Rainbow),
            new Weapon(Localization.MegaRainbow, 18, 56, 1, Guidance.Parabola, Color.Red, WeaponsImg.MegaRainbow),
            //-
            new Weapon(Localization.Moons, 19, 57, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Moons),
            new Weapon(Localization.Orbitals, 19, 57, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Orbitals),
            //-
            new Weapon(Localization.MiniPinger, 20, 58, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Mini_Pinger),
            new Weapon(Localization.Pinger, 20, 58, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Pinger),
            new Weapon(Localization.PingFlood, 20, 58, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Ping_Flood),
            //-
            new Weapon(Localization.Shank, 21, 59, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Shank),
            new Weapon(Localization.Dagger, 21, 59, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Dagger),
            new Weapon(Localization.Sword, 21, 59, 2, Guidance.Parabola, Color.Gray, WeaponsImg.Sword),
            //-
            new Weapon(Localization.Bolt, 22, 60, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Bolt),
            new Weapon(Localization.Lightning, 22, 60, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Lightning),
            new Weapon(Localization._2012, 22, 60, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg._2012),
            //-
            new Weapon(Localization.Gravies, 23, 61, 0, Guidance.Parabola, Color.Red, WeaponsImg.Gravies),
            new Weapon(Localization.Gravits, 23, 61, 1, Guidance.Parabola, Color.Red, WeaponsImg.Gravits),
            //-
            new Weapon(Localization.Spiker, 24, 62, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Spiker),
            new Weapon(Localization.SuperSpiker, 24, 62, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Super_Spiker),
            //-
            new Weapon(Localization.DiscoBall, 25, 63, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Disco_Ball),
            new Weapon(Localization.GroovyBall, 25, 63, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Groovy_Ball),
            //-
            new Weapon(Localization.Boomerang, 26, 64, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Boomerang),
            new Weapon(Localization.BigBoomerang, 26, 64, 1, Guidance.Parabola, Color.Gray, WeaponsImg.BigBoomerang),
            //-
            new Weapon(Localization.Tadpoles, 27, 65, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Tadpoles),
            new Weapon(Localization.Frogs, 27, 65, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Frogs),
            new Weapon(Localization.Bullfrog, 27, 65, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Bullfrog),
            //-
            new Weapon(Localization.MiniV, 28, 66, 0, Guidance.Parabola, Color.Red, WeaponsImg.Mini_V),
            new Weapon(Localization.FlyingV, 28, 66, 1, Guidance.Parabola, Color.Red, WeaponsImg.Flying_V),
            //-
            new Weapon(Localization.YinYang, 29, 67, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Yin_Yang),
            new Weapon(Localization.YinYangYong, 29, 67, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Yin_Yang_Yong),
            //-
            new Weapon(Localization.Fireworks, 30, 68, 0, Guidance.Parabola, Color.Red, WeaponsImg.Fireworks),
            new Weapon(Localization.GrandFinale, 30, 68, 1, Guidance.Parabola, Color.Red, WeaponsImg.Grand_Finale),
            new Weapon(Localization.Pyrotechnics, 30, 68, 2, Guidance.Parabola, Color.Red, WeaponsImg.Pyrotechnics),
            //-
            new Weapon(Localization.WaterBalloon, 31, 69, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Water_Balloon),
            new Weapon(Localization.WaterTrio, 31, 69, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Water_Trio),
            new Weapon(Localization.WaterFight, 31, 69, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Water_Fight),
            //-
            new Weapon(Localization.Magnets, 32, 70, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Magnets),
            new Weapon(Localization.Attractoids, 32, 70, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Attractoids),
            //-
            new Weapon(Localization.Arrow, 33, 71, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Arrow),
            new Weapon(Localization.BowAndArrow, 33, 71, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Bow_And_Arrow),
            new Weapon(Localization.FlamingArrow, 33, 71, 2, Guidance.Parabola, Color.Chocolate, WeaponsImg.Flaming_Arrow),
            //-
            new Weapon(Localization.Driller, 34, 72, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Driller),
            new Weapon(Localization.Slammer, 34, 72, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Slammer),
            //-
            new Weapon(Localization.Quicksand, 35, 73, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Quicksand),
            new Weapon(Localization.Desert, 35, 73, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Desert),
            //-
            new Weapon(Localization.Jumper, 36, 74, 0, Guidance.Parabola, Color.Red, WeaponsImg.Jumper),
            new Weapon(Localization.TripleJumper, 36, 74, 1, Guidance.Parabola, Color.Red, WeaponsImg.Triple_Jumper),
            //-
            new Weapon(Localization.Spaz, 37, 75, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Spaz),
            new Weapon(Localization.Spazzer, 37, 75, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Spazzer),
            new Weapon(Localization.Spaztastic, 37, 75, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Spaztastic),
            //-
            new Weapon(Localization.Pinata, 38, 76, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Pinata),
            new Weapon(Localization.Fiesta, 38, 76, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Fiesta),
            //-
            new Weapon(Localization.Shockwave, 39, 77, 0, Guidance.Parabola, Color.DarkBlue, WeaponsImg.Shockwave),
            new Weapon(Localization.SonicPulse, 39, 77, 1, Guidance.Parabola, Color.DarkBlue, WeaponsImg.Sonic_Pulse),
            //-
            new Weapon(Localization.Bounder, 40, 78, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Bounder),
            new Weapon(Localization.DoubleBounder, 40, 78, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Double_Bounder),
            new Weapon(Localization.TripleBounder, 40, 78, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Triple_Bounder),
            //-
            new Weapon(Localization.UZI, 41, 79, 0, Guidance.Parabola, Color.SlateGray, WeaponsImg.UZI),
            new Weapon(Localization.MP5, 41, 79, 1, Guidance.Parabola, Color.SlateGray, WeaponsImg.MP5),
            new Weapon(Localization.P90, 41, 79, 2, Guidance.Parabola, Color.SlateGray, WeaponsImg.P90),
            //-
            new Weapon(Localization.StickyBomb, 42, 80, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Sticky_Bomb),
            new Weapon(Localization.StickyTrio, 42, 80, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Sticky_Trio),
            new Weapon(Localization.MineLayer, 42, 80, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Mine_Layer),
            new Weapon(Localization.StickyRain, 42, 80, 3, Guidance.Parabola, Color.DarkGray, WeaponsImg.Sticky_Rain),
            //-
            new Weapon(Localization.Fleet, 43, 81, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Fleet),
            new Weapon(Localization.HeavyFleet, 43, 81, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Heavy_Fleet),
            new Weapon(Localization.SuperFleet, 43, 81, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Super_Fleet),
            new Weapon(Localization.Squadron, 43, 81, 3, Guidance.Parabola, Color.DarkGray, WeaponsImg.Squadron),
            //-
            new Weapon(Localization.Rain, 44, 82, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Rain),
            new Weapon(Localization.Hail, 44, 82, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Hail),
            //-
            new Weapon(Localization.Sillyballs, 45, 83, 0, Guidance.Parabola, Color.Purple, WeaponsImg.Sillyballs),
            new Weapon(Localization.Wackyballs, 45, 83, 1, Guidance.Parabola, Color.Purple, WeaponsImg.Wackyballs),
            new Weapon(Localization.Crazyballs, 45, 83, 2, Guidance.Parabola, Color.Purple, WeaponsImg.Crazyballs),
            //-
            new Weapon(Localization.Napalm, 46, 84, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Napalm),
            new Weapon(Localization.HeavyNapalm, 46, 84, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Heavy_Napalm),
            new Weapon(Localization.FireStorm, 46, 84, 2, Guidance.Parabola, Color.Chocolate, WeaponsImg.FireStorm),
            //-
            new Weapon(Localization.SawBlade, 47, 85, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Saw_Blade),
            new Weapon(Localization.RipSaw, 47, 85, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Rip_Saw),
            new Weapon(Localization.DiamondBlade, 47, 85, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Diamond_Blade),
            //-
            new Weapon(Localization.Sunburst, 48, 86, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.SunBurst),
            new Weapon(Localization.SolarFlare, 48, 86, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Solar_Flare),
            //-
            new Weapon(Localization.Synclets, 49, 87, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Synclets),
            new Weapon(Localization.SuperSynclets, 49, 87, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Super_Synclets),
            //-
            new Weapon(Localization.Payload, 50, 88, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Payload),
            new Weapon(Localization.MagicShower, 50, 88, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Magic_Shower),
            //-
            new Weapon(Localization.Shadow, 51, 89, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Shadow),
            new Weapon(Localization.Darkshadow, 51, 89, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Darkshadow),
            new Weapon(Localization.Deathshadow, 51, 89, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Deathshadow),
            //-
            new Weapon(Localization.XAttack, 52, 90, 0, Guidance.Parabola, Color.Gray, WeaponsImg.X_Attack),
            new Weapon(Localization.OAttack, 52, 90, 1, Guidance.Parabola, Color.Gray, WeaponsImg.O_Attack),
            //-
            new Weapon(Localization.CarpetBomb, 53, 91, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Carpet_Bomb),
            new Weapon(Localization.CarpetFire, 53, 91, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Carpet_Fire),
            new Weapon(Localization.IncendiaryBombs, 53, 91, 2, Guidance.Parabola, Color.Chocolate, WeaponsImg.Incendiary_Bombs),
            //-
            new Weapon(Localization.BabySeagull, 54, 92, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Baby_Seagull),
            new Weapon(Localization.Seagull, 54, 92, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Seagull),
            new Weapon(Localization.MamaSeagull, 54, 92, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Mama_Seagull),
            //-
            new Weapon(Localization.Shrapnel, 55, 93, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Shrapnel),
            new Weapon(Localization.Shredders, 55, 93, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Shredders),
            //-
            new Weapon(Localization.Penetrator, 56, 94, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Penetrator),
            new Weapon(Localization.Penetratorv2, 56, 94, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Penetrator_v2),
            //-
            new Weapon(Localization.Jammer, 57, 95, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Jammer),
            new Weapon(Localization.Jiver, 57, 95, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Jiver),
            new Weapon(Localization.Rocker, 57, 95, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Rocker),
            //-
            new Weapon(Localization.Chunklet, 58, 96, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Chunklet),
            new Weapon(Localization.Chunker, 58, 96, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Chunker),
            //-
            new Weapon(Localization.BouncyBall, 59, 97, 0, Guidance.Parabola, Color.Purple, WeaponsImg.Bouncy_Ball),
            new Weapon(Localization.SuperBall, 59, 97, 1, Guidance.Parabola, Color.Purple, WeaponsImg.Super_Ball),
            //-
            new Weapon(Localization.Minions, 60, 98, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Minions),
            new Weapon(Localization.ManyMinions, 60, 98, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Many_Minions),
            //-
            new Weapon(Localization.BatteringRam, 61, 99, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Battering_Ram),
            new Weapon(Localization.DoubleRam, 61, 99, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Double_Ram),
            new Weapon(Localization.RamSquad, 61, 99, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Ram_Squad),
            new Weapon(Localization.DoubleRamSquad, 61, 99, 3, Guidance.Parabola, Color.DarkGray, WeaponsImg.Double_Ram_Squad),
            //-
            new Weapon(Localization.Asteroids, 62, 100, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Asteroids),
            new Weapon(Localization.Comets, 62, 100, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Comets),
            new Weapon(Localization.AsteroidStorm, 62, 100, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Asteroid_Storm),
            //-
            new Weapon(Localization.Spider, 63, 101, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Spider),
            new Weapon(Localization.Tarantula, 63, 101, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Tarantula),
            new Weapon(Localization.DaddyLonglegs, 63, 101, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Daddy_Longlegs),
            new Weapon(Localization.BlackWidow, 63, 101, 3, Guidance.Parabola, Color.DarkGray, WeaponsImg.Black_Widow),
            //-
            new Weapon(Localization.Rampage, 64, 102, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Rampage),
            new Weapon(Localization.Riot, 64, 102, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Riot),
            //-
            new Weapon(Localization.M4, 65, 103, 0, Guidance.Parabola, Color.SlateGray, WeaponsImg.M4),
            new Weapon(Localization.M16, 65, 103, 1, Guidance.Parabola, Color.SlateGray, WeaponsImg.M16),
            new Weapon(Localization.AK47, 65, 103, 2, Guidance.Parabola, Color.SlateGray, WeaponsImg.AK_47),
            //-
            new Weapon(Localization.Clover, 66, 104, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Clover),
            new Weapon(Localization.FourLeafClover, 66, 104, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Four_Leaf_Clover),
            //-
            new Weapon(Localization._3DBomb, 67, 105, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg._3D_Bomb),
            new Weapon(Localization._2x3D, 67, 105, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg._2x3D),
            new Weapon(Localization._3x3D, 67, 105, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg._3x3D),
            //-
            new Weapon(Localization.Snowball, 68, 106, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Snowball),
            new Weapon(Localization.Snowstorm, 68, 106, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Snowstorm),
            //-
            new Weapon(Localization.Spotter, 69, 107, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Spotter),
            new Weapon(Localization.SpotterXL, 69, 107, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Spotter_XL),
            new Weapon(Localization.SpotterXXL, 69, 107, 2, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Spotter_XXL),
            //-
            new Weapon(Localization.FighterJet, 70, 108, 0, Guidance.Parabola, Color.Chocolate, WeaponsImg.Fighter_Jet),
            new Weapon(Localization.HeavyJet, 70, 108, 1, Guidance.Parabola, Color.Chocolate, WeaponsImg.Heavy_Jet),
            //-
            new Weapon(Localization.Bounstrike, 71, 109, 0, Guidance.Parabola, Color.Purple, WeaponsImg.Bounstrike),
            new Weapon(Localization.Bounstream, 71, 109, 1, Guidance.Parabola, Color.Purple, WeaponsImg.Bounstream),
            new Weapon(Localization.Bounstorm, 71, 109, 2, Guidance.Parabola, Color.Purple, WeaponsImg.Bounstorm),
            //-
            new Weapon(Localization.StarFire, 72, 110, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.StarFire),
            new Weapon(Localization.ShootingStar, 72, 110, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Shooting_Star),
            //-
            new Weapon(Localization.BeeHive, 73, 111, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Bee_Hive),
            new Weapon(Localization.KillerBees, 73, 111, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Killer_Bees),
            new Weapon(Localization.Wasps, 73, 111, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Wasps),
            //-
            new Weapon(Localization.DualRoller, 74, 112, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Dual_Roller),
            new Weapon(Localization.Spreader, 74, 112, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Spreader),
            //-
            new Weapon(Localization.Partition, 75, 113, 0, Guidance.Parabola, Color.Gray, WeaponsImg.Partition),
            new Weapon(Localization.Division, 75, 113, 1, Guidance.Parabola, Color.Gray, WeaponsImg.Division),
            //-
            new Weapon(Localization.BFG1000, 76, 114, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.BFG_1000),
            new Weapon(Localization.BFG9000, 76, 114, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.BFG_9000),
            //-
            new Weapon(Localization.Train, 77, 115, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Train),
            new Weapon(Localization.Express, 77, 115, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Express),
            //-
            new Weapon(Localization.MiniTurret, 78, 116, 0, Guidance.Parabola, Color.Red, WeaponsImg.Mini_Turret),
            new Weapon(Localization.TurretMob, 78, 116, 1, Guidance.Parabola, Color.Red, WeaponsImg.TurretMob),
            //-
            new Weapon(Localization.Kamikaze, 79, 117, 0, Guidance.Parabola, Color.Red, WeaponsImg.Kamikaze),
            new Weapon(Localization.SuicideBomber, 79, 117, 1, Guidance.Parabola, Color.Red, WeaponsImg.Suicide_Bomber),
            //-
            new Weapon(Localization.Nuke, 80, 118, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Nuke),
            new Weapon(Localization.MegaNuke, 80, 118, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.MegaNuke),
            //-
            new Weapon(Localization.BlackHole, 81, 119, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Black_Hole),
            new Weapon(Localization.CosmicRift, 81, 119, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Cosmic_Rift),
            //-
            new Weapon(Localization.BumperBombs, 82, 120, 0, Guidance.Parabola, Color.Purple, WeaponsImg.Bumper_Bombs),
            new Weapon(Localization.BumperArray, 82, 120, 1, Guidance.Parabola, Color.Purple, WeaponsImg.Bumper_Array),
            new Weapon(Localization.BumperAssault, 82, 120, 2, Guidance.Parabola, Color.Purple, WeaponsImg.Bumper_Assault),
            //-
            new Weapon(Localization.BreakerMadness, 83, 121, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.BreakerMadness),
            new Weapon(Localization.BreakerMania, 83, 121, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.BreakerMania),
            //-
            new Weapon(Localization.HomingMissile, 84, 122, 0, Guidance.Parabola, Color.Red, WeaponsImg.Homing_Missile),
            new Weapon(Localization.HomingRockets, 84, 122, 1, Guidance.Parabola, Color.Red, WeaponsImg.Homing_Rockets),
            //-
            new Weapon(Localization.Puzzler, 85, 123, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Puzzler),
            new Weapon(Localization.Deceiver, 85, 123, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Deceiver),
            new Weapon(Localization.Baffler, 85, 123, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Baffler),
            //-
            new Weapon(Localization.RocketFire, 86, 124, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Rocket_Fire),
            new Weapon(Localization.RocketCluster, 86, 124, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Rocket_Cluster),
            new Weapon(Localization.Flurry, 86, 124, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Flurry),
            //-
            new Weapon(Localization.Pentagram, 87, 125, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Pentagram),
            new Weapon(Localization.Pentaslam, 87, 125, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Pentaslam),
            //-
            new Weapon(Localization.Radar, 88, 126, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Radar),
            new Weapon(Localization.Sonar, 88, 126, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Sonar),
            new Weapon(Localization.Lidar, 88, 126, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Lidar),
            //-
            new Weapon(Localization.LaserBeam, 89, 127, 0, Guidance.Parabola, Color.Red, WeaponsImg.Laser_Beam),
            new Weapon(Localization.GreatBeam, 89, 127, 1, Guidance.Parabola, Color.Red, WeaponsImg.Great_Beam),
            new Weapon(Localization.UltraBeam, 89, 127, 2, Guidance.Parabola, Color.Red, WeaponsImg.Ultra_Beam),
            new Weapon(Localization.MasterBeam, 89, 127, 3, Guidance.Parabola, Color.Red, WeaponsImg.Master_Beam),
            //-
            new Weapon(Localization.Tweeter, 90, 128, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Tweeter),
            new Weapon(Localization.Squawker, 90, 128, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Squawker),
            new Weapon(Localization.Woofer, 90, 128, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Woofer),
            //-
            new Weapon(Localization.AcidRain, 91, 129, 0, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Acid_Rain),
            new Weapon(Localization.AcidHail, 91, 129, 1, Guidance.Parabola, Color.LimeGreen, WeaponsImg.Acid_Hail),
            //-
            new Weapon(Localization.Sunflower, 92, 130, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Sunflower),
            new Weapon(Localization.Helianthus, 92, 130, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Helianthus),
            //-
            new Weapon(Localization.Taser, 93, 131, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Taser),
            new Weapon(Localization.HeavyTaser, 93, 131, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Heavy_Taser),
            //-
            new Weapon(Localization.Sausage, 94, 132, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Sausage),
            new Weapon(Localization.Bratwurst, 94, 132, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Bratwurst),
            new Weapon(Localization.Kielbasa, 94, 132, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Kielbasa),
            //-
            new Weapon(Localization.Jackpot, 95, 133, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Jackpot),
            new Weapon(Localization.MegaJackpot, 95, 133, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Mega_Jackpot),
            new Weapon(Localization.UltraJackpot, 95, 133, 2, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Ultra_Jackpot),
            new Weapon(Localization.Lottery, 95, 133, 3, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Lottery),
            //-
            new Weapon(Localization.EarlyBird, 96, 134, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Early_Bird),
            new Weapon(Localization.EarlyWorm, 96, 134, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Early_Worm),
            //-
            new Weapon(Localization.Recruiter, 97, 135, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Recruiter),
            new Weapon(Localization.Enroller, 97, 135, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Enroller),
            new Weapon(Localization.Enlister, 97, 135, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Enlister),
            //-
            new Weapon(Localization.Fury, 98, 136, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Fury),
            new Weapon(Localization.Rage, 98, 136, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Rage),
            //-
            new Weapon(Localization.Relocator, 99, 137, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Relocator),
            new Weapon(Localization.DisplacementBomb, 99, 137, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Displacement_Bomb),
            //-
            new Weapon(Localization.Imploder, 100, 138, 0, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Imploder),
            new Weapon(Localization.UltimateImploder, 100, 138, 1, Guidance.Parabola, Color.Goldenrod, WeaponsImg.Ultimate_Imploder),
            //-
            new Weapon(Localization.Stone, 101, 139, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Stone),
            new Weapon(Localization.Boulder, 101, 139, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Boulder),
            new Weapon(Localization.Fireball, 101, 139, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Fireball),
            //-
            new Weapon(Localization.Cat, 101, 140, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Cat),
            new Weapon(Localization.Kittens, 101, 140, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Kittens),
            new Weapon(Localization.SuperCat, 101, 140, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.SuperCat),
            new Weapon(Localization.CatsandDogs, 101, 140, 3, Guidance.Parabola, Color.DarkGray, WeaponsImg.Cats_and_Dogs),
            //-
            new Weapon(Localization.GhostBomb, 101, 141, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Ghost_Bomb),
            new Weapon(Localization.Ghostlets, 101, 141, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Ghostlets),
            //-
            new Weapon(Localization.Flasher, 101, 142, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Flasher),
            new Weapon(Localization.Strobie, 101, 142, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Strobie),
            new Weapon(Localization.Rave, 101, 142, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Rave),
            //-
            new Weapon(Localization.Sprouter, 101, 143, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Sprouter),
            new Weapon(Localization.Blossom, 101, 143, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Blossom),
            //-
            new Weapon(Localization.Square, 101, 144, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Square),
            new Weapon(Localization.Hexagon, 101, 144, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Hexagon),
            new Weapon(Localization.Octagon, 101, 144, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Octagon),
            //-
            new Weapon(Localization.WackyCluster, 101, 145, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Wacky_Cluster),
            new Weapon(Localization.KookyCluster, 101, 145, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Kooky_Cluster),
            new Weapon(Localization.CrazyCluster, 101, 145, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Crazy_Cluster),
            //-
            new Weapon(Localization.Satellite, 101, 146, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Satellite),
            new Weapon(Localization.UFO, 101, 146, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.UFO),
            //-
            new Weapon(Localization.Palm, 102, 147, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Palm),
            new Weapon(Localization.DoublePalm, 102, 147, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Double_Palm),
            new Weapon(Localization.TriplePalm, 102, 147, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Triple_Palm),
            //-
            new Weapon(Localization.ShockShell, 102, 148, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.ShockShell),
            new Weapon(Localization.ShockShellTrio, 102, 148, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.ShockShell_Trio),
            //-
            new Weapon(Localization.Fountain, 102, 149, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Fountain),
            new Weapon(Localization.Waterworks, 102, 149, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Waterworks),
            new Weapon(Localization.Sprinkler, 102, 149, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Sprinkler),
            //-
            new Weapon(Localization.Flattener, 102, 150, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Flattener),
            new Weapon(Localization.Wall, 102, 150, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Wall),
            new Weapon(Localization.Fortress, 102, 150, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Fortress),
            new Weapon(Localization.Funnel, 102, 150, 3, Guidance.Parabola, Color.DarkGray, WeaponsImg.Funnel),
            //-
            new Weapon(Localization.ChickenFling, 102, 151, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Chicken_Fling),
            new Weapon(Localization.ChickenHurl, 102, 151, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Chicken_Hurl),
            new Weapon(Localization.ChickenLaunch, 102, 151, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Chicken_Launch),
            //-
            new Weapon(Localization.MadBirds, 102, 152, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Mad_Birds),
            new Weapon(Localization.FuriousBirds, 102, 152, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Furious_Birds),
            new Weapon(Localization.LividBirds, 102, 152, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Livid_Birds),
            //-
            new Weapon(Localization.Pepper, 102, 153, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Pepper),
            new Weapon(Localization.SaltandPepper, 102, 153, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Salt_and_Pepper),
            //-
            new Weapon(Localization.Needler, 102, 154, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Needler),
            new Weapon(Localization.DualNeedler, 102, 154, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Dual_Needler),
            //-
            new Weapon(Localization.Beacon, 102, 155, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Beacon),
            new Weapon(Localization.Beaconator, 102, 155, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Beaconator),
            //-
            new Weapon(Localization.Kernels, 102, 156, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Kernels),
            new Weapon(Localization.Popcorn, 102, 156, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Popcorn),
            new Weapon(Localization.BurntPopcorn, 102, 156, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Burnt_Popcorn),
            //-
            new Weapon(Localization.Chopper, 102, 157, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Chopper),
            new Weapon(Localization.Apache, 102, 157, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Apache),
            //-
            new Weapon(Localization.Flintlock, 102, 158, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Flintlock),
            new Weapon(Localization.Blunderbuss, 102, 158, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Blunderbuss),
            //-
            new Weapon(Localization.SkullShot, 102, 159, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.SkullShot),
            new Weapon(Localization.Skeleton, 102, 159, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Skeleton),
            //-
            new Weapon(Localization.Pinpoint, 102, 160, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Pinpoint),
            new Weapon(Localization.Needles, 102, 160, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Needles),
            new Weapon(Localization.PinsandNeedles, 102, 160, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Pins_and_Needles),
            //-
            new Weapon(Localization.FatStacks, 102, 161, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Fat_Stacks),
            new Weapon(Localization.DollaBills, 102, 161, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Dolla_Bills),
            new Weapon(Localization.MakeItRain, 102, 161, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Make_It_Rain),
            //-
            new Weapon(Localization.GodRays, 102, 162, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.God_Rays),
            new Weapon(Localization.Deity, 102, 162, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Deity),
            //-
            new Weapon(Localization.HiddenBlade, 102, 163, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Hidden_Blade),
            new Weapon(Localization.SecretBlade, 102, 163, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Secret_Blade),
            new Weapon(Localization.ConcealedBlade, 102, 163, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Concealed_Blade),
            //-
            new Weapon(Localization.PortalGun, 102, 164, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Portal_Gun),
            new Weapon(Localization.ASHPD, 102, 164, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.ASHPD),
            //-
            new Weapon(Localization.Volcano, 103, 165, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Volcano),
            new Weapon(Localization.Eruption, 103, 165, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Eruption),
            //-
            new Weapon(Localization.ThrowingStar, 103, 166, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Throwing_Star),
            new Weapon(Localization.MultiStar, 103, 166, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Multi_Star),
            new Weapon(Localization.Ninja, 103, 166, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Ninja),
            //-
            new Weapon(Localization.Skeet, 103, 167, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Skeet),
            new Weapon(Localization.OlympicSkeet, 103, 167, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Olympic_Skeet),
            //-
            new Weapon(Localization.TangentFire, 103, 168, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Tangent_Fire),
            new Weapon(Localization.TangentAttack, 103, 168, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Tangent_Attack),
            new Weapon(Localization.TangentAssault, 103, 168, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Tangent_Assault),
            //-
            new Weapon(Localization.Summoner, 103, 169, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Summoner),
            new Weapon(Localization.Mage, 103, 169, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Mage),
            //-
            new Weapon(Localization.Travelers, 103, 170, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Travelers),
            new Weapon(Localization.Scavengers, 103, 170, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Scavengers),
            //-
            new Weapon(Localization.JackoLantern, 103, 171, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Jack_o_Lantern),
            new Weapon(Localization.JackoVomit, 103, 171, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Jack_o_Vomit),
            //-
            new Weapon(Localization.WickedWitch, 103, 172, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Wicked_Witch),
            new Weapon(Localization.WitchesBroom, 103, 172, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Witches_Broom),
            new Weapon(Localization.Ghouls, 103, 172, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Ghouls),
            //-
            new Weapon(Localization.Oddball, 103, 173, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Oddball),
            new Weapon(Localization.Oddbomb, 103, 173, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Oddbomb),
            //-
            new Weapon(Localization.Botherer, 103, 174, 0, Guidance.Parabola, Color.DarkGray, WeaponsImg.Botherer),
            new Weapon(Localization.Tormentor, 103, 174, 1, Guidance.Parabola, Color.DarkGray, WeaponsImg.Tormentor),
            new Weapon(Localization.Punisher, 103, 174, 2, Guidance.Parabola, Color.DarkGray, WeaponsImg.Punisher)
        };
        
        private static Dictionary<String, Weapon> GetWeapons()
        {
            Dictionary<String, Weapon> dict = new Dictionary<String, Weapon>();
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