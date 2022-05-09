// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Collections.Immutable;
using NetExtender.NAudio.Types.Sound;
using NetExtender.Types.Random;

namespace ShellShockLive.ViewModels
{
    public enum SoundType
    {
        None,
        Open,
        Close,
        Click,
        Move,
        Screenshot
    }
    
    public static class SoundStorage
    {
        private static class ApplicationSounds
        {
            public static ImmutableDictionary<SoundType, IRandomSelector<AudioSoundFile>> Sounds { get; }

            static ApplicationSounds()
            {
                Sounds = new Dictionary<SoundType, IRandomSelector<AudioSoundFile>>
                {
                    [SoundType.Open] = new RandomSelectorBuilder<AudioSoundFile>
                    {
                        { new AudioSoundFile("Files/Sounds/CardPut1.mp3"), 1 }
                    }.Build(),
                    [SoundType.Close] = new RandomSelectorBuilder<AudioSoundFile>
                    {
                        { new AudioSoundFile("Files/Sounds/CardFlip1.mp3"), 1 }
                    }.Build(),
                    [SoundType.Click] = new RandomSelectorBuilder<AudioSoundFile>
                    {
                        { new AudioSoundFile("Files/Sounds/CardTouch1.mp3"), 1 }
                    }.Build(),
                    [SoundType.Move] = new RandomSelectorBuilder<AudioSoundFile>
                    {
                        { new AudioSoundFile("Files/Sounds/CardPlace1.mp3"), 1 }
                    }.Build(),
                    [SoundType.Screenshot] = new RandomSelectorBuilder<AudioSoundFile>
                    {
                        { new AudioSoundFile("Files/Sounds/Screenshot1.mp3"), 1 }
                    }.Build()
                }.ToImmutableDictionary();
            }
        }
        
        public static IRandomSelector<AudioSoundFile> GetSounds(SoundType type)
        {
            return ApplicationSounds.Sounds.TryGetValue(type, out IRandomSelector<AudioSoundFile>? sound) ? sound : RandomSelector<AudioSoundFile>.Default;
        }
    }
}