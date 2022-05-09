// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Physics.Bindings
{
    public class CustomPhysicsBinding : PhysicsBinding
    {
        public static explicit operator CustomPhysicsBinding(Unsafe value)
        {
            return new CustomPhysicsBinding(value.Angle, value.Wind, value.Power, value.Size, value.Bounds, value.Length, value.Gravity, value.Velocity, value.Radius, value.WindOffset);
        }
        
        public sealed override PhysicsBindings Type
        {
            get
            {
                return PhysicsBindings.Custom;
            }
        }

        public sealed override BindingConstant<Int16> Angle { get; }
        public sealed override BindingConstant<Int16> Wind { get; }
        public sealed override BindingConstant<Int16> Power { get; }

        public sealed override Size Size { get; }
        public sealed override Rectangle Bounds { get; }
        public sealed override UInt16 Length { get; }
        public sealed override Single Gravity { get; }
        public sealed override Single Velocity { get; }
        public sealed override Single Radius { get; }
        public sealed override Single WindOffset { get; }
        
        public CustomPhysicsBinding(BindingConstant<Int16> angle, BindingConstant<Int16> wind, BindingConstant<Int16> power, Size size, Rectangle bounds, UInt16 length, Single gravity, Single velocity, Single radius, Single windoffset)
        {
            Angle = angle;
            Wind = wind;
            Power = power;

            Size = size;
            Bounds = bounds;
            Length = length;
            Gravity = gravity > 0 ? gravity : throw new ArgumentOutOfRangeException(nameof(gravity), gravity, null);
            Velocity = velocity > 0 ? velocity : throw new ArgumentOutOfRangeException(nameof(velocity), velocity, null);
            Radius = radius > 0 ? radius : throw new ArgumentOutOfRangeException(nameof(radius), radius, null);
            WindOffset = windoffset > 0 ? windoffset : throw new ArgumentOutOfRangeException(nameof(windoffset), windoffset, null);
        }
    }
}