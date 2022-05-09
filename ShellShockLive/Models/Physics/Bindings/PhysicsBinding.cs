// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using NetExtender.Types.Exceptions;
using ShellShockLive.Models.Physics.Bindings.Interfaces;
using ShellShockLive.Models.Physics.Bindings.Internal;

namespace ShellShockLive.Models.Physics.Bindings
{
    public enum PhysicsBindings : Byte
    {
        Default,
        Binding1280x1024,
        Binding1366x768,
        Binding1600x1024,
        Binding1680x1050,
        Binding1920x1080,
        Binding2560x1440,
        Custom
    }
    
    public abstract class PhysicsBinding : IPhysicsBinding
    {
        public static implicit operator PhysicsBinding(PhysicsBindings value)
        {
            return (PhysicsBinding) (value switch
            {
                PhysicsBindings.Default => Binding1366x768,
                PhysicsBindings.Binding1280x1024 => Binding1280x1024,
                PhysicsBindings.Binding1366x768 => Binding1366x768,
                PhysicsBindings.Binding1600x1024 => Binding1600x1024,
                PhysicsBindings.Binding1680x1050 => Binding1680x1050,
                PhysicsBindings.Binding1920x1080 => Binding1920x1080,
                PhysicsBindings.Binding2560x1440 => Binding2560x1440,
                PhysicsBindings.Custom => throw new NotSupportedException(),
                _ => throw new EnumUndefinedOrNotSupportedException<PhysicsBindings>(value, nameof(value), null)
            });
        }
        
        public static IPhysicsBinding Binding1280x1024
        {
            get
            {
                return PhysicsBinding1280x1024.Instance;
            }
        }
        
        public static IPhysicsBinding Binding1366x768
        {
            get
            {
                return PhysicsBinding1366x768.Instance;
            }
        }
        
        public static IPhysicsBinding Binding1600x1024
        {
            get
            {
                return PhysicsBinding1600x1024.Instance;
            }
        }
        
        public static IPhysicsBinding Binding1680x1050
        {
            get
            {
                return PhysicsBinding1680x1050.Instance;
            }
        }
        
        public static IPhysicsBinding Binding1920x1080
        {
            get
            {
                return PhysicsBinding1920x1080.Instance;
            }
        }
        
        public static IPhysicsBinding Binding2560x1440
        {
            get
            {
                return PhysicsBinding2560x1440.Instance;
            }
        }

        public abstract PhysicsBindings Type { get; }
        public virtual BindingConstant<Int16> Angle { get; } = new BindingConstant<Int16>(0, 360, 0);
        public virtual BindingConstant<Int16> Wind { get; } = new BindingConstant<Int16>(-100, 100, 0);
        public virtual BindingConstant<Int16> Power { get; } = new BindingConstant<Int16>(0, 100, 85);

        public abstract Size Size { get; }
        public abstract Rectangle Bounds { get; }
        public abstract UInt16 Length { get; }
        public abstract Single Gravity { get; }
        public abstract Single Velocity { get; }
        public abstract Single Radius { get; }
        public abstract Single WindOffset { get; }

        Unsafe IPhysicsBinding.Unsafe()
        {
            return this;
        }
        
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Unsafe
        {
            public static implicit operator PhysicsBinding(Unsafe value)
            {
                return value.Binding switch
                {
                    PhysicsBindings.Custom => (CustomPhysicsBinding) value,
                    _ => value.Binding
                };
            }
            
            public static implicit operator Unsafe(PhysicsBinding? value)
            {
                return value is not null ? new Unsafe
                {
                    Binding = value.Type,
                    Angle = value.Angle,
                    Wind = value.Wind,
                    Power = value.Power,
                    Size = value.Size,
                    Bounds = value.Bounds,
                    Length = value.Length,
                    Gravity = value.Gravity,
                    Velocity = value.Velocity,
                    Radius = value.Radius,
                    WindOffset = value.WindOffset
                } : default;
            }
            
            public PhysicsBindings Binding { get; init; }
            public BindingConstant<Int16> Angle { get; init; }
            public BindingConstant<Int16> Wind { get; init; }
            public BindingConstant<Int16> Power { get; init; }

            public Size Size { get; init; }
            public Rectangle Bounds { get; init; }
            public UInt16 Length { get; init; }
            public Single Gravity { get; init; }
            public Single Velocity { get; init; }
            public Single Radius { get; init; }
            public Single WindOffset { get; init; }
        }
    }
}