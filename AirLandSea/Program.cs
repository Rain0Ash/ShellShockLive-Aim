// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Media;
using System.Windows;
using AirLandSea.Application;
using AirLandSea.View;
using AirLandSea.ViewModels;
using NAudio.Wave;
using NetExtender.Domains;
using NetExtender.Initializer;
using NetExtender.Utilities.NAudio;

namespace AirLandSea
{
    public class Program : Initializer
    {
        protected override void UnhandledException(Object? sender, Exception? exception, Boolean terminating)
        {
            MessageBox.Show(exception?.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            if (terminating)
            {
                Domain.Shutdown(true);
            }
        }

        [STAThread]
        public static void Main()
        {
            Domain.Create("AirLandSea").Initialize<AirLandSeaApplication>().View<AirLandSeaView>();
        }
    }
}