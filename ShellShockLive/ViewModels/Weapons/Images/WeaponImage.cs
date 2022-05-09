// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows.Media;
using NetExtender.WindowsPresentation.Types.Images;

namespace ShellShockLive.ViewModels.Weapons.Images
{
    public sealed class WeaponImage : ApplicationImage
    {
        public static implicit operator Color(WeaponImage? image)
        {
            return image?.Color ?? default;
        }
        
        public Color Color { get; }
        public Brush Brush { get; }
        
        public WeaponImage(String filename, Color color)
            : base("Files/Weapons/Images", filename)
        {
            Color = color;
            Brush = new SolidColorBrush(color);
        }
    }
}