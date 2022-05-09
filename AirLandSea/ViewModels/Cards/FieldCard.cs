// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows.Media.Imaging;
using AirLandSea.Models;

namespace AirLandSea.ViewModels
{
    public record FieldCard : ActiveCard
    {
        public static SecretCard Secret { get; } = new SecretCard(CardType.Field);
        
        public override BitmapImage? Image
        {
            get
            {
                return ImageStorage.GetFieldImage(Field, Position);
            }
        }

        public override CardType Type
        {
            get
            {
                return CardType.Field;
            }
        }

        public override CardSizeType SizeType
        {
            get
            {
                return CardSizeType.Field;
            }
        }
    }
}