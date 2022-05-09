// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Physics.Bindings.Internal
{
    public sealed class PhysicsBinding1680x1050 : InternalPhysicsBinding<PhysicsBinding1680x1050>
    {
        public override PhysicsBindings Type
        {
            get
            {
                return PhysicsBindings.Binding1680x1050;
            }
        }
        
        public override Size Size
        {
            get
            {
                return new Size(1680, 1050);
            }
        }

        public override Rectangle Bounds
        {
            get
            {
                const Int32 top = -1000;
                return new Rectangle(0, top, Size.Width, Size.Height - top - 145);
            }
        }
        
        public override UInt16 Length
        {
            get
            {
                return 300;
            }
        }

        public override Single Gravity
        {
            get
            {
                return 9.8F;
            }
        }

        public override Single Velocity
        {
            get
            {
                return 1.46F;
            }
        }

        public override Single Radius
        {
            get
            {
                return 26.0F;
            }
        }

        public override Single WindOffset
        {
            get
            {
                return 1 / 80.0F;
            }
        }
    }
}