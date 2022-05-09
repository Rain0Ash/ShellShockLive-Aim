// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.Models.Weapons.Shells.Interfaces
{
    public interface IGuidanceShell : IShell, IGuidance
    {
        public IGuidance Guidance { get; }
        public new GuidanceType GuidanceType { get; }
        
        public Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, EnvironmentInfo? environment);
        public Guidance.Enumerator Evaluate(Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public GuidanceSearchInfo Search(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public GuidanceSearchInfo SearchAll(Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
    }
}