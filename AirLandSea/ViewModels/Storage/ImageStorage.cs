// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Media.Imaging;
using AirLandSea.Models;

namespace AirLandSea.ViewModels
{
    public static class ImageStorage
    {
        private static class PlayerCardImages
        {
            public static BitmapImage BackImage { get; }
            public static ImmutableDictionary<PlayerCardType, BitmapImage> Images { get; }

            static PlayerCardImages()
            {
                BackImage = new BitmapImage(new Uri("Files/BackPlayerCard.png", UriKind.Relative));

                Images = new Dictionary<PlayerCardType, BitmapImage>
                {
                    [PlayerCardType.First] = new BitmapImage(new Uri("Files/FirstPlayerCard.png", UriKind.Relative)),
                    [PlayerCardType.Second] = new BitmapImage(new Uri("Files/SecondPlayerCard.png", UriKind.Relative)),
                }.ToImmutableDictionary();
            }
        }

        private static class GamePointCardImages
        {
            public static ImmutableDictionary<GamePointType, BitmapImage> Images { get; }

            static GamePointCardImages()
            {
                Images = new Dictionary<GamePointType, BitmapImage>
                {
                    [GamePointType.Point1] = new BitmapImage(new Uri("Files/1WinPoint.png", UriKind.Relative)),
                    [GamePointType.Point3] = new BitmapImage(new Uri("Files/3WinPoint.png", UriKind.Relative)),
                    [GamePointType.Point6] = new BitmapImage(new Uri("Files/6WinPoint.png", UriKind.Relative))
                }.ToImmutableDictionary();
            }
        }

        private static class FieldCardImages
        {
            public static BitmapImage BackImage { get; }
            public static ImmutableDictionary<FieldCardType, BitmapImage> Images { get; }

            static FieldCardImages()
            {
                BackImage = new BitmapImage(new Uri("Files/BackFieldCard.png", UriKind.Relative));
                
                Images = new Dictionary<FieldCardType, BitmapImage>
                {
                    [FieldCardType.Air] = new BitmapImage(new Uri("Files/SkyFieldCard.png", UriKind.Relative)),
                    [FieldCardType.Sea] = new BitmapImage(new Uri("Files/SeaFieldCard.png", UriKind.Relative)),
                    [FieldCardType.Land] = new BitmapImage(new Uri("Files/EarthFieldCard.png", UriKind.Relative))
                }.ToImmutableDictionary();
            }
        }

        private static class GameCardImages
        {
            public static BitmapImage BackImage { get; }
            public static ImmutableDictionary<(FieldCardType, CardPointType), BitmapImage> Images { get; }

            static GameCardImages()
            {
                BackImage = new BitmapImage(new Uri("Files/BackGameCard.png", UriKind.Relative));

                Images = new Dictionary<(FieldCardType, CardPointType), BitmapImage>
                {
                    [(FieldCardType.Air, CardPointType.One)] = new BitmapImage(new Uri("Files/SkySupport1GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Air, CardPointType.Two)] = new BitmapImage(new Uri("Files/SkyParatroop2GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Air, CardPointType.Three)] = new BitmapImage(new Uri("Files/SkyManeuver3GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Air, CardPointType.Four)] = new BitmapImage(new Uri("Files/SkyAirfield4GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Air, CardPointType.Five)] = new BitmapImage(new Uri("Files/SkyBarrier5GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Air, CardPointType.Six)] = new BitmapImage(new Uri("Files/SkyHeavyAviation6GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Sea, CardPointType.One)] = new BitmapImage(new Uri("Files/SeaTransport1GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Sea, CardPointType.Two)] = new BitmapImage(new Uri("Files/SeaEscalation2GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Sea, CardPointType.Three)] = new BitmapImage(new Uri("Files/SeaManeuver3GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Sea, CardPointType.Four)] = new BitmapImage(new Uri("Files/SeaRelocation4GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Sea, CardPointType.Five)] = new BitmapImage(new Uri("Files/SeaBlockade5GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Sea, CardPointType.Six)] = new BitmapImage(new Uri("Files/SeaHeavyCruiser6GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Land, CardPointType.One)] = new BitmapImage(new Uri("Files/EarthReinforcement1GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Land, CardPointType.Two)] = new BitmapImage(new Uri("Files/EarthAmbush2GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Land, CardPointType.Three)] = new BitmapImage(new Uri("Files/EarthManeuver3GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Land, CardPointType.Four)] = new BitmapImage(new Uri("Files/EarthProtection4GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Land, CardPointType.Five)] = new BitmapImage(new Uri("Files/EarthSabotage5GameCard.png", UriKind.Relative)),
                    [(FieldCardType.Land, CardPointType.Six)] = new BitmapImage(new Uri("Files/EarthHeavyTank6GameCard.png", UriKind.Relative))
                }.ToImmutableDictionary();
            }
        }

        public static BitmapImage? GetBackImage(CardType type)
        {
            return type switch
            {
                CardType.Player => PlayerCardImages.BackImage,
                CardType.Field => FieldCardImages.BackImage,
                CardType.Game => GameCardImages.BackImage,
                _ => null
            };
        }
        
        public static BitmapImage? GetPlayerImage(PlayerCardType type, CardPositionType position)
        {
            if (position == CardPositionType.Backview)
            {
                return PlayerCardImages.BackImage;
            }
            
            return PlayerCardImages.Images.TryGetValue(type, out BitmapImage? image) ? image : null;
        }
        
        public static BitmapImage? GetGamePointImage(GamePointType type)
        {
            return GamePointCardImages.Images.TryGetValue(type, out BitmapImage? image) ? image : null;
        }
        
        public static BitmapImage? GetFieldImage(FieldCardType type, CardPositionType position)
        {
            if (position == CardPositionType.Backview)
            {
                return FieldCardImages.BackImage;
            }
            
            return FieldCardImages.Images.TryGetValue(type, out BitmapImage? image) ? image : null;
        }
        
        public static BitmapImage? GetGameCardImage(FieldCardType type, CardPointType points, CardPositionType position)
        {
            if (position == CardPositionType.Backview)
            {
                return GameCardImages.BackImage;
            }
            
            return GameCardImages.Images.TryGetValue((type, points), out BitmapImage? image) ? image : null;
        }
    }
}