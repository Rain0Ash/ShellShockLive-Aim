// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.NAudio.Types.Sound;

namespace ShellShockLive.View
{
    public class SoundPlayer : SoundPlayer<SoundPlayer>
    {
        public override Single Volume
        {
            get
            {
                return Settings.Instance.Volume.Value / 100F;
            }
        }
    }
}