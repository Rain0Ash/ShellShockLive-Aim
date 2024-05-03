// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NetExtender.Types.Exceptions;
using NetExtender.Types.Transactions.Interfaces;
using NetExtender.Utilities.Types;
using NetExtender.Utilities.UserInterface;
using NetExtender.Utilities.Windows.IO;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Utilities.ViewModels.History;
using ShellShockLive.View;
using ShellShockLive.ViewModels;
using ShellShockLive.ViewModels.Guidance;
using ShellShockLive.ViewModels.History;
using ShellShockLive.ViewModels.Physics;
using ShellShockLive.ViewModels.Render;
using ShellShockLive.ViewModels.Settings;
using ShellShockLive.ViewModels.Weapons;

namespace ShellShockLive
{
    public partial class ShellShockLiveWindow
    {
        public ShellShockLiveModel Model { get; }

        public static SettingsViewModel Settings
        {
            get
            {
                return SettingsViewModel.Instance;
            }
        }

        public ShellShockLiveWindow()
            : this(ImmutableArray<String>.Empty)
        {
        }

        public ShellShockLiveWindow(ImmutableArray<String> arguments)
        {
            Model = new ShellShockLiveModel();
            RenderViewModel.Instance.Start(this);
            InitializeComponent();
        }
        
        private void Initialize(Object? sender, EventArgs args)
        {
            this.SetWindowDisplayAffinity(WindowDisplayAffinity.ExcludeFromCapture);
        }

        protected override void RegisterHotKeys(Object? sender, RoutedEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }
            
            Model.Event.Register();
        }

        private void WeaponsButton(Object sender, RoutedEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            WeaponsViewModel.Instance.ShowPanel = !WeaponsViewModel.Instance.ShowPanel;
            args.Handled = true;
        }

        private void SettingsButton(Object sender, RoutedEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }
            
            SettingsWindow.ShowSettings();
            args.Handled = true;
        }

        private void CloseButton(Object sender, RoutedEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }
            
            Close();
            args.Handled = true;
        }

        private void AngleTextBoxGotFocus(Object sender, RoutedEventArgs args)
        {
            if (args.Handled || sender is not TextBox box)
            {
                return;
            }

            box.Text = PhysicsViewModel.Instance.Angle.ToString();
            args.Handled = true;
        }

        private void AngleTextBoxLostFocus(Object sender, RoutedEventArgs args)
        {
            if (args.Handled || sender is not TextBox)
            {
                return;
            }

            RenderViewModel.Instance.Render();
            args.Handled = true;
        }

        private void WindTextBoxGotFocus(Object sender, RoutedEventArgs args)
        {
            if (args.Handled || sender is not TextBox box)
            {
                return;
            }

            box.Text = PhysicsViewModel.Instance.Wind.ToString();
            args.Handled = true;
        }

        private void WindTextBoxLostFocus(Object sender, RoutedEventArgs args)
        {
            if (args.Handled || sender is not TextBox)
            {
                return;
            }

            RenderViewModel.Instance.Render();
            args.Handled = true;
        }

        private void PowerTextBoxGotFocus(Object sender, RoutedEventArgs args)
        {
            if (args.Handled || sender is not TextBox box)
            {
                return;
            }

            box.Text = PhysicsViewModel.Instance.Power.ToString();
            args.Handled = true;
        }

        private void PowerTextBoxLostFocus(Object sender, RoutedEventArgs args)
        {
            if (args.Handled || sender is not TextBox)
            {
                return;
            }

            RenderViewModel.Instance.Render();
            args.Handled = true;
        }
        
        private void TextBoxEnterKeyDown(Object sender, KeyEventArgs args)
        {
            if (args.Handled || sender is not TextBox box)
            {
                return;
            }

            if (args.Key == Key.Enter)
            {
                box.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
            
            args.Handled = true;
        }

        private void TrajectoryListViewSizeChanged(Object sender, SizeChangedEventArgs args)
        {
            if (args.Handled || sender is not ListView { View: GridView grid } view)
            {
                return;
            }
            
            Double width = (view.ActualWidth - SystemParameters.VerticalScrollBarWidth) / grid.Columns.Count;

            foreach (GridViewColumn column in grid.Columns)
            {
                column.Width = width;
            }
            
            args.Handled = true;
        }

        private void TrajectorySelected(Object sender, MouseButtonEventArgs args)
        {
            if (args.Handled || sender is not ListViewItem { Content: GuidanceSearchResult search })
            {
                return;
            }

            using ITransaction history = HistoryViewModel.Instance.Manager.Transaction().Render();
            GuidanceViewModel.Instance.Set(search);
            args.Handled = true;
        }

        private void VisionButtonClick(Object sender, RoutedEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }
            
            Model.ToggleScanner();
            args.Handled = true;
        }

        private async void ScreenshotButtonClick(Object sender, RoutedEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            await Model.Event.Controller.Controller.MakeScreenshot().ConfigureAwait(false);
        }

        private void VisibilityButtonClick(Object sender, RoutedEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            InterfaceType type = SettingsViewModel.Settings.Interface.Value;
            if (!KeyboardUtilities.Shift.IsShift)
            {
                SettingsViewModel.Settings.Interface.Value = type.Previous();
                ShellShockLiveModel.Render.Render();
                return;
            }

            SettingsViewModel.Settings.Interface.Value = type switch
            {
                InterfaceType.None => InterfaceType.Full,
                InterfaceType.Render => InterfaceType.Full,
                InterfaceType.Interface => InterfaceType.Full,
                InterfaceType.Full => InterfaceType.None,
                _ => throw new EnumUndefinedOrNotSupportedException<InterfaceType>(type, nameof(type), null)
            };
            
            ShellShockLiveModel.Render.Render();
        }
    }
}