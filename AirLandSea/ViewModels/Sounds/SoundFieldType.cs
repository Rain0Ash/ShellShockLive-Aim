// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace AirLandSea.ViewModels.Sounds
{
    [Flags]
    public enum SoundFieldType
    {
        None = 0,
        Air = 1,
        Sea = 2,
        Land = 4,
        All = Air | Sea | Land
    }
}