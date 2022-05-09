// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AirLandSea.Models;
using NetExtender.Types.Collections;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Types;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AirLandSea.ViewModels
{
    public class Battlefield : ReactiveObject
    {
        public BattlefieldSettings Settings { get; }
        public BattlefieldPlayer Player1 { get; }
        public BattlefieldPlayer Player2 { get; }

        [Reactive]
        public PlayerType Current { get; protected set; }

        public BattlefieldPlayer? CurrentPlayer
        {
            get
            {
                return Current switch
                {
                    PlayerType.First => Player1.Number.Player == PlayerCard.First.Player ? Player1 : Player2,
                    PlayerType.Second => Player2.Number.Player == PlayerCard.Second.Player ? Player2 : Player1,
                    _ => null
                };
            }
        }
        
        public BattlefieldPlayer? AnotherPlayer
        {
            get
            {
                return Current switch
                {
                    PlayerType.First => Player1.Number.Player == PlayerCard.First.Player ? Player2 : Player1,
                    PlayerType.Second => Player2.Number.Player == PlayerCard.Second.Player ? Player1 : Player2,
                    _ => null
                };
            }
        }

        public SuppressObservableCollection<FieldCard> Fields { get; }
        private Queue<GameCard> Deck { get; }

        public Battlefield(Player first, Player second)
            : this(first, second, null)
        {
        }

        public Battlefield(Player first, Player second, BattlefieldSettings? settings)
        {
            if (first is null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            if (first.Name == second.Name)
            {
                throw new ArgumentException("Players must have different names");
            }
            
            if (first.IsServer || second.IsServer)
            {
                throw new ArgumentException("Players must be clients");
            }
            
            if (first.Type == second.Type)
            {
                throw new ArgumentException("Players must have different positions");
            }

            Settings = settings ?? new BattlefieldSettings();
            Player1 = new BattlefieldPlayer(first, PlayerCard.First, Settings);
            Player2 = new BattlefieldPlayer(second, PlayerCard.Second, Settings);
            Fields = CardStorage.FieldCards.ToObservableCollection();
            Deck = new Queue<GameCard>();
        }

        public virtual Battlefield Initialize()
        {
            Reset();
            return this;
        }

        public void Surrend()
        {
            BattlefieldPlayer? current = CurrentPlayer;
            BattlefieldPlayer? another = AnotherPlayer;

            if (current is not null && another is not null)
            {
                if (another.Win(current))
                {
                    DialogResult result = MessageBox.Show("Игрок " + another.Player.Name + " победил! Повторить?", "Игра окончена",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        Player1.Reset();
                        Player2.Reset();
                        Reset();
                        return;
                    }
                }
            }
            
            Next();
        }

        protected BattlefieldPlayer? Contains(GameCardEffect effect)
        {
            if (Player1.Contains(effect))
            {
                return Player1;
            }
            
            if (Player2.Contains(effect))
            {
                return Player2;
            }
            
            return null;
        }

        protected virtual void NextStep()
        {
            switch (Current)
            {
                case PlayerType.Server:
                    return;
                case PlayerType.First:
                    Current = PlayerType.Second;
                    break;
                case PlayerType.Second:
                    Current = PlayerType.First;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        protected virtual void SwapPlayer()
        {
            BattlefieldPlayer.NumberSwap(Player1, Player2);
        }

        protected virtual void ResetDeck()
        {
            Deck.Clear();
            Deck.EnqueueRange(CardStorage.GameCards);
            
            Player1.Clear();
            Player2.Clear();
            
            for (Int32 i = 0; i < 6; i++)
            {
                Player1.Add(Deck.Dequeue());
                Player2.Add(Deck.Dequeue());
            }
        }

        public virtual void Next()
        {
            Current = PlayerType.First;
            Fields.Rotate(-1);
            ResetDeck();
            SwapPlayer();
        }

        public virtual void Reset()
        {
            Current = PlayerType.First;
            Fields.Shuffle();
            ResetDeck();
            RandomUtilities.Action(SwapPlayer);
        }
    }
}