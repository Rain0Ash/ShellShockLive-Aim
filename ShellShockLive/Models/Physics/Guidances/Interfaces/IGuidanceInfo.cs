// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Physics.Guidances.Interfaces
{
    public interface IGuidanceInfo : IGuidanceShell
    {
        public GuidanceSearchInfo? Information { get; }
        public PhysicsInfo Physics { get; }
        
        public Guidance.Enumerator Evaluate(Point center, EnvironmentInfo? environment);
        public Guidance.Enumerator Evaluate(Point center, GuidanceStep step, EnvironmentInfo? environment);
        public Guidance.Enumerator Evaluate(IShell shell, Point center, EnvironmentInfo? environment);
        public Guidance.Enumerator Evaluate(IShell shell, Point center, GuidanceStep step, EnvironmentInfo? environment);
        public GuidanceSearchInfo Search(Point center, Point position, EnvironmentInfo? environment);
        public GuidanceSearchInfo Search(Point center, Point position, GuidanceStep step, EnvironmentInfo? environment);
        public GuidanceSearchInfo Search(IShell shell, Point center, Point position, EnvironmentInfo? environment);
        public GuidanceSearchInfo Search(IShell shell, Point center, Point position, GuidanceStep step, EnvironmentInfo? environment);
        public GuidanceSearchInfo SearchAll(Point center, Point position, EnvironmentInfo? environment);
        public GuidanceSearchInfo SearchAll(Point center, Point position, GuidanceStep step, EnvironmentInfo? environment);
        public GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, EnvironmentInfo? environment);
        public GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, GuidanceStep step, EnvironmentInfo? environment);
    }
}