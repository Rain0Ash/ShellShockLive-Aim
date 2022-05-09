// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace AirLandSea.Models
{
    public class Player
    {
        public String Name { get; }
        public PlayerType Type { get; }

        public Boolean IsServer
        {
            get
            {
                return Type == PlayerType.Server;
            }
        }

        public Player(String name, PlayerType type)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            }

            Name = name;
            Type = type;
        }
    }
}