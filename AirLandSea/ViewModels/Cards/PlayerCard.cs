// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows.Media.Imaging;
using AirLandSea.Models;
using ReactiveUI.Fody.Helpers;

namespace AirLandSea.ViewModels
{
    public record PlayerCard : Card
    {
        public static SecretCard Secret { get; } = new SecretCard(CardType.Player);
        public static PlayerCard First { get; } = new FirstPlayerCard();
        public static PlayerCard Second { get; } = new SecondPlayerCard();

        public override BitmapImage? Image
        {
            get
            {
                return ImageStorage.GetPlayerImage(Player, Position);
            }
        }

        public override CardType Type
        {
            get
            {
                return CardType.Player;
            }
        }

        public override CardSizeType SizeType
        {
            get
            {
                return CardSizeType.Default;
            }
        }

        [Reactive]
        public virtual PlayerCardType Player { get; set; }
        
        [Reactive]
        public virtual CardPositionType Position { get; set; }

        private sealed record FirstPlayerCard : PlayerCard
        {
            public override PlayerCardType Player
            {
                get
                {
                    return PlayerCardType.First;
                }
            }

            public override CardPositionType Position
            {
                get
                {
                    return CardPositionType.Foreview;
                }
                set
                {
                }
            }
        }
        
        private sealed record SecondPlayerCard : PlayerCard
        {
            public override PlayerCardType Player
            {
                get
                {
                    return PlayerCardType.Second;
                }
            }
            
            public override CardPositionType Position
            {
                get
                {
                    return CardPositionType.Foreview;
                }
                set
                {
                }
            }
        }
    }
}