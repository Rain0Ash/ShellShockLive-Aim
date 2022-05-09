// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.ViewModels.Vision
{
    public abstract class ColorVisionTemplate
    {
        public static implicit operator ReadOnlySpan<Color>(ColorVisionTemplate? value)
        {
            return value?.Template ?? default;
        }

        public abstract VisionTemplate Template { get; init; }

        public ReadOnlySpan<Color>.Enumerator GetEnumerator()
        {
            return Template.GetEnumerator();
        }
    }
}