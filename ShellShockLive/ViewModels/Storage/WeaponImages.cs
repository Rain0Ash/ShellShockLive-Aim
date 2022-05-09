// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Media;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Internal;
using ShellShockLive.ViewModels.Weapons.Images;

namespace ShellShockLive.ViewModels
{
    public static partial class ImageStorage
    {
        private static class WeaponImages
        {
            public static ImmutableDictionary<IWeapon, WeaponImage> Images { get; }

            static WeaponImages()
            {
                Images = new Dictionary<IWeapon, WeaponImage>
                {
                    [ParabolaWeapon.Instance] = new WeaponImage("Parabola.png", Color.FromArgb(255, 128, 128, 128)),
                    [DirectWeapon.Instance] = new WeaponImage("Direct.png", Color.FromArgb(255, 128, 128, 128)),

                    [ShotWeapon.Instance] = new WeaponImage("Shot.png", Color.FromArgb(255, 128, 128, 128)),
                    [BigShotWeapon.Instance] = new WeaponImage("BigShot.png", Color.FromArgb(255, 128, 128, 128)),
                    [HeavyShotWeapon.Instance] = new WeaponImage("HeavyShot.png", Color.FromArgb(255, 128, 128, 128)),
                    [MassiveShotWeapon.Instance] = new WeaponImage("MassiveShot.png", Color.FromArgb(255, 128, 128, 128)),

                    [ThreeBallWeapon.Instance] = new WeaponImage("ThreeBall.png", Color.FromArgb(255, 128, 128, 128)),
                    [FiveBallWeapon.Instance] = new WeaponImage("FiveBall.png", Color.FromArgb(255, 128, 128, 128)),
                    [ElevenBallWeapon.Instance] = new WeaponImage("ElevenBall.png", Color.FromArgb(255, 128, 128, 128)),
                    [TwentyFiveBallWeapon.Instance] = new WeaponImage("TwentyFiveBall.png", Color.FromArgb(255, 128, 128, 128)),

                    [OneBounceWeapon.Instance] = new WeaponImage("OneBounce.png", Color.FromArgb(255, 255, 0, 255)),
                    [ThreeBounceWeapon.Instance] = new WeaponImage("ThreeBounce.png", Color.FromArgb(255, 255, 0, 255)),
                    [FiveBounceWeapon.Instance] = new WeaponImage("FiveBounce.png", Color.FromArgb(255, 255, 0, 255)),
                    [SevenBounceWeapon.Instance] = new WeaponImage("SevenBounce.png", Color.FromArgb(255, 255, 0, 255)),

                    [DiggerWeapon.Instance] = new WeaponImage("Digger.png", Color.FromArgb(255, 255, 127, 0)),
                    [MegaDiggerWeapon.Instance] = new WeaponImage("MegaDigger.png", Color.FromArgb(255, 255, 127, 0)),
                    [ExcavationWeapon.Instance] = new WeaponImage("Excavation.png", Color.FromArgb(255, 255, 127, 0)),

                    [GrenadeWeapon.Instance] = new WeaponImage("Grenade.png", Color.FromArgb(255, 0, 192, 0)),
                    [TriNadeWeapon.Instance] = new WeaponImage("TriNade.png", Color.FromArgb(255, 0, 192, 0)),
                    [MultiNadeWeapon.Instance] = new WeaponImage("MultiNade.png", Color.FromArgb(255, 0, 192, 0)),
                    [GrenadeStormWeapon.Instance] = new WeaponImage("GrenadeStorm.png", Color.FromArgb(255, 0, 192, 0)),

                    [StreamWeapon.Instance] = new WeaponImage("Stream.png", Color.FromArgb(255, 0, 127, 255)),
                    [CreekWeapon.Instance] = new WeaponImage("Creek.png", Color.FromArgb(255, 0, 127, 255)),
                    [RiverWeapon.Instance] = new WeaponImage("River.png", Color.FromArgb(255, 0, 127, 255)),
                    [TsunamiWeapon.Instance] = new WeaponImage("Tsunami.png", Color.FromArgb(255, 0, 127, 255)),

                    [FlameWeapon.Instance] = new WeaponImage("Flame.png", Color.FromArgb(255, 255, 76, 0)),
                    [BlazeWeapon.Instance] = new WeaponImage("Blaze.png", Color.FromArgb(255, 255, 76, 0)),
                    [InfernoWeapon.Instance] = new WeaponImage("Inferno.png", Color.FromArgb(255, 255, 76, 0)),

                    [RollerWeapon.Instance] = new WeaponImage("Roller.png", Color.FromArgb(255, 255, 0, 0)),
                    [HeavyRollerWeapon.Instance] = new WeaponImage("HeavyRoller.png", Color.FromArgb(255, 255, 0, 0)),
                    [GrollerWeapon.Instance] = new WeaponImage("Groller.png", Color.FromArgb(255, 255, 0, 0)),

                    [BackRollerWeapon.Instance] = new WeaponImage("BackRoller.png", Color.FromArgb(255, 255, 127, 0)),
                    [HeavyBackRollerWeapon.Instance] = new WeaponImage("HeavyBackRoller.png", Color.FromArgb(255, 255, 127, 0)),
                    [BackGrollerWeapon.Instance] = new WeaponImage("BackGroller.png", Color.FromArgb(255, 255, 127, 0)),

                    [SplitterWeapon.Instance] = new WeaponImage("Splitter.png", Color.FromArgb(255, 192, 192, 0)),
                    [DoubleSplitterWeapon.Instance] = new WeaponImage("DoubleSplitter.png", Color.FromArgb(255, 192, 192, 0)),
                    [SuperSplitterWeapon.Instance] = new WeaponImage("SuperSplitter.png", Color.FromArgb(255, 192, 192, 0)),
                    [SplitterChainWeapon.Instance] = new WeaponImage("SplitterChain.png", Color.FromArgb(255, 192, 192, 0)),

                    [BreakerWeapon.Instance] = new WeaponImage("Breaker.png", Color.FromArgb(255, 0, 192, 0)),
                    [DoubleBreakerWeapon.Instance] = new WeaponImage("DoubleBreaker.png", Color.FromArgb(255, 0, 192, 0)),
                    [SuperBreakerWeapon.Instance] = new WeaponImage("SuperBreaker.png", Color.FromArgb(255, 0, 192, 0)),
                    [BreakerChainWeapon.Instance] = new WeaponImage("BreakerChain.png", Color.FromArgb(255, 0, 192, 0)),

                    [TwinklerWeapon.Instance] = new WeaponImage("Twinkler.png", Color.FromArgb(255, 192, 192, 0)),
                    [SparklerWeapon.Instance] = new WeaponImage("Sparkler.png", Color.FromArgb(255, 192, 192, 0)),
                    [CracklerWeapon.Instance] = new WeaponImage("Crackler.png", Color.FromArgb(255, 192, 192, 0)),

                    [SniperWeapon.Instance] = new WeaponImage("Sniper.png", Color.FromArgb(255, 255, 0, 0)),
                    [SubSniperWeapon.Instance] = new WeaponImage("SubSniper.png", Color.FromArgb(255, 255, 0, 0)),
                    [SmartSnipeWeapon.Instance] = new WeaponImage("SmartSnipe.png", Color.FromArgb(255, 255, 0, 0)),

                    [CactusWeapon.Instance] = new WeaponImage("Cactus.png", Color.FromArgb(255, 0, 192, 0)),
                    [CactusStrikeWeapon.Instance] = new WeaponImage("CactusStrike.png", Color.FromArgb(255, 0, 192, 0)),

                    [BulgerWeapon.Instance] = new WeaponImage("Bulger.png", Color.FromArgb(255, 0, 127, 255)),
                    [BigBulgerWeapon.Instance] = new WeaponImage("BigBulger.png", Color.FromArgb(255, 0, 127, 255)),

                    [SinkholeWeapon.Instance] = new WeaponImage("Sinkhole.png", Color.FromArgb(255, 255, 0, 0)),
                    [AreaStrikeWeapon.Instance] = new WeaponImage("AreaStrike.png", Color.FromArgb(255, 255, 0, 0)),
                    [AreaAttackWeapon.Instance] = new WeaponImage("AreaAttack.png", Color.FromArgb(255, 255, 0, 0)),

                    [RapidFireWeapon.Instance] = new WeaponImage("RapidFire.png", Color.FromArgb(255, 127, 191, 255)),
                    [ShotgunWeapon.Instance] = new WeaponImage("Shotgun.png", Color.FromArgb(255, 127, 191, 255)),
                    [BurstFireWeapon.Instance] = new WeaponImage("BurstFire.png", Color.FromArgb(255, 127, 191, 255)),
                    [GatlingGunWeapon.Instance] = new WeaponImage("GatlingGun.png", Color.FromArgb(255, 127, 191, 255)),

                    [TunnelerWeapon.Instance] = new WeaponImage("Tunneler.png", Color.FromArgb(255, 0, 127, 255)),
                    [TorpedoesWeapon.Instance] = new WeaponImage("Torpedoes.png", Color.FromArgb(255, 0, 127, 255)),
                    [TunnelStrikeWeapon.Instance] = new WeaponImage("TunnelStrike.png", Color.FromArgb(255, 0, 127, 255)),
                    [MegaTunnelerWeapon.Instance] = new WeaponImage("MegaTunneler.png", Color.FromArgb(255, 0, 127, 255)),

                    [HorizonWeapon.Instance] = new WeaponImage("Horizon.png", Color.FromArgb(255, 128, 128, 128)),
                    [SweeperWeapon.Instance] = new WeaponImage("Sweeper.png", Color.FromArgb(255, 128, 128, 128)),

                    [AirStrikeWeapon.Instance] = new WeaponImage("AirStrike.png", Color.FromArgb(255, 255, 0, 0)),
                    [HelicopterStrikeWeapon.Instance] = new WeaponImage("HelicopterStrike.png", Color.FromArgb(255, 255, 0, 0)),
                    [AC130Weapon.Instance] = new WeaponImage("AC130.png", Color.FromArgb(255, 255, 0, 0)),
                    [ArtilleryWeapon.Instance] = new WeaponImage("Artillery.png", Color.FromArgb(255, 255, 0, 0)),

                    [FlowerWeapon.Instance] = new WeaponImage("Flower.png", Color.FromArgb(255, 255, 229, 0)),
                    [BouquetWeapon.Instance] = new WeaponImage("Bouquet.png", Color.FromArgb(255, 255, 229, 0)),

                    [GuppiesWeapon.Instance] = new WeaponImage("Guppies.png", Color.FromArgb(255, 255, 127, 0)),
                    [MinnowsWeapon.Instance] = new WeaponImage("Minnows.png", Color.FromArgb(255, 255, 127, 0)),
                    [GoldfishWeapon.Instance] = new WeaponImage("Goldfish.png", Color.FromArgb(255, 255, 127, 0)),

                    [EarthquakeWeapon.Instance] = new WeaponImage("Earthquake.png", Color.FromArgb(255, 128, 128, 128)),
                    [MegaQuakeWeapon.Instance] = new WeaponImage("MegaQuake.png", Color.FromArgb(255, 128, 128, 128)),

                    [BananaWeapon.Instance] = new WeaponImage("Banana.png", Color.FromArgb(255, 192, 192, 0)),
                    [BananaSplitWeapon.Instance] = new WeaponImage("BananaSplit.png", Color.FromArgb(255, 192, 192, 0)),
                    [BananaBunchWeapon.Instance] = new WeaponImage("BananaBunch.png", Color.FromArgb(255, 192, 192, 0)),

                    [SnakeWeapon.Instance] = new WeaponImage("Snake.png", Color.FromArgb(255, 0, 192, 0)),
                    [PythonWeapon.Instance] = new WeaponImage("Python.png", Color.FromArgb(255, 0, 192, 0)),
                    [CobraWeapon.Instance] = new WeaponImage("Cobra.png", Color.FromArgb(255, 0, 192, 0)),

                    [ZipperWeapon.Instance] = new WeaponImage("Zipper.png", Color.FromArgb(255, 0, 255, 255)),
                    [DoubleZipperWeapon.Instance] = new WeaponImage("DoubleZipper.png", Color.FromArgb(255, 0, 255, 255)),
                    [ZipperQuadWeapon.Instance] = new WeaponImage("ZipperQuad.png", Color.FromArgb(255, 0, 255, 255)),

                    [BounsplodeWeapon.Instance] = new WeaponImage("Bounsplode.png", Color.FromArgb(255, 255, 0, 255)),
                    [DoubleBounsplodeWeapon.Instance] = new WeaponImage("DoubleBounsplode.png", Color.FromArgb(255, 255, 0, 255)),
                    [TripleBounsplodeWeapon.Instance] = new WeaponImage("TripleBounsplode.png", Color.FromArgb(255, 255, 0, 255)),

                    [GlockWeapon.Instance] = new WeaponImage("Glock.png", Color.FromArgb(255, 102, 102, 153)),
                    [M9Weapon.Instance] = new WeaponImage("M9.png", Color.FromArgb(255, 102, 102, 153)),
                    [DesertEagleWeapon.Instance] = new WeaponImage("DesertEagle.png", Color.FromArgb(255, 102, 102, 153)),

                    [DeadWeightWeapon.Instance] = new WeaponImage("DeadWeight.png", Color.FromArgb(255, 0, 0, 255)),
                    [DeadRiserWeapon.Instance] = new WeaponImage("DeadRiser.png", Color.FromArgb(255, 0, 0, 255)),

                    [PixelWeapon.Instance] = new WeaponImage("Pixel.png", Color.FromArgb(255, 128, 128, 128)),
                    [MegaPixelWeapon.Instance] = new WeaponImage("MegaPixel.png", Color.FromArgb(255, 128, 128, 128)),
                    [SuperPixelWeapon.Instance] = new WeaponImage("SuperPixel.png", Color.FromArgb(255, 128, 128, 128)),
                    [UltraPixelWeapon.Instance] = new WeaponImage("UltraPixel.png", Color.FromArgb(255, 128, 128, 128)),

                    [BuilderWeapon.Instance] = new WeaponImage("Builder.png", Color.FromArgb(255, 0, 127, 255)),
                    [MegaBuilderWeapon.Instance] = new WeaponImage("MegaBuilder.png", Color.FromArgb(255, 0, 127, 255)),
                    [ConstructionWeapon.Instance] = new WeaponImage("Construction.png", Color.FromArgb(255, 0, 127, 255)),

                    [StaticWeapon.Instance] = new WeaponImage("Static.png", Color.FromArgb(255, 0, 127, 255)),
                    [StaticLinkWeapon.Instance] = new WeaponImage("StaticLink.png", Color.FromArgb(255, 0, 127, 255)),
                    [StaticChainWeapon.Instance] = new WeaponImage("StaticChain.png", Color.FromArgb(255, 0, 127, 255)),

                    [MolehillWeapon.Instance] = new WeaponImage("Molehill.png", Color.FromArgb(255, 255, 127, 0)),
                    [MolesWeapon.Instance] = new WeaponImage("Moles.png", Color.FromArgb(255, 255, 127, 0)),

                    [Counter3000Weapon.Instance] = new WeaponImage("Counter3000.png", Color.FromArgb(255, 128, 128, 128)),
                    [Counter4000Weapon.Instance] = new WeaponImage("Counter4000.png", Color.FromArgb(255, 128, 128, 128)),
                    [Counter5000Weapon.Instance] = new WeaponImage("Counter5000.png", Color.FromArgb(255, 128, 128, 128)),
                    [Counter6000Weapon.Instance] = new WeaponImage("Counter6000.png", Color.FromArgb(255, 128, 128, 128)),

                    [HoverBallWeapon.Instance] = new WeaponImage("HoverBall.png", Color.FromArgb(255, 127, 127, 255)),
                    [HeavyHoverBallWeapon.Instance] = new WeaponImage("HeavyHoverBall.png", Color.FromArgb(255, 127, 127, 255)),

                    [RingerWeapon.Instance] = new WeaponImage("Ringer.png", Color.FromArgb(255, 192, 192, 0)),
                    [HeavyRingerWeapon.Instance] = new WeaponImage("HeavyRinger.png", Color.FromArgb(255, 192, 192, 0)),
                    [OlympicRingerWeapon.Instance] = new WeaponImage("OlympicRinger.png", Color.FromArgb(255, 192, 192, 0)),

                    [RainbowWeapon.Instance] = new WeaponImage("Rainbow.png", Color.FromArgb(255, 255, 0, 0)),
                    [MegaRainbowWeapon.Instance] = new WeaponImage("MegaRainbow.png", Color.FromArgb(255, 255, 0, 0)),

                    [MoonsWeapon.Instance] = new WeaponImage("Moons.png", Color.FromArgb(255, 128, 128, 128)),
                    [OrbitalsWeapon.Instance] = new WeaponImage("Orbitals.png", Color.FromArgb(255, 128, 128, 128)),

                    [MiniPingerWeapon.Instance] = new WeaponImage("MiniPinger.png", Color.FromArgb(255, 192, 192, 0)),
                    [PingerWeapon.Instance] = new WeaponImage("Pinger.png", Color.FromArgb(255, 192, 192, 0)),
                    [PingFloodWeapon.Instance] = new WeaponImage("PingFlood.png", Color.FromArgb(255, 192, 192, 0)),

                    [ShankWeapon.Instance] = new WeaponImage("Shank.png", Color.FromArgb(255, 128, 128, 128)),
                    [DaggerWeapon.Instance] = new WeaponImage("Dagger.png", Color.FromArgb(255, 128, 128, 128)),
                    [SwordWeapon.Instance] = new WeaponImage("Sword.png", Color.FromArgb(255, 128, 128, 128)),

                    [BoltWeapon.Instance] = new WeaponImage("Bolt.png", Color.FromArgb(255, 192, 192, 0)),
                    [LightningWeapon.Instance] = new WeaponImage("Lightning.png", Color.FromArgb(255, 192, 192, 0)),
                    [_2012Weapon.Instance] = new WeaponImage("2012.png", Color.FromArgb(255, 192, 192, 0)),

                    [GraviesWeapon.Instance] = new WeaponImage("Gravies.png", Color.FromArgb(255, 255, 0, 0)),
                    [GravitsWeapon.Instance] = new WeaponImage("Gravits.png", Color.FromArgb(255, 255, 0, 0)),

                    [SpikerWeapon.Instance] = new WeaponImage("Spiker.png", Color.FromArgb(255, 204, 204, 255)),
                    [SuperSpikerWeapon.Instance] = new WeaponImage("SuperSpiker.png", Color.FromArgb(255, 204, 204, 255)),

                    [DiscoBallWeapon.Instance] = new WeaponImage("DiscoBall.png", Color.FromArgb(255, 192, 192, 0)),
                    [GroovyBallWeapon.Instance] = new WeaponImage("GroovyBall.png", Color.FromArgb(255, 192, 192, 0)),

                    [BoomerangWeapon.Instance] = new WeaponImage("Boomerang.png", Color.FromArgb(255, 128, 128, 128)),
                    [BigBoomerangWeapon.Instance] = new WeaponImage("BigBoomerang.png", Color.FromArgb(255, 128, 128, 128)),

                    [TadpolesWeapon.Instance] = new WeaponImage("Tadpoles.png", Color.FromArgb(255, 0, 204, 25)),
                    [FrogsWeapon.Instance] = new WeaponImage("Frogs.png", Color.FromArgb(255, 0, 204, 25)),
                    [BullfrogWeapon.Instance] = new WeaponImage("Bullfrog.png", Color.FromArgb(255, 0, 204, 25)),

                    [MiniVWeapon.Instance] = new WeaponImage("MiniV.png", Color.FromArgb(255, 255, 0, 0)),
                    [FlyingVWeapon.Instance] = new WeaponImage("FlyingV.png", Color.FromArgb(255, 255, 0, 0)),

                    [YinYangWeapon.Instance] = new WeaponImage("YinYang.png", Color.FromArgb(255, 128, 128, 128)),
                    [YinYangYongWeapon.Instance] = new WeaponImage("YinYangYong.png", Color.FromArgb(255, 128, 128, 128)),

                    [FireworksWeapon.Instance] = new WeaponImage("Fireworks.png", Color.FromArgb(255, 255, 0, 0)),
                    [GrandFinaleWeapon.Instance] = new WeaponImage("GrandFinale.png", Color.FromArgb(255, 255, 0, 0)),
                    [PyrotechnicsWeapon.Instance] = new WeaponImage("Pyrotechnics.png", Color.FromArgb(255, 255, 0, 0)),

                    [WaterBalloonWeapon.Instance] = new WeaponImage("WaterBalloon.png", Color.FromArgb(255, 192, 192, 0)),
                    [WaterTrioWeapon.Instance] = new WeaponImage("WaterTrio.png", Color.FromArgb(255, 192, 192, 0)),
                    [WaterFightWeapon.Instance] = new WeaponImage("WaterFight.png", Color.FromArgb(255, 192, 192, 0)),

                    [MagnetsWeapon.Instance] = new WeaponImage("Magnets.png", Color.FromArgb(255, 127, 0, 0)),
                    [AttractoidsWeapon.Instance] = new WeaponImage("Attractoids.png", Color.FromArgb(255, 127, 0, 0)),

                    [ArrowWeapon.Instance] = new WeaponImage("Arrow.png", Color.FromArgb(255, 255, 127, 0)),
                    [BowAndArrowWeapon.Instance] = new WeaponImage("BowAndArrow.png", Color.FromArgb(255, 255, 127, 0)),
                    [FlamingArrowWeapon.Instance] = new WeaponImage("FlamingArrow.png", Color.FromArgb(255, 255, 127, 0)),

                    [DrillerWeapon.Instance] = new WeaponImage("Driller.png", Color.FromArgb(255, 127, 0, 255)),
                    [SlammerWeapon.Instance] = new WeaponImage("Slammer.png", Color.FromArgb(255, 127, 0, 255)),

                    [QuicksandWeapon.Instance] = new WeaponImage("Quicksand.png", Color.FromArgb(255, 255, 229, 127)),
                    [DesertWeapon.Instance] = new WeaponImage("Desert.png", Color.FromArgb(255, 255, 229, 127)),

                    [JumperWeapon.Instance] = new WeaponImage("Jumper.png", Color.FromArgb(255, 255, 0, 0)),
                    [TripleJumperWeapon.Instance] = new WeaponImage("TripleJumper.png", Color.FromArgb(255, 255, 0, 0)),

                    [SpazWeapon.Instance] = new WeaponImage("Spaz.png", Color.FromArgb(255, 127, 0, 255)),
                    [SpazzerWeapon.Instance] = new WeaponImage("Spazzer.png", Color.FromArgb(255, 127, 0, 255)),
                    [SpaztasticWeapon.Instance] = new WeaponImage("Spaztastic.png", Color.FromArgb(255, 127, 0, 255)),

                    [PinataWeapon.Instance] = new WeaponImage("Pinata.png", Color.FromArgb(255, 0, 255, 255)),
                    [FiestaWeapon.Instance] = new WeaponImage("Fiesta.png", Color.FromArgb(255, 0, 255, 255)),

                    [ShockwaveWeapon.Instance] = new WeaponImage("Shockwave.png", Color.FromArgb(255, 0, 0, 255)),
                    [SonicPulseWeapon.Instance] = new WeaponImage("SonicPulse.png", Color.FromArgb(255, 0, 0, 255)),

                    [BounderWeapon.Instance] = new WeaponImage("Bounder.png", Color.FromArgb(255, 255, 127, 127)),
                    [DoubleBounderWeapon.Instance] = new WeaponImage("DoubleBounder.png", Color.FromArgb(255, 255, 127, 127)),
                    [TripleBounderWeapon.Instance] = new WeaponImage("TripleBounder.png", Color.FromArgb(255, 255, 127, 127)),

                    [UziWeapon.Instance] = new WeaponImage("Uzi.png", Color.FromArgb(255, 102, 102, 153)),
                    [Mp5Weapon.Instance] = new WeaponImage("Mp5.png", Color.FromArgb(255, 102, 102, 153)),
                    [P90Weapon.Instance] = new WeaponImage("P90.png", Color.FromArgb(255, 102, 102, 153)),

                    [StickyBombWeapon.Instance] = new WeaponImage("StickyBomb.png", Color.FromArgb(255, 255, 63, 0)),
                    [StickyTrioWeapon.Instance] = new WeaponImage("StickyTrio.png", Color.FromArgb(255, 255, 63, 0)),
                    [MineLayerWeapon.Instance] = new WeaponImage("MineLayer.png", Color.FromArgb(255, 255, 63, 0)),
                    [StickyRainWeapon.Instance] = new WeaponImage("StickyRain.png", Color.FromArgb(255, 255, 63, 0)),

                    [FleetWeapon.Instance] = new WeaponImage("Fleet.png", Color.FromArgb(255, 0, 51, 127)),
                    [HeavyFleetWeapon.Instance] = new WeaponImage("HeavyFleet.png", Color.FromArgb(255, 0, 51, 127)),
                    [SuperFleetWeapon.Instance] = new WeaponImage("SuperFleet.png", Color.FromArgb(255, 0, 51, 127)),
                    [SquadronWeapon.Instance] = new WeaponImage("Squadron.png", Color.FromArgb(255, 0, 51, 127)),

                    [RainWeapon.Instance] = new WeaponImage("Rain.png", Color.FromArgb(255, 0, 153, 255)),
                    [HailWeapon.Instance] = new WeaponImage("Hail.png", Color.FromArgb(255, 0, 153, 255)),

                    [SillyballsWeapon.Instance] = new WeaponImage("Sillyballs.png", Color.FromArgb(255, 255, 0, 255)),
                    [WackyballsWeapon.Instance] = new WeaponImage("Wackyballs.png", Color.FromArgb(255, 255, 0, 255)),
                    [CrazyballsWeapon.Instance] = new WeaponImage("Crazyballs.png", Color.FromArgb(255, 255, 0, 255)),

                    [NapalmWeapon.Instance] = new WeaponImage("Napalm.png", Color.FromArgb(255, 255, 127, 0)),
                    [HeavyNapalmWeapon.Instance] = new WeaponImage("HeavyNapalm.png", Color.FromArgb(255, 255, 127, 0)),
                    [FireStormWeapon.Instance] = new WeaponImage("FireStorm.png", Color.FromArgb(255, 255, 127, 0)),

                    [SawBladeWeapon.Instance] = new WeaponImage("SawBlade.png", Color.FromArgb(255, 127, 127, 127)),
                    [RipSawWeapon.Instance] = new WeaponImage("RipSaw.png", Color.FromArgb(255, 127, 127, 127)),
                    [DiamondBladeWeapon.Instance] = new WeaponImage("DiamondBlade.png", Color.FromArgb(255, 127, 127, 127)),

                    [SunburstWeapon.Instance] = new WeaponImage("Sunburst.png", Color.FromArgb(255, 192, 192, 0)),
                    [SolarFlareWeapon.Instance] = new WeaponImage("SolarFlare.png", Color.FromArgb(255, 192, 192, 0)),

                    [SyncletsWeapon.Instance] = new WeaponImage("Synclets.png", Color.FromArgb(255, 153, 255, 153)),
                    [SuperSyncletsWeapon.Instance] = new WeaponImage("SuperSynclets.png", Color.FromArgb(255, 153, 255, 153)),

                    [PayloadWeapon.Instance] = new WeaponImage("Payload.png", Color.FromArgb(255, 0, 255, 255)),
                    [MagicShowerWeapon.Instance] = new WeaponImage("MagicShower.png", Color.FromArgb(255, 0, 255, 255)),

                    [ShadowWeapon.Instance] = new WeaponImage("Shadow.png", Color.FromArgb(255, 127, 127, 127)),
                    [DarkshadowWeapon.Instance] = new WeaponImage("Darkshadow.png", Color.FromArgb(255, 127, 127, 127)),
                    [DeathshadowWeapon.Instance] = new WeaponImage("Deathshadow.png", Color.FromArgb(255, 127, 127, 127)),

                    [XAttackWeapon.Instance] = new WeaponImage("XAttack.png", Color.FromArgb(255, 128, 128, 128)),
                    [OAttackWeapon.Instance] = new WeaponImage("OAttack.png", Color.FromArgb(255, 128, 128, 128)),

                    [CarpetBombWeapon.Instance] = new WeaponImage("CarpetBomb.png", Color.FromArgb(255, 255, 127, 0)),
                    [CarpetFireWeapon.Instance] = new WeaponImage("CarpetFire.png", Color.FromArgb(255, 255, 127, 0)),
                    [IncendiaryBombsWeapon.Instance] = new WeaponImage("IncendiaryBombs.png", Color.FromArgb(255, 255, 127, 0)),

                    [BabySeagullWeapon.Instance] = new WeaponImage("BabySeagull.png", Color.FromArgb(255, 255, 204, 153)),
                    [SeagullWeapon.Instance] = new WeaponImage("Seagull.png", Color.FromArgb(255, 255, 204, 153)),
                    [MamaSeagullWeapon.Instance] = new WeaponImage("MamaSeagull.png", Color.FromArgb(255, 255, 204, 153)),

                    [ShrapnelWeapon.Instance] = new WeaponImage("Shrapnel.png", Color.FromArgb(255, 128, 128, 128)),
                    [ShreddersWeapon.Instance] = new WeaponImage("Shredders.png", Color.FromArgb(255, 128, 128, 128)),

                    [PenetratorWeapon.Instance] = new WeaponImage("Penetrator.png", Color.FromArgb(255, 127, 0, 76)),
                    [Penetratorv2Weapon.Instance] = new WeaponImage("Penetratorv2.png", Color.FromArgb(255, 127, 0, 76)),

                    [JammerWeapon.Instance] = new WeaponImage("Jammer.png", Color.FromArgb(255, 127, 0, 255)),
                    [JiverWeapon.Instance] = new WeaponImage("Jiver.png", Color.FromArgb(255, 127, 0, 255)),
                    [RockerWeapon.Instance] = new WeaponImage("Rocker.png", Color.FromArgb(255, 127, 0, 255)),

                    [ChunkletWeapon.Instance] = new WeaponImage("Chunklet.png", Color.FromArgb(255, 128, 128, 128)),
                    [ChunkerWeapon.Instance] = new WeaponImage("Chunker.png", Color.FromArgb(255, 128, 128, 128)),

                    [BouncyBallWeapon.Instance] = new WeaponImage("BouncyBall.png", Color.FromArgb(255, 255, 0, 255)),
                    [SuperBallWeapon.Instance] = new WeaponImage("SuperBall.png", Color.FromArgb(255, 255, 0, 255)),

                    [MinionsWeapon.Instance] = new WeaponImage("Minions.png", Color.FromArgb(255, 255, 127, 0)),
                    [ManyMinionsWeapon.Instance] = new WeaponImage("ManyMinions.png", Color.FromArgb(255, 255, 127, 0)),

                    [BatteringRamWeapon.Instance] = new WeaponImage("BatteringRam.png", Color.FromArgb(255, 127, 0, 255)),
                    [DoubleRamWeapon.Instance] = new WeaponImage("DoubleRam.png", Color.FromArgb(255, 127, 0, 255)),
                    [RamSquadWeapon.Instance] = new WeaponImage("RamSquad.png", Color.FromArgb(255, 127, 0, 255)),
                    [DoubleRamSquadWeapon.Instance] = new WeaponImage("DoubleRamSquad.png", Color.FromArgb(255, 127, 0, 255)),

                    [AsteroidsWeapon.Instance] = new WeaponImage("Asteroids.png", Color.FromArgb(255, 191, 191, 191)),
                    [CometsWeapon.Instance] = new WeaponImage("Comets.png", Color.FromArgb(255, 191, 191, 191)),
                    [AsteroidStormWeapon.Instance] = new WeaponImage("AsteroidStorm.png", Color.FromArgb(255, 191, 191, 191)),

                    [SpiderWeapon.Instance] = new WeaponImage("Spider.png", Color.FromArgb(255, 0, 0, 0)),
                    [TarantulaWeapon.Instance] = new WeaponImage("Tarantula.png", Color.FromArgb(255, 0, 0, 0)),
                    [DaddyLonglegsWeapon.Instance] = new WeaponImage("DaddyLonglegs.png", Color.FromArgb(255, 0, 0, 0)),
                    [BlackWidowWeapon.Instance] = new WeaponImage("BlackWidow.png", Color.FromArgb(255, 0, 0, 0)),

                    [RampageWeapon.Instance] = new WeaponImage("Rampage.png", Color.FromArgb(255, 255, 127, 0)),
                    [RiotWeapon.Instance] = new WeaponImage("Riot.png", Color.FromArgb(255, 255, 127, 0)),

                    [M4Weapon.Instance] = new WeaponImage("M4.png", Color.FromArgb(255, 102, 102, 153)),
                    [M16Weapon.Instance] = new WeaponImage("M16.png", Color.FromArgb(255, 102, 102, 153)),
                    [AK47Weapon.Instance] = new WeaponImage("AK47.png", Color.FromArgb(255, 102, 102, 153)),

                    [CloverWeapon.Instance] = new WeaponImage("Clover.png", Color.FromArgb(255, 127, 255, 127)),
                    [FourLeafCloverWeapon.Instance] = new WeaponImage("FourLeafClover.png", Color.FromArgb(255, 127, 255, 127)),

                    [_3DBombWeapon.Instance] = new WeaponImage("3DBomb.png", Color.FromArgb(255, 229, 229, 255)),
                    [_2x3DWeapon.Instance] = new WeaponImage("2x3D.png", Color.FromArgb(255, 229, 229, 255)),
                    [_3x3DWeapon.Instance] = new WeaponImage("3x3D.png", Color.FromArgb(255, 229, 229, 255)),

                    [SnowballWeapon.Instance] = new WeaponImage("Snowball.png", Color.FromArgb(255, 128, 128, 128)),
                    [SnowstormWeapon.Instance] = new WeaponImage("Snowstorm.png", Color.FromArgb(255, 128, 128, 128)),

                    [SpotterWeapon.Instance] = new WeaponImage("Spotter.png", Color.FromArgb(255, 51, 255, 0)),
                    [SpotterXLWeapon.Instance] = new WeaponImage("SpotterXL.png", Color.FromArgb(255, 51, 255, 0)),
                    [SpotterXXLWeapon.Instance] = new WeaponImage("SpotterXXL.png", Color.FromArgb(255, 51, 255, 0)),

                    [FighterJetWeapon.Instance] = new WeaponImage("FighterJet.png", Color.FromArgb(255, 255, 127, 0)),
                    [HeavyJetWeapon.Instance] = new WeaponImage("HeavyJet.png", Color.FromArgb(255, 255, 127, 0)),

                    [BounstrikeWeapon.Instance] = new WeaponImage("Bounstrike.png", Color.FromArgb(255, 255, 0, 255)),
                    [BounstreamWeapon.Instance] = new WeaponImage("Bounstream.png", Color.FromArgb(255, 255, 0, 255)),
                    [BounstormWeapon.Instance] = new WeaponImage("Bounstorm.png", Color.FromArgb(255, 255, 0, 255)),

                    [StarFireWeapon.Instance] = new WeaponImage("StarFire.png", Color.FromArgb(255, 192, 192, 0)),
                    [ShootingStarWeapon.Instance] = new WeaponImage("ShootingStar.png", Color.FromArgb(255, 192, 192, 0)),

                    [BeeHiveWeapon.Instance] = new WeaponImage("BeeHive.png", Color.FromArgb(255, 153, 153, 0)),
                    [KillerBeesWeapon.Instance] = new WeaponImage("KillerBees.png", Color.FromArgb(255, 153, 153, 0)),
                    [WaspsWeapon.Instance] = new WeaponImage("Wasps.png", Color.FromArgb(255, 153, 153, 0)),

                    [DualRollerWeapon.Instance] = new WeaponImage("DualRoller.png", Color.FromArgb(255, 0, 192, 0)),
                    [SpreaderWeapon.Instance] = new WeaponImage("Spreader.png", Color.FromArgb(255, 0, 192, 0)),

                    [PartitionWeapon.Instance] = new WeaponImage("Partition.png", Color.FromArgb(255, 128, 128, 128)),
                    [DivisionWeapon.Instance] = new WeaponImage("Division.png", Color.FromArgb(255, 128, 128, 128)),

                    [BFG1000Weapon.Instance] = new WeaponImage("BFG1000.png", Color.FromArgb(255, 0, 255, 255)),
                    [BFG9000Weapon.Instance] = new WeaponImage("BFG9000.png", Color.FromArgb(255, 0, 255, 255)),

                    [TrainWeapon.Instance] = new WeaponImage("Train.png", Color.FromArgb(255, 127, 76, 0)),
                    [ExpressWeapon.Instance] = new WeaponImage("Express.png", Color.FromArgb(255, 127, 76, 0)),

                    [MiniTurretWeapon.Instance] = new WeaponImage("MiniTurret.png", Color.FromArgb(255, 255, 0, 0)),
                    [TurretMobWeapon.Instance] = new WeaponImage("TurretMob.png", Color.FromArgb(255, 255, 0, 0)),

                    [KamikazeWeapon.Instance] = new WeaponImage("Kamikaze.png", Color.FromArgb(255, 255, 0, 0)),
                    [SuicideBomberWeapon.Instance] = new WeaponImage("SuicideBomber.png", Color.FromArgb(255, 255, 0, 0)),

                    [NukeWeapon.Instance] = new WeaponImage("Nuke.png", Color.FromArgb(255, 192, 192, 0)),
                    [MegaNukeWeapon.Instance] = new WeaponImage("MegaNuke.png", Color.FromArgb(255, 192, 192, 0)),

                    [BlackHoleWeapon.Instance] = new WeaponImage("BlackHole.png", Color.FromArgb(255, 127, 127, 191)),
                    [CosmicRiftWeapon.Instance] = new WeaponImage("CosmicRift.png", Color.FromArgb(255, 127, 127, 191)),

                    [BumperBombsWeapon.Instance] = new WeaponImage("BumperBombs.png", Color.FromArgb(255, 255, 0, 255)),
                    [BumperArrayWeapon.Instance] = new WeaponImage("BumperArray.png", Color.FromArgb(255, 255, 0, 255)),
                    [BumperAssaultWeapon.Instance] = new WeaponImage("BumperAssault.png", Color.FromArgb(255, 255, 0, 255)),

                    [BreakerMadnessWeapon.Instance] = new WeaponImage("BreakerMadness.png", Color.FromArgb(255, 0, 192, 0)),
                    [BreakerManiaWeapon.Instance] = new WeaponImage("BreakerMania.png", Color.FromArgb(255, 0, 192, 0)),

                    [HomingMissileWeapon.Instance] = new WeaponImage("HomingMissile.png", Color.FromArgb(255, 255, 0, 0)),
                    [HomingRocketsWeapon.Instance] = new WeaponImage("HomingRockets.png", Color.FromArgb(255, 255, 0, 0)),

                    [PuzzlerWeapon.Instance] = new WeaponImage("Puzzler.png", Color.FromArgb(255, 76, 0, 153)),
                    [DeceiverWeapon.Instance] = new WeaponImage("Deceiver.png", Color.FromArgb(255, 76, 0, 153)),
                    [BafflerWeapon.Instance] = new WeaponImage("Baffler.png", Color.FromArgb(255, 76, 0, 153)),

                    [RocketFireWeapon.Instance] = new WeaponImage("RocketFire.png", Color.FromArgb(255, 255, 204, 153)),
                    [RocketClusterWeapon.Instance] = new WeaponImage("RocketCluster.png", Color.FromArgb(255, 255, 204, 153)),
                    [FlurryWeapon.Instance] = new WeaponImage("Flurry.png", Color.FromArgb(255, 255, 204, 153)),

                    [PentagramWeapon.Instance] = new WeaponImage("Pentagram.png", Color.FromArgb(255, 255, 63, 0)),
                    [PentaslamWeapon.Instance] = new WeaponImage("Pentaslam.png", Color.FromArgb(255, 255, 63, 0)),

                    [RadarWeapon.Instance] = new WeaponImage("Radar.png", Color.FromArgb(255, 20, 138, 9)),
                    [SonarWeapon.Instance] = new WeaponImage("Sonar.png", Color.FromArgb(255, 20, 138, 9)),
                    [LidarWeapon.Instance] = new WeaponImage("Lidar.png", Color.FromArgb(255, 20, 138, 9)),

                    [LaserBeamWeapon.Instance] = new WeaponImage("LaserBeam.png", Color.FromArgb(255, 255, 0, 0)),
                    [GreatBeamWeapon.Instance] = new WeaponImage("GreatBeam.png", Color.FromArgb(255, 255, 0, 0)),
                    [UltraBeamWeapon.Instance] = new WeaponImage("UltraBeam.png", Color.FromArgb(255, 255, 0, 0)),
                    [MasterBeamWeapon.Instance] = new WeaponImage("MasterBeam.png", Color.FromArgb(255, 255, 0, 0)),

                    [TweeterWeapon.Instance] = new WeaponImage("Tweeter.png", Color.FromArgb(255, 191, 191, 191)),
                    [SquawkerWeapon.Instance] = new WeaponImage("Squawker.png", Color.FromArgb(255, 191, 191, 191)),
                    [WooferWeapon.Instance] = new WeaponImage("Woofer.png", Color.FromArgb(255, 191, 191, 191)),

                    [AcidRainWeapon.Instance] = new WeaponImage("AcidRain.png", Color.FromArgb(255, 0, 192, 0)),
                    [AcidHailWeapon.Instance] = new WeaponImage("AcidHail.png", Color.FromArgb(255, 0, 192, 0)),

                    [SunflowerWeapon.Instance] = new WeaponImage("Sunflower.png", Color.FromArgb(255, 192, 192, 0)),
                    [HelianthusWeapon.Instance] = new WeaponImage("Helianthus.png", Color.FromArgb(255, 192, 192, 0)),

                    [TaserWeapon.Instance] = new WeaponImage("Taser.png", Color.FromArgb(255, 192, 192, 0)),
                    [HeavyTaserWeapon.Instance] = new WeaponImage("HeavyTaser.png", Color.FromArgb(255, 192, 192, 0)),

                    [SausageWeapon.Instance] = new WeaponImage("Sausage.png", Color.FromArgb(255, 186, 125, 69)),
                    [BratwurstWeapon.Instance] = new WeaponImage("Bratwurst.png", Color.FromArgb(255, 186, 125, 69)),
                    [KielbasaWeapon.Instance] = new WeaponImage("Kielbasa.png", Color.FromArgb(255, 186, 125, 69)),

                    [JackpotWeapon.Instance] = new WeaponImage("Jackpot.png", Color.FromArgb(255, 192, 192, 0)),
                    [MegaJackpotWeapon.Instance] = new WeaponImage("MegaJackpot.png", Color.FromArgb(255, 192, 192, 0)),
                    [UltraJackpotWeapon.Instance] = new WeaponImage("UltraJackpot.png", Color.FromArgb(255, 192, 192, 0)),
                    [LotteryWeapon.Instance] = new WeaponImage("Lottery.png", Color.FromArgb(255, 192, 192, 0)),

                    [EarlyBirdWeapon.Instance] = new WeaponImage("EarlyBird.png", Color.FromArgb(255, 192, 192, 0)),
                    [EarlyWormWeapon.Instance] = new WeaponImage("EarlyWorm.png", Color.FromArgb(255, 192, 192, 0)),

                    [RecruiterWeapon.Instance] = new WeaponImage("Recruiter.png", Color.FromArgb(255, 108, 184, 250)),
                    [EnrollerWeapon.Instance] = new WeaponImage("Enroller.png", Color.FromArgb(255, 108, 184, 250)),
                    [EnlisterWeapon.Instance] = new WeaponImage("Enlister.png", Color.FromArgb(255, 108, 184, 250)),

                    [FuryWeapon.Instance] = new WeaponImage("Fury.png", Color.FromArgb(255, 255, 63, 0)),
                    [RageWeapon.Instance] = new WeaponImage("Rage.png", Color.FromArgb(255, 255, 63, 0)),

                    [RelocatorWeapon.Instance] = new WeaponImage("Relocator.png", Color.FromArgb(255, 255, 63, 0)),
                    [DisplacementBombWeapon.Instance] = new WeaponImage("DisplacementBomb.png", Color.FromArgb(255, 255, 63, 0)),

                    [ImploderWeapon.Instance] = new WeaponImage("Imploder.png", Color.FromArgb(255, 255, 229, 0)),
                    [UltimateImploderWeapon.Instance] = new WeaponImage("UltimateImploder.png", Color.FromArgb(255, 255, 229, 0)),

                    [StoneWeapon.Instance] = new WeaponImage("Stone.png", Color.FromArgb(255, 178, 178, 153)),
                    [BoulderWeapon.Instance] = new WeaponImage("Boulder.png", Color.FromArgb(255, 178, 178, 153)),
                    [FireballWeapon.Instance] = new WeaponImage("Fireball.png", Color.FromArgb(255, 178, 178, 153)),

                    [CatWeapon.Instance] = new WeaponImage("Cat.png", Color.FromArgb(255, 178, 127, 76)),
                    [KittensWeapon.Instance] = new WeaponImage("Kittens.png", Color.FromArgb(255, 178, 127, 76)),
                    [SuperCatWeapon.Instance] = new WeaponImage("SuperCat.png", Color.FromArgb(255, 178, 127, 76)),
                    [CatsandDogsWeapon.Instance] = new WeaponImage("CatsandDogs.png", Color.FromArgb(255, 178, 127, 76)),

                    [GhostBombWeapon.Instance] = new WeaponImage("GhostBomb.png", Color.FromArgb(255, 128, 128, 128)),
                    [GhostletsWeapon.Instance] = new WeaponImage("Ghostlets.png", Color.FromArgb(255, 128, 128, 128)),

                    [FlasherWeapon.Instance] = new WeaponImage("Flasher.png", Color.FromArgb(255, 128, 128, 128)),
                    [StrobieWeapon.Instance] = new WeaponImage("Strobie.png", Color.FromArgb(255, 128, 128, 128)),
                    [RaveWeapon.Instance] = new WeaponImage("Rave.png", Color.FromArgb(255, 128, 128, 128)),

                    [SprouterWeapon.Instance] = new WeaponImage("Sprouter.png", Color.FromArgb(255, 0, 192, 0)),
                    [BlossomWeapon.Instance] = new WeaponImage("Blossom.png", Color.FromArgb(255, 0, 192, 0)),

                    [SquareWeapon.Instance] = new WeaponImage("Square.png", Color.FromArgb(255, 128, 128, 128)),
                    [HexagonWeapon.Instance] = new WeaponImage("Hexagon.png", Color.FromArgb(255, 128, 128, 128)),
                    [OctagonWeapon.Instance] = new WeaponImage("Octagon.png", Color.FromArgb(255, 128, 128, 128)),

                    [WackyClusterWeapon.Instance] = new WeaponImage("WackyCluster.png", Color.FromArgb(255, 255, 0, 255)),
                    [KookyClusterWeapon.Instance] = new WeaponImage("KookyCluster.png", Color.FromArgb(255, 255, 0, 255)),
                    [CrazyClusterWeapon.Instance] = new WeaponImage("CrazyCluster.png", Color.FromArgb(255, 255, 0, 255)),

                    [SatelliteWeapon.Instance] = new WeaponImage("Satellite.png", Color.FromArgb(255, 0, 255, 255)),
                    [UFOWeapon.Instance] = new WeaponImage("UFO.png", Color.FromArgb(255, 0, 255, 255)),

                    [PalmWeapon.Instance] = new WeaponImage("Palm.png", Color.FromArgb(255, 0, 192, 0)),
                    [DoublePalmWeapon.Instance] = new WeaponImage("DoublePalm.png", Color.FromArgb(255, 0, 192, 0)),
                    [TriplePalmWeapon.Instance] = new WeaponImage("TriplePalm.png", Color.FromArgb(255, 0, 192, 0)),

                    [ShockShellWeapon.Instance] = new WeaponImage("ShockShell.png", Color.FromArgb(255, 0, 192, 0)),
                    [ShockShellTrioWeapon.Instance] = new WeaponImage("ShockShellTrio.png", Color.FromArgb(255, 0, 192, 0)),

                    [FountainWeapon.Instance] = new WeaponImage("Fountain.png", Color.FromArgb(255, 0, 127, 255)),
                    [WaterworksWeapon.Instance] = new WeaponImage("Waterworks.png", Color.FromArgb(255, 0, 127, 255)),
                    [SprinklerWeapon.Instance] = new WeaponImage("Sprinkler.png", Color.FromArgb(255, 0, 127, 255)),

                    [FlattenerWeapon.Instance] = new WeaponImage("Flattener.png", Color.FromArgb(255, 0, 127, 255)),
                    [WallWeapon.Instance] = new WeaponImage("Wall.png", Color.FromArgb(255, 0, 127, 255)),
                    [FortressWeapon.Instance] = new WeaponImage("Fortress.png", Color.FromArgb(255, 0, 127, 255)),
                    [FunnelWeapon.Instance] = new WeaponImage("Funnel.png", Color.FromArgb(255, 0, 127, 255)),

                    [ChickenFlingWeapon.Instance] = new WeaponImage("ChickenFling.png", Color.FromArgb(255, 153, 102, 0)),
                    [ChickenHurlWeapon.Instance] = new WeaponImage("ChickenHurl.png", Color.FromArgb(255, 153, 102, 0)),
                    [ChickenLaunchWeapon.Instance] = new WeaponImage("ChickenLaunch.png", Color.FromArgb(255, 153, 102, 0)),

                    [MadBirdsWeapon.Instance] = new WeaponImage("MadBirds.png", Color.FromArgb(255, 255, 0, 0)),
                    [FuriousBirdsWeapon.Instance] = new WeaponImage("FuriousBirds.png", Color.FromArgb(255, 255, 0, 0)),
                    [LividBirdsWeapon.Instance] = new WeaponImage("LividBirds.png", Color.FromArgb(255, 255, 0, 0)),

                    [PepperWeapon.Instance] = new WeaponImage("Pepper.png", Color.FromArgb(255, 127, 127, 127)),
                    [SaltAndPepperWeapon.Instance] = new WeaponImage("SaltAndPepper.png", Color.FromArgb(255, 127, 127, 127)),
                    [PaprikaWeapon.Instance] = new WeaponImage("Paprika.png", Color.FromArgb(255, 127, 127, 127)),
                    [CayenneWeapon.Instance] = new WeaponImage("Cayenne.png", Color.FromArgb(255, 127, 127, 127)),

                    [NeedlerWeapon.Instance] = new WeaponImage("Needler.png", Color.FromArgb(255, 204, 76, 204)),
                    [DualNeedlerWeapon.Instance] = new WeaponImage("DualNeedler.png", Color.FromArgb(255, 204, 76, 204)),

                    [BeaconWeapon.Instance] = new WeaponImage("Beacon.png", Color.FromArgb(255, 127, 255, 204)),
                    [BeaconatorWeapon.Instance] = new WeaponImage("Beaconator.png", Color.FromArgb(255, 127, 255, 204)),

                    [KernelsWeapon.Instance] = new WeaponImage("Kernels.png", Color.FromArgb(255, 255, 229, 204)),
                    [PopcornWeapon.Instance] = new WeaponImage("Popcorn.png", Color.FromArgb(255, 255, 229, 204)),
                    [BurntPopcornWeapon.Instance] = new WeaponImage("BurntPopcorn.png", Color.FromArgb(255, 255, 229, 204)),

                    [ChopperWeapon.Instance] = new WeaponImage("Chopper.png", Color.FromArgb(255, 127, 76, 0)),
                    [ApacheWeapon.Instance] = new WeaponImage("Apache.png", Color.FromArgb(255, 127, 76, 0)),

                    [FlintlockWeapon.Instance] = new WeaponImage("Flintlock.png", Color.FromArgb(255, 0, 0, 255)),
                    [BlunderbussWeapon.Instance] = new WeaponImage("Blunderbuss.png", Color.FromArgb(255, 0, 0, 255)),

                    [SkullShotWeapon.Instance] = new WeaponImage("SkullShot.png", Color.FromArgb(255, 127, 127, 127)),
                    [SkeletonWeapon.Instance] = new WeaponImage("Skeleton.png", Color.FromArgb(255, 127, 127, 127)),

                    [PinpointWeapon.Instance] = new WeaponImage("Pinpoint.png", Color.FromArgb(255, 255, 127, 127)),
                    [NeedlesWeapon.Instance] = new WeaponImage("Needles.png", Color.FromArgb(255, 255, 127, 127)),
                    [PinsandNeedlesWeapon.Instance] = new WeaponImage("PinsandNeedles.png", Color.FromArgb(255, 255, 127, 127)),

                    [FatStacksWeapon.Instance] = new WeaponImage("FatStacks.png", Color.FromArgb(255, 0, 255, 51)),
                    [DollaBillsWeapon.Instance] = new WeaponImage("DollaBills.png", Color.FromArgb(255, 0, 255, 51)),
                    [MakeItRainWeapon.Instance] = new WeaponImage("MakeItRain.png", Color.FromArgb(255, 0, 255, 51)),

                    [GodRaysWeapon.Instance] = new WeaponImage("GodRays.png", Color.FromArgb(255, 255, 229, 0)),
                    [DeityWeapon.Instance] = new WeaponImage("Deity.png", Color.FromArgb(255, 255, 229, 0)),

                    [HiddenBladeWeapon.Instance] = new WeaponImage("HiddenBlade.png", Color.FromArgb(255, 153, 153, 153)),
                    [SecretBladeWeapon.Instance] = new WeaponImage("SecretBlade.png", Color.FromArgb(255, 153, 153, 153)),
                    [ConcealedBladeWeapon.Instance] = new WeaponImage("ConcealedBlade.png", Color.FromArgb(255, 153, 153, 153)),

                    [PortalGunWeapon.Instance] = new WeaponImage("PortalGun.png", Color.FromArgb(255, 0, 255, 255)),
                    [ASHPDWeapon.Instance] = new WeaponImage("ASHPD.png", Color.FromArgb(255, 0, 255, 255)),

                    [DroneWeapon.Instance] = new WeaponImage("Drone.png", Color.FromArgb(255, 127, 116, 232)),
                    [HeavyDroneWeapon.Instance] = new WeaponImage("HeavyDrone.png", Color.FromArgb(255, 127, 116, 232)),

                    [VolcanoWeapon.Instance] = new WeaponImage("Volcano.png", Color.FromArgb(255, 255, 63, 0)),
                    [EruptionWeapon.Instance] = new WeaponImage("Eruption.png", Color.FromArgb(255, 255, 63, 0)),

                    [ThrowingStarWeapon.Instance] = new WeaponImage("ThrowingStar.png", Color.FromArgb(255, 127, 127, 191)),
                    [MultiStarWeapon.Instance] = new WeaponImage("MultiStar.png", Color.FromArgb(255, 127, 127, 191)),
                    [NinjaWeapon.Instance] = new WeaponImage("Ninja.png", Color.FromArgb(255, 127, 127, 191)),

                    [SkeetWeapon.Instance] = new WeaponImage("Skeet.png", Color.FromArgb(255, 255, 127, 0)),
                    [OlympicSkeetWeapon.Instance] = new WeaponImage("OlympicSkeet.png", Color.FromArgb(255, 255, 127, 0)),

                    [TangentFireWeapon.Instance] = new WeaponImage("TangentFire.png", Color.FromArgb(255, 0, 255, 127)),
                    [TangentAttackWeapon.Instance] = new WeaponImage("TangentAttack.png", Color.FromArgb(255, 0, 255, 127)),
                    [TangentAssaultWeapon.Instance] = new WeaponImage("TangentAssault.png", Color.FromArgb(255, 0, 255, 127)),

                    [SummonerWeapon.Instance] = new WeaponImage("Summoner.png", Color.FromArgb(255, 127, 0, 255)),
                    [MageWeapon.Instance] = new WeaponImage("Mage.png", Color.FromArgb(255, 127, 0, 255)),

                    [TravelersWeapon.Instance] = new WeaponImage("Travelers.png", Color.FromArgb(255, 192, 192, 0)),
                    [ScavengersWeapon.Instance] = new WeaponImage("Scavengers.png", Color.FromArgb(255, 192, 192, 0)),

                    [JackoLanternWeapon.Instance] = new WeaponImage("JackoLantern.png", Color.FromArgb(255, 255, 153, 0)),
                    [JackoVomitWeapon.Instance] = new WeaponImage("JackoVomit.png", Color.FromArgb(255, 255, 153, 0)),

                    [WickedWitchWeapon.Instance] = new WeaponImage("WickedWitch.png", Color.FromArgb(255, 0, 63, 0)),
                    [WitchesBroomWeapon.Instance] = new WeaponImage("WitchesBroom.png", Color.FromArgb(255, 0, 63, 0)),
                    [GhoulsWeapon.Instance] = new WeaponImage("Ghouls.png", Color.FromArgb(255, 0, 63, 0)),
                    
                    [BothererWeapon.Instance] = new WeaponImage("Botherer.png", Color.FromArgb(255, 186, 125, 69)),
                    [TormentorWeapon.Instance] = new WeaponImage("Tormentor.png", Color.FromArgb(255, 186, 125, 69)),
                    [PunisherWeapon.Instance] = new WeaponImage("Punisher.png", Color.FromArgb(255, 186, 125, 69)),

                    [OddballWeapon.Instance] = new WeaponImage("Oddball.png", Color.FromArgb(255, 0, 192, 0)),
                    [OddbombWeapon.Instance] = new WeaponImage("Oddbomb.png", Color.FromArgb(255, 0, 192, 0)),

                    [PermarollerWeapon.Instance] = new WeaponImage("Permaroller.png", Color.FromArgb(255, 92, 173, 224)),
                    [HeavyPermarollerWeapon.Instance] = new WeaponImage("HeavyPermaroller.png", Color.FromArgb(255, 92, 173, 224)),
                    
                }.ToImmutableDictionary();
            }
        }
    }
}