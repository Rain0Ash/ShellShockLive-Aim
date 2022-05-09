// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AirLandSea.Models;
using NetExtender.Types.Collections;
using NetExtender.Utilities.IO;
using NetExtender.Utilities.Types;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AirLandSea.ViewModels
{
    public class BattlefieldPlayer : ReactiveObject
    {
        public BattlefieldSettings Settings { get; }
        public Player Player { get; }
        
        [Reactive]
        public PlayerCard Number { get; set; }
        public ItemObservableCollection<GameCard> GameCards { get; }
        public ItemObservableCollection<GamePointCard> PointCards { get; }

        public Int32 Points
        {
            get
            {
                return PointCards.Sum(item => (Int32) item.Points);
            }
        }

        public Byte LoosePoints
        {
            get
            {
                return Number.Player switch
                {
                    PlayerCardType.First => Settings.Player1.LooseScore.ElementAtOrDefault(GameCards.Count, (Byte) 1),
                    PlayerCardType.Second => Settings.Player2.LooseScore.ElementAtOrDefault(GameCards.Count, (Byte) 1),
                    _ => throw new NotSupportedException()
                };
            }
        }

        public BattlefieldPlayer(Player player, PlayerCard number, BattlefieldSettings settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Number = number ?? throw new ArgumentNullException(nameof(number));
            GameCards = new ItemObservableCollection<GameCard>();
            PointCards = new ItemObservableCollection<GamePointCard>();
        }

        public static void NumberSwap(BattlefieldPlayer first, BattlefieldPlayer second)
        {
            if (first is null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            (first.Number, second.Number) = (second.Number, first.Number);
        }
        
        public Boolean Contains(GameCard card)
        {
            return GameCards.Contains(card);
        }

        public Boolean Contains(GameCardEffect effect)
        {
            return GameCards.Any(item => item.Effect == effect);
        }
        
        public void Add(GameCard card)
        {
            GameCards.Add(card);
        }

        public virtual Boolean Win(BattlefieldPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentNullException(nameof(player));
            }
            
            List<GamePointCard> points = PointCards.ToList();

            switch (player.LoosePoints)
            {
                case 0:
                    return Points >= Settings.WinningBattleScore;
                case 1:
                    points.Add(GamePointCard.One);
                    break;
                case 2:
                    points.Add(GamePointCard.One);
                    points.Add(GamePointCard.One);
                    break;
                case 3:
                    points.Add(GamePointCard.Three);
                    break;
                case 4:
                    points.Add(GamePointCard.Three);
                    points.Add(GamePointCard.One);
                    break;
                case 5:
                    points.Add(GamePointCard.Three);
                    points.Add(GamePointCard.One);
                    points.Add(GamePointCard.One);
                    break;
                case 6:
                    points.Add(GamePointCard.Six);
                    break;
            }

            PointCards.Clear();

            foreach (GamePointCard card in GamePointCard.Compress(points))
            {
                PointCards.Add(card);
            }

            return Points >= Settings.WinningBattleScore;
        }

        public void Remove(GameCard card)
        {
            GameCards.Remove(card);
        }
        
        public void Clear()
        {
            GameCards.Clear();
        }

        public void Reset()
        {
            Clear();
            PointCards.Clear();
        }
    }
}