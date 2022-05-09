// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Collections.Immutable;
using AirLandSea.Models;

namespace AirLandSea.ViewModels
{
    public static class EffectStorage
    {
        private static ImmutableDictionary<GameCardEffect, GameCardEffectType> EffectTypes { get; }
        
        static EffectStorage()
        {
            EffectTypes = new Dictionary<GameCardEffect, GameCardEffectType>
            {
                [GameCardEffect.None] = GameCardEffectType.None,
                [GameCardEffect.Support] = GameCardEffectType.Player,
                [GameCardEffect.Transport] = GameCardEffectType.Action,
                [GameCardEffect.Reinforcement] = GameCardEffectType.Action,
                [GameCardEffect.Paratroops] = GameCardEffectType.Action,
                [GameCardEffect.Escalation] = GameCardEffectType.Player,
                [GameCardEffect.Ambush] = GameCardEffectType.Action,
                [GameCardEffect.Maneuver] = GameCardEffectType.Action,
                [GameCardEffect.Airfield] = GameCardEffectType.Player,
                [GameCardEffect.Relocation] = GameCardEffectType.Action,
                [GameCardEffect.Protection] = GameCardEffectType.Player,
                [GameCardEffect.Barrier] = GameCardEffectType.Battlefield,
                [GameCardEffect.Blockade] = GameCardEffectType.Battlefield,
                [GameCardEffect.Sabotage] = GameCardEffectType.Action
            }.ToImmutableDictionary();
        }

        public static GameCardEffectType ToEffectType(this GameCardEffect effect)
        {
            return EffectTypes[effect];
        }
    }
}