// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Physics.Bindings.Internal
{
    public sealed class PhysicsBinding2560x1440 : InternalPhysicsBinding<PhysicsBinding2560x1440>
    {
        public override PhysicsBindings Type
        {
            get
            {
                return PhysicsBindings.Binding2560x1440;
            }
        }
        
        public override Size Size
        {
            get
            {
                return new Size(2560, 1440);
            }
        }

        public override Rectangle Bounds
        {
            get
            {
                const Int32 top = -1000;
                return new Rectangle(0, top, Size.Width, Size.Height - top - 240);
            }
        }

        public override UInt16 Length
        {
            get
            {
                return 350;
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
                return 1.8F;
            }
        }

        public override Single Radius
        {
            get
            {
                return 37.0F;
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