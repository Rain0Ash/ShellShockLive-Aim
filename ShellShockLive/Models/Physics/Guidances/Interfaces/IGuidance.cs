// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Physics.Guidances.Interfaces
{
    public interface IGuidance
    {
        public GuidanceType GuidanceType { get; }
        
        public Boolean IsParabola { get; }
        public Boolean IsDirect { get; }
        public Boolean IsCustom { get; }

        public Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment);
        public Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
    }
}