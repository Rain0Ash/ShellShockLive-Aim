using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using NetExtender.Utilities.UserInterface;
using NetExtender.WindowsPresentation.Utilities.Types;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Stacks;
using ShellShockLive.ViewModels;
using ShellShockLive.ViewModels.Weapons;
using ShellShockLive.ViewModels.Weapons.Images;

namespace ShellShockLive.View.WeaponPanel
{
    public partial class WeaponPanelStack
    {
        public static readonly DependencyProperty StackProperty = DependencyPropertyUtilities.Register(nameof(Stack), false);
        public static readonly DependencyProperty BrushProperty = DependencyPropertyUtilities.Register(nameof(Brush), false);
        
        [Bindable(true)]
        public WeaponStack? Stack
        {
            get
            {
                return (WeaponStack?) GetValue(StackProperty);
            }
            set
            {
                SetValue(StackProperty, value);
            }
        }
        
        [Bindable(true)]
        public Brush? Brush
        {
            get
            {
                return (Brush?) GetValue(BrushProperty);
            }
            private set
            {
                SetValue(BrushProperty, value);
            }
        }
        
        public WeaponPanelStack()
        {
            InitializeComponent();
        }

        private void WeaponButtonClick(Object sender, RoutedEventArgs args)
        {
            if (sender is not WeaponButton button || button.Weapon is null)
            {
                return;
            }

            WeaponsViewModel.Instance.Weapon = button.Weapon;
        }
        
        private static void StackChanged(DependencyObject sender)
        {
            WeaponStack? stack = (WeaponStack?) sender.GetValue(StackProperty);

            if (stack is null)
            {
                sender.SetValue(BrushProperty, null);
                return;
            }

            Color? color = null;
            foreach (IWeapon weapon in stack)
            {
                WeaponImage? image = ImageStorage.Get(weapon);
                if (image is null || color is not null && color != image.Color)
                {
                    break;
                }

                color = image.Color;
            }
            
            sender.SetValue(BrushProperty, color is not null ? new SolidColorBrush(color.Value) : default);
        }

        public void Update(IWeapon? weapon)
        {
            foreach (WeaponButton button in Grid.GetChildrens<WeaponButton>())
            {
                button.Update(weapon);
            }
        }
    }
}