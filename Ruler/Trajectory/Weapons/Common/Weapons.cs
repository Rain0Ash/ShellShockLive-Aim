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
        private static readonly WeaponsLocalization Localization =
            new WeaponsLocalization(MainForm.GetLocalCultureCode());

        internal static readonly Weapon[,] WeaponsArray =
        {
                        {
                new Weapon(Localization.Shot, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Shot),
                new Weapon(Localization.BigShot, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Big_Shot),
                new Weapon(Localization.HeavyShot, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Heavy_Shot),
                new Weapon(Localization.MassiveShot, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Massive_Shot)
            },
            {
                new Weapon(Localization.ThreeBall, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Three_Ball),
                new Weapon(Localization.FiveBall, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Five_Ball),
                new Weapon(Localization.ElevenBall, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Eleven_Ball),
                new Weapon(Localization.TwentyFiveBall, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.TwentyFive_Ball)
            },
            {
                new Weapon(Localization.OneBounce, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.One_Bounce),
                new Weapon(Localization.ThreeBounce, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Three_Bounce),
                new Weapon(Localization.FiveBounce, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Five_Bounce),
                new Weapon(Localization.SevenBounce, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Seven_Bounce)
            },
            {
                new Weapon(Localization.Digger, 1, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Digger),
                new Weapon(Localization.MegaDigger, 1, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Mega_Digger),
                new Weapon(Localization.Excavation, 1, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Excavation),
                default
            },
            {
                new Weapon(Localization.Grenade, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Grenade),
                new Weapon(Localization.TriNade, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Tri_Nade),
                new Weapon(Localization.MultiNade, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Multi_Nade),
                new Weapon(Localization.GrenadeStorm, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Grenade_Storm)
            },
            {
                new Weapon(Localization.Stream, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Stream),
                new Weapon(Localization.Creek, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Creek),
                new Weapon(Localization.River, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.River),
                new Weapon(Localization.Tsunami, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Tsunami)
            },
            {
                new Weapon(Localization.Flame, 1, GuidanceType.Parabola, Color.FromArgb(255, 76, 0), WeaponsImg.Flame),
                new Weapon(Localization.Blaze, 1, GuidanceType.Parabola, Color.FromArgb(255, 76, 0), WeaponsImg.Blaze),
                new Weapon(Localization.Inferno, 1, GuidanceType.Parabola, Color.FromArgb(255, 76, 0), WeaponsImg.Inferno),
                default
            },
            {
                new Weapon(Localization.Roller, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Roller),
                new Weapon(Localization.HeavyRoller, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Heavy_Roller),
                new Weapon(Localization.Groller, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Groller),
                default
            },
            {
                new Weapon(Localization.BackRoller, 1, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Back_Roller),
                new Weapon(Localization.HeavyBackRoller, 1, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Heavy_Back_Roller),
                new Weapon(Localization.BackGroller, 1, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Back_Groller),
                default
            },
            {
                new Weapon(Localization.Splitter, 1, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Splitter),
                new Weapon(Localization.DoubleSplitter, 1, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Double_Splitter),
                new Weapon(Localization.SuperSplitter, 1, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Super_Splitter),
                new Weapon(Localization.SplitterChain, 1, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.SplitterChain)
            },
            {
                new Weapon(Localization.Breaker, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Breaker),
                new Weapon(Localization.DoubleBreaker, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Double_Breaker),
                new Weapon(Localization.SuperBreaker, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Super_Breaker),
                new Weapon(Localization.BreakerChain, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.BreakerChain)
            },
            {
                new Weapon(Localization.Twinkler, 1, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Twinkler),
                new Weapon(Localization.Sparkler, 1, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Sparkler),
                new Weapon(Localization.Crackler, 1, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Crackler),
                default
            },
            {
                new Weapon(Localization.Sniper, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Sniper),
                new Weapon(Localization.SubSniper, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Sub_Sniper),
                new Weapon(Localization.SmartSnipe, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.SmartSnipe),
                default
            },
            {
                new Weapon(Localization.Cactus, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Cactus),
                new Weapon(Localization.CactusStrike, 1, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Cactus_Strike),
                default,
                default
            },
            {
                new Weapon(Localization.Bulger, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Bulger),
                new Weapon(Localization.BigBulger, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Big_Bulger),
                default,
                default
            },
            {
                new Weapon(Localization.Sinkhole, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Sinkhole),
                new Weapon(Localization.AreaStrike, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Area_Strike),
                new Weapon(Localization.AreaAttack, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Area_Attack),
                default
            },
            {
                new Weapon(Localization.RapidFire, 1, GuidanceType.Parabola, Color.FromArgb(127, 191, 255), WeaponsImg.RapidFire),
                new Weapon(Localization.Shotgun, 1, GuidanceType.Parabola, Color.FromArgb(127, 191, 255), WeaponsImg.Shotgun),
                new Weapon(Localization.BurstFire, 1, GuidanceType.Parabola, Color.FromArgb(127, 191, 255), WeaponsImg.Burst_Fire),
                new Weapon(Localization.GatlingGun, 1, GuidanceType.Parabola, Color.FromArgb(127, 191, 255), WeaponsImg.Gatling_Gun)
            },
            {
                new Weapon(Localization.Tunneler, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Tunneler),
                new Weapon(Localization.Torpedoes, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Torpedoes),
                new Weapon(Localization.TunnelStrike, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Tunnel_Strike),
                new Weapon(Localization.MegaTunneler, 1, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.MegaTunneler)
            },
            {
                new Weapon(Localization.Horizon, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Horizon),
                new Weapon(Localization.Sweeper, 1, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Sweeper),
                default,
                default
            },
            {
                new Weapon(Localization.AirStrike, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Air_Strike),
                new Weapon(Localization.HelicopterStrike, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Helicopter_Strike),
                new Weapon(Localization.AC130, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.AC_130),
                new Weapon(Localization.Artillery, 1, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Artillery)
            },
            {
                new Weapon(Localization.Flower, 2, GuidanceType.Parabola, Color.FromArgb(255, 229, 0), WeaponsImg.Flower),
                new Weapon(Localization.Bouquet, 2, GuidanceType.Parabola, Color.FromArgb(255, 229, 0), WeaponsImg.Bouquet),
                default,
                default
            },
            {
                new Weapon(Localization.Guppies, 3, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Guppies),
                new Weapon(Localization.Minnows, 3, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Minnows),
                new Weapon(Localization.Goldfish, 3, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Goldfish),
                default
            },
            {
                new Weapon(Localization.Earthquake, 4, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Earthquake),
                new Weapon(Localization.MegaQuake, 4, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Mega_Quake),
                default,
                default
            },
            {
                new Weapon(Localization.Banana, 5, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Banana),
                new Weapon(Localization.BananaSplit, 5, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Banana_Split),
                new Weapon(Localization.BananaBunch, 5, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Banana_Bunch),
                default
            },
            {
                new Weapon(Localization.Snake, 6, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Snake),
                new Weapon(Localization.Python, 6, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Python),
                new Weapon(Localization.Cobra, 6, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Cobra),
                default
            },
            {
                new Weapon(Localization.Zipper, 7, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Zipper),
                new Weapon(Localization.DoubleZipper, 7, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Double_Zipper),
                new Weapon(Localization.ZipperQuad, 7, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Zipper_Quad),
                default
            },
            {
                new Weapon(Localization.Bounsplode, 8, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Bounsplode),
                new Weapon(Localization.DoubleBounsplode, 8, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Double_Bounsplode),
                new Weapon(Localization.TripleBounsplode, 8, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Triple_Bounsplode),
                default
            },
            {
                new Weapon(Localization.Glock, 9, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.Glock),
                new Weapon(Localization.M9, 9, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.M9),
                new Weapon(Localization.DesertEagle, 9, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.Desert_Eagle),
                default
            },
            {
                new Weapon(Localization.DeadWeight, 10, GuidanceType.Parabola, Color.FromArgb(0, 0, 255), WeaponsImg.Dead_Weight),
                new Weapon(Localization.DeadRiser, 10, GuidanceType.Parabola, Color.FromArgb(0, 0, 255), WeaponsImg.Dead_Riser),
                default,
                default
            },
            {
                new Weapon(Localization.Pixel, 11, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Pixel),
                new Weapon(Localization.MegaPixel, 11, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Mega_Pixel),
                new Weapon(Localization.SuperPixel, 11, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Super_Pixel),
                new Weapon(Localization.UltraPixel, 11, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Ultra_Pixel)
            },
            {
                new Weapon(Localization.Builder, 12, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Builder),
                new Weapon(Localization.MegaBuilder, 12, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.MegaBuilder),
                default,
                default
            },
            {
                new Weapon(Localization.Static, 13, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Static),
                new Weapon(Localization.StaticLink, 13, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Static_Link),
                new Weapon(Localization.StaticChain, 13, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Static_Chain),
                default
            },
            {
                new Weapon(Localization.Molehill, 14, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Molehill),
                new Weapon(Localization.Moles, 14, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Moles),
                default,
                default
            },
            {
                new Weapon(Localization.Counter3000, 15, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Counter_3000),
                new Weapon(Localization.Counter4000, 15, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Counter_4000),
                new Weapon(Localization.Counter5000, 15, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Counter_5000),
                new Weapon(Localization.Counter6000, 15, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Counter_6000)
            },
            {
                new Weapon(Localization.HoverBall, 16, GuidanceType.Parabola, Color.FromArgb(127, 127, 255), WeaponsImg.Hover_Ball),
                new Weapon(Localization.HeavyHoverBall, 16, GuidanceType.Parabola, Color.FromArgb(127, 127, 255), WeaponsImg.Heavy_Hover_Ball),
                default,
                default
            },
            {
                new Weapon(Localization.Ringer, 17, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Ringer),
                new Weapon(Localization.HeavyRinger, 17, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Heavy_Ringer),
                new Weapon(Localization.OlympicRinger, 17, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Olympic_Ringer),
                default
            },
            {
                new Weapon(Localization.Rainbow, 18, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Rainbow),
                new Weapon(Localization.MegaRainbow, 18, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.MegaRainbow),
                default,
                default
            },
            {
                new Weapon(Localization.Moons, 19, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Moons),
                new Weapon(Localization.Orbitals, 19, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Orbitals),
                default,
                default
            },
            {
                new Weapon(Localization.MiniPinger, 20, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Mini_Pinger),
                new Weapon(Localization.Pinger, 20, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Pinger),
                new Weapon(Localization.PingFlood, 20, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Ping_Flood),
                default
            },
            {
                new Weapon(Localization.Shank, 21, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Shank),
                new Weapon(Localization.Dagger, 21, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Dagger),
                new Weapon(Localization.Sword, 21, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Sword),
                default
            },
            {
                new Weapon(Localization.Bolt, 22, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Bolt),
                new Weapon(Localization.Lightning, 22, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Lightning),
                new Weapon(Localization._2012, 22, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg._2012),
                default
            },
            {
                new Weapon(Localization.Gravies, 23, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Gravies),
                new Weapon(Localization.Gravits, 23, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Gravits),
                default,
                default
            },
            {
                new Weapon(Localization.Spiker, 24, GuidanceType.Parabola, Color.FromArgb(204, 204, 255), WeaponsImg.Spiker),
                new Weapon(Localization.SuperSpiker, 24, GuidanceType.Parabola, Color.FromArgb(204, 204, 255), WeaponsImg.Super_Spiker),
                default,
                default
            },
            {
                new Weapon(Localization.DiscoBall, 25, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Disco_Ball),
                new Weapon(Localization.GroovyBall, 25, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Groovy_Ball),
                default,
                default
            },
            {
                new Weapon(Localization.Boomerang, 26, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Boomerang),
                new Weapon(Localization.BigBoomerang, 26, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.BigBoomerang),
                default,
                default
            },
            {
                new Weapon(Localization.Tadpoles, 27, GuidanceType.Parabola, Color.FromArgb(0, 204, 25), WeaponsImg.Tadpoles),
                new Weapon(Localization.Frogs, 27, GuidanceType.Parabola, Color.FromArgb(0, 204, 25), WeaponsImg.Frogs),
                new Weapon(Localization.Bullfrog, 27, GuidanceType.Parabola, Color.FromArgb(0, 204, 25), WeaponsImg.Bullfrog),
                default
            },
            {
                new Weapon(Localization.MiniV, 28, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Mini_V),
                new Weapon(Localization.FlyingV, 28, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Flying_V),
                default,
                default
            },
            {
                new Weapon(Localization.YinYang, 29, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Yin_Yang),
                new Weapon(Localization.YinYangYong, 29, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Yin_Yang_Yong),
                default,
                default
            },
            {
                new Weapon(Localization.Fireworks, 30, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Fireworks),
                new Weapon(Localization.GrandFinale, 30, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Grand_Finale),
                new Weapon(Localization.Pyrotechnics, 30, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Pyrotechnics),
                default
            },
            {
                new Weapon(Localization.WaterBalloon, 31, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Water_Balloon),
                new Weapon(Localization.WaterTrio, 31, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Water_Trio),
                new Weapon(Localization.WaterFight, 31, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Water_Fight),
                default
            },
            {
                new Weapon(Localization.Magnets, 32, GuidanceType.Parabola, Color.FromArgb(127, 0, 0), WeaponsImg.Magnets),
                new Weapon(Localization.Attractoids, 32, GuidanceType.Parabola, Color.FromArgb(127, 0, 0), WeaponsImg.Attractoids),
                default,
                default
            },
            {
                new Weapon(Localization.Arrow, 33, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Arrow),
                new Weapon(Localization.BowAndArrow, 33, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Bow_And_Arrow),
                new Weapon(Localization.FlamingArrow, 33, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Flaming_Arrow),
                default
            },
            {
                new Weapon(Localization.Driller, 34, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Driller),
                new Weapon(Localization.Slammer, 34, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Slammer),
                default,
                default
            },
            {
                new Weapon(Localization.Quicksand, 35, GuidanceType.Parabola, Color.FromArgb(255, 229, 127), WeaponsImg.Quicksand),
                new Weapon(Localization.Desert, 35, GuidanceType.Parabola, Color.FromArgb(255, 229, 127), WeaponsImg.Desert),
                default,
                default
            },
            {
                new Weapon(Localization.Jumper, 36, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Jumper),
                new Weapon(Localization.TripleJumper, 36, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Triple_Jumper),
                default,
                default
            },
            {
                new Weapon(Localization.Spaz, 37, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Spaz),
                new Weapon(Localization.Spazzer, 37, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Spazzer),
                new Weapon(Localization.Spaztastic, 37, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Spaztastic),
                default
            },
            {
                new Weapon(Localization.Pinata, 38, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Pinata),
                new Weapon(Localization.Fiesta, 38, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Fiesta),
                default,
                default
            },
            {
                new Weapon(Localization.Shockwave, 39, GuidanceType.Parabola, Color.FromArgb(0, 0, 255), WeaponsImg.Shockwave),
                new Weapon(Localization.SonicPulse, 39, GuidanceType.Parabola, Color.FromArgb(0, 0, 255), WeaponsImg.Sonic_Pulse),
                default,
                default
            },
            {
                new Weapon(Localization.Bounder, 40, GuidanceType.Parabola, Color.FromArgb(255, 127, 127), WeaponsImg.Bounder),
                new Weapon(Localization.DoubleBounder, 40, GuidanceType.Parabola, Color.FromArgb(255, 127, 127), WeaponsImg.Double_Bounder),
                new Weapon(Localization.TripleBounder, 40, GuidanceType.Parabola, Color.FromArgb(255, 127, 127), WeaponsImg.Triple_Bounder),
                default
            },
            {
                new Weapon(Localization.UZI, 41, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.UZI),
                new Weapon(Localization.MP5, 41, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.MP5),
                new Weapon(Localization.P90, 41, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.P90),
                default
            },
            {
                new Weapon(Localization.StickyBomb, 42, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Sticky_Bomb),
                new Weapon(Localization.StickyTrio, 42, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Sticky_Trio),
                new Weapon(Localization.MineLayer, 42, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Mine_Layer),
                new Weapon(Localization.StickyRain, 42, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Sticky_Rain)
            },
            {
                new Weapon(Localization.Fleet, 43, GuidanceType.Parabola, Color.FromArgb(0, 51, 127), WeaponsImg.Fleet),
                new Weapon(Localization.HeavyFleet, 43, GuidanceType.Parabola, Color.FromArgb(0, 51, 127), WeaponsImg.Heavy_Fleet),
                new Weapon(Localization.SuperFleet, 43, GuidanceType.Parabola, Color.FromArgb(0, 51, 127), WeaponsImg.Super_Fleet),
                new Weapon(Localization.Squadron, 43, GuidanceType.Parabola, Color.FromArgb(0, 51, 127), WeaponsImg.Squadron)
            },
            {
                new Weapon(Localization.Rain, 44, GuidanceType.Parabola, Color.FromArgb(0, 153, 255), WeaponsImg.Rain),
                new Weapon(Localization.Hail, 44, GuidanceType.Parabola, Color.FromArgb(0, 153, 255), WeaponsImg.Hail),
                default,
                default
            },
            {
                new Weapon(Localization.Sillyballs, 45, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Sillyballs),
                new Weapon(Localization.Wackyballs, 45, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Wackyballs),
                new Weapon(Localization.Crazyballs, 45, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Crazyballs),
                default
            },
            {
                new Weapon(Localization.Napalm, 46, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Napalm),
                new Weapon(Localization.HeavyNapalm, 46, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Heavy_Napalm),
                new Weapon(Localization.FireStorm, 46, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.FireStorm),
                default
            },
            {
                new Weapon(Localization.SawBlade, 47, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Saw_Blade),
                new Weapon(Localization.RipSaw, 47, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Rip_Saw),
                new Weapon(Localization.DiamondBlade, 47, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Diamond_Blade),
                default
            },
            {
                new Weapon(Localization.Sunburst, 48, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.SunBurst),
                new Weapon(Localization.SolarFlare, 48, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Solar_Flare),
                default,
                default
            },
            {
                new Weapon(Localization.Synclets, 49, GuidanceType.Parabola, Color.FromArgb(153, 255, 153), WeaponsImg.Synclets),
                new Weapon(Localization.SuperSynclets, 49, GuidanceType.Parabola, Color.FromArgb(153, 255, 153), WeaponsImg.Super_Synclets),
                default,
                default
            },
            {
                new Weapon(Localization.Payload, 50, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Payload),
                new Weapon(Localization.MagicShower, 50, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Magic_Shower),
                default,
                default
            },
            {
                new Weapon(Localization.Shadow, 51, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Shadow),
                new Weapon(Localization.Darkshadow, 51, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Darkshadow),
                new Weapon(Localization.Deathshadow, 51, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Deathshadow),
                default
            },
            {
                new Weapon(Localization.XAttack, 52, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.X_Attack),
                new Weapon(Localization.OAttack, 52, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.O_Attack),
                default,
                default
            },
            {
                new Weapon(Localization.CarpetBomb, 53, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Carpet_Bomb),
                new Weapon(Localization.CarpetFire, 53, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Carpet_Fire),
                new Weapon(Localization.IncendiaryBombs, 53, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Incendiary_Bombs),
                default
            },
            {
                new Weapon(Localization.BabySeagull, 54, GuidanceType.Parabola, Color.FromArgb(255, 204, 153), WeaponsImg.Baby_Seagull),
                new Weapon(Localization.Seagull, 54, GuidanceType.Parabola, Color.FromArgb(255, 204, 153), WeaponsImg.Seagull),
                new Weapon(Localization.MamaSeagull, 54, GuidanceType.Parabola, Color.FromArgb(255, 204, 153), WeaponsImg.Mama_Seagull),
                default
            },
            {
                new Weapon(Localization.Shrapnel, 55, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Shrapnel),
                new Weapon(Localization.Shredders, 55, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Shredders),
                default,
                default
            },
            {
                new Weapon(Localization.Penetrator, 56, GuidanceType.Parabola, Color.FromArgb(127, 0, 76), WeaponsImg.Penetrator),
                new Weapon(Localization.Penetratorv2, 56, GuidanceType.Parabola, Color.FromArgb(127, 0, 76), WeaponsImg.Penetrator_v2),
                default,
                default
            },
            {
                new Weapon(Localization.Jammer, 57, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Jammer),
                new Weapon(Localization.Jiver, 57, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Jiver),
                new Weapon(Localization.Rocker, 57, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Rocker),
                default
            },
            {
                new Weapon(Localization.Chunklet, 58, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Chunklet),
                new Weapon(Localization.Chunker, 58, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Chunker),
                default,
                default
            },
            {
                new Weapon(Localization.BouncyBall, 59, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Bouncy_Ball),
                new Weapon(Localization.SuperBall, 59, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Super_Ball),
                default,
                default
            },
            {
                new Weapon(Localization.Minions, 60, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Minions),
                new Weapon(Localization.ManyMinions, 60, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Many_Minions),
                default,
                default
            },
            {
                new Weapon(Localization.BatteringRam, 61, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Battering_Ram),
                new Weapon(Localization.DoubleRam, 61, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Double_Ram),
                new Weapon(Localization.RamSquad, 61, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Ram_Squad),
                new Weapon(Localization.DoubleRamSquad, 61, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Double_Ram_Squad)
            },
            {
                new Weapon(Localization.Asteroids, 62, GuidanceType.Parabola, Color.FromArgb(191, 191, 191), WeaponsImg.Asteroids),
                new Weapon(Localization.Comets, 62, GuidanceType.Parabola, Color.FromArgb(191, 191, 191), WeaponsImg.Comets),
                new Weapon(Localization.AsteroidStorm, 62, GuidanceType.Parabola, Color.FromArgb(191, 191, 191), WeaponsImg.Asteroid_Storm),
                default
            },
            {
                new Weapon(Localization.Spider, 63, GuidanceType.Parabola, Color.FromArgb(0, 0, 0), WeaponsImg.Spider),
                new Weapon(Localization.Tarantula, 63, GuidanceType.Parabola, Color.FromArgb(0, 0, 0), WeaponsImg.Tarantula),
                new Weapon(Localization.DaddyLonglegs, 63, GuidanceType.Parabola, Color.FromArgb(0, 0, 0), WeaponsImg.Daddy_Longlegs),
                new Weapon(Localization.BlackWidow, 63, GuidanceType.Parabola, Color.FromArgb(0, 0, 0), WeaponsImg.Black_Widow)
            },
            {
                new Weapon(Localization.Rampage, 64, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Rampage),
                new Weapon(Localization.Riot, 64, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Riot),
                default,
                default
            },
            {
                new Weapon(Localization.M4, 65, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.M4),
                new Weapon(Localization.M16, 65, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.M16),
                new Weapon(Localization.AK47, 65, GuidanceType.Parabola, Color.FromArgb(102, 102, 153), WeaponsImg.AK_47),
                default
            },
            {
                new Weapon(Localization.Clover, 66, GuidanceType.Parabola, Color.FromArgb(127, 255, 127), WeaponsImg.Clover),
                new Weapon(Localization.FourLeafClover, 66, GuidanceType.Parabola, Color.FromArgb(127, 255, 127), WeaponsImg.Four_Leaf_Clover),
                default,
                default
            },
            {
                new Weapon(Localization._3DBomb, 67, GuidanceType.Parabola, Color.FromArgb(229, 229, 255), WeaponsImg._3D_Bomb),
                new Weapon(Localization._2x3D, 67, GuidanceType.Parabola, Color.FromArgb(229, 229, 255), WeaponsImg._2x3D),
                new Weapon(Localization._3x3D, 67, GuidanceType.Parabola, Color.FromArgb(229, 229, 255), WeaponsImg._3x3D),
                default
            },
            {
                new Weapon(Localization.Snowball, 68, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Snowball),
                new Weapon(Localization.Snowstorm, 68, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Snowstorm),
                default,
                default
            },
            {
                new Weapon(Localization.Spotter, 69, GuidanceType.Parabola, Color.FromArgb(51, 255, 0), WeaponsImg.Spotter),
                new Weapon(Localization.SpotterXL, 69, GuidanceType.Parabola, Color.FromArgb(51, 255, 0), WeaponsImg.Spotter_XL),
                new Weapon(Localization.SpotterXXL, 69, GuidanceType.Parabola, Color.FromArgb(51, 255, 0), WeaponsImg.Spotter_XXL),
                default
            },
            {
                new Weapon(Localization.FighterJet, 70, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Fighter_Jet),
                new Weapon(Localization.HeavyJet, 70, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Heavy_Jet),
                default,
                default
            },
            {
                new Weapon(Localization.Bounstrike, 71, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Bounstrike),
                new Weapon(Localization.Bounstream, 71, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Bounstream),
                new Weapon(Localization.Bounstorm, 71, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Bounstorm),
                default
            },
            {
                new Weapon(Localization.StarFire, 72, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.StarFire),
                new Weapon(Localization.ShootingStar, 72, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Shooting_Star),
                default,
                default
            },
            {
                new Weapon(Localization.BeeHive, 73, GuidanceType.Parabola, Color.FromArgb(153, 153, 0), WeaponsImg.Bee_Hive),
                new Weapon(Localization.KillerBees, 73, GuidanceType.Parabola, Color.FromArgb(153, 153, 0), WeaponsImg.Killer_Bees),
                new Weapon(Localization.Wasps, 73, GuidanceType.Parabola, Color.FromArgb(153, 153, 0), WeaponsImg.Wasps),
                default
            },
            {
                new Weapon(Localization.DualRoller, 74, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Dual_Roller),
                new Weapon(Localization.Spreader, 74, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Spreader),
                default,
                default
            },
            {
                new Weapon(Localization.Partition, 75, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Partition),
                new Weapon(Localization.Division, 75, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Division),
                default,
                default
            },
            {
                new Weapon(Localization.BFG1000, 76, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.BFG_1000),
                new Weapon(Localization.BFG9000, 76, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.BFG_9000),
                default,
                default
            },
            {
                new Weapon(Localization.Train, 77, GuidanceType.Parabola, Color.FromArgb(127, 76, 0), WeaponsImg.Train),
                new Weapon(Localization.Express, 77, GuidanceType.Parabola, Color.FromArgb(127, 76, 0), WeaponsImg.Express),
                default,
                default
            },
            {
                new Weapon(Localization.MiniTurret, 78, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Mini_Turret),
                new Weapon(Localization.TurretMob, 78, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.TurretMob),
                default,
                default
            },
            {
                new Weapon(Localization.Kamikaze, 79, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Kamikaze),
                new Weapon(Localization.SuicideBomber, 79, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Suicide_Bomber),
                default,
                default
            },
            {
                new Weapon(Localization.Nuke, 80, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Nuke),
                new Weapon(Localization.MegaNuke, 80, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.MegaNuke),
                default,
                default
            },
            {
                new Weapon(Localization.BlackHole, 81, GuidanceType.Parabola, Color.FromArgb(127, 127, 191), WeaponsImg.Black_Hole),
                new Weapon(Localization.CosmicRift, 81, GuidanceType.Parabola, Color.FromArgb(127, 127, 191), WeaponsImg.Cosmic_Rift),
                default,
                default
            },
            {
                new Weapon(Localization.BumperBombs, 82, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Bumper_Bombs),
                new Weapon(Localization.BumperArray, 82, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Bumper_Array),
                new Weapon(Localization.BumperAssault, 82, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Bumper_Assault),
                default
            },
            {
                new Weapon(Localization.BreakerMadness, 83, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.BreakerMadness),
                new Weapon(Localization.BreakerMania, 83, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.BreakerMania),
                default,
                default
            },
            {
                new Weapon(Localization.HomingMissile, 84, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Homing_Missile),
                new Weapon(Localization.HomingRockets, 84, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Homing_Rockets),
                default,
                default
            },
            {
                new Weapon(Localization.Puzzler, 85, GuidanceType.Parabola, Color.FromArgb(76, 0, 153), WeaponsImg.Puzzler),
                new Weapon(Localization.Deceiver, 85, GuidanceType.Parabola, Color.FromArgb(76, 0, 153), WeaponsImg.Deceiver),
                new Weapon(Localization.Baffler, 85, GuidanceType.Parabola, Color.FromArgb(76, 0, 153), WeaponsImg.Baffler),
                default
            },
            {
                new Weapon(Localization.RocketFire, 86, GuidanceType.Parabola, Color.FromArgb(255, 204, 153), WeaponsImg.Rocket_Fire),
                new Weapon(Localization.RocketCluster, 86, GuidanceType.Parabola, Color.FromArgb(255, 204, 153), WeaponsImg.Rocket_Cluster),
                new Weapon(Localization.Flurry, 86, GuidanceType.Parabola, Color.FromArgb(255, 204, 153), WeaponsImg.Flurry),
                default
            },
            {
                new Weapon(Localization.Pentagram, 87, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Pentagram),
                new Weapon(Localization.Pentaslam, 87, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Pentaslam),
                default,
                default
            },
            {
                new Weapon(Localization.Radar, 88, GuidanceType.Parabola, Color.FromArgb(20, 138, 9), WeaponsImg.Radar),
                new Weapon(Localization.Sonar, 88, GuidanceType.Parabola, Color.FromArgb(20, 138, 9), WeaponsImg.Sonar),
                new Weapon(Localization.Lidar, 88, GuidanceType.Parabola, Color.FromArgb(20, 138, 9), WeaponsImg.Lidar),
                default
            },
            {
                new Weapon(Localization.LaserBeam, 89, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Laser_Beam),
                new Weapon(Localization.GreatBeam, 89, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Great_Beam),
                new Weapon(Localization.UltraBeam, 89, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Ultra_Beam),
                new Weapon(Localization.MasterBeam, 89, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Master_Beam)
            },
            {
                new Weapon(Localization.Tweeter, 90, GuidanceType.Parabola, Color.FromArgb(191, 191, 191), WeaponsImg.Tweeter),
                new Weapon(Localization.Squawker, 90, GuidanceType.Parabola, Color.FromArgb(191, 191, 191), WeaponsImg.Squawker),
                new Weapon(Localization.Woofer, 90, GuidanceType.Parabola, Color.FromArgb(191, 191, 191), WeaponsImg.Woofer),
                default
            },
            {
                new Weapon(Localization.AcidRain, 91, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Acid_Rain),
                new Weapon(Localization.AcidHail, 91, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Acid_Hail),
                default,
                default
            },
            {
                new Weapon(Localization.Sunflower, 92, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Sunflower),
                new Weapon(Localization.Helianthus, 92, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Helianthus),
                default,
                default
            },
            {
                new Weapon(Localization.Taser, 93, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Taser),
                new Weapon(Localization.HeavyTaser, 93, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Heavy_Taser),
                default,
                default
            },
            {
                new Weapon(Localization.Sausage, 94, GuidanceType.Parabola, Color.FromArgb(186, 125, 69), WeaponsImg.Sausage),
                new Weapon(Localization.Bratwurst, 94, GuidanceType.Parabola, Color.FromArgb(186, 125, 69), WeaponsImg.Bratwurst),
                new Weapon(Localization.Kielbasa, 94, GuidanceType.Parabola, Color.FromArgb(186, 125, 69), WeaponsImg.Kielbasa),
                default
            },
            {
                new Weapon(Localization.Jackpot, 95, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Jackpot),
                new Weapon(Localization.MegaJackpot, 95, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Mega_Jackpot),
                new Weapon(Localization.UltraJackpot, 95, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Ultra_Jackpot),
                new Weapon(Localization.Lottery, 95, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Lottery)
            },
            {
                new Weapon(Localization.EarlyBird, 96, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Early_Bird),
                new Weapon(Localization.EarlyWorm, 96, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Early_Worm),
                default,
                default
            },
            {
                new Weapon(Localization.Recruiter, 97, GuidanceType.Parabola, Color.FromArgb(108, 184, 250), WeaponsImg.Recruiter),
                new Weapon(Localization.Enroller, 97, GuidanceType.Parabola, Color.FromArgb(108, 184, 250), WeaponsImg.Enroller),
                new Weapon(Localization.Enlister, 97, GuidanceType.Parabola, Color.FromArgb(108, 184, 250), WeaponsImg.Enlister),
                default
            },
            {
                new Weapon(Localization.Fury, 98, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Fury),
                new Weapon(Localization.Rage, 98, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Rage),
                default,
                default
            },
            {
                new Weapon(Localization.Relocator, 99, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Relocator),
                new Weapon(Localization.DisplacementBomb, 99, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Displacement_Bomb),
                default,
                default
            },
            {
                new Weapon(Localization.Imploder, 100, GuidanceType.Parabola, Color.FromArgb(255, 229, 0), WeaponsImg.Imploder),
                new Weapon(Localization.UltimateImploder, 100, GuidanceType.Parabola, Color.FromArgb(255, 229, 0), WeaponsImg.Ultimate_Imploder),
                default,
                default
            },
            {
                new Weapon(Localization.Stone, 101, GuidanceType.Parabola, Color.FromArgb(178, 178, 153), WeaponsImg.Stone),
                new Weapon(Localization.Boulder, 101, GuidanceType.Parabola, Color.FromArgb(178, 178, 153), WeaponsImg.Boulder),
                new Weapon(Localization.Fireball, 101, GuidanceType.Parabola, Color.FromArgb(178, 178, 153), WeaponsImg.Fireball),
                default
            },
            {
                new Weapon(Localization.Cat, 101, GuidanceType.Parabola, Color.FromArgb(178, 127, 76), WeaponsImg.Cat),
                new Weapon(Localization.Kittens, 101, GuidanceType.Parabola, Color.FromArgb(178, 127, 76), WeaponsImg.Kittens),
                new Weapon(Localization.SuperCat, 101, GuidanceType.Parabola, Color.FromArgb(178, 127, 76), WeaponsImg.SuperCat),
                new Weapon(Localization.CatsandDogs, 101, GuidanceType.Parabola, Color.FromArgb(178, 127, 76), WeaponsImg.Cats_and_Dogs)
            },
            {
                new Weapon(Localization.GhostBomb, 101, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Ghost_Bomb),
                new Weapon(Localization.Ghostlets, 101, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Ghostlets),
                default,
                default
            },
            {
                new Weapon(Localization.Flasher, 101, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Flasher),
                new Weapon(Localization.Strobie, 101, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Strobie),
                new Weapon(Localization.Rave, 101, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Rave),
                default
            },
            {
                new Weapon(Localization.Sprouter, 101, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Sprouter),
                new Weapon(Localization.Blossom, 101, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Blossom),
                default,
                default
            },
            {
                new Weapon(Localization.Square, 101, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Square),
                new Weapon(Localization.Hexagon, 101, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Hexagon),
                new Weapon(Localization.Octagon, 101, GuidanceType.Parabola, Color.FromArgb(128, 128, 128), WeaponsImg.Octagon),
                default
            },
            {
                new Weapon(Localization.WackyCluster, 101, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Wacky_Cluster),
                new Weapon(Localization.KookyCluster, 101, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Kooky_Cluster),
                new Weapon(Localization.CrazyCluster, 101, GuidanceType.Parabola, Color.FromArgb(255, 0, 255), WeaponsImg.Crazy_Cluster),
                default
            },
            {
                new Weapon(Localization.Satellite, 101, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Satellite),
                new Weapon(Localization.UFO, 101, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.UFO),
                default,
                default
            },
            {
                new Weapon(Localization.Palm, 102, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Palm),
                new Weapon(Localization.DoublePalm, 102, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Double_Palm),
                new Weapon(Localization.TriplePalm, 102, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Triple_Palm),
                default
            },
            {
                new Weapon(Localization.ShockShell, 102, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.ShockShell),
                new Weapon(Localization.ShockShellTrio, 102, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.ShockShell_Trio),
                default,
                default
            },
            {
                new Weapon(Localization.Fountain, 102, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Fountain),
                new Weapon(Localization.Waterworks, 102, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Waterworks),
                new Weapon(Localization.Sprinkler, 102, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Sprinkler),
                default
            },
            {
                new Weapon(Localization.Flattener, 102, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Flattener),
                new Weapon(Localization.Wall, 102, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Wall),
                new Weapon(Localization.Fortress, 102, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Fortress),
                new Weapon(Localization.Funnel, 102, GuidanceType.Parabola, Color.FromArgb(0, 127, 255), WeaponsImg.Funnel)
            },
            {
                new Weapon(Localization.ChickenFling, 102, GuidanceType.Parabola, Color.FromArgb(153, 102, 0), WeaponsImg.Chicken_Fling),
                new Weapon(Localization.ChickenHurl, 102, GuidanceType.Parabola, Color.FromArgb(153, 102, 0), WeaponsImg.Chicken_Hurl),
                new Weapon(Localization.ChickenLaunch, 102, GuidanceType.Parabola, Color.FromArgb(153, 102, 0), WeaponsImg.Chicken_Launch),
                default
            },
            {
                new Weapon(Localization.MadBirds, 102, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Mad_Birds),
                new Weapon(Localization.FuriousBirds, 102, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Furious_Birds),
                new Weapon(Localization.LividBirds, 102, GuidanceType.Parabola, Color.FromArgb(255, 0, 0), WeaponsImg.Livid_Birds),
                default
            },
            {
                new Weapon(Localization.Pepper, 102, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Pepper),
                new Weapon(Localization.SaltandPepper, 102, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Salt_and_Pepper),
                default,
                default
            },
            {
                new Weapon(Localization.Needler, 102, GuidanceType.Parabola, Color.FromArgb(204, 76, 204), WeaponsImg.Needler),
                new Weapon(Localization.DualNeedler, 102, GuidanceType.Parabola, Color.FromArgb(204, 76, 204), WeaponsImg.Dual_Needler),
                default,
                default
            },
            {
                new Weapon(Localization.Beacon, 102, GuidanceType.Parabola, Color.FromArgb(127, 255, 204), WeaponsImg.Beacon),
                new Weapon(Localization.Beaconator, 102, GuidanceType.Parabola, Color.FromArgb(127, 255, 204), WeaponsImg.Beaconator),
                default,
                default
            },
            {
                new Weapon(Localization.Kernels, 102, GuidanceType.Parabola, Color.FromArgb(255, 229, 204), WeaponsImg.Kernels),
                new Weapon(Localization.Popcorn, 102, GuidanceType.Parabola, Color.FromArgb(255, 229, 204), WeaponsImg.Popcorn),
                new Weapon(Localization.BurntPopcorn, 102, GuidanceType.Parabola, Color.FromArgb(255, 229, 204), WeaponsImg.Burnt_Popcorn),
                default
            },
            {
                new Weapon(Localization.Chopper, 102, GuidanceType.Parabola, Color.FromArgb(127, 76, 0), WeaponsImg.Chopper),
                new Weapon(Localization.Apache, 102, GuidanceType.Parabola, Color.FromArgb(127, 76, 0), WeaponsImg.Apache),
                default,
                default
            },
            {
                new Weapon(Localization.Flintlock, 102, GuidanceType.Parabola, Color.FromArgb(0, 0, 255), WeaponsImg.Flintlock),
                new Weapon(Localization.Blunderbuss, 102, GuidanceType.Parabola, Color.FromArgb(0, 0, 255), WeaponsImg.Blunderbuss),
                default,
                default
            },
            {
                new Weapon(Localization.SkullShot, 102, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.SkullShot),
                new Weapon(Localization.Skeleton, 102, GuidanceType.Parabola, Color.FromArgb(127, 127, 127), WeaponsImg.Skeleton),
                default,
                default
            },
            {
                new Weapon(Localization.Pinpoint, 102, GuidanceType.Parabola, Color.FromArgb(255, 127, 127), WeaponsImg.Pinpoint),
                new Weapon(Localization.Needles, 102, GuidanceType.Parabola, Color.FromArgb(255, 127, 127), WeaponsImg.Needles),
                new Weapon(Localization.PinsandNeedles, 102, GuidanceType.Parabola, Color.FromArgb(255, 127, 127), WeaponsImg.Pins_and_Needles),
                default
            },
            {
                new Weapon(Localization.FatStacks, 102, GuidanceType.Parabola, Color.FromArgb(0, 255, 51), WeaponsImg.Fat_Stacks),
                new Weapon(Localization.DollaBills, 102, GuidanceType.Parabola, Color.FromArgb(0, 255, 51), WeaponsImg.Dolla_Bills),
                new Weapon(Localization.MakeItRain, 102, GuidanceType.Parabola, Color.FromArgb(0, 255, 51), WeaponsImg.Make_It_Rain),
                default
            },
            {
                new Weapon(Localization.GodRays, 102, GuidanceType.Parabola, Color.FromArgb(255, 229, 0), WeaponsImg.God_Rays),
                new Weapon(Localization.Deity, 102, GuidanceType.Parabola, Color.FromArgb(255, 229, 0), WeaponsImg.Deity),
                default,
                default
            },
            {
                new Weapon(Localization.HiddenBlade, 102, GuidanceType.Parabola, Color.FromArgb(153, 153, 153), WeaponsImg.Hidden_Blade),
                new Weapon(Localization.SecretBlade, 102, GuidanceType.Parabola, Color.FromArgb(153, 153, 153), WeaponsImg.Secret_Blade),
                new Weapon(Localization.ConcealedBlade, 102, GuidanceType.Parabola, Color.FromArgb(153, 153, 153), WeaponsImg.Concealed_Blade),
                default
            },
            {
                new Weapon(Localization.PortalGun, 102, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.Portal_Gun),
                new Weapon(Localization.ASHPD, 102, GuidanceType.Parabola, Color.FromArgb(0, 255, 255), WeaponsImg.ASHPD),
                default,
                default
            },
            {
                new Weapon(Localization.Volcano, 103, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Volcano),
                new Weapon(Localization.Eruption, 103, GuidanceType.Parabola, Color.FromArgb(255, 63, 0), WeaponsImg.Eruption),
                default,
                default
            },
            {
                new Weapon(Localization.ThrowingStar, 103, GuidanceType.Parabola, Color.FromArgb(127, 127, 191), WeaponsImg.Throwing_Star),
                new Weapon(Localization.MultiStar, 103, GuidanceType.Parabola, Color.FromArgb(127, 127, 191), WeaponsImg.Multi_Star),
                new Weapon(Localization.Ninja, 103, GuidanceType.Parabola, Color.FromArgb(127, 127, 191), WeaponsImg.Ninja),
                default
            },
            {
                new Weapon(Localization.Skeet, 103, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Skeet),
                new Weapon(Localization.OlympicSkeet, 103, GuidanceType.Parabola, Color.FromArgb(255, 127, 0), WeaponsImg.Olympic_Skeet),
                default,
                default
            },
            {
                new Weapon(Localization.TangentFire, 103, GuidanceType.Parabola, Color.FromArgb(0, 255, 127), WeaponsImg.Tangent_Fire),
                new Weapon(Localization.TangentAttack, 103, GuidanceType.Parabola, Color.FromArgb(0, 255, 127), WeaponsImg.Tangent_Attack),
                new Weapon(Localization.TangentAssault, 103, GuidanceType.Parabola, Color.FromArgb(0, 255, 127), WeaponsImg.Tangent_Assault),
                default
            },
            {
                new Weapon(Localization.Summoner, 103, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Summoner),
                new Weapon(Localization.Mage, 103, GuidanceType.Parabola, Color.FromArgb(127, 0, 255), WeaponsImg.Mage),
                default,
                default
            },
            {
                new Weapon(Localization.Travelers, 103, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Travelers),
                new Weapon(Localization.Scavengers, 103, GuidanceType.Parabola, Color.FromArgb(192, 192, 0), WeaponsImg.Scavengers),
                default,
                default
            },
            {
                new Weapon(Localization.JackoLantern, 103, GuidanceType.Parabola, Color.FromArgb(255, 153, 0), WeaponsImg.Jack_o_Lantern),
                new Weapon(Localization.JackoVomit, 103, GuidanceType.Parabola, Color.FromArgb(255, 153, 0), WeaponsImg.Jack_o_Vomit),
                default,
                default
            },
            {
                new Weapon(Localization.WickedWitch, 103, GuidanceType.Parabola, Color.FromArgb(0, 63, 0), WeaponsImg.Wicked_Witch),
                new Weapon(Localization.WitchesBroom, 103, GuidanceType.Parabola, Color.FromArgb(0, 63, 0), WeaponsImg.Witches_Broom),
                new Weapon(Localization.Ghouls, 103, GuidanceType.Parabola, Color.FromArgb(0, 63, 0), WeaponsImg.Ghouls),
                default
            },
            {
                new Weapon(Localization.Oddball, 103, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Oddball),
                new Weapon(Localization.Oddbomb, 103, GuidanceType.Parabola, Color.FromArgb(0, 192, 0), WeaponsImg.Oddbomb),
                default,
                default
            },
            {
                new Weapon(Localization.Botherer, 103, GuidanceType.Parabola, Color.FromArgb(186, 125, 69), WeaponsImg.Botherer),
                new Weapon(Localization.Tormentor, 103, GuidanceType.Parabola, Color.FromArgb(186, 125, 69), WeaponsImg.Tormentor),
                new Weapon(Localization.Punisher, 103, GuidanceType.Parabola, Color.FromArgb(186, 125, 69), WeaponsImg.Punisher),
                default
            }
        };
    }
}