// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Runtime.InteropServices;
using NetExtender.Types.Exceptions;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Shells.Internal;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Shells.Interfaces;
using ShellShockLive.Models.Weapons.Stacks;

namespace ShellShockLive.Models.Weapons.Shells
{
    public abstract class Shell : IShell
    {
        public static implicit operator Shell(GuidanceType value)
        {
            return (Shell) (value switch
            {
                Physics.Guidances.GuidanceType.Parabola => Parabola,
                Physics.Guidances.GuidanceType.Direct => Direct,
                Physics.Guidances.GuidanceType.Custom => throw new NotSupportedException(),
                _ => throw new EnumUndefinedOrNotSupportedException<GuidanceType>(value, nameof(value), null)
            });
        }
        
        public static IGuidanceShell Parabola
        {
            get
            {
                return ParabolaShell.Instance;
            }
        }

        public static IGuidanceShell Direct
        {
            get
            {
                return DirectShell.Instance;
            }
        }
        
        public abstract ShellType ShellType { get; }

        public virtual GuidanceType? GuidanceType
        {
            get
            {
                return default;
            }
        }

        public virtual Single Wind
        {
            get
            {
                return ShellType.HasFlag(ShellType.Wind) ? 1 : 0;
            }
        }

        public Boolean IsWind
        {
            get
            {
                return Wind != 0;
            }
        }

        public virtual Single Gravitation
        {
            get
            {
                return ShellType.HasFlag(ShellType.Gravitation) ? 1 : 0;
            }
        }

        public Boolean IsGravitation
        {
            get
            {
                return Gravitation != 0;
            }
        }

        public virtual Single BlackHole
        {
            get
            {
                return ShellType.HasFlag(ShellType.Wind) ? 1 : 0;
            }
        }

        public Boolean IsBlackHole
        {
            get
            {
                return BlackHole != 0;
            }
        }

        public Boolean IsPortal
        {
            get
            {
                return ShellType.HasFlag(ShellType.Portal);
            }
        }

        public Boolean IsRebound
        {
            get
            {
                return ShellType.HasFlag(ShellType.Rebound);
            }
        }
        
        Unsafe IShell.Unsafe()
        {
            return this;
        }
        
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Unsafe
        {
            public static implicit operator Unsafe(Shell? value)
            {
                return value is not null ? new Unsafe
                {
                    GuidanceType = value.GuidanceType,
                    ShellType = value.ShellType,
                    Wind = value.Wind,
                    Gravitation = value.Gravitation,
                    BlackHole = value.BlackHole,
                    IsPortal = value.IsPortal,
                    IsRebound = value.IsRebound
                } : default;
            }

            public static Unsafe From(IShell? value)
            {
                return value is not null ? new Unsafe
                {
                    Weapon = value is IWeapon weapon ? WeaponsStack.Instance[weapon] : default,
                    GuidanceType = value.GuidanceType,
                    ShellType = value.ShellType,
                    Wind = value.Wind,
                    Gravitation = value.Gravitation,
                    BlackHole = value.BlackHole,
                    IsPortal = value.IsPortal,
                    IsRebound = value.IsRebound
                } : default;
            }

            public UInt16? Weapon { get; init; }
            public GuidanceType? GuidanceType { get; init; }
            public ShellType ShellType { get; init; }
            public Single Wind { get; init; }
            public Boolean IsWind
            {
                get
                {
                    return Wind != 0;
                }
            }

            public Single Gravitation { get; init; }
            public Boolean IsGravitation
            {
                get
                {
                    return Gravitation != 0;
                }
            }

            public Single BlackHole { get; init; }
            public Boolean IsBlackHole
            {
                get
                {
                    return BlackHole != 0;
                }
            }

            public Boolean IsPortal { get; init; }
            public Boolean IsRebound { get; init; }
            
            public IWeapon? ToWeapon()
            {
                return Weapon is { } id ? WeaponsStack.Instance.AsWeapons()[id] : default;
            }
        }
    }
}