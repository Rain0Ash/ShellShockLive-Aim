// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using AirLandSea.Models;

namespace AirLandSea.ViewModels
{
    public class BattlefieldResult
    {
        public Player Player1 { get; }
        public Player Player2 { get; }
        public PlayerCardType Winner { get; }
        
        public BattlefieldResult(Player first, Player second, PlayerCardType winner)
        {
            Player1 = first ?? throw new ArgumentNullException(nameof(first));
            Player2 = second ?? throw new ArgumentNullException(nameof(second));
            Winner = winner;
        }
    }
}