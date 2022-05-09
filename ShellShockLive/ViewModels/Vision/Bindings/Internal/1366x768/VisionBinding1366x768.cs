// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ShellShockLive.Models.Physics.Bindings;
using ShellShockLive.Models.Physics.Bindings.Interfaces;

namespace ShellShockLive.ViewModels.Vision.Bindings.Internal
{
    public sealed class VisionBinding1366x768 : InternalVisionBinding<VisionBinding1366x768>
    {
        public override IPhysicsBinding Physics
        {
            get
            {
                return PhysicsBinding.Binding1366x768;
            }
        }

        public override Size Size
        {
            get
            {
                return new Size(1366, 768);
            }
        }

        public override PlayerBinding Player
        {
            get
            {
                Size size = Size;
                
                return new PlayerBinding
                {
                    Player = new Size(20, 20),
                    Screen = new Rectangle(0, 100, size.Width, Size.Height - 100 - Information.Screen.Height)
                };
            }
        }
        
        public override WeaponBinding Weapon
        {
            get
            {
                return new WeaponBinding
                {
                    Title = new Rectangle(504, 734, 190, 24),
                    Image = new Rectangle(450, 710, 52, 52),
                    Screen = new Rectangle(450, 710, 275, 52)
                };
            }
        }

        public override WindBinding Wind
        {
            get
            {
                return new WindBinding
                {
                    Text = new Rectangle(671, 52, 24, 18),
                    Left = new Rectangle(655, 55, 10, 10),
                    Center = new Rectangle(668, 50, 30, 20),
                    Right = new Rectangle(701, 55, 10, 10)
                };
            }
        }

        public override FuelBinding Fuel
        {
            get
            {
                return new FuelBinding
                {
                    Text = new Rectangle(250, 670, 34, 16),
                    Image = new Rectangle(190, 666, 96, 96)
                };
            }
        }

        public override InformationBinding Information
        {
            get
            {
                Size size = Size;
                const Int32 height = 110;
                
                return new InformationBinding
                {
                    Screen = new Rectangle(0, size.Height - height, size.Width, height)
                };
            }
        }
    }
}