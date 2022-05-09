// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using NetExtender.Types.Exceptions;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Weapons.Shells
{
    public abstract class GuidanceShell : Shell, IGuidanceShell
    {
        public static implicit operator GuidanceShell(GuidanceType value)
        {
            return (GuidanceShell) (value switch
            {
                Physics.Guidances.GuidanceType.Parabola => Parabola,
                Physics.Guidances.GuidanceType.Direct => Direct,
                Physics.Guidances.GuidanceType.Custom => throw new NotSupportedException(),
                _ => throw new EnumUndefinedOrNotSupportedException<GuidanceType>(value, nameof(value), null)
            });
        }
        
        [return: NotNullIfNotNull("value")]
        public static implicit operator GuidanceShell?(GuidanceType? value)
        {
            return (GuidanceShell?) (value switch
            {
                null => null,
                Physics.Guidances.GuidanceType.Parabola => Parabola,
                Physics.Guidances.GuidanceType.Direct => Direct,
                Physics.Guidances.GuidanceType.Custom => throw new NotSupportedException(),
                _ => throw new EnumUndefinedOrNotSupportedException<GuidanceType>(value.Value, nameof(value), null)
            });
        }
        
        public abstract IGuidance Guidance { get; }

        public override GuidanceType? GuidanceType
        {
            get
            {
                return Guidance.GuidanceType;
            }
        }

        GuidanceType IGuidance.GuidanceType
        {
            get
            {
                return Guidance.GuidanceType;
            }
        }

        GuidanceType IGuidanceShell.GuidanceType
        {
            get
            {
                return Guidance.GuidanceType;
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
    }
}