// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows;
using System.Windows.Input;
using NetExtender.UserInterface.WindowsPresentation.Windows;
using ShellShockLive.ViewModels;
using ShellShockLive.ViewModels.Settings;

namespace ShellShockLive.View
{
    public partial class SettingsWindow
    {
        public static SettingsViewModel Model
        {
            get
            {
                return SettingsViewModel.Instance;
            }
        }

        private static SoundPlayer SoundPlayer
        {
            get
            {
                return SoundPlayer.Default;
            }
        }

        private SettingsWindow()
        {
            InitializeComponent();
        }

        public static void ShowSettings()
        {
            if (SingletonWindow<SettingsWindow>.Singleton.Show() is not null)
            {
                SoundPlayer.Default.Play(SoundStorage.GetSounds(SoundType.Open).GetRandomOrDefault());
            }
        }
        
        private void SaveButtonClick(Object sender, RoutedEventArgs args)
        {
            Settings.Instance.Save();
            SingletonWindow<SettingsWindow>.Singleton.Close();
        }

        private void ResetButtonClick(Object sender, RoutedEventArgs args)
        {
            if (MessageBox.Show(Localization.ResetMessage.Current, Localization.ResetTitle.Current, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) != MessageBoxResult.Yes)
            {
                return;
            }
            
            Settings.Instance.Reset();
        }
        
        private void KeyboardClick(Object sender, KeyEventArgs args)
        {
            if (args.Handled || args.IsRepeat)
            {
                return;
            }

            switch (args.Key)
            {
                case Key.Escape:
                    SingletonWindow<SettingsWindow>.Singleton.Close();
                    return;
                case Key.Enter:
                case Key.Space:
                case Key.F2:
                    SaveButtonClick(sender, args);
                    return;
                case Key.Back:
                    ResetButtonClick(sender, args);
                    return;
                default:
                    return;
            }
        }
    }
}