// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ShellShockLive.ViewModels.Events;
using ShellShockLive.ViewModels.Guidance;
using ShellShockLive.ViewModels.Physics;
using ShellShockLive.ViewModels.Render;
using ShellShockLive.ViewModels.Settings;
using ShellShockLive.ViewModels.Vision;
using ShellShockLive.ViewModels.Weapons;

namespace ShellShockLive.ViewModels
{
    public class ShellShockLiveModel : ReactiveViewModel
    {
        public static GameViewModel Game
        {
            get
            {
                return GameViewModel.Instance;
            }
        }
        
        public static RenderViewModel Render
        {
            get
            {
                return RenderViewModel.Instance;
            }
        }

        public static GuidanceViewModel Guidance
        {
            get
            {
                return GuidanceViewModel.Instance;
            }
        }

        public static WeaponsViewModel Weapons
        {
            get
            {
                return WeaponsViewModel.Instance;
            }
        }

        public static PhysicsViewModel Physics
        {
            get
            {
                return PhysicsViewModel.Instance;
            }
        }

        public EventControllerViewModel Event { get; }
        
        private UInt16 Scanning { get; set; }

        public ShellShockLiveModel()
        {
            Event = new EventControllerViewModel();
        }

        public void ToggleScanner()
        {
            if (SettingsViewModel.Settings.Scanning.Value == ShellShockLive.Settings.Constants.Scanning.Minimum)
            {
                SettingsViewModel.Settings.Scanning.Value = Scanning > 0 ? Scanning : ShellShockLive.Settings.Constants.Scanning.Start;
                Scanning = 0;
                return;
            }
            
            // ReSharper disable once InvertIf
            if (SettingsViewModel.Settings.Scanning.Value > ShellShockLive.Settings.Constants.Scanning.Minimum)
            {
                Scanning = SettingsViewModel.Settings.Scanning.Value;
                SettingsViewModel.Settings.Scanning.Value = ShellShockLive.Settings.Constants.Scanning.Minimum;
            }
        }
    }
}