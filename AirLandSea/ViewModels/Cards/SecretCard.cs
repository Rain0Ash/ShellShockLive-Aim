using System;
using AirLandSea.Models;

namespace AirLandSea.ViewModels
{
    public sealed record SecretCard : GameCard
    {
        public static SecretCard Default { get; } = new SecretCard();

        public override CardType Type { get; }

        public override FieldCardType Field
        {
            get
            {
                return FieldCardType.Unknown;
            }
            set
            {
            }
        }
        
        public override CardPositionType Position
        {
            get
            {
                return CardPositionType.Backview;
            }
            set
            {
            }
        }

        public override GameCardEffect Effect
        {
            get
            {
                return GameCardEffect.None;
            }
        }

        public override CardPointType Points
        {
            get
            {
                return CardPointType.Zero;
            }
            set
            {
            }
        }
        
        private SecretCard()
        {
        }
        
        public SecretCard(CardType type)
        {
            Type = type;
        }
    }
}