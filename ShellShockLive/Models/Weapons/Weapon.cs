// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Shells;
using ShellShockLive.Models.Weapons.Shells.Interfaces;
using ShellShockLive.Models.Weapons.Stacks;

namespace ShellShockLive.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public virtual String Title
        {
            get
            {
                return GetType().Name.Replace(nameof(Weapon), String.Empty);
            }
        }

        public abstract Byte Level { get; }
        public abstract IShell Shell { get; }

        public virtual WeaponStack? Stack
        {
            get
            {
                return null;
            }
        }

        public abstract IGuidance Guidance { get; }

        public ShellType ShellType
        {
            get
            {
                return Shell.ShellType;
            }
        }
        
        public GuidanceType GuidanceType
        {
            get
            {
                return Guidance.GuidanceType;
            }
        }

        GuidanceType? IShell.GuidanceType
        {
            get
            {
                return GuidanceType;
            }
        }

        public Single Wind
        {
            get
            {
                return Shell.Wind;
            }
        }

        public Boolean IsWind
        {
            get
            {
                return Shell.IsWind;
            }
        }

        public Single Gravitation
        {
            get
            {
                return Shell.Gravitation;
            }
        }

        public Boolean IsGravitation
        {
            get
            {
                return Shell.IsGravitation;
            }
        }

        public Single BlackHole
        {
            get
            {
                return Shell.BlackHole;
            }
        }

        public Boolean IsBlackHole
        {
            get
            {
                return Shell.IsBlackHole;
            }
        }

        public Boolean IsPortal
        {
            get
            {
                return Shell.IsPortal;
            }
        }

        public Boolean IsRebound
        {
            get
            {
                return Shell.IsRebound;
            }
        }

        public Boolean IsParabola
        {
            get
            {
                return Guidance.IsParabola;
            }
        }

        public Boolean IsDirect
        {
            get
            {
                return Guidance.IsDirect;
            }
        }

        public Boolean IsCustom
        {
            get
            {
                return Guidance.IsCustom;
            }
        }
        
        public Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Evaluate(this, center, physics, environment);
        }

        public Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Evaluate(this, center, physics, step, environment);
        }

        public Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.Evaluate(shell, center, physics, environment);
        }

        public Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.Evaluate(shell, center, physics, step, environment);
        }
        
        public GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Search(this, center, position, physics, environment);
        }

        public GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Search(this, center, position, physics, step, environment);
        }

        public GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.Search(shell, center, position, physics, environment);
        }

        public GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.Search(shell, center, position, physics, step, environment);
        }
        
        public GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return SearchAll(this, center, position, physics, environment);
        }

        public GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return SearchAll(this, center, position, physics, step, environment);
        }

        public GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.SearchAll(shell, center, position, physics, environment);
        }

        public GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.SearchAll(shell, center, position, physics, step, environment);
        }

        Shell.Unsafe IShell.Unsafe()
        {
            return ShellShockLive.Models.Weapons.Shells.Shell.Unsafe.From(this);
        }

        public override String ToString()
        {
            return Title;
        }
    }
}