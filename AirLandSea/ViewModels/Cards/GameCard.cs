// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows.Media.Imaging;
using AirLandSea.Models;
using ReactiveUI.Fody.Helpers;

namespace AirLandSea.ViewModels
{
    public record GameCard : ActiveCard
    {
        public static SecretCard Secret { get; } = new SecretCard(CardType.Game);
        
        public override BitmapImage? Image
        {
            get
            {
                return ImageStorage.GetGameCardImage(Field, Points, Position);
            }
        }

        public override CardType Type
        {
            get
            {
                return CardType.Game;
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
        public virtual GameCardEffect Effect { get; set; }
        
        public virtual GameCardEffectType EffectType
        {
            get
            {
                return Effect.ToEffectType();
            }
        }

        [Reactive]
        public virtual CardPointType Points { get; set; }
    }
}