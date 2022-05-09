// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Drawing;
using ShellShockLive.Models.Environment.Containers;
using ShellShockLive.Models.Environment.Interfaces;

namespace ShellShockLive.Models.Environment
{
    public class EnvironmentInfo : ISurface
    {
        public SurfaceType Type
        {
            get
            {
                return SurfaceType.None;
            }
        }

        public Boolean Interactive
        {
            get
            {
                return false;
            }
        }

        public PointContainer? Player { get; init; }
        public ImmutableArray<PointContainer> Alies { get; init; }
        public ImmutableArray<PointContainer> Enemies { get; init; }
        public ImmutableArray<ISurface> Surfaces { get; init; }

        public EnvironmentInfo()
        {
        }
        
        public EnvironmentInfo(PointContainer? player, ImmutableArray<PointContainer> alies, ImmutableArray<PointContainer> enemies, ImmutableArray<ISurface> surfaces)
        {
            Player = player;
            Alies = alies;
            Enemies = enemies;
            Surfaces = surfaces;
        }

        public Boolean Intersect(Point point)
        {
            return false;
        }

        public Surface.Unsafe Unsafe()
        {
            throw new NotImplementedException();
        }

        public Object Clone()
        {
            throw new NotImplementedException();
        }
    }
}