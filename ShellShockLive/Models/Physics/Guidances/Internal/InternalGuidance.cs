// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Physics.Guidances.Internal
{
    public abstract class InternalGuidance<T> : Guidance where T : InternalGuidance<T>, new()
    {
        private static Lazy<T> Internal { get; } = new Lazy<T>(() => new T(), true);

        public static T Instance
        {
            get
            {
                return Internal.Value;
            }
        }

        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            //TODO: FirstOrDefault для ParallelQuery
            GuidanceSearchResult result = SearchInternal(shell, center, position, physics, step, environment).FirstOrDefault(physics);
            return new GuidanceSearchInfo(result, position, step);
        }

        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            GuidanceSearchResult[] result = SearchParallelInternal(shell, center, position, physics, step, environment);
            return new GuidanceSearchInfo(result, position, step);
        }

        protected abstract IEnumerable<GuidanceSearchResult> SearchInternal(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);

        protected virtual GuidanceSearchResult[] SearchParallelInternal(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return SearchInternal(shell, center, position, physics, step, environment).ToArray();
        }
    }
}