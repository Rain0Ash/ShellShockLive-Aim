// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ReactiveUI;
using ShellShockLive.Models.Environment.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.ViewModels.Environment.Interfaces;

namespace ShellShockLive.ViewModels.Environment
{
    public abstract class SurfaceViewModel<T> : SurfaceViewModel, ISurfaceViewModel<T> where T : class, ISurface
    {
        public abstract override T Surface { get; }
        
        ISurface ISurfaceViewModel.Surface
        {
            get
            {
                return Surface;
            }
        }
    }

    public abstract class SurfaceViewModel : ReactiveObject, ISurfaceViewModel
    {
        public abstract ISurface Surface { get; }

        public Boolean Interactive
        {
            get
            {
                return Surface.Interactive;
            }
        }

        public virtual Byte Transparent
        {
            get
            {
                return Byte.MaxValue;
            }
        }

        public abstract void Draw(IGuidanceInfo guidance, Graphics graphics);

        protected virtual Color Adapt(Color color)
        {
            return Adapt(Transparent, color);
        }

        protected virtual Color Adapt(Int32 transparent, Color color)
        {
            return Color.FromArgb(transparent, color);
        }

        protected virtual Color Adapt(Double multiplier, Color color)
        {
            Int32 transparent = Math.Clamp((Int32) (Transparent * multiplier), Byte.MinValue, Byte.MaxValue);
            return Adapt(transparent, color);
        }

        public Boolean Intersect(Point point)
        {
            return Surface.Intersect(point);
        }
    }
}