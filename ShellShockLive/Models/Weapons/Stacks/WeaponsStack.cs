// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Stacks.Internal;

namespace ShellShockLive.Models.Weapons.Stacks
{
    public sealed class WeaponsStack : IReadOnlyList<WeaponStack>, IReadOnlyList<IWeapon>
    {
        static WeaponsStack()
        {
            foreach (WeaponStack stack in Instance)
            {
                foreach (IWeapon weapon in stack.Where(weapon => weapon.Stack?.Contains(weapon) == false))
                {
                    throw new InvalidOperationException($"Invalid stack for '{weapon.Title}' weapon");
                }
            }
        }
        
        private static Lazy<WeaponsStack> Internal { get; } = new Lazy<WeaponsStack>(() => new WeaponsStack(), true);

        public static WeaponsStack Instance
        {
            get
            {
                return Internal.Value;
            }
        }
        
        private ImmutableArray<WeaponStack> Stacks { get; }
        private ImmutableArray<IWeapon> Weapons { get; }
        private ImmutableDictionary<IWeapon, UInt16> Index { get; }

        public Int32 Count
        {
            get
            {
                return Stacks.Length;
            }
        }

        Int32 IReadOnlyCollection<IWeapon>.Count
        {
            get
            {
                return Weapons.Length;
            }
        }
        
        private WeaponsStack() : this
            (
                #region Stacks
                GuidanceWeaponStack.Instance,
                ShotWeaponStack.Instance,
                BallWeaponStack.Instance,
                BounceWeaponStack.Instance,
                DiggerWeaponStack.Instance,
                GrenadeWeaponStack.Instance,
                StreamWeaponStack.Instance,
                FlameWeaponStack.Instance,
                RollerWeaponStack.Instance,
                BackRollerWeaponStack.Instance,
                SplitterWeaponStack.Instance,
                BreakerWeaponStack.Instance,
                TwinklerWeaponStack.Instance,
                SniperWeaponStack.Instance,
                CactusWeaponStack.Instance,
                BulgerWeaponStack.Instance,
                SinkholeWeaponStack.Instance,
                RapidFireWeaponStack.Instance,
                TunnelerWeaponStack.Instance,
                HorizonWeaponStack.Instance,
                AirStrikeWeaponStack.Instance,
                FlowerWeaponStack.Instance,
                GuppiesWeaponStack.Instance,
                EarthquakeWeaponStack.Instance,
                BananaWeaponStack.Instance,
                SnakeWeaponStack.Instance,
                ZipperWeaponStack.Instance,
                BounsplodeWeaponStack.Instance,
                PistolWeaponStack.Instance,
                DeadWeightWeaponStack.Instance,
                PixelWeaponStack.Instance,
                BuilderWeaponStack.Instance,
                StaticWeaponStack.Instance,
                MolehillWeaponStack.Instance,
                CounterWeaponStack.Instance,
                HoverBallWeaponStack.Instance,
                RingerWeaponStack.Instance,
                RainbowWeaponStack.Instance,
                MoonsWeaponStack.Instance,
                PingerWeaponStack.Instance,
                DaggerWeaponStack.Instance,
                BoltWeaponStack.Instance,
                GraviesWeaponStack.Instance,
                SpikerWeaponStack.Instance,
                DiscoBallWeaponStack.Instance,
                BoomerangWeaponStack.Instance,
                TadpolesWeaponStack.Instance,
                MiniVWeaponStack.Instance,
                YinYangWeaponStack.Instance,
                FireworksWeaponStack.Instance,
                WaterBalloonWeaponStack.Instance,
                MagnetsWeaponStack.Instance,
                ArrowWeaponStack.Instance,
                DrillerWeaponStack.Instance,
                QuicksandWeaponStack.Instance,
                JumperWeaponStack.Instance,
                SpazWeaponStack.Instance,
                PinataWeaponStack.Instance,
                ShockwaveWeaponStack.Instance,
                BounderWeaponStack.Instance,
                UziWeaponStack.Instance,
                StickyBombWeaponStack.Instance,
                FleetWeaponStack.Instance,
                RainWeaponStack.Instance,
                SillyballsWeaponStack.Instance,
                NapalmWeaponStack.Instance,
                SawBladeWeaponStack.Instance,
                SunburstWeaponStack.Instance,
                SyncletsWeaponStack.Instance,
                PayloadWeaponStack.Instance,
                ShadowWeaponStack.Instance,
                AttackWeaponStack.Instance,
                CarpetBombWeaponStack.Instance,
                SeagullWeaponStack.Instance,
                ShrapnelWeaponStack.Instance,
                PenetratorWeaponStack.Instance,
                JammerWeaponStack.Instance,
                ChunkletWeaponStack.Instance,
                BouncyBallWeaponStack.Instance,
                MinionsWeaponStack.Instance,
                RamWeaponStack.Instance,
                AsteroidsWeaponStack.Instance,
                SpiderWeaponStack.Instance,
                RampageWeaponStack.Instance,
                RifleWeaponStack.Instance,
                CloverWeaponStack.Instance,
                BombWeaponStack.Instance,
                SnowballWeaponStack.Instance,
                SpotterWeaponStack.Instance,
                FighterJetWeaponStack.Instance,
                BounstrikeWeaponStack.Instance,
                StarFireWeaponStack.Instance,
                BeeHiveWeaponStack.Instance,
                DualRollerWeaponStack.Instance,
                PartitionWeaponStack.Instance,
                BFGWeaponStack.Instance,
                TrainWeaponStack.Instance,
                TurretWeaponStack.Instance,
                KamikazeWeaponStack.Instance,
                NukeWeaponStack.Instance,
                BlackHoleWeaponStack.Instance,
                BumperBombsWeaponStack.Instance,
                BreakerMadnessWeaponStack.Instance,
                HomingMissileWeaponStack.Instance,
                PuzzlerWeaponStack.Instance,
                RocketFireWeaponStack.Instance,
                PentagramWeaponStack.Instance,
                RadarWeaponStack.Instance,
                LaserBeamWeaponStack.Instance,
                TweeterWeaponStack.Instance,
                AcidRainWeaponStack.Instance,
                SunflowerWeaponStack.Instance,
                TaserWeaponStack.Instance,
                SausageWeaponStack.Instance,
                JackpotWeaponStack.Instance,
                EarlyBirdWeaponStack.Instance,
                RecruiterWeaponStack.Instance,
                FuryWeaponStack.Instance,
                RelocatorWeaponStack.Instance,
                ImploderWeaponStack.Instance,
                StoneWeaponStack.Instance,
                CatWeaponStack.Instance,
                GhostBombWeaponStack.Instance,
                FlasherWeaponStack.Instance,
                SprouterWeaponStack.Instance,
                SquareWeaponStack.Instance,
                WackyClusterWeaponStack.Instance,
                SatelliteWeaponStack.Instance,
                PalmWeaponStack.Instance,
                ShockShellWeaponStack.Instance,
                FountainWeaponStack.Instance,
                FlattenerWeaponStack.Instance,
                ChickenWeaponStack.Instance,
                BirdsWeaponStack.Instance,
                PepperWeaponStack.Instance,
                NeedlerWeaponStack.Instance,
                BeaconWeaponStack.Instance,
                KernelsWeaponStack.Instance,
                ChopperWeaponStack.Instance,
                FlintlockWeaponStack.Instance,
                SkullShotWeaponStack.Instance,
                PinpointWeaponStack.Instance,
                FatStacksWeaponStack.Instance,
                GodRaysWeaponStack.Instance,
                HiddenBladeWeaponStack.Instance,
                PortalGunWeaponStack.Instance,
                DroneWeaponStack.Instance,
                VolcanoWeaponStack.Instance,
                ThrowingStarWeaponStack.Instance,
                SkeetWeaponStack.Instance,
                TangentFireWeaponStack.Instance,
                SummonerWeaponStack.Instance,
                TravelersWeaponStack.Instance,
                JackoLanternWeaponStack.Instance,
                WickedWitchWeaponStack.Instance,
                BothererWeaponStack.Instance,
                OddballWeaponStack.Instance,
                PermarollerWeaponStack.Instance
                #endregion
            )
        {
        }

        private WeaponsStack(params WeaponStack[] stacks)
        {
            if (stacks is null)
            {
                throw new ArgumentNullException(nameof(stacks));
            }

            Stacks = stacks.ToImmutableArray();
            Weapons = Stacks.SelectMany().ToImmutableArray();
            
            UInt16 i = 0;
            Index = Weapons.ToImmutableDictionary(weapon => weapon, _ => i++);
        }

        public IReadOnlyList<WeaponStack> AsStacks()
        {
            return this;
        }
        
        public IReadOnlyList<IWeapon> AsWeapons()
        {
            return this;
        }

        public IEnumerator<WeaponStack> GetEnumerator()
        {
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (WeaponStack stack in Stacks)
            {
                yield return stack;
            }
        }

        IEnumerator<IWeapon> IEnumerable<IWeapon>.GetEnumerator()
        {
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (IWeapon weapon in Weapons)
            {
                yield return weapon;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public WeaponStack this[Int32 index]
        {
            get
            {
                return Stacks[index];
            }
        }

        IWeapon IReadOnlyList<IWeapon>.this[Int32 index]
        {
            get
            {
                return Weapons[index];
            }
        }

        public UInt16? this[IWeapon weapon]
        {
            get
            {
                if (weapon is null)
                {
                    throw new ArgumentNullException(nameof(weapon));
                }

                return Index.TryGetValue(weapon, out UInt16 index) ? index : default;
            }
        }
    }
}