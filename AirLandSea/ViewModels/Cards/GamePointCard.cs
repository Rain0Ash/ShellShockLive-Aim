// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using AirLandSea.Models;
using ReactiveUI.Fody.Helpers;

namespace AirLandSea.ViewModels
{
    public record GamePointCard : Card
    {
        public static SecretCard Secret { get; } = new SecretCard(CardType.Point);
        public static GamePointCard One { get; } = new GamePoint1Card();
        public static GamePointCard Three { get; } = new GamePoint3Card();
        public static GamePointCard Six { get; } = new GamePoint6Card();

        public static GamePointCard[] Compress(IEnumerable<GamePointCard> cards)
        {
            if (cards is null)
            {
                throw new ArgumentNullException(nameof(cards));
            }

            Int32 sum = cards.Sum(item => (Int32) item.Points);
            List<GamePointCard> result = new List<GamePointCard>();

            for (Int32 i = 0; i < sum / 6; i++)
            {
                result.Add(Six);
            }

            sum %= 6;
            
            for (Int32 i = 0; i < sum / 3; i++)
            {
                result.Add(Three);
            }
            
            sum %= 3;
            
            for (Int32 i = 0; i < sum; i++)
            {
                result.Add(One);
            }
            
            return result.ToArray();
        }

        public override BitmapImage? Image
        {
            get
            {
                return ImageStorage.GetGamePointImage(Points);
            }
        }

        public override CardType Type
        {
            get
            {
                return CardType.Point;
            }
        }

        public override CardSizeType SizeType
        {
            get
            {
                return CardSizeType.GamePoint;
            }
        }

        [Reactive]
        public virtual GamePointType Points { get; set; }

        private sealed record GamePoint1Card : GamePointCard
        {
            public override GamePointType Points
            {
                get
                {
                    return GamePointType.Point1;
                }
                set
                {
                }
            }
        }
        
        private sealed record GamePoint3Card : GamePointCard
        {
            public override GamePointType Points
            {
                get
                {
                    return GamePointType.Point3;
                }
                set
                {
                }
            }
        }
        
        private sealed record GamePoint6Card : GamePointCard
        {
            public override GamePointType Points
            {
                get
                {
                    return GamePointType.Point6;
                }
                set
                {
                }
            }
        }
    }
}