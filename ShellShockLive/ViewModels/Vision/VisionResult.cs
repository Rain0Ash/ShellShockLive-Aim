// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Types.Monads;
using ShellShockLive.Models.Weapons.Interfaces;

namespace ShellShockLive.ViewModels.Vision
{
    public readonly struct VisionResult
    {
        public static implicit operator Boolean(VisionResult value)
        {
            return value.Type > VisionType.None;
        }
        
        public static implicit operator VisionType(VisionResult value)
        {
            return value.Type;
        }

        public Maybe<Point> Player { get; }
        public Maybe<IWeapon> Weapon { get; }
        public Maybe<Int16> Wind { get; }
        public Maybe<UInt16> Fuel { get; }
        
        public VisionType Type
        {
            get
            {
                VisionType type = VisionType.None;

                if (Player)
                {
                    type |= VisionType.Player;
                }

                if (Weapon)
                {
                    type |= VisionType.Weapon;
                }

                if (Wind)
                {
                    type |= VisionType.Wind;
                }

                if (Fuel)
                {
                    type |= VisionType.Fuel;
                }

                return type;
            }
        }

        public VisionResult(Maybe<Point> player, Maybe<IWeapon> weapon, Maybe<Int16> wind, Maybe<UInt16> fuel)
        {
            Player = player;
            Weapon = weapon;
            Wind = wind;
            Fuel = fuel;
        }

        public override String ToString()
        {
            return $"Player: {Player} Weapon: {Weapon} Wind: {Wind} Fuel: {Fuel}";
        }
    }
}