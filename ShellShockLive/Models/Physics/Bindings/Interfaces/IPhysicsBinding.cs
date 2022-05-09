// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Physics.Bindings.Interfaces
{
    public interface IPhysicsBinding
    {
        public BindingConstant<Int16> Angle { get; }
        public BindingConstant<Int16> Wind { get; }
        public BindingConstant<Int16> Power { get; }

        public Size Size { get; }
        public Rectangle Bounds { get; }
        public UInt16 Length { get; }
        public Single Gravity { get; }
        public Single Velocity { get; }
        public Single Radius { get; }
        public Single WindOffset { get; }

        public PhysicsBinding.Unsafe Unsafe();
    }
}