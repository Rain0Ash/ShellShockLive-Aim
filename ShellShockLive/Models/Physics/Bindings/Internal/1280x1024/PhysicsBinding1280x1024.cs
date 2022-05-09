// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Physics.Bindings.Internal
{
    public sealed class PhysicsBinding1280x1024 : InternalPhysicsBinding<PhysicsBinding1280x1024>
    {
        public override PhysicsBindings Type
        {
            get
            {
                return PhysicsBindings.Binding1280x1024;
            }
        }

        public override Size Size
        {
            get
            {
                return new Size(1280, 1024);
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
                return 220;
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
                return 1.272F;
            }
        }

        public override Single Radius
        {
            get
            {
                return 19.9F;
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