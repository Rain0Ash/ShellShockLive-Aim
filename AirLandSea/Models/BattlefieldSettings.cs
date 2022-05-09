// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using AirLandSea.Models;

namespace AirLandSea
{
    public class BattlefieldSettings
    {
        private readonly Byte _score = 18;
        public Byte WinningBattleScore
        {
            get
            {
                return _score;
            }
            init
            {
                if (_score <= 0)
                {
                    throw new ArgumentException("Winning battle score must be greater than 0");
                }
                
                _score = value;
            }
        }

        public BattlefieldPlayerSettings Player1 { get; init; } = new BattlefieldPlayerSettings { LooseScoreType = PlayerCardType.First };
        public BattlefieldPlayerSettings Player2 { get; init; } = new BattlefieldPlayerSettings { LooseScoreType = PlayerCardType.Second };

        public class BattlefieldPlayerSettings
        {
            private static ImmutableArray<Byte> Loose1 { get; } = new Byte[] { 6, 4, 3, 3, 2, 2, 2, 2 }.ToImmutableArray();
            private static ImmutableArray<Byte> Loose2 { get; } = new Byte[] { 6, 4, 3, 3, 2, 2, 2, 2 }.ToImmutableArray();

            private readonly ImmutableArray<Byte> _loose;
            public ImmutableArray<Byte> LooseScore
            {
                get
                {
                    return _loose;
                }
                init
                {
                    if (value.Length < 7)
                    {
                        throw new ArgumentException("Loose score must be at least 7 elements long");
                    }
                    
                    _loose = value;
                }
            }

            public PlayerCardType LooseScoreType
            {
                init
                {
                    LooseScore = value switch
                    {
                        PlayerCardType.First => Loose1,
                        PlayerCardType.Second => Loose2,
                        _ => throw new NotSupportedException()
                    };
                }
            }
        }
    }
}