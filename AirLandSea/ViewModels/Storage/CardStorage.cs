// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Immutable;
using System.Linq;
using AirLandSea.Models;
using NetExtender.Utilities.Types;

namespace AirLandSea.ViewModels
{
    public static class CardStorage
    {
        private static ImmutableArray<PlayerCard> Players { get; } = new[]
        {
            new PlayerCard { Player = PlayerCardType.First },
            new PlayerCard { Player = PlayerCardType.Second }
        }.ToImmutableArray();

        private static ImmutableArray<GamePointCard> Points { get; } = new[]
        {
            new GamePointCard { Points = GamePointType.Point1 },
            new GamePointCard { Points = GamePointType.Point3 },
            new GamePointCard { Points = GamePointType.Point6 },
        }.ToImmutableArray();

        private static ImmutableArray<FieldCard> Fields { get; } = new[]
        {
            new FieldCard { Field = FieldCardType.Air },
            new FieldCard { Field = FieldCardType.Sea },
            new FieldCard { Field = FieldCardType.Land },
        }.ToImmutableArray();

        private static ImmutableArray<GameCard> Cards { get; } = new[]
        {
            new GameCard { Field = FieldCardType.Air, Points = CardPointType.One, Effect = GameCardEffect.Support },
            new GameCard { Field = FieldCardType.Air, Points = CardPointType.Two, Effect = GameCardEffect.Paratroops },
            new GameCard { Field = FieldCardType.Air, Points = CardPointType.Three, Effect = GameCardEffect.Maneuver },
            new GameCard { Field = FieldCardType.Air, Points = CardPointType.Four, Effect = GameCardEffect.Airfield },
            new GameCard { Field = FieldCardType.Air, Points = CardPointType.Five, Effect = GameCardEffect.Barrier },
            new GameCard { Field = FieldCardType.Air, Points = CardPointType.Six, Effect = GameCardEffect.None },
            new GameCard { Field = FieldCardType.Sea, Points = CardPointType.One, Effect = GameCardEffect.Transport },
            new GameCard { Field = FieldCardType.Sea, Points = CardPointType.Two, Effect = GameCardEffect.Escalation },
            new GameCard { Field = FieldCardType.Sea, Points = CardPointType.Three, Effect = GameCardEffect.Maneuver },
            new GameCard { Field = FieldCardType.Sea, Points = CardPointType.Four, Effect = GameCardEffect.Relocation },
            new GameCard { Field = FieldCardType.Sea, Points = CardPointType.Five, Effect = GameCardEffect.Blockade },
            new GameCard { Field = FieldCardType.Sea, Points = CardPointType.Six, Effect = GameCardEffect.None },
            new GameCard { Field = FieldCardType.Land, Points = CardPointType.One, Effect = GameCardEffect.Reinforcement },
            new GameCard { Field = FieldCardType.Land, Points = CardPointType.Two, Effect = GameCardEffect.Ambush },
            new GameCard { Field = FieldCardType.Land, Points = CardPointType.Three, Effect = GameCardEffect.Maneuver },
            new GameCard { Field = FieldCardType.Land, Points = CardPointType.Four, Effect = GameCardEffect.Protection },
            new GameCard { Field = FieldCardType.Land, Points = CardPointType.Five, Effect = GameCardEffect.Sabotage },
            new GameCard { Field = FieldCardType.Land, Points = CardPointType.Six, Effect = GameCardEffect.None }
        }.ToImmutableArray();
        
        
        private static ImmutableDictionary<PlayerCardType, PlayerCard> PlayerCardsInfo { get; }
        private static ImmutableDictionary<GamePointType, GamePointCard> GamePointCardsInfo { get; }
        private static ImmutableDictionary<FieldCardType, FieldCard> FieldCardsInfo { get; }
        private static ImmutableDictionary<(FieldCardType, GameCardEffect), GameCard> FieldEffectGameCardsInfo { get; }
        private static ImmutableDictionary<(FieldCardType, CardPointType), GameCard> FieldPointGameCardsInfo { get; }

        static CardStorage()
        {
            PlayerCardsInfo = Players.ToImmutableDictionary(card => card.Player);
            GamePointCardsInfo = Points.ToImmutableDictionary(card => card.Points);
            FieldCardsInfo = Fields.ToImmutableDictionary(card => card.Field);
            FieldEffectGameCardsInfo = Cards.ToImmutableDictionary(card => (card.Field, card.Effect));
            FieldPointGameCardsInfo = Cards.ToImmutableDictionary(card => (card.Field, card.Points));
        }
        
        private static T[] Clone<T>(ImmutableArray<T> array)
        {
            return array.Select(item => item.Clone()).WhereNotNull().ToArray();
        }

        public static PlayerCard[] PlayerCards
        {
            get
            {
                return Clone(Players);
            }
        }
        
        public static GamePointCard[] GamePointCards
        {
            get
            {
                return Clone(Points);
            }
        }
        
        public static FieldCard[] FieldCards
        {
            get
            {
                return Clone(Fields);
            }
        }
        
        public static GameCard[] GameCards
        {
            get
            {
                return Clone(Cards);
            }
        }

        private static PlayerCard? GetPlayerCard(this PlayerCardType player)
        {
            return PlayerCardsInfo.TryGetValue(player, out PlayerCard? card) ? card : null;
        }
        
        public static PlayerCard? ToPlayerCard(this PlayerCardType player)
        {
            return GetPlayerCard(player)?.Clone();
        }

        private static GamePointCard? GetGamePointCard(this GamePointType points)
        {
            return GamePointCardsInfo.TryGetValue(points, out GamePointCard? card) ? card : null;
        }
        
        public static GamePointCard? ToGamePointCard(this GamePointType points)
        {
            return GetGamePointCard(points)?.Clone();
        }

        private static FieldCard? GetFieldCard(this FieldCardType field)
        {
            return FieldCardsInfo.TryGetValue(field, out FieldCard? card) ? card : null;
        }
        
        public static FieldCard? ToFieldCard(this FieldCardType field)
        {
            return GetFieldCard(field)?.Clone();
        }

        private static GameCard? GetGameCard(this FieldCardType field, GameCardEffect effect)
        {
            return FieldEffectGameCardsInfo.TryGetValue((field, effect), out GameCard? card) ? card : null;
        }

        public static GameCard? ToGameCard(this FieldCardType field, GameCardEffect effect)
        {
            return ToGameCard(effect, field);
        }

        public static GameCard? ToGameCard(this GameCardEffect effect, FieldCardType field)
        {
            return GetGameCard(field, effect)?.Clone();
        }

        private static GameCard? GetGameCard(this FieldCardType field, CardPointType point)
        {
            return FieldPointGameCardsInfo.TryGetValue((field, point), out GameCard? card) ? card : null;
        }
        
        public static GameCard? ToGameCard(this CardPointType point, FieldCardType field)
        {
            return ToGameCard(field, point);
        }

        private static GameCard? ToGameCard(this FieldCardType field, CardPointType point)
        {
            return GetGameCard(field, point)?.Clone();
        }
    }
}