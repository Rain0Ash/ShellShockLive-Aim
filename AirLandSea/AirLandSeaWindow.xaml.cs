using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using AirLandSea.Models;
using AirLandSea.View;
using AirLandSea.ViewModels;
using AirLandSea.ViewModels.Sounds;
using NAudio.Wave;
using NetExtender.Times.Timers.Interfaces;
using NetExtender.Types.Events;
using NetExtender.Utilities.NAudio;
using NetExtender.Utilities.Types;

namespace AirLandSea
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AirLandSeaWindow
    {
        public Battlefield Battlefield { get; }
        public BattlefieldSoundPlayer SoundPlayer { get; }

        public AirLandSeaWindow()
        {
            Battlefield = new Battlefield(new Player("Rain0Ash", PlayerType.First), new Player("Rain1Ash", PlayerType.Second)).Initialize();
            SoundPlayer = new BattlefieldSoundPlayer(Battlefield);
            SoundPlayer.Play(SoundStorage.GetBackgroundSounds(SoundFieldType.Air).First());
            InitializeComponent();
        }

        private void SurrendButtonOnClick(Object sender, RoutedEventArgs e)
        {
            Battlefield.Surrend();
        }
    }
}