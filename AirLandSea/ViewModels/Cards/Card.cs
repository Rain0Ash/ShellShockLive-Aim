// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Windows;
using System.Windows.Media.Imaging;
using AirLandSea.Models;
using ReactiveUI;

namespace AirLandSea.ViewModels
{
    public abstract record Card : ReactiveRecord
    {
        public abstract CardType Type { get; }
        public abstract CardSizeType SizeType { get; }
        public abstract BitmapImage? Image { get; }

        public virtual Int32Rect Rectangle
        {
            get
            {
                return Image?.SourceRect ?? Int32Rect.Empty;
            }
        }
        
        public virtual Size Size
        {
            get
            {
                Int32Rect rectangle = Rectangle;
                return rectangle.HasArea ? new Size(rectangle.Width, rectangle.Height) : Size.Empty;
            }
        }
    }
}