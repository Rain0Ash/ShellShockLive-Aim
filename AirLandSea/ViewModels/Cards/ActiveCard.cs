// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using AirLandSea.Models;
using ReactiveUI.Fody.Helpers;

namespace AirLandSea.ViewModels
{
    public abstract record ActiveCard : Card
    {
        [Reactive]
        public virtual FieldCardType Field { get; set; }
        
        [Reactive]
        public virtual CardPositionType Position { get; set; }

        public void Rotate()
        {
            Position = Position switch
            {
                CardPositionType.Foreview => CardPositionType.Backview,
                CardPositionType.Backview => CardPositionType.Foreview,
                _ => throw new NotSupportedException()
            };
        }
    }
}