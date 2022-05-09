// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ShellShockLive.Models.Physics.Bindings;
using ShellShockLive.Models.Physics.Bindings.Interfaces;
using ShellShockLive.ViewModels.Vision.Bindings.Internal;

namespace ShellShockLive.ViewModels.Vision.Bindings
{
    public abstract class VisionBinding
    {
        public abstract IPhysicsBinding Physics { get; }
        public abstract Size Size { get; }
        public abstract PlayerBinding Player { get; }
        public abstract WeaponBinding Weapon { get; }
        public abstract WindBinding Wind { get; }
        public abstract FuelBinding Fuel { get; }
        public abstract InformationBinding Information { get; }
        
        private static ImmutableDictionary<IPhysicsBinding, VisionBinding> Equality { get; } = new Dictionary<IPhysicsBinding, VisionBinding>
        {
            [PhysicsBinding.Binding1366x768] = VisionBinding1366x768.Instance
        }.ToImmutableDictionary();

        public static Boolean TryGetBinding(IPhysicsBinding binding, [MaybeNullWhen(false)] out VisionBinding result)
        {
            if (binding is null)
            {
                throw new ArgumentNullException(nameof(binding));
            }

            return Equality.TryGetValue(binding, out result);
        }

        public readonly struct PlayerBinding
        {
            public Size Player { get; init; }
            public Rectangle Screen { get; init; }
            
            public PlayerBinding(Size player, Rectangle screen)
            {
                Player = player;
                Screen = screen;
            }
        }

        public readonly struct WeaponBinding
        {
            public Rectangle Title { get; init; }
            public Rectangle Image { get; init; }
            public Rectangle Screen { get; init; }

            public WeaponBinding(Rectangle title, Rectangle image, Rectangle screen)
            {
                Title = title;
                Image = image;
                Screen = screen;
            }
        }
        
        public readonly struct WindBinding
        {
            public Rectangle Text { get; init; }
            public Rectangle Left { get; init; }
            public Rectangle Center { get; init; }
            public Rectangle Right { get; init; }
            
            public WindBinding(Rectangle text, Rectangle left, Rectangle center, Rectangle right)
            {
                Text = text;
                Left = left;
                Center = center;
                Right = right;
            }
        }
        
        public readonly struct FuelBinding
        {
            public Rectangle Text { get; init; }
            public Rectangle Image { get; init; }
            
            public FuelBinding(Rectangle text, Rectangle image)
            {
                Text = text;
                Image = image;
            }
        }
        
        public readonly struct InformationBinding
        {
            public Rectangle Screen { get; init; }
            
            public InformationBinding(Rectangle screen)
            {
                Screen = screen;
            }
        }
    }
}