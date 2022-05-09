// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NAudio.Wave;

namespace AirLandSea.ViewModels.Sounds
{
    public class Sound
    {
        public String FileName { get; }
        public TimeSpan Start { get; init; }
        public TimeSpan Stop { get; init; }
        public TimeSpan Length { get; init; }

        public Double Volume { get; init; } = 1;
        
        public SoundType Type { get; init; }
        public SoundFieldType Field { get; init; } = SoundFieldType.All;
        public SoundTargetType Target { get; init; } = SoundTargetType.All;

        public Sound(String filename)
        {
            FileName = filename ?? throw new ArgumentNullException(nameof(filename));
        }
    }
}