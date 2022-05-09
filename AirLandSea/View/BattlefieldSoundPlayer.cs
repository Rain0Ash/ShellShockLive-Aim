// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirLandSea.ViewModels;
using AirLandSea.ViewModels.Sounds;
using NAudio.Wave;
using NetExtender.Utilities.NAudio;
using ReactiveUI;

namespace AirLandSea.View
{
    public class BattlefieldSoundPlayer : ReactiveObject
    {
        protected Battlefield? Battlefield { get; private set; }

        public Single Volume { get; set; }

        private List<ActiveSound> ActiveSounds { get; } = new List<ActiveSound>();

        public BattlefieldSoundPlayer(Battlefield? battlefield)
        {
            Battlefield = battlefield;
        }

        public Boolean Play(Sound sound)
        {
            if (sound is null)
            {
                throw new ArgumentNullException(nameof(sound));
            }
            
            ActiveSounds.Add(new ActiveSound(sound, this).Play());
            return true;
        }

        public void Reset(Battlefield? battlefield)
        {
            Battlefield = battlefield;
        }

        private class ActiveSound : IDisposable
        {
            public Sound Sound { get; }
            public BattlefieldSoundPlayer Player { get; }
            public AudioFileReader Reader { get; }
            private WaveOutEvent Device { get; }
            
            public ActiveSound(Sound sound, BattlefieldSoundPlayer player)
            {
                Sound = sound ?? throw new ArgumentNullException(nameof(sound));
                Player = player ?? throw new ArgumentNullException(nameof(player));
                Reader = new AudioFileReader(Sound.FileName);
                Device = new WaveOutEvent();
                Device.PlaybackStopped += Stop;
            }

            public ActiveSound Play()
            {
                Device.Play(Reader);
                return this;
            }
            
            private void Stop(Object? sender, StoppedEventArgs e)
            {
                Dispose();
            }

            public void Dispose()
            {
                Reader.Dispose();
                Device.Dispose();
                Player.ActiveSounds.Remove(this);
            }
        }
    }
}