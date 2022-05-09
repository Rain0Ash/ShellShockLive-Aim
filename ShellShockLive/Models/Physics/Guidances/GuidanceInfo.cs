// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Shells;
using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Physics.Guidances
{
    public abstract class GuidanceInfo : IGuidanceInfo
    {
        public static implicit operator GuidanceSearchInfo?(GuidanceInfo? value)
        {
            return value?.Information;
        }
        
        public static implicit operator PhysicsInfo(GuidanceInfo? value)
        {
            return value?.Physics ?? default;
        }

        public GuidanceSearchInfo? Information { get; }
        public PhysicsInfo Physics { get; }
        public abstract IGuidance Guidance { get; }
        public abstract IShell Shell { get; }
        
        public ShellType ShellType
        {
            get
            {
                return Shell.ShellType;
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
        
        protected GuidanceInfo(PhysicsInfo physics)
        {
            Physics = physics;
        }
        
        protected GuidanceInfo(GuidanceSearchInfo search)
        {
            Information = search ?? throw new ArgumentNullException(nameof(search));
            Physics = search;
        }
        
        public Guidance.Enumerator Evaluate(Point center, EnvironmentInfo? environment)
        {
            return Evaluate(center, Physics, environment);
        }

        public Guidance.Enumerator Evaluate(Point center, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Evaluate(center, Physics, step, environment);
        }

        public Guidance.Enumerator Evaluate(IShell shell, Point center, EnvironmentInfo? environment)
        {
            return Evaluate(shell, center, Physics, environment);
        }

        public Guidance.Enumerator Evaluate(IShell shell, Point center, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Evaluate(shell, center, Physics, step, environment);
        }

        public abstract Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public abstract Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        
        public GuidanceSearchInfo Search(Point center, Point position, EnvironmentInfo? environment)
        {
            return Search(center, position, Physics, environment);
        }

        public GuidanceSearchInfo Search(Point center, Point position, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Search(center, position, Physics, step, environment);
        }

        public GuidanceSearchInfo Search(IShell shell, Point center, Point position, EnvironmentInfo? environment)
        {
            return Search(shell, center, position, Physics, environment);
        }

        public GuidanceSearchInfo Search(IShell shell, Point center, Point position, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Search(shell, center, position, Physics, step, environment);
        }

        public abstract GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        
        public GuidanceSearchInfo SearchAll(Point center, Point position, EnvironmentInfo? environment)
        {
            return SearchAll(center, position, Physics, environment);
        }

        public GuidanceSearchInfo SearchAll(Point center, Point position, GuidanceStep step, EnvironmentInfo? environment)
        {
            return SearchAll(center, position, Physics, step, environment);
        }

        public GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, EnvironmentInfo? environment)
        {
            return SearchAll(shell, center, position, Physics, environment);
        }

        public GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, GuidanceStep step, EnvironmentInfo? environment)
        {
            return SearchAll(shell, center, position, Physics, step, environment);
        }

        public abstract GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        
        public Shell.Unsafe Unsafe()
        {
            return ShellShockLive.Models.Weapons.Shells.Shell.Unsafe.From(this);
        }
    }

    public sealed class GuidanceCustomInfo : GuidanceInfo
    {
        public override IGuidance Guidance { get; }
        public override IShell Shell { get; }

        public GuidanceCustomInfo(PhysicsInfo physics, IGuidance guidance, IShell shell)
            : base(physics)
        {
            Guidance = guidance ?? throw new ArgumentNullException(nameof(guidance));
            Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        }
        
        public GuidanceCustomInfo(GuidanceSearchInfo search, IGuidance guidance, IShell shell)
            : base(search)
        {
            Guidance = guidance ?? throw new ArgumentNullException(nameof(guidance));
            Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        }
        
        public override Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.Evaluate(Shell, center, physics, environment);
        }

        public override Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.Evaluate(Shell, center, physics, step, environment);
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.Evaluate(shell, center, physics, environment);
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.Evaluate(shell, center, physics, step, environment);
        }
        
        public override GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.Search(Shell, center, position, physics, environment);
        }

        public override GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.Search(Shell, center, position, physics, step, environment);
        }

        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.Search(shell, center, position, physics, environment);
        }

        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.Search(shell, center, position, physics, step, environment);
        }
        
        public override GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.SearchAll(Shell, center, position, physics, environment);
        }

        public override GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.SearchAll(Shell, center, position, physics, step, environment);
        }

        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Guidance.SearchAll(shell, center, position, physics, environment);
        }

        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Guidance.SearchAll(shell, center, position, physics, step, environment);
        }
    }

    public sealed class GuidanceShellInfo : GuidanceInfo
    {
        public override IGuidanceShell Shell { get; }

        public override IGuidance Guidance
        {
            get
            {
                return Shell;
            }
        }

        public GuidanceShellInfo(PhysicsInfo physics, IGuidanceShell shell)
            : base(physics)
        {
            Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        }

        public GuidanceShellInfo(GuidanceSearchInfo search, IGuidanceShell shell)
            : base(search)
        {
            Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        }
        
        public override Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Shell.Evaluate(center, physics, environment);
        }

        public override Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Shell.Evaluate(center, physics, step, environment);
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Shell.Evaluate(shell, center, physics, environment);
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Shell.Evaluate(shell, center, physics, step, environment);
        }
        
        public override GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Shell.Search(center, position, physics, environment);
        }

        public override GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Shell.Search(center, position, physics, step, environment);
        }

        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Shell.Search(shell, center, position, physics, environment);
        }

        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Shell.Search(shell, center, position, physics, step, environment);
        }
        
        public override GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Shell.SearchAll(center, position, physics, environment);
        }

        public override GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Shell.SearchAll(center, position, physics, step, environment);
        }

        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Shell.SearchAll(shell, center, position, physics, environment);
        }

        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Shell.SearchAll(shell, center, position, physics, step, environment);
        }
    }

    public sealed class GuidanceWeaponInfo : GuidanceInfo
    {
        public IWeapon Weapon { get; }

        public override IGuidance Guidance
        {
            get
            {
                return Weapon;
            }
        }

        public override IShell Shell
        {
            get
            {
                return Weapon;
            }
        }

        public GuidanceWeaponInfo(PhysicsInfo physics, IWeapon weapon)
            : base(physics)
        {
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public GuidanceWeaponInfo(GuidanceSearchInfo search, IWeapon weapon)
            : base(search)
        {
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }
        
        public override Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Weapon.Evaluate(center, physics, environment);
        }

        public override Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Weapon.Evaluate(center, physics, step, environment);
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Weapon.Evaluate(shell, center, physics, environment);
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Weapon.Evaluate(shell, center, physics, step, environment);
        }
        
        public override GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Weapon.Search(center, position, physics, environment);
        }

        public override GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Weapon.Search(center, position, physics, step, environment);
        }

        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Weapon.Search(shell, center, position, physics, environment);
        }

        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Weapon.Search(shell, center, position, physics, step, environment);
        }
        
        public override GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Weapon.SearchAll(center, position, physics, environment);
        }

        public override GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Weapon.SearchAll(center, position, physics, step, environment);
        }

        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Weapon.SearchAll(shell, center, position, physics, environment);
        }

        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return Weapon.SearchAll(shell, center, position, physics, step, environment);
        }
    }
}