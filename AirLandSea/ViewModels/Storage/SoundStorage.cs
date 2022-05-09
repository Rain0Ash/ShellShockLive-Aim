// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Collections.Immutable;
using AirLandSea.Models;
using AirLandSea.ViewModels.Sounds;
using NetExtender.Utilities.Types;

namespace AirLandSea.ViewModels
{
    public static class SoundStorage
    {
        private static class BackgroundSounds
        {
            public static ImmutableDictionary<SoundFieldType, ImmutableArray<Sound>> Sounds { get; }

            static BackgroundSounds()
            {
                Sounds = new Dictionary<SoundFieldType, ImmutableArray<Sound>>
                {
                    [SoundFieldType.Air] = new List<Sound>
                    {
                        new Sound("Files/Sounds/AirBackground1.mp3") { Type = SoundType.Background, Field = SoundFieldType.Air }
                    }.ToImmutableArray(),
                    
                    [SoundFieldType.Sea] = new List<Sound>
                    {
                    }.ToImmutableArray(),
                    
                    [SoundFieldType.Land] = new List<Sound>
                    {
                        new Sound("Files/Sounds/EarthBackground1.mp3"){ Type = SoundType.Background, Field = SoundFieldType.Land }
                    }.ToImmutableArray(),
                }.ToImmutableDictionary();
            }
        }

        private static class EffectSounds
        {
            public static ImmutableDictionary<GameCardEffect, ImmutableArray<Sound>> Sounds { get; }

            static EffectSounds()
            {
                Sounds = new Dictionary<GameCardEffect, ImmutableArray<Sound>>
                {
                    [GameCardEffect.Support] = new List<Sound>
                    {
                        new Sound("Files/Sounds/ReactiveWarplaneMovement1.mp3") { Type = SoundType.Attack },
                        new Sound("Files/Sounds/ReactiveWarplaneMovement2.mp3") { Type = SoundType.Attack },
                        new Sound("Files/Sounds/ReactiveWarplaneMovement3.mp3") { Type = SoundType.Attack }
                    }.ToImmutableArray(),
                    [GameCardEffect.Escalation] = new List<Sound>
                    {
                        new Sound("Files/Sounds/NuclearExplosion1.mp3"),
                        new Sound("Files/Sounds/NuclearMultiExplosion1.mp3")
                    }.ToImmutableArray()
                }.ToImmutableDictionary();
            }
        }

        public static ImmutableArray<Sound> GetBackgroundSounds(SoundFieldType field)
        {
            if (field == SoundFieldType.None)
            {
                return ImmutableArray<Sound>.Empty;
            }
            
            IEnumerable<Sound> result = ImmutableList<Sound>.Empty;

            if (field.HasFlag(SoundFieldType.Air) && BackgroundSounds.Sounds.TryGetValue(SoundFieldType.Air, out ImmutableArray<Sound> sounds))
            {
                result = result.Concat(sounds);
            }
            
            if (field.HasFlag(SoundFieldType.Sea) && BackgroundSounds.Sounds.TryGetValue(SoundFieldType.Sea, out sounds))
            {
                result = result.Concat(sounds);
            }
            
            if (field.HasFlag(SoundFieldType.Land) && BackgroundSounds.Sounds.TryGetValue(SoundFieldType.Land, out sounds))
            {
                result = result.Concat(sounds);
            }

            return result.ToImmutableArray();
        }
        
        public static ImmutableArray<Sound> GetEffectSounds(GameCardEffect effect)
        {
            return EffectSounds.Sounds.TryGetValue(effect, out ImmutableArray<Sound> sounds) ? sounds : ImmutableArray<Sound>.Empty;
        }
    }
}